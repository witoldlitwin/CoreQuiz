using System;
using System.Collections.Generic;

namespace CoreQuiz.Models
{
    public class Result
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public int Percentage { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public ICollection<Answer> Answers { get; set; }
        public Quiz Quiz { get; set; }
        public ApplicationUser User { get; set; }
    }
}
