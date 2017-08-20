using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Data.Entity;
using Vidly.Models;
using Vidly_New.Dtos;
using Vidly_New.Models;

namespace Vidly_New.Controllers.API {
    public class MoviesController: ApiController {

        ApplicationDbContext context;

        public MoviesController() {
            context = new ApplicationDbContext();
            Mapper.Initialize(cfg => {
                cfg.CreateMap<MovieDto, Movie>().ForMember(c => c.Id, opt => opt.Ignore());
                cfg.CreateMap<Movie, MovieDto>();
                cfg.CreateMap<Genre, GenreDto>();
            });
        }

        // GET api/movies
        public IEnumerable<MovieDto> GetMovies() {
            return context.Movies.
                Include(m => m.Genre).      //need: using System.Data.Entity;
                ToList().
                Select(Mapper.Map<Movie, MovieDto>);
        }

        // GET api/movies/5
        public IHttpActionResult GetMovie(int id) {
            var movie = context.Movies.SingleOrDefault(m => m.Id == id);
            if(movie == null) return NotFound();
            return Ok(Mapper.Map<Movie, MovieDto>(movie) );
        }

        // POST api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto) {
            if(!ModelState.IsValid) return BadRequest();
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            movie.DateAdded = DateTime.Now;
            movieDto.Id = movie.Id;
            context.Movies.Add(movie);
            context.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        // PUT api/movies/5
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto) {
            if(!ModelState.IsValid) return BadRequest();
            var movieInDb = context.Movies.SingleOrDefault(m => m.Id == id);
            if(movieInDb == null) return NotFound();
            movieDto.Id = movieInDb.Id;
            Mapper.Map(movieDto, movieInDb);
            context.SaveChanges();
            return Ok();

        }

        // DELETE api/movies/5
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id) {
            var movieInDb = context.Movies.SingleOrDefault(m => m.Id == id);
            if(movieInDb == null) return NotFound();
            context.Movies.Remove(movieInDb);
            context.SaveChanges();
            return Ok();
        }
    }
}