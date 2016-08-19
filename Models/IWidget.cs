using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMTemplate.Models
{
    public interface IWidget
    {
        string WidgetName { get; set; }
        int? WidgetId { get; set; }
        DateTime CreatedDate { get; set; }
        string Description { get; set; }
        bool IsMasterWidget { get; set; }
    }
}
