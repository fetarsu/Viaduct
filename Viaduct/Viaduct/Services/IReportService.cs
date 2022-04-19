using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Viaduct.Models;

namespace Viaduct.Services
{
    public interface IReportService
    {
        Task<IEnumerable<Report>> GetAllReports();
        Task<IEnumerable<Report>> GetReport(DateTime date);
        Task<Report> UpdateReport(Report report);
        Task<Report> AddReport(Report report);
    }
}