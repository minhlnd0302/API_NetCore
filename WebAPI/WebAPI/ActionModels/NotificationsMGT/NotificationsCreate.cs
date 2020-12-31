using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.ActionModels.NotificationsMGT
{
    public class NotificationsCreate : ControllerBase
    {
        public Notification Notification { get; set; }

        public async Task<ActionResult<Notification>> Excute()
        {
            var _context = new TGDDContext();

            try
            {
                Notification.Id = _context.Notifications.Max(notification => notification.Id) + 1;

            }
            catch
            {

                Notification.Id = 1;

            }


            _context.Notifications.Add(Notification);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                bool notificationExist = _context.Notifications.Any(notification => notification.Id == Notification.Id);
                if (notificationExist)
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            //return CreatedAtAction("GetNotification", new { id = Notification.Id }, Notification);

            return Ok(Notification);
        }
    }
}
