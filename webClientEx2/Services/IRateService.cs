using webClientEx2.Models;
namespace webClientEx2.Services
{
    public interface IRateService
    {
        public List<Rate> GetAll();
        
        public Rate Get(int id);

        public void Edit(int id, string name, string text, int number);

        public void Delete(int id);
        public void Create(string text, string name, int number);

    }
}
