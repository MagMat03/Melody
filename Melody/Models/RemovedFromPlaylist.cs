using System.ComponentModel.DataAnnotations;

namespace Melody.Models
{
    public class RemovedFromPlaylist
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int SongId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        public DateTime DateRemoved { get; set; } = DateTime.Now;
    }
}
