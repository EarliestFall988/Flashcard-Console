// See https://aka.ms/new-console-template for more information
using System.Text.Json;

// Console.WriteLine("Hello, World!");


StudySet? set = null;

var docs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\flashcards\\"; //TODO: change this to a local file location

Console.WriteLine(docs);

if (!Directory.Exists(docs))
{
    Directory.CreateDirectory(docs);
    Console.WriteLine("Directory Created");
}

var files = Directory.GetFiles(docs, "*.json");

if (files.Length == 0)
{
    CardCreator creator = new CardCreator();
    set = creator.CreateNewStudySet();
}
else
{

    Console.WriteLine("Load a study set or create a new one? (l/c)");

    var result = Console.ReadLine();

    if (result == "l")
    {
        Console.WriteLine("Which study set would you like to load?");

        int i = 0;

        foreach (var x in files)
        {
            Console.WriteLine((i + 1) + ": " + x);
            i++;
        }

        var fileNumber = Console.ReadLine();

        if (fileNumber == null)
        {
            Console.WriteLine("You must enter a valid number");
            return;
        }

        var json = File.ReadAllText(files[(int.Parse(fileNumber) - 1)]);
        set = JsonSerializer.Deserialize<StudySet>(json);
    }
    else if (result == "c")
    {
        CardCreator creator = new CardCreator();
        set = creator.CreateNewStudySet();
    }
    else
    {
        Console.WriteLine("You must enter a valid option");
        return;
    }
}

if (set == null)
{
    Console.WriteLine("Something went wrong");
    return;
}

var quiz = "";

while (quiz != "x")
{
    Console.WriteLine("Quiz, Edit, Study, or Exit? (q/e/s/x)");
    quiz = Console.ReadLine();

    if (quiz == "q")
    {
        Quiz quizTime = new Quiz();
        quizTime.QuizPlayer(set.Cards);
    }
    else if (quiz == "e")
    {
        CardCreator creator = new CardCreator();
        creator.AddCards(set);
    }
    else if (quiz == "s")
    {
        Study study = new Study();
        study.StudyMainMenu(set.Cards);
    }
    else if (quiz == "x")
    {
        Console.WriteLine("Goodbye!");
    }
    else
    {
        Console.WriteLine("Please enter a valid option");
    }
}



//write a function to take a value to the second power

