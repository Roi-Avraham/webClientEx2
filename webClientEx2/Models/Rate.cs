using System.ComponentModel.DataAnnotations;
namespace webClientEx2.Models
{
    public class Rate
    {
        public string Text { get; set; }

        [Required]
        public string Name { get; set; }
        public int Id { get; set; }
        public DateTime Date { get; set; }

        [Required]
        [Range (1,5)]
        public int RatingNum { get; set; }
    }
}
