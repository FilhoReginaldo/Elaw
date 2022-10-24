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

public class FileCreateHandler : IRequestHandler<FileCreateCommand, BaseResponseDTO>
{
    private readonly IExecutionRepository _iexecutionRepository;
    public FileCreateHandler(IExecutionRepository iexecutionRepository)
    {
        _iexecutionRepository = iexecutionRepository ??
        throw new ArgumentNullException(nameof(iexecutionRepository));
    }
    public async Task<BaseResponseDTO> Handle(FileCreateCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponseDTO();

        try
        {
            var execution = await _iexecutionRepository.GetExecutionAsync(request.GuidExecution);
            var file = new Domain.Entities.File(execution.Id, request.Guid, request.Code, request.Name, request.Package, request.LinesNumber, request.Active, request.CreatedAt, request.UpdatedAt);

            return await _iexecutionRepository.CreatedFileExecutionAsync(file);

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
