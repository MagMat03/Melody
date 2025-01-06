using System.Security.Claims;
using Melody.Data;
using Melody.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Melody.Controllers
{
    [Authorize]
    public class PlaylistController : Controller
    {
        private readonly ApplicationDbContext context;

        public PlaylistController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            List<Playlist> list = context.Playlists.Include(p => p.User).Where(p => p.User.Id == userId).ToList();
            return View(list);
        }
    }
}
