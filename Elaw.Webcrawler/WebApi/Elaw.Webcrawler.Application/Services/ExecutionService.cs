using AutoMapper;
using Elaw.Webcrawler.Application.Interfaces;
using Elaw.Webcrawler.Application.Products.Commands;
using Elaw.Webcrawler.Domain.DTOs;
using Elaw.Webcrawler.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elaw.Webcrawler.Application.Services;

public class ExecutionService : IExecutionService
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ExecutionService(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    public async Task<BaseResponseDTO> CreatedExecutionAsync(ExecutionDTO execution)
    {
        var executionCommand = _mapper.Map<ExecutionCreateCommand>(execution);
        return await _mediator.Send(executionCommand);
    }

    public async Task<BaseResponseDTO> CreatedFileExecutionAsync(FileDTO fileExecution)
    {
        var fileExecutionCommand = _mapper.Map<FileCreateCommand>(fileExecution);
        return await _mediator.Send(fileExecutionCommand);
    }

    public async Task<BaseResponseDTO> UpdatedExecutionAsync(ExecutionDTO execution)
    {
        var executionCommand = _mapper.Map<ExecutionUpdateCommand>(execution);
        return await _mediator.Send(executionCommand);
    }
}
