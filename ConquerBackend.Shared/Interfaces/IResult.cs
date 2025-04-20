using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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
