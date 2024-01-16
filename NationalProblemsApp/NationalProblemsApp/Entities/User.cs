namespace NationalProblemsApp.Entities
{
    public class User : BaseEntity
    {
        public string UserID { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public string EmailID { get; set; } = string.Empty;
    }
}