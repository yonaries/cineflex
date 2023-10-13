using Domain.Entities;
using Persistence.Repositories;
using Application.Common.Exceptions;

namespace Application.Services;

public class MovieService
{
    private readonly MovieRepository _movieRepository;
    private readonly IValidator<Movie> createMovieValidator;
    private readonly IValidator<Movie> updateMovieValidator;

    public MovieService(MovieRepository MovieRepository)
    {
        _movieRepository = MovieRepository;
        this.createMovieValidator = createMovieValidator;
        this.updateMovieValidator = updateMovieValidator;
    }

    public async Task<List<Movie>> GetAllMoviesAsync()
    {
        return await _movieRepository.GetAllMoviesAsync();
    }

    public async Task<Movie> GetMovieByIdAsync(int Id)
    {
        return await _movieRepository.GetMovieByIdAsync(Id);
    }

    public async Task CreateNewMovieAsync(Movie Movie)
    {
        var validationResult = createMovieValidator.Validate(Movie);

        if (validationResult.IsValid)
        {
            await _movieRepository.CreateMovieAsync(Movie);
        } else {
            throw new ValidationException(validationResult.Errors);
        }
    }

    public async Task UpdateExistingMovieAsync(Movie Movie)
    {
        var validationResult = updateMovieValidator.Validate(Movie);
        
        if (validationResult.IsValid)
        {
            await _movieRepository.UpdateMovieAsync(Movie);
        } else {
            throw new ValidationException(validationResult.Errors);
        }

    }

    public async Task DeleteMovieAsync(int Id)
    {
        await _movieRepository.DeleteMovieAsync(Id);
    }
}

