using Elaw.Webcrawler.Domain.DTOs;
using Elaw.Webcrawler.Domain.Entities;
using Elaw.Webcrawler.Domain.Interfaces;
using Elaw.Webcrawler.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elaw.Webcrawler.Infra.Data.Repositories;

public class ExecutionRepository : IExecutionRepository
{
    private ElawDbContext _elawDbContext = null;
    public ExecutionRepository(ElawDbContext elawDbContext)
    {
        _elawDbContext = elawDbContext;
    }
    public async Task<BaseResponseDTO> CreatedExecutionAsync(Execution execution)
    {
        var response = new BaseResponseDTO();

        try
        {
            _elawDbContext.Executions.Add(execution);
            await _elawDbContext.SaveChangesAsync();

            response.Guid = execution.Guid;
            response.Code = "0";
            response.Message = "Successfully Created";
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.Code = "DB04-01";
            response.Message = ex.Message;
            response.Success = false;
        }


        return response;
    }

    public async Task<BaseResponseDTO> CreatedFileExecutionAsync(Domain.Entities.File fileExecution)
    {
        var response = new BaseResponseDTO();

        try
        {
            _elawDbContext.Files.Add(fileExecution);
            await _elawDbContext.SaveChangesAsync();

            response.Guid = fileExecution.Guid;
            response.Code = "0";
            response.Message = "Successfully Created";
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.Code = "DB04-01";
            response.Message = ex.Message;
            response.Success = false;
        }


        return response;
    }

    public async Task<Execution>? GetExecutionAsync(Guid? GuidExecution)
    {
        return await _elawDbContext.Executions.AsNoTracking().Where(p => p.Guid.Equals(GuidExecution)).FirstOrDefaultAsync();
    }

    public async Task<BaseResponseDTO> UpdatedExecutionAsync(Execution execution)
    {
        var response = new BaseResponseDTO();

        try
        {
            _elawDbContext.Executions.Update(execution);
            await _elawDbContext.SaveChangesAsync();

            response.Guid = execution.Guid;
            response.Code = "0";
            response.Message = "Successfully updated";
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.Code = "DB04-01";
            response.Message = ex.Message;
            response.Success = false;
        }


        return response;
    }

}
