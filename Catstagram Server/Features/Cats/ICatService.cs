
using System.Threading.Tasks;

namespace Catstagram_Server.Features.Cats
{
    public interface ICatService
    {
        public  Task<int> Create(string ImageUrl, string Desc, string userId);
        

    }
}
