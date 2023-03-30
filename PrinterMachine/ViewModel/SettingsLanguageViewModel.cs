using PrinterMachine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PrinterMachine.ViewModel
{
    class SettingsLanguageViewModel : IPageViewModel
    {

        public event EventHandler<EventArgs<string>>? ViewChanged;
        public string PageId { get; set; }
        public string Title { get; set; }

        public SettingsLanguageViewModel(string pageIndex = "settingsLanguage")
        {
            PageId = pageIndex;
            Title = "Settings Language Page";
        }

        private ICommand? _goToLabel;
        private ICommand? _goToHome;
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
