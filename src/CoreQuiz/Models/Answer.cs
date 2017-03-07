using System;

namespace CoreQuiz.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
        public bool IsUserOption { get; set; }
        public DateTime CreateDateTime { get; set; }

        public ApplicationUser CreatedBy { get; set; }
    }
}
