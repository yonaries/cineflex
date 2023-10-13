using Microsoft.AspNetCore.Mvc;
using Application.Feature.Cinema.Commands;
using Application.Feature.Cinema.Queries;
using Application.Common.Responses;
using Application.Common.Exceptions;
using Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [Route("api/cinemas")]
    public class CinemaController : ControllerBase
    {
        private readonly CinemaCommandHandler _cinemaCommandHandler;
        private readonly CinemaQueryHandler _cinemaQueryHandler;

        public CinemaController(CinemaCommandHandler cinemaCommandHandler, CinemaQueryHandler cinemaQueryHandler)
        {
            _cinemaCommandHandler = cinemaCommandHandler;
            _cinemaQueryHandler = cinemaQueryHandler;
        }

        // GET api/cinemas
        [HttpGet]
        public async Task<IActionResult> GetAllCinemas()
        {
            var query = new GetCinemasQuery();
            List<Cinema> cinemas = await _cinemaQueryHandler.Handle(query);
            return Ok(new SuccessResponse(cinemas));
        }

        // GET api/cinemas/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCinemaById(int id)
        {
            var query = new GetCinemaByIdQuery(id);
            Cinema cinema = await _cinemaQueryHandler.Handle(query);

            if (cinema == null)
            {
                return NotFoundException("Cinema Not Found");
            }

            return Ok(new SuccessResponse(cinema));
        }

        // POST api/cinemas
        [HttpPost]
        public async Task<IActionResult> CreateCinema([FromBody] Cinema newCinema)
        {
            if (newCinema == null)
            {
                return BadRequestException("Bad Request");
            }

            var command = new CreateCinemaCommand(newCinema);
            await _cinemaCommandHandler.Handle(command);

            return CreatedAtAction(nameof(GetCinemaById), new { id = newCinema.Id }, newCinema);
        }

        // PUT api/cinemas/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCinema(int id, [FromBody] Cinema updatedCinema)
        {
            if (updatedCinema == null || id != updatedCinema.Id)
            {
                return BadRequestException("Bad Request");
            }

            var existingCinemaQuery = new GetCinemaByIdQuery(id);
            var existingCinema = await _cinemaQueryHandler.Handle(existingCinemaQuery);

            if (existingCinema == null)
            {
                return NotFoundException("Cinema Not Found");
            }

            var updateCommand = new UpdateCinemaCommand(updatedCinema);
            await _cinemaCommandHandler.Handle(updateCommand);

            return Ok(new SuccessResponse<Cinema>("Cinema Updated Successfully", updatedCinema));
        }

        // DELETE api/cinemas/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCinema(int id)
        {
            var existingCinemaQuery = new GetCinemaByIdQuery(id);
            var existingCinema = await _cinemaQueryHandler.Handle(existingCinemaQuery);

            if (existingCinema == null)
            {
                return NotFoundException("Cinema Not Found");
            }

            var deleteCommand = new DeleteCinemaCommand(id);
            await _cinemaCommandHandler.Handle(deleteCommand);

            return Ok(new SuccessResponse<Cinema>("Cinema Deleted Successfully", existingCinema));
        }
    }
}
