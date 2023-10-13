using Domain.Entities;
using Persistence.Repositories;
using Application.Common.Exceptions;
using FluentValidation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationFeature.Movie.Requests.Commands
{
    public class CreateMovieCommand
    {
        public Movie Movie { get; }

        public CreateMovieCommand(Movie movie)
        {
            Movie = movie;
        }
    }

    public class UpdateMovieCommand
    {
        public Movie Movie { get; }

        public UpdateMovieCommand(Movie movie)
        {
            Movie = movie;
        }
    }

    public class DeleteMovieCommand
    {
        public int Id { get; }

        public DeleteMovieCommand(int id)
        {
            Id = id;
        }
    }

}
