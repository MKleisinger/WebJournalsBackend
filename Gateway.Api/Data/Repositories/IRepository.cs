using Gateway.Api.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gateway.Api.Data.Repositories {
    public interface IRepository<T> {
        Task<IEnumerable<T>> GetAll(string entityId = "");
        Task<T> GetByID(string entityID);
        Task Create(T entity);
        Task Update(T entity);
    }
}
