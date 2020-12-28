using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.DTOModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI.Utils
{

    public class AssigndataUtils : DbContext
    { 
        // nếu id = 0 là thêm mới, ngược lại là chỉnh sửa
        public static Comment AssignComment(CommentDTO commentsDTO, long id)
        {
            var _context = new TGDDContext();
            var comment = new Comment();

            if (id == 0)
            {
                id = _context.Comments.Max(p => p.Id) + 1;
            }

            // assign value from commentDTO to comments
            {
                comment.Id = id;
                comment.CustomerId = commentsDTO.CustomerId;
                comment.ProductId = commentsDTO.ProductId;
                comment.Message = commentsDTO.Message;
                comment.Date = DateTime.Now;
                comment.Ratting = commentsDTO.Ratting;
            }
            return comment;
        }

        public static Order AssignOrder(OrderDTO orderDTO, long id)
        {
            var _context = new TGDDContext();
            var order = new Order();

            if(id == 0)
            {
                id = _context.Orders.Max(o => o.Id) + 1;
            }

            order.Id = id;
            order.Date = DateTime.Now;
            order.CustomerId = orderDTO.CustomerId;
            order.Discount = orderDTO.Discount;
            order.Total = orderDTO.Total;
            order.ShippingAddress = orderDTO.ShippingAddress;
            order.StatusId = orderDTO.StatusId;
            order.Note = orderDTO.Note;
            order.PaymentMethod = orderDTO.PaymentMethod;

            var orderDetailId = _context.OrderDetails.Max(od => od.Id);
            // OrderDetail od ; 
         
            foreach(var orderDetail in orderDTO.OrderDetails)
            { 
                var od = new OrderDetail();
                orderDetailId ++ ;
                od.Id = orderDetailId;
                od.Quantity = orderDetail.Quantity;
                od.ProductId = orderDetail.ProductId;

                od.OrderId = id;

                order.OrderDetails.Add(od);
            };
             
            return order;
        }

        public static Voucher AssignVoucher (VoucherDTO voucherDTO, long id)
        {
            var _context = new TGDDContext();

            if (id == 0)
            {
                id = _context.Vouchers.Max(o => o.Id) + 1;
            }

            var newVoucher = new Voucher { 
                Id = id,
                Code = voucherDTO.Code,
                DiscountPercent = voucherDTO.DiscountPercent,
                Name = voucherDTO.Name,
                StartDate = DateTime.Parse(voucherDTO.StartDate),
                EndDate = DateTime.Parse(voucherDTO.EndDate),
            };

            return newVoucher;
        }
        public static Product AssignProduct(ProductDTO productsDTO, long id)
        {
            var product = new Product();

            return product;
        }
    }
}
