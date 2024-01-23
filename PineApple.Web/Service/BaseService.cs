using Newtonsoft.Json;
using Pineapple.Web.Models;
using Pineapple.Web.Models;
using Pineapple.Web.Service.IService;
using System.Text;

namespace Pineapple.Web.Service
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ResponceDto?> SendAsync(RequestDto requestDto)
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient("PineapleAPI");

                HttpRequestMessage message = new();

                message.Headers.Add("Accept", "application/json");
                //token

                message.RequestUri = new Uri(requestDto.Url);

                if (requestDto.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");
                }

                switch (requestDto.ApiType)
                {
                    case Utility.SD.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case Utility.SD.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case Utility.SD.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                HttpResponseMessage apiResponce = new();

                apiResponce = await client.SendAsync(message);

                switch (apiResponce.StatusCode)
                {
                    case System.Net.HttpStatusCode.NotFound:
                        return new ResponceDto() { IsSuccess = false, Message = "NotFound" };
                    case System.Net.HttpStatusCode.Forbidden:
                        return new ResponceDto() { IsSuccess = false, Message = "Forbidden" };
                    case System.Net.HttpStatusCode.Unauthorized:
                        return new ResponceDto() { IsSuccess = false, Message = "Unauthorized" };
                    case System.Net.HttpStatusCode.InternalServerError:
                        return new ResponceDto() { IsSuccess = false, Message = "InternalServerError" };
                    default:
                        var apiContent = await apiResponce.Content.ReadAsStringAsync();
                        var apiResponceDto = JsonConvert.DeserializeObject<ResponceDto>(apiContent);
                        return apiResponceDto;
                }
            }
            catch (Exception ex)
            {
                var dto = new ResponceDto()
                {
                    IsSuccess = false,
                    Message = ex.Message.ToString()
                };
                return dto;
            }
        }
    }
}
