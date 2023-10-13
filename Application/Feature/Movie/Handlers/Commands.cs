using Domain.Entities;
using Persistence.Repositories;
using Application.Common.Exceptions;
using FluentValidation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Feature.Movie.Handlers;

public class MovieCommandHandler
{
    private readonly MovieRepository _movieRepository;
    private readonly IValidator<Movie> createMovieValidator;
    private readonly IValidator<Movie> updateMovieValidator;

    public MovieCommandHandler(MovieRepository movieRepository, IValidator<Movie> createMovieValidator, IValidator<Movie> updateMovieValidator)
    {
        _movieRepository = movieRepository;
        this.createMovieValidator = createMovieValidator;
        this.updateMovieValidator = updateMovieValidator;
    }

    public async Task Handle(CreateMovieCommand command)
    {
        var validationResult = createMovieValidator.Validate(command.Movie);

        if (validationResult.IsValid)
        {
            await _movieRepository.CreateMovieAsync(command.Movie);
        }
        else
        {
            throw new ValidationException(validationResult.Errors);
        }
    }

    public async Task Handle(UpdateMovieCommand command)
    {
        var validationResult = updateMovieValidator.Validate(command.Movie);

        if (validationResult.IsValid)
        {
            await _movieRepository.UpdateMovieAsync(command.Movie);
        }
        else
        {
            throw new ValidationException(validationResult.Errors);
        }
    }

    public async Task Handle(DeleteMovieCommand command)
    {
        await _movieRepository.DeleteMovieAsync(command.Id);
    }
}