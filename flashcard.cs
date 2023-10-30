


public class FlashCard
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public bool AlreadyFound = false;

    public bool isCorrect = false;

    public string Question { get; set; } = "";

    public string Answer { get; set; } = "";
}