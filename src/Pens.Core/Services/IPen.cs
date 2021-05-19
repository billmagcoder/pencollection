using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pens.Core.Models;

namespace Pens.Core.Services
{
    public interface IPen
    {
        Task<List<Pen>> GetAll();
        
        Task<Pen> GetPen(int id);

        Task AddPen(Pen pen);

        Task UpdatePen(Pen pen);

        Task DeletePen(int id);
    }
}
