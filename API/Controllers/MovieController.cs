using Microsoft.AspNetCore.Mvc;
using Infrastructure;
using Application.Services;
using Application.Common.Exceptions;
using Application.Common.Responses;
using Domain.Entities;

namespace API.Controllers;

[ApiController]
[Route("api/movies")]
public class MovieController : ControllerBase
{
    private readonly MovieService _movieService;

    public MovieController(MovieService MovieService)
    {
        _movieService = MovieService;
    }

    // GET api/movies/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetMovieById(int id)
    {
        Movie Movie = await _movieService.GetMovieByIdAsync(id);
        if (Movie == null)
        {
            return NotFoundException("Cinema NotFound");
        }
        return Ok(new SuccessResponse(Movie));
    }

    // GET api/movies/{movieId}
    [HttpGet("movie/{id}")]
    public async Task<IActionResult> GetMoviesById(int Id)
    {
        List<Movie> Movies = await _movieService.GetMoviesByIdAsync(Id);
        return Ok(new SuccessResponse(Movies));
    }

    // POST api/movies
    [HttpPost]
    public async Task<IActionResult> CreateMovie([FromBody] Movie newMovie)
    {
        if (newMovie == null)
        {
            return BadRequestException("BadRequest");
        }

        await _movieService.CreateNewMovieAsync(newMovie);
        return CreatedAtAction(nameof(GetMovieById), new { id = newMovie.Id }, newMovie);
    }

    // PUT api/movies/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMovie(int id, [FromBody] Movie updatedMovie)
    {
        if (updatedMovie == null || id != updatedMovie.Id)
        {
            return BadRequestException("BadRequest");
        }

        var existingMovie = await _movieService.GetMovieByIdAsync(id);
        if (existingMovie == null)
        {
            return NotFoundException("Cinema NotFound");
        }

        await _movieService.UpdateExistingMovieAsync(updatedMovie);
        return Ok(new SuccessResponse<Movie>("Movie Updated Successfuly", updatedMovie));
    }

    // DELETE api/movies/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMovie(int id)
    {
        var existingMovie = await _movieService.GetMovieByIdAsync(id);
        if (existingMovie == null)
        {
            return NotFoundException("Cinema NotFound");
        }

        await _movieService.DeleteMovieAsync(id);
        return Ok(new SuccessResponse<Movie>("Movie Deleted Successfuly", existingMovie));
    
    }
}
