using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Data;
using WebShop.Models.Entities;
using WebShop.ViewModels;

namespace WebShop.Models.Repo
{
    public class OrderRepo : IOrderRepo
    {
        private readonly DBWebShop _dBWebShop;
        List<OrderItem> OrderItems = new List<OrderItem>();
        List<Order> orders = new List<Order>();
        public OrderRepo(DBWebShop dBWebShop)
        {
            _dBWebShop = dBWebShop;
        }
        public void Create(CreateOrderViewModel createOrder)
        {
            Order newOrder = new Order
            {
                //OrderId = createOrder.OrderId,
                OrderDate = createOrder.OrderDate
            };
            _dBWebShop.Add(newOrder);
            _dBWebShop.SaveChanges();
            for (int i = 0; i < createOrder.OrderItems.Count;  i++)
            {
                OrderItem itemsOrdered = new OrderItem
                {
                    OrderId = newOrder.OrderId,
                    Quantity = createOrder.OrderItems[i].Quantity,
                    ProductId = createOrder.OrderItems[i].ProductId
                  
                };
               
                _dBWebShop.Add(itemsOrdered);
                _dBWebShop.SaveChanges();
            }


        }

        public List<OrderItem> Read()
        {
            OrderItems = _dBWebShop.OrderItem.Include(o => o.Order).ToList();
            OrderItems = _dBWebShop.OrderItem.Include(p => p.Product).ToList();

            return OrderItems;
        }
       

        public void Edit(int id, UpdateOrderViewModel updateOrder)
        {
            Order orderToUpdate = FindById(id);
            orderToUpdate.OrderDate = updateOrder.OrderDate;
            _dBWebShop.Update(orderToUpdate);
            _dBWebShop.SaveChanges();

            for (int i = 0; i < updateOrder.OrderItems.Count; i++)
            {
                orderToUpdate.OrderId = id;
                orderToUpdate.OrderItems[i].ProductId = updateOrder.OrderItems[i].ProductId;
                orderToUpdate.OrderItems[i].Quantity = updateOrder.OrderItems[i].Quantity;
            }
            _dBWebShop.Update(orderToUpdate);
            _dBWebShop.SaveChanges();
        }

        public List<Order> FindByCustomer(int CustomerId)
        {
            throw new NotImplementedException();
        }

        public Order FindById(int Id)
        {
            orders = _dBWebShop.Order.ToList();

            foreach (Order item in orders)
            {
                if (item.OrderId == Id)
                {
                    return item;
                }
            }
            return null;
        }

        public void Delete(int Id)
        {
            Order OrderToDelete = FindById(Id);
            _dBWebShop.Remove(OrderToDelete);
            _dBWebShop.SaveChanges();
        }
    }
}
