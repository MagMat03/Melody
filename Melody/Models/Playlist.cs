using System.ComponentModel.DataAnnotations;

namespace Melody.Models
{
    public class Playlist
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public AppUser User { get; set; }

        public List<Song> Songs { get; set; } = new List<Song>();
    }
}
