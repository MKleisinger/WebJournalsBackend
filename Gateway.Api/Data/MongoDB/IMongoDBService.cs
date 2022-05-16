using Gateway.Api.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gateway.Api.Data.MongoDB {
    public interface IMongoDBService<T> {
        Task<IEnumerable<T>> GetAsync();
        Task<T> GetByIDAsync(string entityID);
        Task<IEnumerable<T>> GetByPropertyAsync(string propertyName, object value);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);        
        Task DeleteAsync(string entityID);
        void Init(string collection);
    }
}
