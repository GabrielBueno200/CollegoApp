using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Web;

namespace API.Utils
{
    public class ResponseResult : IResponseResult{
        public HttpStatusCode StatusCode {get; set;}

        public string Message {get; set;} 

        public List<ResponseResult> Errors {get; set;}

        public bool HasErrors  { get {return Errors != null;} }

        public string JsonErrors { get { 
            return JsonSerializer.Serialize(new {
                data = Errors.Select(e => e.Message)
            });
        }}
        
    }
}