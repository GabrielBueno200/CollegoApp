using System.Net;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;

namespace Application.Core.Notifications
{
    public class ResponseNotifications {

        public NotificationType Type { get; set; }

        public string Message {get; set; } 
 
        
        public static List<ResponseNotifications> getIdentityResultErrors(IdentityResult result){

            return result.Errors.Select(err => new ResponseNotifications{
                Type = NotificationType.VALIDATION_ERROR,
                Message = err.Description
            }).ToList();

        }

        public static List<ResponseNotifications> getResultErrors(ValidationResult result){

            return result.Errors.Select(err => new ResponseNotifications {
                Type = NotificationType.VALIDATION_ERROR,
                Message = $"{err.PropertyName}:  {err.ErrorMessage}" 
            }).ToList();

        }

        public static void AddNotification(List<ResponseNotifications> Notification, string message, NotificationType type = NotificationType.VALIDATION_ERROR){ 
            Notification.Add(new ResponseNotifications {
                Type = type,
                Message = message
            });
        }

        public static List<ResponseNotifications> Merge(List<ResponseNotifications> A, List<ResponseNotifications> B) => A.Concat(B).ToList();
        
    }
}