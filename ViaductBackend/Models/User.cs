using Microsoft.AspNetCore.Datasync.EFCore;

namespace ViaductBackend.Models
{
    public class User : EntityTableData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Permission { get; set; }
    }
}
