using System;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Web;
using MoreLinq;
using System.Dynamic;

namespace Application.Core.Notifications
{
    public class NotificationsContext : INotificationsContext {

        public List<ResponseNotifications> Notifications { get; set; } = new List<ResponseNotifications>();

        public bool HasNotifications  { get { return Notifications.Count > 0; } }
        
        public string NotificationFromType(NotificationType type) => Notifications.Where(x => x.Type == type).FirstOrDefault()?.Message ?? null;

        public void AddNotification(string name, NotificationType type) => ResponseNotifications.AddNotification(Notifications, name, type);

        public object JsonNotifications { get {

            dynamic notificationsByTypeObject = new ExpandoObject();
            var NotificationTypes = Notifications.DistinctBy(x => x.Type).Select(x => x.Type.ToString());

            NotificationTypes.ForEach(err => {
                (notificationsByTypeObject as IDictionary<string, Object>)[err] = 
                    Notifications.Where(x => x.Type.ToString() == err)?.Select(x => x.Message);
            });

            return new { errors = notificationsByTypeObject };
        }}
    }
}