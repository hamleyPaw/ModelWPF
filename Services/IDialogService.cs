using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMTemplate.Services
{
    public interface IDialogService<T>
    {
        T CurrentView { get; }

        void Show();
        void ShowDialog();

        void ShowDialog(Action actionOnClose, Action actionOnCancel);
    }
}
