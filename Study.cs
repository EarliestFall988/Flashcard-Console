using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Study
{


    public void StudyMainMenu(List<FlashCard> cards)
    {

        bool stop = false;

        while (!stop)
        {
            Console.WriteLine("Study, Show All Cards or Exit Card Study? (s/a/x)");

            var result = Console.ReadLine();
            // Console.WriteLine(result);

            if (result == "x")
            {
                stop = true;
            }
            else if (result == "s")
                StudyCards(cards);
            else if (result == "a")
                ListCards(cards);
            else
                Console.WriteLine("Invalid Input");
        }

    }


    public void StudyCards(List<FlashCard> cards)
    {

        Console.Clear();

        int i = 1;

        foreach (var x in cards)
        {
            Console.WriteLine(i + "/" + cards.Count + "\n\t" + x.Question);
            Console.WriteLine("(Press any key to see the answer)");
            Console.ReadKey();
            Console.WriteLine("\t" + x.Answer);
            Console.WriteLine("(Press any key to continue)");
            Console.ReadKey();
            Console.Clear();

            i++;
        }
    }

    public void ListCards(List<FlashCard> cards)
    {

        Console.Clear();

        int i = 0;

        foreach (var x in cards)
        {
            Console.WriteLine((i + 1) + "/" + cards.Count + "\n");
            Console.WriteLine("\tQ: " + x.Question);
            Console.WriteLine("\tA: " + x.Answer + "\n");

            i++;
        }
    }
}
