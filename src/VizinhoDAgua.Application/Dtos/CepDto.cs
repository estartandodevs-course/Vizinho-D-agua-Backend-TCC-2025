using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VizinhoDAgua.Application.Dtos
{
    public sealed record CepResponseDto(
        string? Road,
        string? Neighborhood,
        string? City,
        string? StateCode,
        string? PostalCode
    );
}