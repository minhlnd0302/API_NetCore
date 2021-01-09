using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.ActionModels.ProductsMGT;
using WebAPI.DTOModels;
using WebAPI.Models;
using WebAPI.Utils;

namespace WebAPI.ActionModels.OrdersMGT
{
    public class OrdersCreate : ControllerBase
    {
        public OrderDTO OrderDTO { get; set; }
        public async Task<ActionResult<Order>> Excute()
        {
            AssigndataUtils AssigndataUtils = new AssigndataUtils();

            var _context = new TGDDContext();
            var order = new Order();
            order = await AssigndataUtils.AssignOrder(OrderDTO, 0);

            // update stock, buying time
            {
                ProductsAutoUpdate productsAutoUpdate = new ProductsAutoUpdate();

                List<OrderDetail> orderDetails = order.OrderDetails.ToList();

                foreach (OrderDetail orderDetail in orderDetails)
                {
                    Product product = await _context.Products.FindAsync(orderDetail.ProductId);
                    product.BuyingTimes += orderDetail.Quantity;
                    product.Stock -= orderDetail.Quantity;

                    _context.Entry(product).State = EntityState.Modified;
                }
                await _context.SaveChangesAsync();

            }


            //thống kê
             

            _context.Orders.Add(order);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                bool orderExist = _context.Orders.Any(o => o.Id == order.Id);
                if (orderExist)
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            {
                DateTime dateTime = order.Date.Value;

                int day = dateTime.DayOfYear;
                int week = dateTime.DayOfYear / 7 - 1;
                if (week < 1)
                {
                    week = 1;
                }
                else if (week > 52)
                {
                    week = 52;
                }
                int month = dateTime.Month;
                int year = dateTime.Year;

                YearStatistical yearStatisticals = await _context.YearStatisticals.FirstOrDefaultAsync(y => y.Year == year);
                if (yearStatisticals != null)
                {
                    yearStatisticals.TotalYear += order.Total;
                    _context.Entry(yearStatisticals).State = EntityState.Modified;
                    await _context.SaveChangesAsync();


                    MonthStatistical monthStatistical = await _context.MonthStatisticals.FirstOrDefaultAsync(m => m.Month == month && m.YearId == yearStatisticals.Id);

                    if (monthStatistical != null)
                    {
                        monthStatistical.TotalMonth += order.Total;
                        _context.Entry(monthStatistical).State = EntityState.Modified;
                        await _context.SaveChangesAsync();

                        WeekStatistical weekStatistical = await _context.WeekStatisticals.FirstOrDefaultAsync(w => w.Week == week && yearStatisticals.Id == w.YearId);

                        if (weekStatistical != null)
                        {
                            weekStatistical.TotalWeek += order.Total;
                            _context.Entry(weekStatistical).State = EntityState.Modified;
                            await _context.SaveChangesAsync();

                            //DayStatistical dayStatistical = await _context.DayStatisticals.FirstOrDefaultAsync(d => d.Day == day && d.YearId == yearStatisticals.Id);
                        }
                        else
                        {
                            long MonthId = _context.MonthStatisticals.Max(m => m.Id) + 1;
                            long WeekId = _context.WeekStatisticals.Max(w => w.Id) + 1;

                            newWeek(order, _context, yearStatisticals.Id, MonthId, week);
                            //newday(order, _context, yearStatisticals.Id, MonthId, WeekId, day);
                        }
                    }
                    else
                    {
                        long MonthId = _context.MonthStatisticals.Max(m => m.Id) + 1;
                        long WeekId = _context.WeekStatisticals.Max(w => w.Id) + 1;


                        newMonth(order, _context, yearStatisticals.Id, month);
                        newWeek(order, _context, yearStatisticals.Id, MonthId, week);
                        //newday(order, _context, yearStatisticals.Id, MonthId, WeekId, day);
                    }

                }
                else
                {
                    long MonthId = _context.MonthStatisticals.Max(m => m.Id) + 1;
                    long WeekId = _context.WeekStatisticals.Max(w => w.Id) + 1;

                    newYear(order, _context, year);
                    newMonth(order, _context, yearStatisticals.Id, month);
                    newWeek(order, _context, yearStatisticals.Id, MonthId, week);
                    //newday(order, _context, yearStatisticals.Id, MonthId, WeekId, day);
                }

            }

            return CreatedAtAction("GetOrders", new { id = order.Id }, order);
        }

        public async void newYear(Order order, TGDDContext _context, int year)
        {
            long newYearId = _context.YearStatisticals.Max(YearStatistical => YearStatistical.Id) + 1;

            YearStatistical yearStatistica = new YearStatistical
            {
                Id = newYearId,
                TotalYear = order.Total,
                Year = year,
            };

            _context.YearStatisticals.Add(yearStatistica);
            await _context.SaveChangesAsync();
        }
        public async void newMonth(Order order, TGDDContext _context, long yeaId, int month)
        {
            long newMonthId = _context.YearStatisticals.Max(y => y.Id) + 1;
            MonthStatistical monthStatistical = new MonthStatistical
            {
                Id = newMonthId,
                YearId = yeaId,
                TotalMonth = order.Total,
                Month = month
            };

            _context.MonthStatisticals.Add(monthStatistical);
            await _context.SaveChangesAsync();

        }
        public async void newWeek(Order order, TGDDContext _context, long yearId, long monthId, int Week)
        {
            long newWeekId = _context.WeekStatisticals.Max(w => w.Id) + 1;

            WeekStatistical weekStatistical = new WeekStatistical
            {
                Id = newWeekId,
                MonthId = monthId,
                YearId = yearId,
                TotalWeek = order.Total,
                Week = Week
            };
            //_context.SaveChanges();

            _context.WeekStatisticals.Add(weekStatistical);
            await _context.SaveChangesAsync();
        }
        public async void newday(Order order, TGDDContext _context, long yearId, long monthId, long weekId, int day)
        {
            long newDayId = _context.DayStatisticals.Max(d => d.Id) + 1;

            DayStatistical dayStatistical = new DayStatistical
            {
                Id = newDayId,
                MonthId = monthId,
                YearId = yearId,
                WeekId = weekId,
                TotalDay = order.Total,
                Day = day
            };
            _context.DayStatisticals.Add(dayStatistical); 
            await _context.SaveChangesAsync();
        }
    }
}
