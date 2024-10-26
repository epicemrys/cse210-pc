// Charles Ukoh
// CSE 210 WK05 
// Emrys Mindfulness App
// Exceeding Requirement:
    // Countdown Before Prompting
    //Early Termination with "done"
    // Display Listed Items at the End
    // Inform the User to Type "done"
    // Load previously entered log file
    // Text that grows out quickly at first and then slows as they near the end of the breath //


using System;
using System.Threading;

// Base class for all activities
class MindfulnessActivity
{
    public int Duration { get; set; }

    public void StartCommon(string activityName, string activityDescription)
    {
        Console.WriteLine($"{activityName} Activity: {activityDescription}");
        Console.WriteLine("Enter the duration of the activity in seconds: ");
        Duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Get ready to begin...");
        Thread.Sleep(3000); // Pause for 3 seconds before starting
    }

    public void EndCommon(string activityType)
    {
        Thread.Sleep(3000); // Pause for 3 seconds before displaying the summary
        Console.WriteLine($"Activity: {activityType} completed. Duration: {Duration} seconds.");
    }
}

// Breathing Activity
class BreathingActivity : MindfulnessActivity
{
    public void Start()
    {
        StartCommon("Breathing", "This activity will guide you through a breathing exercise to help you relax and focus.");

        Console.WriteLine("Find a comfortable position and relax.");
        Console.WriteLine("Let's begin the breathing exercise.");
        Console.WriteLine();

        for (int i = 1; i <= 3; i++) // Perform the breathing exercise for 3 cycles
        {
            Console.WriteLine($"Cycle {i}: Inhale deeply as the text grows out quickly...");
            PerformBreathAnimation(6, "Inhale"); // Perform the inhale animation with rapid text growth
            Console.WriteLine("Now exhale slowly as the text slows down...");
            PerformBreathAnimation(8, "Exhale"); // Perform the exhale animation with slower text growth
        }

        EndCommon("Breathing");
    }

    private void PerformBreathAnimation(int initialLength, string breathType)
    {
        int finalLength = initialLength * 2; // Final length of the text
        int growthIncrement = 1; // Increment by which the text grows
        int currentLength = initialLength; // Current length of the text

        // Inhale or exhale animation based on breath type
        while (currentLength <= finalLength)
        {
            string breathText = GenerateBreathText(currentLength, breathType);
            Console.WriteLine(breathText);
            System.Threading.Thread.Sleep(1000); // Adjust the sleep time for slower growth
            currentLength += growthIncrement; // Increment the text length gradually
        }
    }

    private string GenerateBreathText(int iteration, string breathType)
    {
        int textLength = 5 + 2 * iteration; // Adjust text growth based on iteration
        string breathText = new string('.', textLength); // Generate text with increasing length
        if (breathType == "Inhale")
        {
            breathText = "Inhale " + breathText;
        }
        else if (breathType == "Exhale")
        {
            breathText = "Exhale " + breathText;
        }
        return breathText;
    }


    private void AnimateCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i); // Display the countdown number
            Thread.Sleep(1000);
            Console.Write("\b");
            Thread.Sleep(200); 
            Console.Write(" "); 
            Console.Write("\b"); // Move the cursor back
        }
        Console.WriteLine(); // Move to the next line after the countdown
    }
}

// Reflection Activity
class ReflectionActivity : MindfulnessActivity
{
    private static readonly string[] Prompts = new string[]
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private static readonly List<string> Questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public void Start()
    {
        StartCommon("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience.");
        Console.WriteLine();

        Random random = new Random();
        int questionIndex = 0;

        for (int i = 0; i < Duration && questionIndex < Questions.Count; i++)
        {
            int promptIndex = random.Next(Prompts.Length);
            Console.WriteLine(Prompts[promptIndex]);

            AnimatePause(2000); // Custom method for animated pause
            Console.WriteLine(Questions[questionIndex]);
            AnimatePause(3000);
            questionIndex++;
        }

        EndCommon("Reflection");
    }

    private void AnimatePause(int milliseconds)
    {
        int count = milliseconds / 100;
        for (int i = 0; i < count; i++)
        {
            Console.Write("."); // Animation
            Thread.Sleep(100);
            Console.Write("\b \b");
            Thread.Sleep(100);
        }
    }
}

// Listing Activity
class ListingActivity : MindfulnessActivity
{
    private readonly string[] prompts = new string[]
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private readonly List<string> askedPrompts = new List<string>();
    private bool continueActivity = true;

