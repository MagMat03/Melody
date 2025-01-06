using Melody.Data;
using Melody.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Melody.Controllers
{
    [Authorize]
    public class SongController : Controller
    {
        private readonly ApplicationDbContext context;

        public SongController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            List<Song> allSongs = context.Songs.Include(s => s.Artist).ToList();
            return View(allSongs);
        }
    }
}
