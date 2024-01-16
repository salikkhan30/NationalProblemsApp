using NationalProblemsApp.Entities;

namespace NationalProblemsApp.Services
{
    public interface IFeedbackService
    {
        Task<HandlerResponse> GetUserFeedbacks(UserDTO obj);
        Task<HandlerResponse> AddFeedback(FeedbackListDTO obj);
    }
}
