using CommandNexus.Platform.Service.Models;

namespace CommandNexus.Platform.Service.Data
{
    public interface IRepository<T> where T : IModel
    {
        bool SaveChanges();

        IEnumerable<T> GetAll();
        T? GetById(Guid id);
        void Create(T platform);
    }
}
