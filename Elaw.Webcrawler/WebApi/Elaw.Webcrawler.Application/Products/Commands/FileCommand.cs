﻿using Elaw.Webcrawler.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elaw.Webcrawler.Application.Products.Commands;

public class FileCommand: FileDTO, IRequest<BaseResponseDTO>
{
}
