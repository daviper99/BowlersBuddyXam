using System.Threading.Tasks;

namespace BowlersBuddy.WinPhoneMVVM10.Model
{
    public interface IDataService
    {
        Task<DataItem> GetData();
    }
}