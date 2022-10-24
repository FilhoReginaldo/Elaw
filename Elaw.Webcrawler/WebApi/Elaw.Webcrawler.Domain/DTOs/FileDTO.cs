using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elaw.Webcrawler.Domain.DTOs;

public class FileDTO
{
    public Guid Guid { get; set; }
    public Guid GuidExecution { get; set; }
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Package { get; set; } = null!;
    public Int16? LinesNumber { get; set; }
    public bool Active { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
