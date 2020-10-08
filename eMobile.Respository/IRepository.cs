using eMobile.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eMobile.Respository
{
    public interface IRepository<T> where T : BaseEntity
    {
        List<T> GetAll();
        T Get(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SaveChanges();
    }
}
