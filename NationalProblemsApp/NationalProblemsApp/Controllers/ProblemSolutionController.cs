using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NationalProblemsApp.Data;
using NationalProblemsApp.Entities;
using NationalProblemsApp.Services;
using System.Reflection.Metadata;

namespace NationalProblemsApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProblemSolutionController : ControllerBase
    {
        private HandlerResponse hResponse;
        private readonly IMapper mapper;
        private readonly ILogger<ProblemSolutionController> logger;
        private readonly IFeedbackService feedback;
        private readonly NationalProblemsDbContext db;

        public ProblemSolutionController(IMapper _mapper, ILogger<ProblemSolutionController> _logger, IFeedbackService _feedback)
        {
            feedback = _feedback;
            mapper = _mapper;
            logger = _logger;
        }

        [HttpPost]
        [Route("get-user-feedbacks")]
        public async Task<UserDTO> GetUserFeedbacks(UserDTO obj)
        {
            try
            {
                logger.LogInformation("GetUserFeedbacks");
                await Task.Run(() =>
                {
                    logger.LogInformation("GetUserFeedbacks");
                });

                hResponse = await feedback.GetUserFeedbacks(obj);
                
                if (hResponse.Success)
                {
                    obj = (UserDTO)hResponse.DataObject;
                }
                return obj;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error in GetUsers");
                throw; // Rethrow the exception
            }
        }

        [HttpPost]
        [Route("add-feedback")]
        public async Task<HandlerResponse> AddFeedback(FeedbackListDTO obj)
        {
            try
            {
                logger.LogInformation("AddFeedback");
                await Task.Run(() => { logger.LogInformation("AddFeedback"); });

                hResponse = await feedback.AddFeedback(obj);

                //var obj = hResponse.DataObject.

                return hResponse;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error in AddFeedback");
                throw; // Rethrow the exception
            }
        }

        //[HttpGet]
        //[Route("GetUser")]
        //public async Task<ActionResult<User>> GetUser(int userId)
        //{
        //    try
        //    {
        //        await Task.Run(() =>
        //        {
        //            logger.LogInformation("GetUser");
        //        });

        //        var user = users.Find(x => x.IdPk == userId);

        //        if (user == null)
        //            return NotFound(users);

        //        return Ok(user);
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.LogError(ex, "Error in GetUser");
        //        throw; // Rethrow the exception
        //    }
        //}

        //[HttpPost]
        //[Route("AddUser")]
        //public async Task<ActionResult<User>> AddUser(User user)
        //{
        //    try
        //    {
        //        await Task.Run(() =>
        //        {
        //            logger.LogInformation("AddUser");
        //        });

        //        if (user == null)
        //            return NotFound(user);

        //        int userId = users.Select(x => x.IdPk).Max();
        //        user.IdPk = userId + 1;

        //        users.Add(user);

        //        return Ok(user);
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.LogError(ex, "Error in AddUser");
        //        throw; // Rethrow the exception
        //    }
        //}

        //[HttpPut]
        //[Route("UpdateUser")]
        //public async Task<ActionResult<User>> UpdateUser(User user)
        //{
        //    try
        //    {
        //        await Task.Run(() =>
        //        {
        //            logger.LogInformation("UpdateUser");
        //        });

        //        if (user == null)
        //            return NotFound(user);

        //        User? getuser = users.Find(x => x.UserID == user.UserID);

        //        if (getuser == null)
        //            return NotFound(user);

        //        getuser.EmailID = user.EmailID;
        //        getuser.MobileNumber = user.MobileNumber;

        //        return Ok(user);
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.LogError(ex, "Error in UpdateUser");
        //        throw; // Rethrow the exception
        //    }

        //}

        //[HttpDelete]
        //[Route("DeleteUser")]
        //public async Task<ActionResult<User>> DeleteUser(User user)
        //{
        //    try
        //    {
        //        await Task.Run(() =>
        //        {
        //            logger.LogInformation("DeleteUser");
        //        });

        //        if (user == null)
        //            return NotFound(user);

        //        int remove = users.RemoveAll(x => x.UserID == user.UserID);
        //        if (remove < 1)
        //            return NotFound(user);

        //        return Ok(user);
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.LogError(ex, "Error in DeleteUser");
        //        throw; // Rethrow the exception
        //    }

        //}

    }
}