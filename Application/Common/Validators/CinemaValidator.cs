using FluentValidation;
using Domain.Entities;

public class CreateCinemaValidator : AbstractValidator<Cinema>
{
    public CreateCinemaValidator()
    {
        RuleFor(cinema => cinema.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(100).WithMessage("Title cannot exceed 100 characters");

        RuleFor(cinema => cinema.Location)
            .NotEmpty().WithMessage("Location is required")

        RuleFor(cinema =cinema.Address)
            .NotEmpty().WithMessage("Address is required")

        RuleFor(cinema => .Phone)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .Matches(@"^\+?(\d{1,4}[-\s]?)?(\d{9,14})$") 
            .WithMessage("{PropertyName} is not a valid phone number.");

        RuleFor(cinema => cinema.Email)
            .NotEmpty().WithMessage("Email is required")
    }
}

public class UpdateCinemaValidator : AbstractValidator<Cinema>
{
    public UpdateCinemaValidator()
    {
        RuleFor(cinema => cinema.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(100).WithMessage("Title cannot exceed 100 characters");

        RuleFor(cinema => cinema.Location)
            .NotEmpty().WithMessage("Location is required")

        RuleFor(cinema =cinema.Address)
            .NotEmpty().WithMessage("Address is required")

        RuleFor(cinema => .Phone)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .Matches(@"^\+?(\d{1,4}[-\s]?)?(\d{9,14})$") 
            .WithMessage("{PropertyName} is not a valid phone number.");

        RuleFor(cinema => cinema.Email)
            .NotEmpty().WithMessage("Email is required")

    }
}
