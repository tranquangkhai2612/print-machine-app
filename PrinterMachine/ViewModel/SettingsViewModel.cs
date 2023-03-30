using PrinterMachine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PrinterMachine.ViewModel
{
    class SettingsViewModel : IPageViewModel
    {

        public event EventHandler<EventArgs<string>>? ViewChanged;
        public string PageId { get; set; }
        public string Title { get; set; }

        public SettingsViewModel(string pageIndex = "settings")
        {
            PageId = pageIndex;
            Title = "Settings Page";
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

        private ICommand? _goToLabel;

        public ICommand GoToLabel
        {
            get
            {
                return _goToLabel ??= new RelayCommand(x =>
                {
                    ViewChanged?.Raise(this, "label");
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

        private ICommand? _goToSettingsLanguage;

        public ICommand GoToSettingsLanguage
        {
            get
            {
                return _goToSettingsLanguage ??= new RelayCommand(x =>
                {
                    ViewChanged?.Raise(this, "settingsLanguage");
                });
            }
        }

        private ICommand? _goToSettingsAccount;

        public ICommand GoToSettingsAccount
        {
            get
            {
                return _goToSettingsAccount ??= new RelayCommand(x =>
                {
                    ViewChanged?.Raise(this, "settingsAccount");
                });
            }
        }

    }
}
