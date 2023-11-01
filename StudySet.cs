using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class StudySet
{
    public string StudyId { get; set; } = Guid.NewGuid().ToString();

    public string StudyName { get; set; } = "";

    public List<FlashCard> Cards { get; set; } = new List<FlashCard>();
    
}
