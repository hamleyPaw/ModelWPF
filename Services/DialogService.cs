using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMTemplate.Services
{
    public class DialogService<T> : IDialogService<T> where T : Window
    {
        // The problem with this approach is that it ties to
        // Window
        // Hence, the tests have to reference all the assemblies associated
        // in order to mock.

        private T _CurrentView;

        public T CurrentView
        {
            get { return _CurrentView; }
        }


        public void Show()
        {
            var container = ((App)Application.Current).DependencyContainer;

            container.GetInstance<T>().Show();
        }

        public void ShowDialog()
        {
            var container = ((App)Application.Current).DependencyContainer;

            var view = container.GetInstance<T>();

            _CurrentView = view;

            view.Owner = ((App) Application.Current).MainWindow;
            view.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            view.ShowDialog();
        }

        public void ShowDialog(Action actionOnOK, Action actionOnCancel)
        {
            var container = ((App)Application.Current).DependencyContainer;

            var view = container.GetInstance<T>();

            _CurrentView = view;

            view.Owner = ((App)Application.Current).MainWindow;
            view.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            var result = view.ShowDialog();

            if (result.HasValue)
            {
                if (result.Value == true && actionOnOK != null)
                {
                    actionOnOK.Invoke();
                }
                else
                {
                    if (actionOnCancel != null)
                    {
                        actionOnCancel.Invoke();
                    }
                }
            }
            else
            {
                if (actionOnCancel != null)
                {
                    actionOnCancel.Invoke();
                }
            }

            
        }
    }
}
