using webClientEx2.Models;
namespace webClientEx2.Services
{
    public interface IRateService
    {
        public Task<List<Rate>> GetAll();
        public Task<Rate> Get(int id);
        public Task Edit(int id, string name, string text, int number);
        public Task<Rate> Create(string text, string name, int number);
        public Task Delete(int id);
        public Task<ICollection<Rate>> Search(string query);


    }
}
