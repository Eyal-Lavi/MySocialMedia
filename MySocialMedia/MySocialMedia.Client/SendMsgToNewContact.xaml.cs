using MySocialMedia.Client.Services;
using MySocialMedia.Common.DBTables.MessageDTOs;
using MySocialMedia.Common.DBTables;
using MySocialMedia.Common.DTOs.utlisDTOs;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MySocialMedia.Client
{
    /// <summary>
    /// Interaction logic for SendMsgToNewContact.xaml
    /// </summary>
    public partial class SendMsgToNewContact : Window
    {
        private readonly LoginResponseDTO _loginData;
        private readonly string _username;
        private readonly ApiService _apiService = new ApiService("https://localhost:7121/api");

        public SendMsgToNewContact(LoginResponseDTO loginData,string username)
        {
            InitializeComponent();
            _loginData = loginData;
            _username = username;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void SendNewMsgWin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void EnterTo_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void EnterMessage_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private async void Send_Click(object sender, RoutedEventArgs e)
        {
            string userTarget = ToInput.Text;
            string userMessage = MessageInput.Text;
            
            //validation
            //sending
            try
            {
                var targetUserId = await GetUserId(userTarget);

                await _apiService.SendMessageAsync(_loginData.AuthToken, new UserMessageCreationDTO
                {
                    SenderUserId = _loginData.UserId,
                    ReceiverUserId = targetUserId,
                    MessageData = userMessage,
                });
                var userWindow = new MainAppWindow(_loginData, _username);
                userWindow.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public async Task<int> GetUserId(string username)// not implement
        {
            if(System.String.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentNullException($"username: {username} .");
            }
            return await _apiService.GetUserIdByUsername(username);
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            var userWindow = new MainAppWindow(_loginData, _username);
            userWindow.Show();
            this.Close();
        }
    }
}
