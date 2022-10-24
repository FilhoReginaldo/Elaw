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

public class ExecutionCreateHandler : IRequestHandler<ExecutionCreateCommand, BaseResponseDTO>
{
    private readonly IExecutionRepository _iexecutionRepository;
    public ExecutionCreateHandler(IExecutionRepository iexecutionRepository)
    {
        _iexecutionRepository = iexecutionRepository ??
        throw new ArgumentNullException(nameof(iexecutionRepository));
    }
    public async Task<BaseResponseDTO> Handle(ExecutionCreateCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponseDTO();

        try
        {
            var execution = new Domain.Entities.Execution(1, request.Guid, request.Code, request.StartDate, request.EndDate, request.PagesNumber, request.Active, request.CreatedAt, request.UpdatedAt);

            return await _iexecutionRepository.CreatedExecutionAsync(execution);

        }
        catch (Exception ex)
        {
            response.Code = "NG02-01";
            response.Success = false;
            response.Message = ex.Message;
        }

        return response;
    }
}
