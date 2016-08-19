using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMTemplate.Models;
using MVVMTemplate.Views;

namespace MVVMTemplate.Services
{
    public class WidgetCreatorServant : IWidgetCreatorServant
    {
        private IDialogService<WidgetView> _DialogService;

        public WidgetCreatorServant(IDialogService<WidgetView> dialogService)
        {
            if (dialogService == null)
            {
                throw new ArgumentNullException("dialogService");
            }

            _DialogService = dialogService;
        }

        public IWidget CreateNewWidget()
        {
            IWidget newWidget = null;

            _DialogService.ShowDialog(() =>
                {
                    newWidget = _DialogService.CurrentView.ViewModel.CurrentWidget;
                },
                null);

            return newWidget;
        }
    }
}
