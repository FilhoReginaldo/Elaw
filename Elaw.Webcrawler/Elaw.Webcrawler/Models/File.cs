using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elaw.Webcrawler.Models;

public class File
{
    public Guid GuidExecution { get; set; }
    public string Name { get; set; } = null!;
    public string Package { get; set; } = null!;
    public Int16? LinesNumber { get; set; }
    public bool Active { get; set; }
    public DateTime CreatedAt { get; set; }
}
