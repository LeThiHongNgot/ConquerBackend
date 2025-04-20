using ConquerBackend.Shared.Interfaces;
using System.Net;

namespace ConquerBackend.Shared
{
    public class Result<T> : IResult<T>
    {
        public bool Succeeded { get; set; }
        public T Data { get; set; }
        public List<string> Messages { get; set; } = new();
        public HttpStatusCode StatusCode { get; set; }

        public static Result<T> Success(T data, string message = "Success", HttpStatusCode status = HttpStatusCode.OK)
        {
            return new Result<T>
            {
                Succeeded = true,
                Data = data,
                StatusCode = status,
                Messages = new List<string> { message }
            };
        }

        public static Result<T> Failure(string message, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new Result<T>
            {
                Succeeded = false,
                Data = default,
                StatusCode = status,
                Messages = new List<string> { message }
            };
        }

        public static Result<T> Failure(List<string> messages, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new Result<T>
            {
                Succeeded = false,
                Data = default,
                StatusCode = status,
                Messages = messages
            };
        }
    }


}
