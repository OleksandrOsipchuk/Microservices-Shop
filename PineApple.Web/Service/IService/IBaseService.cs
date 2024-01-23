using Pineapple.Web.Models;
using Pineapple.Web.Models;

namespace Pineapple.Web.Service.IService
{
    public interface IBaseService
    {
        Task<ResponceDto?> SendAsync(RequestDto);
    }
}
