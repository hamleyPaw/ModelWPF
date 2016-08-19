using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMTemplate.Models
{
    public class Widget : IWidget
    {
        public DateTime CreatedDate { get; set; }

        public string Description { get; set; }

        public bool IsMasterWidget { get; set; }

        public int? WidgetId { get; set; }

        public string WidgetName { get; set; }
    }
}
