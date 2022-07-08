using Microsoft.Azure.Mobile.Server;

namespace WebApplication1.DataObjects
{
    public class TodoItem : EntityData
    {
        public string Text { get; set; }

        public bool Complete { get; set; }
    }
}