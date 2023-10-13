using Infrastructure;
using Domain.Entities;
using Application.Common.Exceptions;

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class CinemaRepository
{
    private readonly CineFlexDbContext _dbContext;

    public CinemaRepository(CineFlexDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // CREATE operation (async)
    public async Task CreateCinemaAsync(Cinema Cinema)
    {
        _dbContext.Cinemas.Add(Cinema);
        await _dbContext.SaveChangesAsync();
    }

    // READ operations (async)
    public async Task<Cinema> GetCinemaByIdAsync(int Id)
    {
        return await _dbContext.Cinemas.FindAsync(Id);
    }

    public async Task<List<Cinema>> GetCinemasByIdAsync(int Id)
    {
        return await _dbContext.Cinemas.Where(c => c.Id == Id).ToListAsync();
    }

    // UPDATE operation (async)
    public async Task UpdateCinemaAsync(Cinema updatedCinema)
    {
        var existingCinema = await _dbContext.Cinemas.FindAsync(updatedCinema.Id);

        if (existingCinema == null)
        {
            throw new NotFoundExeption("Cinema not found");
        }

        // Update the properties of the existing Cinema
        existingCinema.Text = updatedCinema.Text;

        await _dbContext.SaveChangesAsync();
    }

    // DELETE operation (async)
    public async Task DeleteCinemaAsync(int Id)
    {
        var Cinema = await _dbContext.Cinemas.FindAsync(Id);

        if (Cinema != null)
        {
            _dbContext.Cinemas.Remove(Cinema);
            await _dbContext.SaveChangesAsync();
        }
    }
}
