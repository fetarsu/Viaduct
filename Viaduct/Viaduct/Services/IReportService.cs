using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Viaduct.Models;

namespace Viaduct.Services
{
    public interface IReportService
    {
        DateTime ReportDate { get; set; }
    }
}