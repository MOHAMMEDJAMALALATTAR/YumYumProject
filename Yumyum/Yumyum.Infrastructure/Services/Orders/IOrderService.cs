using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yumyum.Core.DTOs;
using Yumyum.Core.Exceptions;
using Yumyum.Core.ViewModels;
using Yumyum.Data.Models;

namespace Yumyum.Infrastructure.Services.Orders
{
    public interface IOrderService
    {
        Task<List<OrderViewModel>> GetAll();
        Task<CreateOrderDto> Create(CreateOrderDto dto);
        Task<int> Update(UpdateOrderDto dto);
        Task<int> Delete(int id);
       
    }
}
