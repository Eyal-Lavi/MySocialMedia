using Microsoft.Win32;
using MySocialMedia.Client.Services;
using MySocialMedia.Common.DTOs.UserDTOs;
using MySocialMedia.Common.DTOs.utlisDTOs;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MySocialMedia.Client
{

    public partial class MainWindow : Window
    {
        private readonly ApiService _apiService = new ApiService("https://localhost:7121/api");
        private bool _loginPremisson = true;
        private bool _registerPremisson = true;

        public MainWindow()
        {
            InitializeComponent();
        }
        private void MainWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void CreateAccount_Click(object sender, RoutedEventArgs e)
        {
            Register.Visibility = Visibility.Visible;
            Login.Visibility = Visibility.Hidden;
        }

        private void Already_have_an_account_Click(object sender, RoutedEventArgs e)
        {
            Login.Visibility = Visibility.Visible;
            Register.Visibility = Visibility.Hidden;
        }

        private async void LogIn_Click(object sender, RoutedEventArgs e)
        {
            if (_loginPremisson == false)
            {
                return;
            }
            _loginPremisson = false;

            var loginDataReq = new UserLoginDTO
            {
                UserName = EnterUserName.Text,
                Password = EnterPassword.Text,
            };

            try
            {
                var listErrors = ValidationUiService.CheckAllParamsLogin(loginDataReq);

                if (listErrors.Count != 0)
                {
                    ErrorMessageLogin.Visibility = Visibility.Visible;
                    _loginPremisson = true;
                    return;
                }

                var loginResponse = await _apiService.LogInAsync(loginDataReq);

                if (loginResponse != null)
                {
                    _loginPremisson = true;
                    OpenMainAppWindow(loginResponse, loginDataReq.UserName);
                }
            }
            catch (Exception ex)
            {
                ErrorMessageLogin.Visibility = Visibility.Visible;
                _loginPremisson = true;
                MessageBox.Show(ex.Message);
            }
        }
        private void OpenMainAppWindow(LoginResponseDTO userData,string username)
        {
            var mainAppWindow = new MainAppWindow(userData, username);
            mainAppWindow.Show();
            this.Close(); // Close the current window
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void Confirm_reg_Click(object sender, RoutedEventArgs e)
        {
            if (_registerPremisson == false)
            {
                return;
            }
            _registerPremisson = false;
            var userCreation = new UserCreationDTO
            {
                UserName = EnterUsername_Reg.Text,
                FirstName = EnterFirstName_Reg.Text,
                LastName = EnterLastName_Reg.Text,
                Password = EnterPassword_Reg.Text,
            };

            try
            {
                var listErrors = ValidationUiService.CheckAllParamsRegister(userCreation);
                if (listErrors.Count != 0)
                {
                    _registerPremisson = true;
                    return;
                }

                var response = await _apiService.RegisterAsync(userCreation);

                if (response)
                {
                    _registerPremisson = true;
                    MessageBox.Show("Register Complete");
                }
            }
            catch (Exception ex)
            {
                _registerPremisson = true;
                MessageBox.Show(ex.Message);
            }
        }

        private void EnterUserName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(ErrorMessageLogin != null)
            {
                ErrorMessageLogin.Visibility = Visibility.Hidden;
            }
        }

        private void EnterPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ErrorMessageLogin != null)
            {
                ErrorMessageLogin.Visibility = Visibility.Hidden;
            }
        }
    }
}