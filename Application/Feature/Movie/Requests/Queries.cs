using Domain.Entities;
using Persistence.Repositories;
using Application.Common.Exceptions;
using FluentValidation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Feature.Movie.Requests.Queries
{
    public class GetMoviesQuery
    {
    }

    public class GetMovieByIdQuery
    {
        public int Id { get; }

        public GetMovieByIdQuery(int id)
        {
            Id = id;
        }
    }


}