namespace Pineapple.Web.Models
{
    public class ResponceDto
    {
        public object Data { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "";

    }
}
