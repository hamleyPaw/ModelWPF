using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

using MVVMTemplate.ViewModel.Contexts;

namespace MVVMTemplate.Contexts {
    public class ViewModelContext : IViewModelContext {
        public ViewModelContext(Window mainWindow) {
            this.userInterface = new UserInterfaceContext(mainWindow);
        }

        private IUserInterfaceContext userInterface;
        public IUserInterfaceContext UserInterface {
            get { return userInterface; }
        }
    }
}
