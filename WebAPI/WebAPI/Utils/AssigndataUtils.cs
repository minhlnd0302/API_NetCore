using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.DTOModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebAPI.ActionModels.ProductsMGT;

namespace WebAPI.Utils
{

    public class AssigndataUtils : DbContext
    {
        // nếu id = 0 là thêm mới, ngược lại là chỉnh sửa
        public Comment AssignComment(CommentDTO commentsDTO, long id)
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

        public async Task<Order> AssignOrder(OrderDTO orderDTO, long id)
        {
            var _context = new TGDDContext();
            var order = new Order();
            var listOrderDetail = new List<OrderDetail>();

            if (id == 0)
            {
                id = _context.Orders.Max(o => o.Id) + 1;
            }
            else
            {
                listOrderDetail = await _context.OrderDetails.Where(orderDetail => orderDetail.OrderId == id).ToListAsync();

                foreach(OrderDetail orderDetail in listOrderDetail)
                {
                    foreach(OrderDetailDTO orderDetailDTO in orderDTO.OrderDetails)
                    {
                        if(orderDetailDTO.ProductId == orderDetail.ProductId)
                        {
                            orderDetail.Quantity = orderDetailDTO.Quantity;

                            _context.Entry(orderDetail).State = EntityState.Modified;

                            break;
                        }
                    }
                }

                await _context.SaveChangesAsync();
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

            foreach (var orderDetail in orderDTO.OrderDetails)
            {
                if (listOrderDetail.Count > 0) break;

                var od = new OrderDetail();
                orderDetailId++;
                od.Id = orderDetailId;
                od.Quantity = orderDetail.Quantity;
                od.ProductId = orderDetail.ProductId;

                Product product = _context.Products.Find(od.ProductId);


                od.CurrentPrice = product.Price;

                od.OrderId = id;

                order.OrderDetails.Add(od);
            };

            return order;
        }

        public Voucher AssignVoucher(VoucherDTO voucherDTO, long id)
        {
            var _context = new TGDDContext();

            if (id == 0)
            {
                id = _context.Vouchers.Max(o => o.Id) + 1;
            }

            var newVoucher = new Voucher
            {
                Id = id,
                Code = voucherDTO.Code,
                DiscountPercent = voucherDTO.DiscountPercent,
                Name = voucherDTO.Name,
                StartDate = DateTime.Parse(voucherDTO.StartDate),
                EndDate = DateTime.Parse(voucherDTO.EndDate),
            };

            return newVoucher;
        }
        public async Task<Product> AssignProduct(ProductDTO productDTO, long ProductId)
        {
            var _context = new TGDDContext();
            Product newProduct = new Product();
            string type = "";

            long? DescriptionId = new long?();



            if (ProductId == 0)
            {
                ProductId = _context.Products.Max(p => p.Id) + 1;
                productDTO.Id = ProductId;

                DescriptionId = _context.Descriptions.Max(d => d.Id) + 1;
                productDTO.description.Id = (long)DescriptionId;


                newProduct.Id = _context.Products.Max(p => p.Id) + 1;
                //newProduct.Descriptions.FirstOrDefault().Id = (long)DescriptionId;
            }
            else
            {
                newProduct = await _context.Products.Where(p => p.Id == ProductId).Include(p => p.Descriptions).FirstOrDefaultAsync();
                DescriptionId = newProduct.Descriptions.Select(d => d.Id).FirstOrDefault();
                ProductsDeleteImage productsDeleteImage = new ProductsDeleteImage { ProductId = ProductId };
                await productsDeleteImage.Excute();

                type = "Update";
            }





            newProduct.Id = ProductId;
            newProduct.Name = productDTO.Name;
            newProduct.Price = productDTO.Price;
            newProduct.Stock = productDTO.Stock;
            newProduct.DateArrive = DateTime.Now.ToString();
            newProduct.Rating = 0;
            newProduct.CategoryId = productDTO.CategoryId;
            newProduct.BrandId = productDTO.BrandId;
            newProduct.BuyingTimes = 0;

            // desctiption
            {
                var newDescription = new Description();

                newDescription.Id = (long)DescriptionId;
                newDescription.Memory = productDTO.description.Memory;
                newDescription.Os = productDTO.description.Os;
                newDescription.ProductId = ProductId;
                newDescription.Ram = productDTO.description.Ram;
                newDescription.ScreenSize = productDTO.description.ScreenSize;
                newDescription.Cpu = productDTO.description.Cpu;
                newDescription.Color = productDTO.description.Color;
                newDescription.Battery = productDTO.description.Battery;
                newDescription.Introduction = productDTO.description.Introduction;
                

                Description description = _context.Descriptions.FirstOrDefault(d => d.ProductId == ProductId);

                if (description != null)
                {
                    _context.Descriptions.Remove(description);
                    _context.Descriptions.Add(newDescription);

                    await _context.SaveChangesAsync();
                }
                else
                {
                    newProduct.Descriptions = new List<Description> { newDescription };
                }  
            }


            var newImageId = _context.Images.Max(i => i.Id) + 1; 
            foreach (string url in productDTO.images)
            {
                var newImage = new Image
                {
                    Id = newImageId,
                    Url = url,
                    ProductId = ProductId,
                    Product = newProduct

                };

                if (type == "Update")
                {
                    _context.Images.Add(newImage);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    newProduct.Images.Add(newImage); 
                } 
                newImageId++;
            }

            return newProduct;
        }
    }
}
