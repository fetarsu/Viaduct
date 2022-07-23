using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Viaduct.Models;

namespace Viaduct.Services.Data
{
    public interface IReportDataService
    {
        Task SaveReportAsync(Report item, bool newItem);

        Task<Report> ReadReportAsync(string id);

        Task<Report> GetUserByLogin(string login);

        Task DeleteUserAsync(string id);
    }
}
