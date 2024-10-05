using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

class Program
{
   static void Main(string[] args)
   {
       // ScriptureMemorizer class to start the program
       var scriptureMemorizer = new ScriptureMemorizer();

       // Run the program
       scriptureMemorizer.Run();
   }
}

class ScriptureMemorizer
{
    private List<Scripture> scriptures;
    private Random random;

    public void Run()
{
    // Initializing the list of scriptures here
    InitializeScriptures();
    var random = new Random();

    foreach (var scripture in scriptures)
    {
        DisplayScripture(scripture);

        while (!scripture.IsCompletelyHidden())
        {
            Console.WriteLine("\nPress enter to continue or type 'quit' to exit:");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "quit")
            {
                return;
            }

            // Hide a few random words in the scripture
            scripture.HideWords();
            DisplayScripture(scripture);
        }
    }
}

private void DisplayScripture(Scripture scripture)
{
    Console.Clear();
    // Display the complete scripture, including the reference and the text
    scripture.Display();
}

private void InitializeScriptures()
{
    // Instantiate the list of scriptures here
    scriptures = new List<Scripture>
    {
        new Scripture("John 3:16", "For God so loved the world, that he gave his only Son, that whoever believes in him should not perish but have eternal life."),
        new Scripture("Proverbs 3:5-6", "Trust in the Lord with all your heart, and do not lean on your own understanding. In all your ways acknowledge him, and he will make straight your paths."),
        new Scripture("Alma 32:21", "And now as I said concerning faith—faith is not to have a perfect knowledge of things; therefore if ye have faith ye hope for things which are not seen, which are true."),
        new Scripture("2 Nephi 2:25", "Adam fell that men might be; and men are, that they might have joy."),
    };
}

    private void HideRandomWordsInTheScriptures()
    {
        // Get a random scripture from the list
        var randomScripture = GetRandomScripture();

        // Hide a few random words in the scripture display
        randomScripture.HideWords();
    }

    private void DisplayScriptures()
    {
        // Display the complete scripture, including the reference and the text
        foreach (var scripture in scriptures)
        {
            scripture.Display();
        }
    }

    private bool AreAllWordsHidden()
    {
        // Check if all words in the scripture are hidden
        return scriptures.All(s => s.IsCompletelyHidden());
    }

    private Scripture GetRandomScripture()
    {
        // Get a random scripture from the list
        var index = random.Next(scriptures.Count);
        return scriptures[index];
    }
}

class Scripture
{
   public string Reference { get; private set; }
   private List<Word> Words { get; set; }

   public Scripture(string reference, string text)
   {
       Reference = reference;
       Words = text.Split(' ').Select(w => new Word(w)).ToList();
   }

   public void HideWords()
   {
       // Randomly hide a few words in the scripture
       var random = new Random();
       var wordsToHide = random.Next(1, Words.Count / 2);
       for (var i = 0; i < wordsToHide; i++)
       {
           Words[random.Next(Words.Count)].Hide();
       }
   }

   public void Display()
   {
       // Now display the complete scripture, including the reference and the text
       Console.WriteLine($"{Reference}: {string.Join(" ", Words.Select(w => w.IsHidden ? "___" : w.Text))}");
   }

   public bool IsCompletelyHidden()
   {
       // Check if all words in the scripture are hidden
       return Words.All(w => w.IsHidden);
   }
}

class Word
{
   public string Text { get; private set; }
   public bool IsHidden { get; private set; }

   public Word(string text)
   {
       Text = text;
       IsHidden = false;
   }

   public void Hide()
   {
       IsHidden = true;
   }
}


// Exceeding requirement
// Choose scriptures at random to present to the user.
// Separated the concerns such as the responsibilities of scripture presentation, data loading, and user interaction into distinct methods within the ScriptureMemorizer class.
// Added more scripture verses
// The program uses a list of Scripture objects to store multiple scriptures instead of a single scripture. 
// Utilized a do-while loop to continue presenting scriptures to the user. After displaying a scripture, the program waits for user input and continues until the user decides to quit.