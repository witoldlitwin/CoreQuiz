namespace CoreQuiz.Models
{
    public class ResultsPage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Filename { get; set; }

        public ApplicationUser CreatedBy { get; set; }
    }
}
