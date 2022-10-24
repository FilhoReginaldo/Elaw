using Elaw.Webcrawler.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elaw.Webcrawler.Domain.Interfaces;

public interface IExecutionRepository
{
    Task<Entities.Execution>? GetExecutionAsync(Guid? GuidExecution);
    Task<BaseResponseDTO> CreatedExecutionAsync(Domain.Entities.Execution execution);
    Task<BaseResponseDTO> UpdatedExecutionAsync(Domain.Entities.Execution execution);
    Task<BaseResponseDTO> CreatedFileExecutionAsync(Domain.Entities.File fileExecution);
}
