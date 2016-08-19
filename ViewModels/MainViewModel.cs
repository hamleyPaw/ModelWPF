using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using MVVMTemplate.Models;
using MVVMTemplate.Services;

namespace MVVMTemplate.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(IWidgetCreatorServant widgetCreatorServant)
            : base()
        {
            if (widgetCreatorServant == null)
            {
                throw new ArgumentNullException("widgetCreatorServant");
            }

            _WidgetCreatorServant = widgetCreatorServant;
        }

        private string _TestText = "Hello World";
        private bool _CanUpdate;

        private IWidgetCreatorServant _WidgetCreatorServant;

        private RelayCommand _CloseCommand;
        private RelayCommand _UpdateCommand;
        private RelayCommand _GetNewWidgetCommand;

        private IWidget _CurrentWidget;
        
        public string TestText
        {
            get { return _TestText; }
            set
            {
                if (_TestText != value)
                {
                    _TestText = value;
                    OnPropertyChanged(() => TestText);
                }
            }
        }

        public bool CanUpdate
        {
            get { return _CanUpdate; }
            set
            {
                _CanUpdate = value;
                OnPropertyChanged(() => CanUpdate);
            }
        }

        // Responsibilities...
        // Close (could be called from a menu option)

        public ICommand CloseCommand
        {
            get
            {
                if(_CloseCommand == null)
                {
                    // TODO What to do here?
                    //_CloseCommand = new RelayCommand(param => ShowTestMessage());
                }

                return _CloseCommand;
            }
        }

        public ICommand UpdateCommand
        {
            get
            {
                if(_UpdateCommand == null)
                {
                    _UpdateCommand = new RelayCommand(param => GetUpdateText(), param => CanUpdate);
                }

                return _UpdateCommand;
            }
        }

        public IWidget CurrentWidget
        {
            get { return _CurrentWidget; }
            set
            {
                _CurrentWidget = value;
                OnPropertyChanged(() => CurrentWidget);
            }
        }

        public ICommand GetNewWidgetCommand
        {
            get
            {
                if (_GetNewWidgetCommand == null)
                {
                    _GetNewWidgetCommand = new RelayCommand(param => CreateNewWidget());
                }

                return _GetNewWidgetCommand;
            }
        }

        private void GetUpdateText()
        {
            this.TestText = "Button Clicked";
        }

        private void CreateNewWidget()
        {
            CurrentWidget = _WidgetCreatorServant.CreateNewWidget();

            int test = -1;
            test++;
        }
    }
}

