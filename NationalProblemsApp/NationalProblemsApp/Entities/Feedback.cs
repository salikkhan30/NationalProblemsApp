namespace NationalProblemsApp.Entities
{
    public class Feedback : BaseEntity
    {
        public string UserID { get; set; } = string.Empty;
        public string ProblemTitle { get; set; } = string.Empty;
        public string ProblemDescription { get; set; } = string.Empty;
        public string Solution { get; set; } = string.Empty;
    }
}