// See https://aka.ms/new-console-template for more information
using System.Text.Json;

Console.WriteLine("Hello, World!");


List<FlashCard> Cards = new List<FlashCard>();

var jsondoc = File.ReadAllText("flashcards.json");

var result = JsonSerializer.Deserialize<List<FlashCard>>(jsondoc);

if (result != null && result.Count > 0)
{
    Cards = result;
}




var quiz = "";

while (quiz != "x")
{
    Console.WriteLine("Quiz, Edit, or Exit? (q/e/x)");
    quiz = Console.ReadLine();

    if (quiz == "q")
    {
        Quiz quizTime = new Quiz();
        quizTime.QuizPlayer(Cards);
    }
    else if (quiz == "e")
    {
        CardCreator creator = new CardCreator();
        creator.AddCards(Cards);
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