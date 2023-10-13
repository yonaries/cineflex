using Domain.Entities;
using Persistence.Repositories;
using Application.Common.Exceptions;
using FluentValidation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Feature.Movie.Handlers;
public class MovieQueryHandler
{
    private readonly MovieRepository _movieRepository;

    public MovieQueryHandler(MovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task<List<Movie>> Handle(GetMoviesQuery query)
    {
        return await _movieRepository.GetAllMoviesAsync();
    }

    public async Task<Movie> Handle(GetMovieByIdQuery query)
    {
        return await _movieRepository.GetMovieByIdAsync(query.Id);
    }
}