using AutoMapper;
using Elaw.Webcrawler.Application.Products.Commands;
using Elaw.Webcrawler.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elaw.Webcrawler.Application.Mappings;

public class DTOToCommandMappingProfile: Profile
{
    public DTOToCommandMappingProfile()
    {
        CreateMap<ExecutionDTO, ExecutionCreateCommand>();
        CreateMap<ExecutionDTO, ExecutionUpdateCommand>();
        CreateMap<FileDTO, FileCreateCommand>();
    }
}
