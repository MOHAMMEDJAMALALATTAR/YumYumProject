using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yumyum.Core.DTOs;
using Yumyum.Core.Exceptions;
using Yumyum.Core.ViewModels;
using Yumyum.Data.Models;
using Yumyum.Data;
using Microsoft.EntityFrameworkCore;

namespace Yumyum.Infrastructure.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly YumyumDbContext _context;
        private readonly IMapper _mapper;

        public OrderService(YumyumDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<OrderViewModel>> GetAll()
        {
            var orders = await _context.Orders.Include(x => x.Customer).ToListAsync();
            var orderss = _mapper.Map<List<OrderViewModel>>(orders);

            return orderss;
        }

        public async Task<CreateOrderDto> Create(CreateOrderDto dto)
        {
            var order = _mapper.Map<Order>(dto);
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return dto;
        }

        public async Task<int> Update(UpdateOrderDto dto)
        {
            var order = await _context.Orders.SingleOrDefaultAsync(x => x.Id == dto.Id);
            if (order == null)
            {
                throw new NotFoundException();
            }
            var updatedOrder = _mapper.Map(dto, order);
            _context.Orders.Update(updatedOrder);
            await _context.SaveChangesAsync();
            return order.Id;
        }

        public async Task<int> Delete(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                throw new NotFoundException();
            }
            _context.Orders.Remove(order);
            _context.SaveChanges();
            return order.Id;
        }
    }
}
