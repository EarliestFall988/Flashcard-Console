

public class Quiz
{

    public List<(FlashCard card, string incorrectAnswer)> CardsMissed = new List<(FlashCard, string incorrectAnswer)>();
    int cardsCorrect = 0;

    public List<FlashCard> CardsLeft = new List<FlashCard>();

    public int totalCards = 0;

    public void QuizPlayer(List<FlashCard> cards)
    {

        totalCards = cards.Count;

        CardsLeft.AddRange(cards.ToArray());

        Console.WriteLine("Starting Quiz");

        while (CardsLeft.Count > 0)
        {
            var random = new Random();
            var r = random.Next(0, CardsLeft.Count - 1);
            var card = CardsLeft[r];
            CardsLeft.RemoveAt(r);

            if (CardsLeft.Count < totalCards)
                Thread.Sleep(2000);

            Console.Clear();
            Console.WriteLine(card.Question);

            var answer = Console.ReadLine()?.Trim().ToLower();

            if (answer == card.Answer.Trim().ToLower())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Correct!");
                Console.ResetColor();
                card.isCorrect = true;

                cardsCorrect++;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect!");
                Console.ResetColor();
                Console.WriteLine("The correct answer is: " + card.Answer);

                if (answer != null)
                    CardsMissed.Add((card, answer));
                else
                    CardsMissed.Add((card, "<No Answer Given>"));
            }
        }

        Console.WriteLine("Quiz Complete!\n\n");
        Console.WriteLine($"You got {cardsCorrect} out of {totalCards} cards ({((float)cardsCorrect / (float)totalCards) * 100f}%) correct\n\n");

        ShowCardsMissed();
    }

    public void ShowCardsMissed()
    {

        int i = 1;

        if (CardsMissed.Count == 0)
        {

            Console.WriteLine("Nice! No Cards Missed! (Press Enter to Continue)");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("Cards Missed! (Press Enter to Continue)\n");

        foreach (var card in CardsMissed)
        {
            Console.WriteLine($"\n({i})--------------------");
            Console.WriteLine("\tQ:" + card.card.Question);
            Console.WriteLine("\tA:" + card.card.Answer + " (Your Answer: " + card.incorrectAnswer + ")");

            i++;
        }

        Console.ReadLine();
    }
}