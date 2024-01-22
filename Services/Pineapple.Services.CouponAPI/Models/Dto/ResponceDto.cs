namespace Pineapple.Services.CouponAPI.Models.Dto
{
    public class ResponceDto
    {
        public object Data { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "";

    }
}
