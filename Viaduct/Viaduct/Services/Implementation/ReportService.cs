using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Viaduct.Models;

namespace Viaduct.Services.Implementation
{
    public class ReportService : IReportService
    {
        public DateTime ReportDate { get; set; }
    }
}