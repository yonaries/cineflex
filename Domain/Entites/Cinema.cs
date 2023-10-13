using System;
using System.Collections.Generic;
using Domain.Common;

namespace Domain.Entites;

public class Cinema : BaseDomain
{
    public string Name { get; set; }
    public string Location { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}