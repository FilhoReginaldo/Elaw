using System;
using System.Collections.Generic;

namespace Elaw.Webcrawler.Infra.Data.EntitiesConfiguration
{
    public partial class File
    {
        public long Id { get; set; }
        public long IdExecution { get; set; }
        public Guid Guid { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Package { get; set; } = null!;
        public int? LinesNumber { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
