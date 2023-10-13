using Microsoft.AspNetCore.Mvc;
using Application.Feature.Movie.Commands;
using Application.Feature.Movie.Queries;
using Application.Common.Responses;
using Application.Common.Exceptions;
using Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MovieController : ControllerBase
    {
        private readonly MovieCommandHandler _movieCommandHandler;
        private readonly MovieQueryHandler _movieQueryHandler;

        public MovieController(MovieCommandHandler movieCommandHandler, MovieQueryHandler movieQueryHandler)
        {
            _movieCommandHandler = movieCommandHandler;
            _movieQueryHandler = movieQueryHandler;
        }

        // GET api/movies/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var query = new GetMovieByIdQuery(id);
            Movie movie = await _movieQueryHandler.Handle(query);

            if (movie == null)
            {
                return NotFoundException("Movie Not Found");
            }

            return Ok(new SuccessResponse(movie));
        }

        // GET api/movies/movie/{id}
        [HttpGet("movie/{id}")]
        public async Task<IActionResult> GetMoviesById(int id)
        {
            var query = new GetMoviesByIdQuery(id);
            List<Movie> movies = await _movieQueryHandler.Handle(query);
            return Ok(new SuccessResponse(movies));
        }

        // POST api/movies
        [HttpPost]
        public async Task<IActionResult> CreateMovie([FromBody] Movie newMovie)
        {
            if (newMovie == null)
            {
                return BadRequestException("Bad Request");
            }

            var command = new CreateMovieCommand(newMovie);
            await _movieCommandHandler.Handle(command);

            return CreatedAtAction(nameof(GetMovieById), new { id = newMovie.Id }, newMovie);
        }

        // PUT api/movies/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(int id, [FromBody] Movie updatedMovie)
        {
            if (updatedMovie == null || id != updatedMovie.Id)
            {
                return BadRequestException("Bad Request");
            }

            var existingMovieQuery = new GetMovieByIdQuery(id);
            var existingMovie = await _movieQueryHandler.Handle(existingMovieQuery);

            if (existingMovie == null)
            {
                return NotFoundException("Movie Not Found");
            }

            var updateCommand = new UpdateMovieCommand(updatedMovie);
            await _movieCommandHandler.Handle(updateCommand);

            return Ok(new SuccessResponse<Movie>("Movie Updated Successfully", updatedMovie));
        }

        // DELETE api/movies/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var existingMovieQuery = new GetMovieByIdQuery(id);
            var existingMovie = await _movieQueryHandler.Handle(existingMovieQuery);

            if (existingMovie == null)
            {
                return NotFoundException("Movie Not Found");
            }

            var deleteCommand = new DeleteMovieCommand(id);
            await _movieCommandHandler.Handle(deleteCommand);

            return Ok(new SuccessResponse<Movie>("Movie Deleted Successfully", existingMovie));
        }
    }
}
