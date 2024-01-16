namespace NationalProblemsApp.Entities
{
    public class FeedbackListDTO : HandlerModel
    {
        public UserDTO UserDto { get; set; } = new UserDTO();
        public List<FeedbackDTO> FeedbackListDto { get; set; } = new List<FeedbackDTO>();
    }

    public class FeedbackDTO : HandlerModel
    {
        public int IdPk { get; set; } = 0;
        public int UserID { get; set; } = 0;
        public string ProblemTitle { get; set; } = string.Empty;
        public string ProblemDescription { get; set; } = string.Empty;
        public string Solution { get; set; } = string.Empty;
    }
    public class UserDTO : HandlerModel
    {
        public int IdPk { get; set; } = 0;
        public string UserID { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public string EmailID { get; set; } = string.Empty;
    }
}