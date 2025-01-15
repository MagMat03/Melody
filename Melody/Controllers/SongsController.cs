using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Melody.Data;
using Melody.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Melody.Controllers
{
    [Authorize]
    public class SongsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SongsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Songs
        public async Task<IActionResult> Index()
        {
            var user = GetUser();
            ViewBag.IsArtist = user.IsArtist;
            ViewBag.ArtistSongs = _context.Songs.Include(s => s.Artist).Where(s => s.Artist == user).ToList();
            return View(await _context.Songs.Include(s => s.Artist).ToListAsync());
        }

        // GET: Songs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _context.Songs
                .FirstOrDefaultAsync(m => m.SongID == id);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

        // GET: Songs/Create
        public IActionResult Create()
        {
            var user = GetUser();
            if (user == null || !user.IsArtist)
            {
                return Forbid();
            }

            return View();
        }

        // POST: Songs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SongViewModel songModel)
        {
            var user = GetUser();
            if (user == null || !user.IsArtist)
            {
                return Forbid();
            }


            if (ModelState.IsValid)
            {
                var song = new Song
                {
                    Artist = user,
                    Title = songModel.Title,
                };
                _context.Add(song);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(songModel);
        }

        // GET: Songs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var user = GetUser();
            if (user == null || !user.IsArtist)
            {
                return Forbid();
            }

            if (id == null)
            {
                return NotFound();
            }

            var song = await _context.Songs.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }

            if (song.Artist != user)
            {
                return Forbid();
            }

            return View(song);
        }

        // POST: Songs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SongEditViewModel songModel)
        {
            var user = GetUser();
            if (user == null || !user.IsArtist)
            {
                return Forbid();
            }

            var song = _context.Songs.Include(s => s.Artist).FirstOrDefault(s => s.SongID == id);
            if (song == null)
            {
                return NotFound();
            }

            if(song.Artist != user)
            {
                return Forbid();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    song.Title = songModel.Title;
                    _context.Update(song);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SongExists(song.SongID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(song);
        }

        // GET: Songs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var user = GetUser();
            if (user == null || !user.IsArtist)
            {
                return Forbid();
            }

            if (id == null)
            {
                return NotFound();
            }

            var song = await _context.Songs
                .FirstOrDefaultAsync(m => m.SongID == id);
            if (song == null)
            {
                return NotFound();
            }

            if (song.Artist != user)
            {
                return Forbid();
            }

            return View(song);
        }

        // POST: Songs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = GetUser();
            if (user == null || !user.IsArtist)
            {
                return Forbid();
            }

            var song = _context.Songs.Include(s => s.Playlists).FirstOrDefault(s => s.SongID == id);

            if (song == null)
            {
                return NotFound();
            }

            if (song.Artist != user)
            {
                return Forbid();
            }

            if (song != null)
            {
                song.Playlists.Clear();
                _context.Songs.Update(song);
                _context.Songs.Remove(song);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult AddToPlaylist(int songId)
        {
            var song = _context.Songs.FirstOrDefault(s => s.SongID == songId);
            if(song == null)
            {
                return NotFound();
            }

            var user = GetUser();
            var playlist = _context.Playlists.Include(p => p.User).Include(p => p.Songs).FirstOrDefault(p => p.User == user);
            if (playlist == null)
            {
                playlist = new Playlist
                {
                    Title = "Default",
                    User = user
                };
                _context.Playlists.Add(playlist);
                _context.SaveChanges();
            }
            if(!playlist.Songs.Exists(p => p.SongID == songId))
            {
                playlist.Songs.Add(song);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        private bool SongExists(int id)
        {
            return _context.Songs.Any(e => e.SongID == id);
        }

        private AppUser? GetUser()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return _context.Users.FirstOrDefault(u => u.Id == userId);
        }
    }
}
