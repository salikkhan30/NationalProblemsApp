using AutoMapper;
using NationalProblemsApp.Controllers;
using NationalProblemsApp.Data;
using NationalProblemsApp.Entities;
using System.Data;
using System.Net;

namespace NationalProblemsApp.GlobalMethods
{
    public interface IHelper
    {
        public HandlerResponse SetResponseObject(HandlerResponse HandlerResponse, HandlerModel dataObject, string message = "",
            HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest, bool success = false);
        public string GetMaxUserId();
    }
}