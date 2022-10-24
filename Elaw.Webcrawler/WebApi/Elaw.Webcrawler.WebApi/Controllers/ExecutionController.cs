using Elaw.Webcrawler.Application.Interfaces;
using Elaw.Webcrawler.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Elaw.Webcrawler.WebApi.Controllers;

[Route("[controller]")]
public class ExecutionController : ControllerBase
{
    private readonly IExecutionService _iexecutionService;
    public ExecutionController(IExecutionService iexecutionService)
    {
        _iexecutionService = iexecutionService;
    }

    /// <summary>
    /// alert : Para inserir uma execução no sistema
    /// </summary>
    /// <returns>Retorna sucesso ou falha</returns>
    [HttpPost]
    public async Task<BaseResponseDTO> Post([FromBody] ExecutionDTO execution)
    {
        return await _iexecutionService.CreatedExecutionAsync(execution);

    }

    /// <summary>
    /// alert : Para atualizar um alerta no sistema
    /// </summary>
    /// <returns>Retorna sucesso ou falha</returns>
    [HttpPut]
    public async Task<BaseResponseDTO> Put([FromBody] ExecutionDTO execution)
    {
        return await _iexecutionService.UpdatedExecutionAsync(execution);

    }


    /// <summary>
    /// alert : Para inserir um arquivo no sistema
    /// </summary>
    /// <returns>Retorna sucesso ou falha</returns>
    [HttpPost]
    [Route("File")]
    public async Task<BaseResponseDTO> Post([FromBody] FileDTO file)
    {
        return await _iexecutionService.CreatedFileExecutionAsync(file);

    }
}
