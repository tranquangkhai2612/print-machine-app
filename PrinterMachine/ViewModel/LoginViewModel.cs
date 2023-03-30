using PrinterMachine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PrinterMachine.ViewModel
{
    class LoginViewModel : IPageViewModel
    {

        public event EventHandler<EventArgs<string>>? ViewChanged;
        public string PageId { get; set; }
        public string Title { get; set; }

        public LoginViewModel(string pageIndex = "login")
        {
            PageId = pageIndex;
            Title = "Login Page";
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

    }
}
