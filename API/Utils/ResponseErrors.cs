using System.Net;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;

namespace API.Utils
{
    public static class ResponseErrors {
        public static List<ResponseResult> getIdentityResultErrors(IdentityResult result){

            return result.Errors.Select(err => new ResponseResult {
                StatusCode = HttpStatusCode.BadRequest,
                Message = err.Description
            }).ToList();

        }

        public static List<ResponseResult> getResultErrors(ValidationResult result){

            return result.Errors.Select(err => new ResponseResult {
                StatusCode = HttpStatusCode.BadRequest,
                Message = err.ErrorMessage 
            }).ToList();

        }

        public static List<ResponseResult> AddError(List<ResponseResult> Errors, string error, HttpStatusCode statusCode){ 
            Errors.Add(new ResponseResult {
                StatusCode = statusCode,
                Message = error
            });

            return Errors;
        }

        public static List<ResponseResult> Merge(List<ResponseResult> A, List<ResponseResult> B) => A.Concat(B).ToList();
        
    }
}