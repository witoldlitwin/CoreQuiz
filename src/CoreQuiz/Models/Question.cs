using System;
using System.Collections.Generic;

namespace CoreQuiz.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Points { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime LastModificationDateTime { get; set; }

        public ApplicationUser CreatedBy { get; set; }
        public ApplicationUser ModifiedBy { get; set; }
        public QuestionType Type { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}
