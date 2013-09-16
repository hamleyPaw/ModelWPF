using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

using MVVMTemplate.ViewModel;
using MVVMTemplate.ViewModel.Contexts;

using System.IO;
using System.Xml;
using System.Runtime.Serialization;

namespace MVVMTemplate.ViewModel {
    public class MainViewModel : ViewModelBase {
        public MainViewModel(IViewModelContext context)
            : base(context) {

        }

        private bool canCreateNewWidgets = true;
        public bool CanCreateNewWidgets {
            get {
                return this.canCreateNewWidgets;
            }
            set {
                this.canCreateNewWidgets = value;
                this.OnPropertyChanged(() => this.CanCreateNewWidgets);
            }
        }

        // Responsibilities...
        // Closing the app...
        // Opening a sub-view

        private RelayCommand closeCommand;
        public ICommand CloseCommand {
            get {
                if (closeCommand == null) {
                    closeCommand = new RelayCommand(param => this.OnRequestClose());
                }

                return closeCommand;
            }
        }

        private RelayCommand getNewWidgetCommand;
        public ICommand OpenSubViewCommand {
            get {
                if (getNewWidgetCommand == null) {
                    getNewWidgetCommand = new RelayCommand(param => this.CreateNewWidget(), param => this.CanCreateNewWidgets);
                }

                return getNewWidgetCommand;
            }
        }

        private void CreateNewWidget() {
            // Create an instance of the View Model required.
            // Call a method on that to get the data we require.
            // The details of how that is done are left to the VM
            // (for instance, putting up a UI dialog, etc.)

            // All that the UserInterface Context should be asked is to show a particular view
            // and get the result.



            //this.Context.UserInterface.GetMVVMTestSubView(() => {
                this.Context.UserInterface.ShowMessage("Finished", "Done", null);
            //});

                int test = 1;
                test++;
        }
    }
}
