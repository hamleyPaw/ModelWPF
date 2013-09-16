using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMTemplate.ViewModel.Contexts {
    public interface IViewModelContext {
        IUserInterfaceContext UserInterface { get; }
    }
}
