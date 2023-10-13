using System;
using System.Collections.Generic;
using Domain.Common;
namespace Domain.Entites;

public class Movie: BaseDomain
{
    public string Title { get; set; }
    public string Genre { get; set; }
    public int Year { get; set; }
}

public class MovieSearchBy
{
    public string Title { get; set; }
}
