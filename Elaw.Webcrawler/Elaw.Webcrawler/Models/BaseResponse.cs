using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elaw.Webcrawler.Models;

public class BaseResponse
{
    public Guid? Guid { get; set; }
    public string Code { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; }
}
