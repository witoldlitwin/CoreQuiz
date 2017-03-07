using System;
using System.Collections.Generic;

namespace CoreQuiz.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime LastModificationDateTime { get; set; }
        
        public WelcomePage WelcomePage { get; set; }
        public ResultsPage ResultsPage { get; set; }
        public ApplicationUser CreatedBy { get; set; }
        public ApplicationUser ModifiedBy { get; set; }

        public ICollection<Question> Questions { get; set; }
        public ICollection<ApplicationUser> AssignedUsers { get; set; }
    }
}
