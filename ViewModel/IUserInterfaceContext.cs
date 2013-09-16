using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMTemplate.ViewModel.Contexts {
    public interface IUserInterfaceContext {
        void ShowMessage(string title, string message, Action closeAction);

        void GetMVVMTestSubView();
    }
}
