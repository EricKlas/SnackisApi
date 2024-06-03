using SnackisApi.Models;

namespace SnackisApi.DAL
{
    public interface IDatabaseInfoService
    {
        Task<DatabaseInfo> GetDbInfoCount();
    }
}
