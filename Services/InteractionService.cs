using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using MVVMTemplate.Views;

namespace MVVMTemplate.Services
{
    public class InteractionService : IInteractionService
    {
        private readonly Stack<Window> _WindowStack = new Stack<Window>();

        public InteractionService()
        {
            //if (parentWindow == null)
            //{
            //    throw new ArgumentNullException("parentWindow");
            //}

            //_WindowStack.Push(parentWindow);

        }

        #region IUserInterfaceContext Members

        public void ShowMessage(string title, string message, Action closeAction)
        {
            MessageBoxResult result = MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Information);

            if (result == MessageBoxResult.OK && closeAction != null)
            {
                closeAction();
            }
        }

        public void ShowMVVMTestSubView()
        {
            //var subWindow = new SubView();
            //ShowDialog(subWindow, null, true);
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

            dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            
            _WindowStack.Push(dialog);

            dialog.ShowDialog();

            if (_WindowStack.Count > 0)
            {
                _WindowStack.Peek().OpacityMask = null;
            }
        }
    }
}