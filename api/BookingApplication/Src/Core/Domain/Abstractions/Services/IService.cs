using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions.Services
{
    public interface IService<T>
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<T> GetById(Guid id);
        public Task<T> Create(T client);
        public Task<T> Update(Guid id, T client);
        public Task<T> Delete(Guid id);
    }
}
