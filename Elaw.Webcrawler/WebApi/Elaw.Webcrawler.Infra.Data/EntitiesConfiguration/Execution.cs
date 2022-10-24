using System;
using System.Collections.Generic;

namespace Elaw.Webcrawler.Infra.Data.EntitiesConfiguration
{
    public partial class Execution
    {
        public long Id { get; set; }
        public long IdSystem { get; set; }
        public Guid Guid { get; set; }
        public string Code { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? PagesNumber { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
