using System.Net;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;

namespace Application.Utils
{
    public class ResponseErrors {

        public ErrorType Type { get; set; }

        public string Message {get; set; } 
 
        
        public static List<ResponseErrors> getIdentityResultErrors(IdentityResult result){

            return result.Errors.Select(err => new ResponseErrors{
                Type = ErrorType.VALIDATION_ERROR,
                Message = err.Description
            }).ToList();

        }

        public static List<ResponseErrors> getResultErrors(ValidationResult result){

            return result.Errors.Select(err => new ResponseErrors {
                Type = ErrorType.VALIDATION_ERROR,
                Message = $"{err.PropertyName}:  {err.ErrorMessage}" 
            }).ToList();

        }

        public static void AddError(List<ResponseErrors> Errors, string error, ErrorType type = ErrorType.VALIDATION_ERROR){ 
            Errors.Add(new ResponseErrors {
                Type = type,
                Message = error
            });
        }

        public static List<ResponseErrors> Merge(List<ResponseErrors> A, List<ResponseErrors> B) => A.Concat(B).ToList();
        
    }
}