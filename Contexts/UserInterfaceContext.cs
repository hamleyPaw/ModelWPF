using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using MVVMTemplate.ViewModels.Contexts;
using MVVMTemplate.Views;

namespace MVVMTemplate.Contexts
{
    public class UserInterfaceContext : IUserInterfaceContext
    {
        private readonly Stack<Window> _WindowStack = new Stack<Window>();

        public UserInterfaceContext(Window mainWindow)
        {
            _WindowStack.Push(mainWindow);
        }

        #region IUserInterfaceContext Members

        void IUserInterfaceContext.ShowMessage(string title, string message, Action closeAction)
        {
            MessageBoxResult result = MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Information);

            if (result == MessageBoxResult.OK && closeAction != null)
            {
                closeAction();
            }
        }

        void IUserInterfaceContext.GetMVVMTestSubView()
        {
            var subWindow = new SubView();
            ShowDialog(subWindow, null, true);
        }

        #endregion

        private void ShowDialog(Window dialog, Action<bool> onClosed, bool subDialog)
        {
            dialog.Closed += (sender, args) =>
            {
                _WindowStack.Pop();

                if (onClosed != null)
                {
                    onClosed(dialog.DialogResult ?? false);
                }
            };

            if (subDialog && _WindowStack.Count > 0)
            {
                dialog.Owner = _WindowStack.Peek();
                dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;

                var mask = new SolidColorBrush(Colors.White);
                mask.Opacity = 0.5;

                _WindowStack.Peek().OpacityMask = mask;
            }

            _WindowStack.Push(dialog);

            dialog.ShowDialog();

            if (_WindowStack.Count > 0)
            {
                _WindowStack.Peek().OpacityMask = null;
            }
        }
    }
}