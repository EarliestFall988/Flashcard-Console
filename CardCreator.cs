using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class CardCreator
{


    public void AddCards(List<FlashCard> cards)
    {
        bool stop = false;

        while (!stop)
        {
            Console.WriteLine("Add, Edit or Exit Card Editor? (a/e/x)");

            var result = Console.ReadLine();
            // Console.WriteLine(result);

            if (result== "x")
            {
                stop = true;
            }
            else if (result == "a")
                AddCard(cards);
            else if (result == "e")
                EditCard(cards);
            else
                Console.WriteLine("Invalid Input");
        }
    }

    public void AddCard(List<FlashCard> cards)
    {
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

        SaveCards(cards);
    }

    public void EditCard(List<FlashCard> cards)
    {

        Console.WriteLine("\tEditing cards\n");


        for (int i = 0; i < cards.Count; i++)
        {
            Console.WriteLine($"{i + 1}. Q: {cards[i].Question} (A: {cards[i].Answer})");
        }

        Console.WriteLine("Which card would you like to edit?");
        var cardToEdit = Console.ReadLine();

        if (cardToEdit == null)
        {
            Console.WriteLine("You must enter a card number");
            return;
        }

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

        SaveCards(cards);
    }


    public void SaveCards(List<FlashCard> cards)
    {
        var json = System.Text.Json.JsonSerializer.Serialize(cards);
        File.WriteAllText("flashcards.json", json);

        Console.WriteLine("Cards Saved!");
    }
}

