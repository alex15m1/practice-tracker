using System;

namespace PracticeTracker.Models
{   
    public class PracticeEntry
    {
        public int Id {get; set; }
        public DateTime Date { get; set;}
        public bool WarmUp { get; set; }
        public bool Scales { get; set; }
        public bool Intonation { get; set; }
        public bool TechnicalExercises { get; set; }
        public int MinutesPracticed { get; set; }
        public string? Notes { get; set; }
    }
}