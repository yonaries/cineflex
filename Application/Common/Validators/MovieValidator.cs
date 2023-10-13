using FluentValidation;
using Domain.Entities;

public class CreateMovieValidator : AbstractValidator<Movie>
{
    public CreateMovieValidator()
    {
        RuleFor(movie => movie.Title)
            .NotEmpty().WithMessage("Title is required")
            .MaximumLength(100).WithMessage("Title cannot exceed 100 characters");

        RuleFor(movie => movie.Year)
            .NotEmpty().WithMessage("Release year is required")
            .InclusiveBetween(1900, DateTime.Now.Year).WithMessage("Invalid release year");
    }
}

public class UpdateMovieValidator : AbstractValidator<Movie>
{
    public UpdateMovieValidator()
    {
        RuleFor(movie => movie.Id)
            .NotEmpty().WithMessage("Movie ID is required");

        RuleFor(movie => movie.Title)
            .NotEmpty().WithMessage("Title is required")
            .MaximumLength(100).WithMessage("Title cannot exceed 100 characters");

        RuleFor(movie => movie.Year)
            .NotEmpty().WithMessage("Release year is required")
            .InclusiveBetween(1900, DateTime.Now.Year).WithMessage("Invalid release year");

    }
}
