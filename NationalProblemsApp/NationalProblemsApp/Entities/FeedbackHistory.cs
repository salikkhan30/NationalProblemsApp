namespace NationalProblemsApp.Entities
{
    public class FeedbackHistory : BaseEntity
    {
        public int FeedbackID { get; set; } = 0;
        public int UserID { get; set; } = 0;
        public string OldProblemTitle { get; set; } = string.Empty;
        public string OldProblemDescription { get; set; } = string.Empty;
        public string OldSolution { get; set; } = string.Empty;
    }
}