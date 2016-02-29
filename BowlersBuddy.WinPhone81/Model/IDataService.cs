using System.Threading.Tasks;

namespace BowlersBuddy.WinPhone81.Model
{
    public interface IDataService
    {
        Task<DataItem> GetData();
    }
}