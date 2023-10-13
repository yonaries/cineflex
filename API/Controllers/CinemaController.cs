using Microsoft.AspNetCore.Mvc;
using Infrastructure;
using Application.Services;
using Application.Common.Responses;
using Application.Common.Exceptions;
using Domain.Entities;

namespace API.Controllers;

[ApiController]
[Route("api/cinemas")]
public class CinemaController : ControllerBase
{
	private readonly CinemaService _CinemaService;

    public CinemaController(CinemaService CinemaService)
    {
        _CinemaService = CinemaService;
    }

    // GET api/Cinemas
    [HttpGet]
    public async Task<IActionResult> GetAllCinemas()
    {
        List<Cinema> Cinemas = await _CinemaService.GetAllCinemasAsync();
        return Ok(new SuccessResponse(Cinemas));
    }

    // GET api/Cinemas/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCinemaById(int id)
    {
        Cinema Cinema = await _CinemaService.GetCinemaByIdAsync(id);

        return Ok(new SuccessResponse(Cinemas));
    }

    // Cinema api/Cinemas
    [HttpPost]
    public async Task<IActionResult> CreateCinema([FromBody] Cinema newCinema)
    {
        if (newCinema == null)
        {
            return BadRequestException("BadRequest");
        }

        await _CinemaService.CreateNewCinemaAsync(newCinema);
        return CreatedAtAction(nameof(GetCinemaById), new { id = newCinema.Id }, newCinema);
    }

    // PUT api/Cinemas/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCinema(int id, [FromBody] Cinema updatedCinema)
    {
        if (updatedCinema == null || id != updatedCinema.Id)
        {
            return BadRequestException("BadRequest");
        }

        var existingCinema = await _CinemaService.GetCinemaByIdAsync(id);

        if (existingCinema == null)
        {
            return NotFoundException("Cinema NotFound");
        }

        await _CinemaService.UpdateExistingCinemaAsync(updatedCinema);
        return Ok(new SuccessResponse<Cinema>("Cinema Updated Successfuly",, updatedCinema));
    }

    // DELETE api/Cinemas/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCinema(int id)
    {
        var existingCinema = await _CinemaService.GetCinemaByIdAsync(id);
        if (existingCinema == null)
        {
            return NotFoundException("Cinema NotFound");
        }

        await _CinemaService.DeleteCinemaAsync(id);
        return Ok(new SuccessResponse<Cinema>("Cinema Deleted Successfuly", existingCinema));
    }
}