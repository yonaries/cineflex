using Domain.Entities;
using Persistence.Repositories;
using Application.Common.Exceptions;

namespace Application.Services;

public class CinemaService
{
    private readonly CinemaRepository _cinemaRepository;
    private readonly IValidator<Cinema> createCinemaValidator;
    private readonly IValidator<Cinema> updateCinemaValidator;


    public CinemaService(CinemaRepository CinemaRepository)
    {
        _cinemaRepository = CinemaRepository;
    }

    public async Task CreateNewCinemaAsync(Cinema cinema)
    {
        var validationResult = createCinemaValidator.Validate(cinema);

        if (validationResult.IsValid) 
        {
            await _cinemaRepository.CreateCinemaAsync(cinema);
        } else {
            throw new ValidationException(validationResult.Errors);
        }
        
    }

    public async Task<Cinema> GetCinemaByIdAsync(int Id)
    {
        return await _cinemaRepository.GetCinemaByIdAsync(Id);
    }

    public async Task<List<Cinema>> GetCinemasByIdAsync(int Id)
    {
        return await _cinemaRepository.GetCinemasByIdAsync(Id);
    }

    public async Task UpdateExistingCinemaAsync(Cinema cinema)
    {
        var validationResult = updateCinemaValidator.Validate(cinema);

        if (validationResult.IsValid)
        {
            await _cinemaRepository.UpdateCinemaAsync(cinema);
        } else {
            throw new ValidationException(validationResult.Errors);
        }

    }

    public async Task DeleteCinemaAsync(int Id)
    {
        await _cinemaRepository.DeleteCinemaAsync(Id);
    }
}
