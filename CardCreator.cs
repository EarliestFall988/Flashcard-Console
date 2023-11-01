using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class CardCreator
{


    private static readonly string directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\flashcards\\"; //TODO: change this to a local file


    public StudySet CreateNewStudySet()
    {

        string? setName = "";

        while (setName == null || setName == "")
        {

            Console.WriteLine("What is the name of your new study set?");
            setName = Console.ReadLine();

            if (setName == null)
            {
                Console.WriteLine("You must enter a name for your study set");
            }



            var files = Directory.GetFiles(directory, "*.json");

            if (File.Exists(directory + "/" + setName + ".json"))
            {
                Console.WriteLine("This study set already exists");
            }
        }

        StudySet set = new StudySet();
        set.StudyName = setName;

        AddCards(set);

        return set;
    }


    public void AddCards(StudySet set)
    {
        bool stop = false;

        while (!stop)
        {
            Console.WriteLine("Add, Edit or Exit Card Editor? (a/e/x)");

            var result = Console.ReadLine();
            // Console.WriteLine(result);

            if (result == "x")
            {
                stop = true;
            }
            else if (result == "a")
                AddCard(set);
            else if (result == "e")
                EditCard(set);
            else
                Console.WriteLine("Invalid Input");
        }
    }

    public void AddCard(StudySet set)
    {

        var cards = set.Cards;

        Console.WriteLine("what is the question?");
        var question = Console.ReadLine()?.Trim();

        Console.WriteLine("what is the answer?");
        var answer = Console.ReadLine()?.Trim();

        FlashCard card = new FlashCard();

        if (question == null || answer == null)
        {
            Console.WriteLine("You must enter a question and an answer");
            return;
        }

        card.Question = question;
        card.Answer = answer;

        cards.Add(card);

        SaveCards(set);
    }

    public void EditCard(StudySet set)
    {

        var cards = set.Cards;

        Console.WriteLine("\tEditing cards\n");


        for (int i = 0; i < cards.Count; i++)
        {
            Console.WriteLine($"{i + 1}. Q: {cards[i].Question} \n\t (A: {cards[i].Answer})");
        }

        Console.WriteLine("Which card (number) would you like to edit? (Enter x to exit edit mode)");
        var cardToEdit = Console.ReadLine();

        if (cardToEdit == null)
        {
            Console.WriteLine("You must enter a card number");
            return;
        }

        if (cardToEdit == "x")
            return;

        var cardIndex = int.Parse(cardToEdit) - 1;

        if (cardIndex < 0 || cardIndex >= cards.Count)
        {
            Console.WriteLine("You must enter a valid card number");
            return;
        }

        Console.WriteLine("what is the question?");

        var question = Console.ReadLine()?.Trim();

        Console.WriteLine("what is the answer?");

        var answer = Console.ReadLine()?.Trim();

        if (question == null || answer == null)
        {
            Console.WriteLine("You must enter a question and an answer");
            return;
        }

        cards[cardIndex].Question = question;
        cards[cardIndex].Answer = answer;

        SaveCards(set);
    }


    public void SaveCards(StudySet set)
    {
        var json = System.Text.Json.JsonSerializer.Serialize(set);
        File.WriteAllText(directory + "\\" + set.StudyName + ".json", json);

        Console.WriteLine("Cards Saved!");
    }
}

