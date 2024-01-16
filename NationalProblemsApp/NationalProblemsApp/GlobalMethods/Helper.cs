using AutoMapper;
using NationalProblemsApp.Controllers;
using NationalProblemsApp.Data;
using NationalProblemsApp.Entities;
using System.Data;
using System.Net;
using System.Reflection;

namespace NationalProblemsApp.GlobalMethods
{
    public class Helper : IHelper
    {
        private readonly IMapper mapper;
        private readonly ILogger<Helper> logger;
        private NationalProblemsDbContext db;

        public Helper(IMapper _mapper, NationalProblemsDbContext _db)
        {
            mapper = _mapper;
            db = _db;
        }

        public HandlerResponse SetResponseObject(HandlerResponse HandlerResponse, HandlerModel dataObject, string message = "",
            HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest, bool success = false)
        {
            HandlerResponse.Success = success;
            HandlerResponse.Message = message;
            HandlerResponse.StatusCode = (int)httpStatusCode;
            HandlerResponse.DataObject = dataObject;
            return HandlerResponse;
        }
        public string GetMaxUserId()
        {
            string? maxUserId = db.Users.Select(x => x.UserID).Max();
            if (maxUserId == null)
                return "1";
            else
                return (int.Parse(maxUserId) + 1).ToString();
        }
        //public T SetBaseEntityFields<T>(T entity, T dto, bool isForCreated)
        //{
        //    entity.CreatedBy = dto.UserID;
        //    entity.CreatedOn = isForCreated ? DateTime.Now : entity.CreatedOn;
        //    entity.UpdatedBy = dto.UserID;
        //    entity.UpdatedOn = DateTime.Now;

        //    return entity;
        //}
        //public T SetBaseEntityFields<T>(T entity, string userId, bool isForCreate = true) where T : class
        //{
        //    PropertyInfo CreatedByProperty = typeof(T).GetProperty("CreatedBy");
        //    PropertyInfo CreatedOnProperty = typeof(T).GetProperty("CreatedOn");
        //    PropertyInfo UpdatedByProperty = typeof(T).GetProperty("UpdatedBy");
        //    PropertyInfo UpdatedOnProperty = typeof(T).GetProperty("UpdatedOn");

        //    if (CreatedOnProperty != null)
        //    {
        //        CreatedByProperty.SetValue(entity, isForCreate ? DateTime.Now : CreatedByProperty.GetValue(entity));
        //    }
        //    if (CreatedOnProperty != null)
        //    {
        //        CreatedByProperty.SetValue(entity, userId);
        //    }
        //    if (UpdatedByProperty != null)
        //    {
        //        UpdatedByProperty.SetValue(entity, DateTime.Now);
        //    }
        //    if (UpdatedOnProperty != null)
        //    {
        //        UpdatedOnProperty.SetValue(entity, DateTime.Now);
        //    }

        //    return entity;
        //}

    }
}