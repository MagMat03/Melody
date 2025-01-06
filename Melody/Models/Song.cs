using System.ComponentModel.DataAnnotations;

namespace Melody.Models
{
    public class Song
    {
        [Key]
        public int SongID { get; set; }

        [Required] 
        [StringLength(100)] 
        public string Title { get; set; }

        [Required]
        public AppUser Artist { get; set; }

        public List<Playlist> Playlists { get; set; } = new List<Playlist>();
    }
}
