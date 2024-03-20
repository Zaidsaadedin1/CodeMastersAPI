using CodeMasters.Dtos.OrdersDtos;
using CodeMasters.Models;
using CodeMasters.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeMasters.Context;
using Microsoft.EntityFrameworkCore;

namespace CodeMasters.Services
{
    public class OrderService : IOrder
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateOrder(CreateOrderDto createOrderDto)
        {
            var order = new Orders
            {
                FirstName = createOrderDto.FirstName,
                LastName = createOrderDto.LastName, 
                University = createOrderDto.University,
                Major = createOrderDto.Major,
                PhoneNumber = createOrderDto.PhoneNumber,
                Description = createOrderDto.Description,
                CreateAt = createOrderDto.CreateAt,
                StartAtDate = createOrderDto.StartAtDate,
                DeadLineDate = createOrderDto.DeadLineDate
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return 1; 
        }

        public async Task<int> UpdateOrder(UpdateOrderDto updateOrderDto,int id)
        {
            var existingOrder = await _context.Orders.FindAsync(id);

            if (existingOrder == null)
            {
                throw new InvalidOperationException("Order not found");
            }

            existingOrder.FirstName = updateOrderDto.FirstName;
            existingOrder.LastName = updateOrderDto.LastName;
            existingOrder.University = updateOrderDto.University;
            existingOrder.Major = updateOrderDto.Major;
            existingOrder.PhoneNumber = updateOrderDto.PhoneNumber;
            existingOrder.Description = updateOrderDto.Description;
            existingOrder.StartAtDate = updateOrderDto.StartAtDate;
            existingOrder.DeadLineDate = updateOrderDto.DeadLineDate;

            await _context.SaveChangesAsync();

            return existingOrder.Id; 
        }

        public async Task<int> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                throw new InvalidOperationException("Order not found");
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return order.Id; 
        }

        public async Task<GetOrderDto> GetOrderById(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                throw new InvalidOperationException("Order not found");
            }

            var getOrderDto = new GetOrderDto
            {
                FirstName = order.FirstName,
                LastName = order.LastName,
                University = order.University,
                Major = order.Major,
                PhoneNumber = order.PhoneNumber,
                Description = order.Description,
                StartAtDate = order.StartAtDate,
                DeadLineDate = order.DeadLineDate
            };

            return getOrderDto; 
        }

        public async Task<List<GetOrderDto>> GetAllOrders()
        {
            var orders = await _context.Orders.ToListAsync();

            var getOrderDtos = orders.Select(order => new GetOrderDto
            {
                FirstName = order.FirstName,
                LastName = order.LastName,
                University = order.University,
                Major = order.Major,
                PhoneNumber = order.PhoneNumber,
                Description = order.Description,
                StartAtDate = order.StartAtDate,
                DeadLineDate = order.DeadLineDate
            }).ToList();

            return getOrderDtos; 
        }
    }
}
