// Exceeding Requirements
// Users can set and modify point values for each goal type
// Users can view only their score and the ability to skip
// Users receive immediate feedback when goals are completed,
// Goals can be saved and loaded from a file
// Tracking for Checklist Goals
// Users can add their username to make it more personalized

using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    // Abstract base class for goals
    public abstract class Goal
    {
        protected string _name;
        protected int _points;
        protected int _completedCount;
        protected bool _isComplete;

        protected Goal(string name, int points)
        {
            _name = name;
            _points = points;
            _completedCount = 0;
            _isComplete = false;
        }

        public abstract void RecordEvent(); 
        public abstract string GetStatus(); 

        protected void CheckCompletion()
        {
            if (_completedCount > 0 && !_isComplete)
            {
                Console.WriteLine($"Goal '{_name}' is completed!");
                _isComplete = true;
            }
        }

        public int GetPoints() => _completedCount * _points;
    }

    public class SimpleGoal : Goal
    {
        public SimpleGoal(string name, int points) : base(name, points) { }

        public override void RecordEvent()
        {
            _completedCount++;
            CheckCompletion();
        }

        public override string GetStatus() => _isComplete ? $"[X] {_name}" : $"[ ] {_name}";
    }

    public class EternalGoal : Goal
    {
        public EternalGoal(string name, int points) : base(name, points) { }

        public override void RecordEvent()
        {
            _completedCount++;
        }

        public override string GetStatus() => $"{_name} (Completed: {_completedCount})";
    }

    public class ChecklistGoal : Goal
    {
        private int _targetCount;
        private int _bonusPoints;

        public ChecklistGoal(string name, int points, int targetCount, int bonusPoints) 
            : base(name, points)
        {
            _targetCount = targetCount;
            _bonusPoints = bonusPoints;
        }

        public override void RecordEvent()
        {
            _completedCount++;
            if (_completedCount == _targetCount)
            {
                _points += _bonusPoints; 
                CheckCompletion(); 
            }
        }

        public override string GetStatus() 
            => $"{_name} [Completed: {_completedCount}/{_targetCount}]";
    }

    public class User
    {
        private string _username;
        private int _score;
        private List<Goal> _goals;

        public User(string username)
        {
            _username = username;
            _score = 0;
            _goals = new List<Goal>();
        }

        public void AddGoal(Goal goal) 
        {
            _goals.Add(goal);
        }

        public void RecordGoalEvent(int index) 
        {
            if (index < _goals.Count)
            {
                _goals[index].RecordEvent();
                _score += _goals[index].GetPoints();
            }
        }

        public void ShowGoals()
        {
            foreach (var goal in _goals)
            {
                Console.WriteLine(goal.GetStatus());
            }
        }

        public void ShowScore() => Console.WriteLine($"Score for {_username}: {_score}");

        public void SaveGoals(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (var goal in _goals)
                {
                    writer.WriteLine($"{goal.GetType().Name},{goal.GetStatus()}");
                }
            }
        }

        public void LoadGoals(string fileName)
        {
            if (File.Exists(fileName))
            {
                var lines = File.ReadAllLines(fileName);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    string goalType = parts[0];
                    string goalStatus = parts[1];

                    if (goalType == nameof(SimpleGoal))
                    {
                        var name = goalStatus.Substring(4); // Remove '[ ] ' or '[X] ' prefix
                        AddGoal(new SimpleGoal(name, 100)); // Constant points for simplicity
                    }
                    else if (goalType == nameof(EternalGoal))
                    {
                        var name = goalStatus.Split('(')[0].Trim();
                        AddGoal(new EternalGoal(name, 100)); // Constant points for simplicity
                    }
                    else if (goalType == nameof(ChecklistGoal))
                    {
                        var partsInfo = goalStatus.Split(new[] { ' ', '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
                        var name = partsInfo[0]; // Name
                        var completed = int.Parse(partsInfo[2]); // Completed count
                        var targetCount = int.Parse(partsInfo[4]); // Target count
                        
                        ChecklistGoal goal = new ChecklistGoal(name, 50, targetCount, 500);
                        // We set the completed count based on the loaded data
                        goal.RecordEvent(); // Calls RecordEvent to simulate a completed goal
                        for (int i = 0; i < completed; i++) goal.RecordEvent(); // Simulate the number of times completed
                        AddGoal(goal);
                    }
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Eternal Quest Program!");
            Console.Write("Please enter your username: ");
            string username = Console.ReadLine();
            User user = new User(username);

            while (true)
            {
                Console.WriteLine("\nMenu option:");
                Console.WriteLine("1. Add Simple Goal");
                Console.WriteLine("2. Add Eternal Goal");
                Console.WriteLine("3. Add Checklist Goal");
                Console.WriteLine("4. Record Goal Event");
                Console.WriteLine("5. Show Goals");
                Console.WriteLine("6. Show Score");
                Console.WriteLine("7. Save Goals");
                Console.WriteLine("8. Load Goals");
                Console.WriteLine("9. Exit");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter goal name: ");
                        string simpleGoalName = Console.ReadLine();
                        Console.Write("Enter points for completion: ");
                        int simpleGoalPoints = int.Parse(Console.ReadLine());
                        user.AddGoal(new SimpleGoal(simpleGoalName, simpleGoalPoints));
                        break;

                    case "2":
                        Console.Write("Enter goal name: ");
                        string eternalGoalName = Console.ReadLine();
                        Console.Write("Enter points for each completion: ");
                        int eternalGoalPoints = int.Parse(Console.ReadLine());
                        user.AddGoal(new EternalGoal(eternalGoalName, eternalGoalPoints));
                        break;

                    case "3":
                        Console.Write("Enter goal name: ");
                        string checklistGoalName = Console.ReadLine();
                        Console.Write("Enter points for each checklist completion: ");
                        int checklistGoalPoints = int.Parse(Console.ReadLine());
                        Console.Write("Enter target count for completion: ");
                        int targetCount = int.Parse(Console.ReadLine());
                        Console.Write("Enter bonus points for completing the checklist: ");
                        int bonusPoints = int.Parse(Console.ReadLine());
                        user.AddGoal(new ChecklistGoal(checklistGoalName, checklistGoalPoints, targetCount, bonusPoints));
                        break;

                    case "4":
                        Console.WriteLine("Select a goal to record (0 to skip):");
                        user.ShowGoals();
                        int indexToRecord = int.Parse(Console.ReadLine()) - 1;
                        if (indexToRecord >= 0) user.RecordGoalEvent(indexToRecord);
                        break;

                    case "5":
                        user.ShowGoals();
                        break;

                    case "6":
                        user.ShowScore();
                        break;

                    case "7":
                        Console.Write("Enter filename to save your goals: ");
                        string saveFilename = Console.ReadLine();
                        user.SaveGoals(saveFilename);
                        Console.WriteLine("Goals saved!");
                        break;

                    case "8":
                        Console.Write("Enter filename to load goals: ");
                        string loadFilename = Console.ReadLine();
                        user.LoadGoals(loadFilename);
                        Console.WriteLine("Goals loaded!");
                        break;

                    case "9":
                        Console.WriteLine("Exiting the program. You ROCK! Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}