﻿using Microsoft.EntityFrameworkCore;
using MusicLibraryWebAPI;
using Microsoft.AspNetCore.Mvc;
using MusicLibraryWebAPI.Data;
using MusicLibraryWebAPI.Model;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicLibraryWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public SongsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<Songs>
        //              ***Completed***
        [HttpGet]
        public IEnumerable<Song> Get()
        {
            var songs = _context.Songs.ToList();
            return songs;
        }

        // GET: api/<Songs>/5
        //              ***Completed***
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var song = _context.Songs
                    .Where(s => s.Id == id).Single();
                return Ok(song);
            }
            catch (InvalidOperationException)
            {
                return NotFound($"No movie with Id = {id}");
            }
        }

        // POST api/<Songs>
        //              ***Completed***
        [HttpPost]
        public IActionResult Post([FromBody] Song song)
        {
            _context.Songs.Add(song);
            _context.SaveChanges();
            return StatusCode(201, song);
        }

        // PUT api/<Songs>/5
        //              ***Completed***
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Song songUpdate)
        {
            var song = _context.Songs
                .Where(s => s.Id == id).Single();
            song.Title = songUpdate.Title;
            song.Artist = songUpdate.Artist;
            song.Album = songUpdate.Album;
            song.ReleaseDate = songUpdate.ReleaseDate;
            song.Genre = songUpdate.Genre;
            _context.SaveChanges();
            return Ok(songUpdate);

        }

        // DELETE api/<Songs>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var songToDelete = _context.Songs
                .Where(s => s.Id == id).SingleOrDefault();
            _context.Songs.Remove(songToDelete);
            _context.SaveChanges();
            return NoContent();
        }
       
        [HttpPatch("{id}/like")]
        public IActionResult Like(int id)
        {
            var song = _context.Songs
                .Where(s => s.Id == id).SingleOrDefault();
            song.Likes++;
            _context.SaveChanges();
            return StatusCode(201, $"Your input has been recorded and the total likes have been adjusted. Likes: {song.Likes}");
        }
        
        [HttpPatch("{id}/dislike")]
        public IActionResult Dislike(int id)
        {
            var song = _context.Songs
                .Where(s => s.Id == id).SingleOrDefault();
            if (song.Likes > 0)
            {
                song.Likes--;
                _context.SaveChanges();
                return StatusCode(201, $"Your input has been recorded and the total likes have been adjusted. Likes: {song.Likes}");
            }
            else
            {
                return StatusCode(201, $"Your input was received. No change was made to the total number of likes because there were zero to start with. Likes: {song.Likes}");
            }
        }
    }
}
