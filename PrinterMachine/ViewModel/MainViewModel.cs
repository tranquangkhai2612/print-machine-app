using PrinterMachine.Core;
using PrinterMachine.Model;
using PrinterMachine.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;

namespace PrinterMachine.ViewModel
{
    public class MainViewModel : BaseViewModel
    {

        private IPageViewModel? _pageViewModel;

        private readonly Dictionary<string, IPageViewModel>? _pageViewModels = new();

        public IPageViewModel? CurrentPageViewModel
        {
            get { return _pageViewModel; }
            set
            {
                _pageViewModel = value;
                OnPropertyChanged(nameof(CurrentPageViewModel));
            }
        }

        // CLOSE BUTTON
        public static class ButtonBehavior
        {
            #region Private Section

            private static Window MainWindow = Application.Current.MainWindow;

            #endregion

            #region IsCloseProperty

            public static readonly DependencyProperty IsCloseProperty;

            public static void SetIsClose(DependencyObject DepObject, bool value)
            {
                DepObject.SetValue(IsCloseProperty, value);
            }

            public static bool GetIsClose(DependencyObject DepObject)
            {
                return (bool)DepObject.GetValue(IsCloseProperty);
            }

            static ButtonBehavior()
            {
                IsCloseProperty = DependencyProperty.RegisterAttached("IsClose",
                                                                      typeof(bool),
                                                                      typeof(ButtonBehavior),
                                                                      new UIPropertyMetadata(false, IsCloseTurn));
            }

            #endregion

            private static void IsCloseTurn(DependencyObject sender, DependencyPropertyChangedEventArgs e)
            {
                if (e.NewValue is bool && ((bool)e.NewValue) == true)
                {
                    if (MainWindow != null)
                        MainWindow.PreviewKeyDown += new KeyEventHandler(MainWindow_PreviewKeyDown);

                    var button = sender as Button;

                    if (button != null)
                        button.Click += new RoutedEventHandler(button_Click);
                }
            }

            private static void button_Click(object sender, RoutedEventArgs e)
            {
                MainWindow.Close();
            }

            private static void MainWindow_PreviewKeyDown(object sender, KeyEventArgs e)
            {
                if (e.Key == Key.Escape)
                    MainWindow.Close();
            }
        }


        public MainViewModel(IDataModel pageViews)
        {
            _pageViewModels["home"] = new HomeViewModel("home");
            _pageViewModels["home"].ViewChanged += (o, s) =>
            {
                CurrentPageViewModel = _pageViewModels[s.Value];
                pageViews.Data = "Data: " + s.Value.ToString();
            };

            _pageViewModels["label"] = new LabelViewModel("label");
            _pageViewModels["label"].ViewChanged += (o, s) =>
            {
                CurrentPageViewModel = _pageViewModels[s.Value];
                pageViews.Data = "Data: " + s.Value.ToString();
            };

            _pageViewModels["labelSettings"] = new LabelSettingsViewModel("labelSettings");
            _pageViewModels["labelSettings"].ViewChanged += (o, s) =>
            {
                CurrentPageViewModel = _pageViewModels[s.Value];
                pageViews.Data = "Data: " + s.Value.ToString();
            };

            _pageViewModels["login"] = new LoginViewModel("login");
            _pageViewModels["login"].ViewChanged += (o, s) =>
            {
                CurrentPageViewModel = _pageViewModels[s.Value];
                pageViews.Data = "Data: " + s.Value.ToString();
            };

            _pageViewModels["settings"] = new SettingsViewModel("settings");
            _pageViewModels["settings"].ViewChanged += (o, s) =>
            {
                CurrentPageViewModel = _pageViewModels[s.Value];
                pageViews.Data = "Data: " + s.Value.ToString();
            };

            _pageViewModels["settingsLanguage"] = new SettingsLanguageViewModel("settingsLanguage");
            _pageViewModels["settingsLanguage"].ViewChanged += (o, s) =>
            {
                CurrentPageViewModel = _pageViewModels[s.Value];
                pageViews.Data = "Data: " + s.Value.ToString();
            };

            _pageViewModels["settingsAccount"] = new SettingsAccountViewModel("settingsAccount");
            _pageViewModels["settingsAccount"].ViewChanged += (o, s) =>
            {
                CurrentPageViewModel = _pageViewModels[s.Value];
                pageViews.Data = "Data: " + s.Value.ToString();
            };


            CurrentPageViewModel = _pageViewModels["home"];
        }
    }
}
