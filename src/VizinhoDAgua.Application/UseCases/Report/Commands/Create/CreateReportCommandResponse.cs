using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VizinhoDAgua.Application.UseCases.Report.Commands.Create
{
    public class CreateReportCommandResponse
    {
        public Guid Id { get; private set; }

        public CreateReportCommandResponse(Guid id)
        {
            Id = id;
        }
    }
}
