using System.Net;

namespace ConquerBackend.Shared.Interfaces
{
    public interface IResult<T>
    {
        bool Succeeded { get; set; }
        T Data { get; set; }
        List<string> Messages { get; set; }
        HttpStatusCode StatusCode { get; set; }
    }

}
