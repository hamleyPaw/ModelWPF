using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace MVVMTemplate.ViewModels {
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public ViewModelBase()
        {
            
        }

        public event EventHandler<DialogCloseEventArgs> RequestClose;

        protected void OnRequestClose(bool? dialogAccepted)
        {
            var handler = this.RequestClose;

            if (handler != null)
            {
                handler(this, new DialogCloseEventArgs(dialogAccepted));
            }
        }

        #region INotifyPropertyChanged Members

        /// <summary>
        /// Raised when a property on this object has a new value.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// Use a lambda expression to ensure we get the correct name
        /// </summary>
        /// <param name="expression">A lambda expression of the propery that has a new value.</param>
        protected void OnPropertyChanged(Expression<Func<object>> expression)
        {
            if (this.PropertyChanged != null)
            {
                this.OnPropertyChanged(PropertyNameHelper.GetPropertyName(expression));
            }
        }

       

        #endregion INotifyPropertyChanged Members
    }

    public class DialogCloseEventArgs : EventArgs
    {
        private bool? _DialogAccepted;
        public bool? DialogAccepted
        {
            get
            {
                return _DialogAccepted;
            }
        }

        public DialogCloseEventArgs(bool? dialogAccepted)
        {
            _DialogAccepted = dialogAccepted;
        }
    }
}
