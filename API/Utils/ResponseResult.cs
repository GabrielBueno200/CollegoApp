using System;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Web;
using MoreLinq;
using System.Dynamic;

namespace API.Utils
{
    public class ResponseResult : IResponseResult {

        public List<ResponseErrors> Errors { get; set; } = new List<ResponseErrors>();

        public bool HasErrors  { get { return Errors.Count > 0; } }
        
        public string ErrorFromType(ErrorType type) => Errors.Where(x => x.Type == type).FirstOrDefault()?.Message ?? null;

        public void AddError(string name, ErrorType type) => ResponseErrors.AddError(Errors, name, type);

        public object JsonErrors { get {

            dynamic errorsByTypeObject = new ExpandoObject();
            var errorTypes = Errors.DistinctBy(x => x.Type).Select(x => x.Type.ToString());

            errorTypes.ForEach(err => {
                (errorsByTypeObject as IDictionary<string, Object>)[err] = 
                    Errors.Where(x => x.Type.ToString() == err)?.Select(x => x.Message);
            });

            return new { errors = errorsByTypeObject };
        }}
    }
}