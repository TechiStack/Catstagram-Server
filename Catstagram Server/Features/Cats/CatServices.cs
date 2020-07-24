
using System.Threading.Tasks;
using Catstagram_Server.Data;
using Catstagram_Server.Data.Models;
using Catstagram_Server.Features.Cats;
namespace Catstagram_Server.Features.Cats
{
    public class CatServices : ICatService
    {
        private readonly CatstagramDbContext data;

        public CatServices(CatstagramDbContext data) => this.data = data;
        

        public async Task<int> Create(string ImageUrl,string Desc,string userId)
        {
            var cat = new Cat
            {
                Description = Desc,
                ImageUrl = ImageUrl,
                UserId = userId
            };
            this.data.Add(cat);

            await this.data.SaveChangesAsync();

            return cat.Id;

        }
    }
}
