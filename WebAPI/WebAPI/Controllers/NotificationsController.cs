using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.ActionModels.NotificationsMGT;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        // GET: api/Notifications
        [Authorize(Roles = "0")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Notification>>> GetNotifications()
        {
            NotificationsGetAll notificationsGetAll = new NotificationsGetAll();
            return await notificationsGetAll.Excute();
        }

        //[Authorize(Roles = "0")]
        [HttpPost]
        public async Task<ActionResult<Notification>> PostNotification(Notification notification)
        {
            NotificationsCreate notificationsCreate = new NotificationsCreate { Notification = notification };

            return await notificationsCreate.Excute();

        }

        // DELETE: api/Notifications/5
        [Authorize(Roles = "0")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Notification>> DeleteNotification(long id)
        {
            NotificationsDeletebyId notificationsDeletebyId = new NotificationsDeletebyId { NotificationId = id };

            return await notificationsDeletebyId.Excute();
        }

        [Authorize(Roles = "0")]
        [HttpDelete]
        public async Task<ActionResult<Notification>> DeleteNotificationAll()
        {
            NotificationsDeleteAll notificationsDeleteAll = new NotificationsDeleteAll();

            return await notificationsDeleteAll.Excute();
        }
    }
}