    public void Start()
    {
        Console.WriteLine("Welcome to the Listing Activity.");
        Console.WriteLine();

        while (continueActivity)
        {
            StartCommon("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
            Console.WriteLine();

            string currentPrompt = GetUniquePrompt(askedPrompts);
            int itemCounter = 0;
            List<string> itemsListed = new List<string>();

            if (!string.IsNullOrEmpty(currentPrompt))
            {
                Console.WriteLine($"Think about: {currentPrompt}");
                AnimateCountdown(5); // Countdown to begin thinking about the prompt
                Console.WriteLine("Start listing items...");

                System.Timers.Timer timer = new System.Timers.Timer(Duration * 1000);
                bool activityComplete = false;

                timer.Elapsed += (sender, e) =>
                {
                    activityComplete = true;
                    timer.Stop();

                    Console.WriteLine("\nListing time is up!");
                    if (itemCounter > 0)
                    {
                        Console.WriteLine($"You listed {itemCounter} items:");
                        foreach (var item in itemsListed)
                        {
                            Console.WriteLine(item);
                        }
                    }

                    SaveLog(currentPrompt, itemsListed); // Save the log at the end of the activity
                };

                timer.Start();

                while (!activityComplete)
                {
                    string input = Console.ReadLine();
                    if (input.ToLower() == "done")
                    {
                        break;
                    }
                    if (!string.IsNullOrEmpty(input)) // User has entered an item
                    {
                        itemCounter++;
                        itemsListed.Add(input);
                    }
                }

                askedPrompts.Add(currentPrompt); // Add the current prompt to the list

                Console.WriteLine("Do you want to continue? (yes/no)");
                string continueResponse = Console.ReadLine();

                if (continueResponse.ToLower() != "yes")
                {
                    break; // Exit the loop if the user does not want to continue
                }
            }
            else
            {
                Console.WriteLine("You've completed all prompts. Do you want to continue? (yes/no)");
                string continueResponse = Console.ReadLine();

                if (continueResponse.ToLower() != "yes")
                {
                    break; // Exit the loop if no more unique prompts are available
                }
            }
        }

        EndCommon("Listing");

        if (File.Exists("listing_log.txt"))
        {
            Console.WriteLine("Do you want to load the previously saved log? (yes/no)");
            string loadResponse = Console.ReadLine();

            if (loadResponse.ToLower() == "yes")
            {
                LoadLog();
            }
        }
    }

    private string GetUniquePrompt(List<string> askedPrompts)
    {
        foreach (var prompt in prompts)
        {
            if (!askedPrompts.Contains(prompt))
            {
                return prompt;
            }
        }
        return null; // Return null if all prompts have been asked
    }

    private void AnimateCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"Get ready to think... {i}"); // Display the countdown and a message
            System.Threading.Thread.Sleep(1000); 
            Console.Write("\b"); 
            System.Threading.Thread.Sleep(200); // Short pause before next number
            Console.Write(new string(' ', 10)); // Overwrite the entire line
            Console.Write("\r"); // Move the cursor back to the beginning of the line
        }
        Console.WriteLine("Get ready to think... Go!"); // Show Go! when the countdown ends
        Console.WriteLine();
    }

    private void SaveLog(string prompt, List<string> itemsListed)
    {
        using (StreamWriter sw = new StreamWriter("listing_log.txt", true))
        {
            sw.WriteLine("Prompt: " + prompt);
            foreach (var item in itemsListed)
            {
                sw.WriteLine("Item: " + item);
            }
            sw.WriteLine();
        }
    }
    private void LoadLog()
    {
        if (File.Exists("listing_log.txt"))
        {
            string[] logLines = File.ReadAllLines("listing_log.txt");
            foreach (var line in logLines)
            {
                Console.WriteLine(line);
            }
        }
        else
        {
            Console.WriteLine("No log file found.");
        }
    }

class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to the Emrys Mindfulness App!");
            Console.WriteLine();

            BreathingActivity breathingActivity = new BreathingActivity();
            ReflectionActivity reflectionActivity = new ReflectionActivity();
            ListingActivity listingActivity = new ListingActivity();

            Console.WriteLine("Choose an activity:  ");
            Console.WriteLine("1. Breathing ");
            Console.WriteLine("2. Reflection ");
            Console.WriteLine("3. Listing ");
            Console.WriteLine();
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    breathingActivity.Start();
                    break;
                case 2:
                    reflectionActivity.Start();
                    break;
                case 3:
                    listingActivity.Start();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
            {
                Console.WriteLine("Thank you for using the Emrys Mindfulness App.");
                Console.WriteLine();
            }    
        }
    }    
}