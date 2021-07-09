using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Web;

namespace API.Utils
{
    public class ResponseResult : IResponseResult{


        public List<ResponseErrors> Errors { get; set; } = new List<ResponseErrors>();

        public bool HasErrors  { get { return Errors.Count > 0;} }
        
        public string EntityNotFound { get { 
            return Errors.Where(x => x.Type == ErrorType.ENTITY_NOT_FOUND).FirstOrDefault()?.Message;
        }}

        public object JsonErrors { get { 
            return new {
                data = Errors
            };
        }}
        
    }
}