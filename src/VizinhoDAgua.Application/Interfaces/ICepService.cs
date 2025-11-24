using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VizinhoDAgua.Application.Dtos;

namespace VizinhoDAgua.Application.Interfaces
{
    public interface ICepService
    {
        Task<CepResponseDto?> GetAddressByCepAsync(string cep, CancellationToken cancellationToken);
    }
}
