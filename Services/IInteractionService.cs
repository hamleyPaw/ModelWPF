using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMTemplate.Services {
    public interface IInteractionService {
        void ShowMessage(string title, string message, Action closeAction);

        void ShowMVVMTestSubView();
    }
}
