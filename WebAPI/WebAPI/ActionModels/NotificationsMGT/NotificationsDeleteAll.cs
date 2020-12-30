using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.ActionModels.NotificationsMGT
{
    public class NotificationsDeleteAll : ControllerBase
    {
        public async Task<ActionResult> Excute()
        {
            var _context = new TGDDContext();

            try
            {
                _context.Database.ExecuteSqlCommand("TRUNCATE TABLE Notifications");

                _context.SaveChangesAsync();
            }
            catch
            {
                return BadRequest("Đã xảy ra lỗi !");
            }

            return Ok("Xóa thành công !");

        }

    }
}
