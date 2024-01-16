using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Writers;
using NationalProblemsApp.Controllers;
using NationalProblemsApp.Data;
using NationalProblemsApp.Entities;
using NationalProblemsApp.GlobalMethods;
using System.Net;

namespace NationalProblemsApp.Services
{
    public class FeedbackService : IFeedbackService
    {
        private HandlerResponse hResponse;
        private readonly IHelper helper;
        private readonly IMapper mapper;
        private readonly ILogger<ProblemSolutionController> logger;
        private readonly NationalProblemsDbContext db;

        public FeedbackService(IMapper _mapper, ILogger<ProblemSolutionController> _logger, NationalProblemsDbContext _db,
            IHelper _helper)
        {
            hResponse = new HandlerResponse();
            mapper = _mapper;
            logger = _logger;
            db = _db;
            helper = _helper;
        }

        public async Task<HandlerResponse> GetUserFeedbacks(UserDTO obj)
        {
            try
            {
                if (obj == null)
                {
                    hResponse = helper.SetResponseObject(hResponse, null, "Please provided expected data");
                    return hResponse;
                }

                FeedbackListDTO fbListdto = new FeedbackListDTO();

                // If User Not Exist then Return 
                var user = await db.Users.FirstOrDefaultAsync(x => x.MobileNumber == obj.MobileNumber || x.EmailID == obj.EmailID);
                if (user == null)
                {
                    hResponse = helper.SetResponseObject(hResponse, null, "Please provide correct Mobile # or Email id", HttpStatusCode.NotFound);
                    return hResponse;
                }

                obj.IdPk = user.IdPk;
                obj.EmailID = user.EmailID;
                obj.MobileNumber = user.MobileNumber;
                obj.UserID = user.UserID;


                helper.SetResponseObject(hResponse, obj, "", HttpStatusCode.OK, true);
                return hResponse;
            }
            catch (Exception ex)
            {
                hResponse = helper.SetResponseObject(hResponse, null, ex.Message);
                return hResponse;
            }
        }
        public async Task<HandlerResponse> AddFeedback(FeedbackListDTO obj)
        {
            try
            {
                if (obj == null || obj.FeedbackListDto == null || obj.FeedbackListDto.Count == 0)
                {
                    hResponse = helper.SetResponseObject(hResponse, null, "Please provided expected data");
                    return hResponse;
                }

                List<Feedback> fbEntList = new List<Feedback>();
                foreach (var dto in obj.FeedbackListDto)
                {
                    var fbEnt = new Feedback();
                    fbEnt.ProblemTitle = dto.ProblemTitle;
                    fbEnt.ProblemDescription = dto.ProblemDescription;
                    fbEnt.Solution = dto.Solution;

                    fbEntList.Add(fbEnt);
                }

                // If User Not Exist then Create
                if (!db.Users.Where(x => x.MobileNumber == obj.UserDto.MobileNumber || x.EmailID == obj.UserDto.EmailID).Any())
                {
                    User user = new User();
                    mapper.Map(obj.UserDto, user);
                    user.UserID = helper.GetMaxUserId();
                    db.Users.Add(user);
                }

                db.Feedbacks.AddRange(fbEntList);

                await db.SaveChangesAsync();

                await Task.Run(() =>
                {
                    helper.SetResponseObject(hResponse, obj, "Successfully Added", HttpStatusCode.OK, true);
                    return hResponse;
                });

                return hResponse;
            }
            catch(Exception ex)
            {
                hResponse = helper.SetResponseObject(hResponse, null, ex.Message);
                return hResponse;
            }
        }
    }
}
