namespace NationalProblemsApp.Entities
{
    public class HandlerResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
        public HandlerModel DataObject { get; set; }
    }
    public class HandlerModel
    {
    }
}