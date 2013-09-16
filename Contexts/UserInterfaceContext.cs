using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

using Microsoft.Win32;

using MVVMTemplate.Views;
using MVVMTemplate.ViewModel;
using MVVMTemplate.ViewModel.Contexts;

namespace MVVMTemplate.Contexts {
    public class UserInterfaceContext : IUserInterfaceContext {
        private Stack<Window> windowStack = new Stack<Window>();

        public UserInterfaceContext(Window mainWindow) {
            this.windowStack.Push(mainWindow);
        }

        #region IUserInterfaceContext Members

        void IUserInterfaceContext.ShowMessage(string title, string message, Action closeAction) {
            var result = MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Information);

            if (result == MessageBoxResult.OK && closeAction != null) {
                closeAction();
            }
        }

        void IUserInterfaceContext.GetMVVMTestSubView() {
            var subWindow = new SubView();
            this.ShowDialog(subWindow, null, true);
        }

        #endregion

        private void ShowDialog(Window dialog, Action<bool> onClosed, bool subDialog = false) {
            dialog.Closed += (sender, args) => {
                windowStack.Pop();

                if (onClosed != null) {
                    onClosed(dialog.DialogResult ?? false);
                }
            };

            if (subDialog && windowStack.Count > 0) {
                dialog.Owner = windowStack.Peek();
                dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;

                var mask = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.White);
                mask.Opacity = 0.5;

                windowStack.Peek().OpacityMask = mask;
            }

            windowStack.Push(dialog);

            dialog.ShowDialog();

            if (windowStack.Count > 0) {
                windowStack.Peek().OpacityMask = null;
            }
        }
    }
}
