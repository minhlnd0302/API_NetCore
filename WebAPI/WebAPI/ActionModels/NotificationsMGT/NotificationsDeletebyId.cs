using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.ActionModels.NotificationsMGT
{
    public class NotificationsDeletebyId : ControllerBase
    { 
        public long NotificationId { get; set; }
        public async Task<ActionResult<Notification>> Excute()
        {
            var _context = new TGDDContext();
            var notification = await _context.Notifications.FindAsync(NotificationId);
            if (notification == null)
            {
                return NotFound();
            }

            _context.Notifications.Remove(notification);
            await _context.SaveChangesAsync();

            return notification;
        }
    }
}
