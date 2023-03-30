using PrinterMachine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PrinterMachine.ViewModel
{
    public class LabelViewModel : IPageViewModel
    {
        public event EventHandler<EventArgs<string>>? ViewChanged;
        public string PageId { get; set; }
        public string Title { get; set; }

        public LabelViewModel(string pageIndex = "label")
        {
            PageId = pageIndex;
            Title = "Label Page";
        }

        private ICommand? _goToHome;
        public ICommand GoToHome
        {
            get
            {
                return _goToHome ??= new RelayCommand(x =>
                {
                    ViewChanged?.Raise(this, "home");
                });
            }
        }

        private ICommand? _goToLabelSettings;
        public ICommand GoToLabelSettings
        {
            get
            {
                return _goToLabelSettings ??= new RelayCommand(x =>
                {
                    ViewChanged?.Raise(this, "labelSettings");
                });
            }
        }

        private ICommand? _goToSettings;
        public ICommand GoToSettings
        {
            get
            {
                return _goToSettings ??= new RelayCommand(x =>
                {
                    ViewChanged?.Raise(this, "settings");
                });
            }
        }


        private ICommand? _goToLogin;
        public ICommand GoToLogin
        {
            get
            {
                return _goToLogin ??= new RelayCommand(x =>
                {
                    ViewChanged?.Raise(this, "login");
                });
            }
        }
    }
}
