using AutoMapper;
using Elaw.Webcrawler.Domain.DTOs;
using Elaw.Webcrawler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elaw.Webcrawler.Application.Mappings;

public class DomainToDTOMappingProfile: Profile
{
    public DomainToDTOMappingProfile()
    {
        //Execution
        CreateMap<Execution, ExecutionDTO>().ReverseMap();
        CreateMap<Execution, BaseResponseDTO>().ReverseMap();

        //File
        CreateMap<Domain.Entities.File, FileDTO>().ReverseMap();
        CreateMap<Domain.Entities.File, BaseResponseDTO>().ReverseMap();

    }
}
