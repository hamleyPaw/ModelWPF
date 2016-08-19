using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MVVMTemplate.ViewModels;

namespace MVVMTemplate.Views {
    public partial class WidgetView : Window
    {
        private WidgetViewModel _ViewModel;

        public WidgetView(WidgetViewModel viewModel)
        {
            InitializeComponent();
            _ViewModel = viewModel;
            base.DataContext = viewModel;

            viewModel.RequestClose += (obj, args) =>
            {
                this.DialogResult = args.DialogAccepted;
                this.Close();
            };

            //EventHandler<DialogCloseEventArgs> handler = null;
            //handler = delegate
            //{
            //    viewModel.RequestClose -= handler;
            //    this.DialogResult = 
            //    this.Close();
            //};
            //viewModel.RequestClose += handler;
        }

        public WidgetViewModel ViewModel
        {
            get { return _ViewModel; }
        }
    }
}
