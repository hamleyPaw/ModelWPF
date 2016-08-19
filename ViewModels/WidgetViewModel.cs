using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVMTemplate.Models;

namespace MVVMTemplate.ViewModels
{
    public class WidgetViewModel : ViewModelBase, IWidgetViewModel
    {
        private IWidget _CurrenWidget = new Widget();

        public IWidget CurrentWidget
        {
            get { return _CurrenWidget; }
            set { _CurrenWidget = value; }
        }

        private RelayCommand _CancelCommand;
        private RelayCommand _OkCommand;

        public ICommand CancelCommand
        {
            get
            {
                if (_CancelCommand == null)
                {
                    _CancelCommand = new RelayCommand(param => OnRequestClose(false));
                }

                return _CancelCommand;
            }
        }

        public ICommand OkCommand
        {
            get
            {
                if (_OkCommand == null)
                {
                    _OkCommand = new RelayCommand(param => OnRequestClose(true));
                }

                return _OkCommand;
            }
        }

        public string WidgetName
        {
            get { return _CurrenWidget.WidgetName; }
            set
            {
                _CurrenWidget.WidgetName = value;
                OnPropertyChanged(() => WidgetName);
            }
        }

        public DateTime CreatedDate
        {
            get { return _CurrenWidget.CreatedDate; }
            set
            {
                _CurrenWidget.CreatedDate = value;
                OnPropertyChanged(() => CreatedDate);
            }

        }

        public string Description
        {
            get { return _CurrenWidget.Description; }
            set
            {
                _CurrenWidget.Description = value;
                OnPropertyChanged(() => Description);
            }
        }

        public bool IsMasterWidget
        {
            get { return _CurrenWidget.IsMasterWidget; }
            set
            {
                _CurrenWidget.IsMasterWidget = value;
                OnPropertyChanged(() => IsMasterWidget);
            }
        }
    }
}
