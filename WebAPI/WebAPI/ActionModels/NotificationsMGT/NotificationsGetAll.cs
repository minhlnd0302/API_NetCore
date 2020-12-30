using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.ActionModels.NotificationsMGT
{
    public class NotificationsGetAll
    {
        public async Task<ActionResult<IEnumerable<Notification>>> Excute()
        {
            var _context = new TGDDContext();
            return await _context.Notifications.ToListAsync();
        }
    }

}
