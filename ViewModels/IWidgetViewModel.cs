using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVMTemplate.Models;

namespace MVVMTemplate.ViewModels
{
    public interface IWidgetViewModel
    {
        IWidget CurrentWidget { get; set; }

        string WidgetName { get; set; }
        DateTime CreatedDate { get; set; }
        string Description { get; set; }
        bool IsMasterWidget { get; set; }

        ICommand OkCommand { get; }
        ICommand CancelCommand {get; }
    }
}
