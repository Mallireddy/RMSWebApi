using System.Collections.Generic;

namespace RMSWebApi.RepoInterface
{
    public interface IBaseRepo<T>
    {
        List<T> GetAll();
        T GetById(int id);
        bool AddRecord(T Record);
        bool UpdateRecord(T Record);
        bool DeleteRecord(int id); 
    }
}
