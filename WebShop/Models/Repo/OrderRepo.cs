﻿using System;
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
        public OrderRepo(DBWebShop dBWebShop)
        {
            _dBWebShop = dBWebShop;
        }
        public void Create(CreateOrderViewModel createOrder)
        {
            Order newOrder = new Order
            {
                OrderId = createOrder.OrderId,
                OrderDate = createOrder.OrderDate
            };

            for (int i = 0; i < createOrder.OrderItems.Count;  i++)
            {
                OrderItem itemsOrdered = new OrderItem
                {
                    OrderId = newOrder.OrderId,
                    Quantity = createOrder.OrderItems[i].Quantity,
                    ProductId = createOrder.OrderItems[i].ProductId
                  
                };
                _dBWebShop.Add(newOrder);
                _dBWebShop.SaveChanges();
                _dBWebShop.Add(itemsOrdered);
                _dBWebShop.SaveChanges();
            }


        }

        /// <summary>
        /// modifiering av en viss order
        ///  ersätter Edit i IOrderItem ?
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Order Edit(int Id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// vilka order har en viss kund sedan tidigare
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns></returns>        
        public List<Order> FindByCustomer(int CustomerId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// sökning efter en viss order
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>        
        public Order FindById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
