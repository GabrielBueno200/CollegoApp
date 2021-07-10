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
        
        public string ErrorFromType(ErrorType type) => Errors.Where(x => x.Type == type).FirstOrDefault()?.Message;

        public void AddError(string name, ErrorType type){
            ResponseErrors.AddError(Errors, name, type);
        }
        public object JsonErrors { get { 
            return new {
                errors = Errors.Select(x => new {
                    type = x.Type.ToString(),
                    message = x.Message
                })
            };
        }}

        
    }
}