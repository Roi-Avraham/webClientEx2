using webClientEx2.Models;
namespace webClientEx2.Services
{
    public class RateService:IRateService
    {
        private static List<Rate> rateList = new List<Rate>();
        public List<Rate> GetAll()
        {
            return rateList;    
        }
        public Rate Get(int id)
        {
            return rateList.Find(x => x.Id == id);   
        }
        public void Edit(int id, string name, string text, int number)
        {
            Rate rate = Get(id);
            rate.Name = name;
            rate.Text = text;
            rate.RatingNum = number; 
            rate.Date = DateTime.Now;
        }

        public void Create(string text, string name, int number)
        {
            int nextId = 1;
            if(rateList.Count>0)
            {
                nextId = rateList.Max(rate => rate.Id) + 1;
            }
            DateTime now = DateTime.Now;
            rateList.Add(new Rate() { Id = nextId, Text = text, Date = now, Name = name, RatingNum = number });
        }
        public void Delete(int id)
        {
            rateList.Remove(Get(id));
        }
    }
}
