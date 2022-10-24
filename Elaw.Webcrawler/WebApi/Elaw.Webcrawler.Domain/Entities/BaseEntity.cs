using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elaw.Webcrawler.Domain.Entities;

public class BaseEntity
{
    public long Id { get; protected set; }
    public Guid Guid { get; protected set; }
    public string Code { get; protected set; }
    public bool Active { get; protected set; }
    public DateTime CreatedAt { get; protected set; }
    public DateTime? UpdatedAt { get; protected set; }
}
