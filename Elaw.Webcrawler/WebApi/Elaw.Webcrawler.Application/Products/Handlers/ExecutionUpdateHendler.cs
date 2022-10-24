using Elaw.Webcrawler.Application.Products.Commands;
using Elaw.Webcrawler.Domain.DTOs;
using Elaw.Webcrawler.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elaw.Webcrawler.Application.Products.Handlers;

public class ExecutionUpdateHendler : IRequestHandler<ExecutionUpdateCommand, BaseResponseDTO>
{
    private readonly IExecutionRepository _iexecutionRepository;
    public ExecutionUpdateHendler(IExecutionRepository iexecutionRepository)
    {
        _iexecutionRepository = iexecutionRepository ??
        throw new ArgumentNullException(nameof(iexecutionRepository));
    }
    public async Task<BaseResponseDTO> Handle(ExecutionUpdateCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponseDTO();
        var execution = await _iexecutionRepository.GetExecutionAsync(request.Guid);

        if (execution == null)
        {
            response.Code = "NG04-01";
            response.Success = false;
            response.Message = "The entity could not be found in the database.";
        }
        else
        {
            execution.Update(request.Guid ,request.EndDate, request.Active, request.UpdatedAt);
            return await _iexecutionRepository.UpdatedExecutionAsync(execution);
        }

        return response;
    }
}
