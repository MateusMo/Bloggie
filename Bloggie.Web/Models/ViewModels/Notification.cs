using Bloggie.Web.Enums;
using System.Reflection.Metadata.Ecma335;

namespace Bloggie.Web.Models.ViewModels
{
    public class Notification
    {
        public string Message { get; set; }
        public NotificationType Type { get; set; }

    }
}
