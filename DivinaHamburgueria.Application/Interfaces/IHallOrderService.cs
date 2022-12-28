﻿using DivinaHamburgueria.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Application.Interfaces
{
    public interface IHallOrderService
    {
        Task<IEnumerable<HallOrderDTO>> GetAll();
        Task<HallOrderDTO?> GetById(int id);
        Task Add(HallOrderDTO hallOrderDTO);
        Task Update(HallOrderDTO hallOrderDTO);
        Task Remove(int id);
    }
}
