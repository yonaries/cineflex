using Domain.Entities;
using Persistence.Repositories;
using Application.Common.Exceptions;
using FluentValidation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Feature.Cinema.Commands
{
    public class CreateCinemaCommand
    {
        public Cinema Cinema { get; }

        public CreateCinemaCommand(Cinema cinema)
        {
            Cinema = cinema;
        }
    }

    public class UpdateCinemaCommand
    {
        public Cinema Cinema { get; }

        public UpdateCinemaCommand(Cinema cinema)
        {
            Cinema = cinema;
        }
    }

    public class DeleteCinemaCommand
    {
        public int Id { get; }

        public DeleteCinemaCommand(int id)
        {
            Id = id;
        }
    }
}
