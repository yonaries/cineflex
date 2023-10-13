using Infrastructure;
using Domain.Entities;
using Application.Common.Exceptions;

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class MovieRepository
{
    private readonly CineFlexDbContext _dbContext;

    public MovieRepository(CineFlexDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // CREATE operation (async)
    public async Task CreateMovieAsync(Movie Movie)
    {
        _dbContext.Movies.Add(Movie);
        await _dbContext.SaveChangesAsync();
    }

    // READ operations (async)
    public async Task<Movie> GetMovieByIdAsync(int Id)
    {
        return await _dbContext.Movies.FindAsync(Id);
    }

    public async Task<List<Movie>> GetMoviesByIdAsync(int Id)
    {
        return await _dbContext.Movies.Where(c => c.Id == Id).ToListAsync();
    }

    // UPDATE operation (async)
    public async Task UpdateMovieAsync(Movie updatedMovie)
    {
        var existingMovie = await _dbContext.Movies.FindAsync(updatedMovie.Id);

        if (existingMovie == null)
        {
            throw new NotFoundExeption("Movie not found");
        }

        // Update the properties of the existing Movie
        existingMovie.Text = updatedMovie.Text;

        await _dbContext.SaveChangesAsync();
    }

    // DELETE operation (async)
    public async Task DeleteMovieAsync(int Id)
    {
        var Movie = await _dbContext.Movies.FindAsync(Id);

        if (Movie != null)
        {
            _dbContext.Movies.Remove(Movie);
            await _dbContext.SaveChangesAsync();
        }
    }
}
