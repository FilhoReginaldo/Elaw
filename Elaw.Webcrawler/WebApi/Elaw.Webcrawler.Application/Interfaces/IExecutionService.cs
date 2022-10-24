using Elaw.Webcrawler.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elaw.Webcrawler.Application.Interfaces;

public interface IExecutionService
{
    Task<BaseResponseDTO> CreatedExecutionAsync(ExecutionDTO execution);
    Task<BaseResponseDTO> UpdatedExecutionAsync(ExecutionDTO execution);
    Task<BaseResponseDTO> CreatedFileExecutionAsync(FileDTO fileExecution);
}
