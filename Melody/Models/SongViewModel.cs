using System.ComponentModel.DataAnnotations;

namespace Melody.Models
{
    public class SongViewModel
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
    }
}
