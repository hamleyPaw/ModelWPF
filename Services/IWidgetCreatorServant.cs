using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVVMTemplate.Models;

namespace MVVMTemplate.Services
{
    public interface IWidgetCreatorServant
    {
        IWidget CreateNewWidget();
    }
}
