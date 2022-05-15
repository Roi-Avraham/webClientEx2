using Microsoft.EntityFrameworkCore;
using webClientEx2.Data;
using webClientEx2.Models;
namespace webClientEx2.Services
{
    public class RateService:IRateService
    {
        private readonly webClientEx2Context _context;
        public RateService(webClientEx2Context context)
        {
            _context = context;
        }

        public async Task<List<Rate>> GetAll()
        {
            return await _context.Rate.ToListAsync();    
        }
        public async Task<Rate> Get(int id)
        {
            if (id == null)
            {
                return null;
            }

            var rate = await _context.Rate
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rate == null)
            {
                return null;
            }
            return rate;
        }
        public async Task Edit(int id, string name, string text, int number)
        {
            Rate rate = await Get(id);
            if (text != null)
            {
                rate.Text = text;
                await _context.SaveChangesAsync();

            }
            if (name != null)
            {
                rate.Name = name;
                await _context.SaveChangesAsync();
            }
            if (number != 0)
            {
                rate.RatingNum = number;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Rate> Create(string text, string name, int number)
        {
            Rate rate = new Rate(text,name, DateTime.Now, number);
            _context.Add(rate);
            await _context.SaveChangesAsync();
            return rate;
        }
        public async Task Delete(int id)
        {
            var rate = await _context.Rate.FindAsync(id);
            _context.Rate.Remove(rate);
            await _context.SaveChangesAsync();
        }
        public async Task<ICollection<Rate>> Search(string query)
        {
            var q = from rate in _context.Rate
                    where rate.Text.Contains(query) || rate.Name.Contains(query)
                    select rate;
            return await q.ToListAsync();
        }
    }
}
