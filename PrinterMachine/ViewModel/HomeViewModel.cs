using PrinterMachine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PrinterMachine.ViewModel
{
    public class HomeViewModel : IPageViewModel
    {

        public event EventHandler<EventArgs<string>>? ViewChanged;
        public string PageId { get; set; }
        public string Title { get; set; }

        public HomeViewModel(string pageIndex = "home")
        {
            PageId = pageIndex;
            Title = "Home Page";
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



    }
}
