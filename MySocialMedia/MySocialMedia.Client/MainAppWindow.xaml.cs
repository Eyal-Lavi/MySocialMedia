using MySocialMedia.Client.Services;
using MySocialMedia.Common.DBTables.MessageDTOs;
using MySocialMedia.Common.DTOs.utlisDTOs;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Net.WebSockets;
using System.Text;
using System.Net.Http;
using System.Text.Json;
using MySocialMedia.Common.DBTables;
using System.Windows.Media;

namespace MySocialMedia.Client
{
    public partial class MainAppWindow : Window
    {
        private readonly LoginResponseDTO _userData;
        public MainAppViewModel ViewModel { get; set; }
        
        private readonly HttpClient _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:7121/api/") };
        private ClientWebSocket _clientWebSocket = new ClientWebSocket();

        private readonly ApiService _apiService = new ApiService("https://localhost:7121/api");
        
        public MainAppWindow(LoginResponseDTO userData , string username)
        {
            InitializeComponent();
            
            _userData = userData;
            ViewModel = new MainAppViewModel();
            DataContext = ViewModel;
            lvDataBinding.ItemsSource = _userData.Chats;
            
            ViewModel.CurrentUserName = username;
            userThatLogin_Username.Content = username;
            
            ConnectWebSocketWithToken(ViewModel.CurrentUserName);
        }
        private async void ConnectWebSocketWithToken(string token)
        {
            try
            {
                _clientWebSocket.Options.SetRequestHeader("Sec-WebSocket-Protocol", token);
                await _clientWebSocket.ConnectAsync(new Uri("wss://localhost:7121/ws"), CancellationToken.None);

                _ = Task.Run(() => ReceiveMessagesAsync(_clientWebSocket));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eyal -> An error occurred: {ex.Message}");
            }
        }

        private async Task ReceiveMessagesAsync(ClientWebSocket clientWebSocket)
        {
            var buffer = new byte[1024 * 4];
            while (clientWebSocket.State == WebSocketState.Open)
            {
                try
                {
                    var result = await clientWebSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                    Console.WriteLine($"WebSocket received message with length {result.Count}");

                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        await clientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
                        Console.WriteLine("WebSocket closed by server");
                    }
                    else
                    {
                        var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                        Console.WriteLine($"Received message: {message}");
                        var options = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        };
                        
                        var messageObject = JsonSerializer.Deserialize<UserMessageDTO>(message, options);
   
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            if(ViewModel.SelectedChat?.ChatId == messageObject?.SenderUserId)
                            {
                                messageObject.SendUser = new User { USER_NAME = ViewModel?.SelectedChat?.ChatName };
                                ViewModel.UserMessages.Add(messageObject);
                                ScrollMessagesToEnd();
                            }
                        });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in ReceiveMessagesAsync: {ex.Message}");
                }
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private async void ListViewContancs_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Border border && border.DataContext is ChatSummaryDTO data)
            {
                if (ViewModel.SelectedChat != null && ViewModel.SelectedChat.ChatName == data.ChatName)
                {
                    return;
                }
                ViewModel.SelectedChat = data; // עדכון הצ'אט הנבחר
                var response = await _apiService.GetMessagesAsync(_userData.AuthToken, data.ChatName);
                ViewModel.UserMessages = new ObservableCollection<UserMessageDTO>(response);
                ChatBlock.Visibility = Visibility.Visible;
                UsernameTitleChat.Content = $"@{data.ChatName}";
                EnterMessageBox.Text = String.Empty;
                ScrollMessagesToEnd();
            }
        }
        private async void ImageSend_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string userMessage = EnterMessageBox.Text;
            
            try
            {
                await _apiService.SendMessageAsync(_userData.AuthToken, new UserMessageCreationDTO
                {
                    SenderUserId = _userData.UserId,
                    ReceiverUserId = ViewModel.SelectedChat.ChatId,
                    MessageData = userMessage,
                });
                ViewModel.UserMessages.Add(new UserMessageDTO
                {
                    SendUser = new User { USER_NAME = ViewModel.CurrentUserName},
                    MessageData = userMessage,
                    MessageDate = DateTime.Now,
                    SenderUserId = _userData.UserId,
                    ReceiverUserId = ViewModel.SelectedChat.ChatId,
                });
                ScrollMessagesToEnd();
                EnterMessageBox.Text = String.Empty;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot Send the message -" + ex.Message);
            }
            if(e != null)// מכיוון שהפעלתי את הפונקציה הזאתי ממקום אחר ושלחתי null
            {
                e.Handled = true;
            }
        }
        private void LogoutButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainAppWindow_Closing(sender, e);
            OpenMainWindow();
        }
        private void OpenMainWindow()
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        private void ScrollMessagesToEnd()
        {
            if(messagesDataList.Items.Count > 0)
            {
                var border = VisualTreeHelper.GetChild(messagesDataList, 0) as Decorator;

                if (border != null)
                {
                    var scrollViewer = border.Child as ScrollViewer;

                    scrollViewer?.ScrollToEnd();
                }
            }
        }
        private async void MainAppWindow_Closing(object sender, MouseButtonEventArgs e)
        {
            if (_clientWebSocket != null && _clientWebSocket.State == WebSocketState.Open)
            {
                await _clientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", CancellationToken.None);
                _clientWebSocket.Dispose();
            }
        }

        private void ShutDownImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainAppWindow_Closing(sender, e);
            this.Close();
        }

        private void NewContactMessage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var sendMessageToNewContactWindow = new SendMsgToNewContact(_userData ,ViewModel.CurrentUserName);
            sendMessageToNewContactWindow.Show();
            this.Close();
        }

        private void EnterMessageBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                ImageSend_MouseLeftButtonDown(sender , null);
            }
        }
    }
}

public class MainAppViewModel : INotifyPropertyChanged
{
    private ObservableCollection<UserMessageDTO> _userMessages;
    private ChatSummaryDTO _selectedChat;
    private string _currentUserName;

    public ObservableCollection<UserMessageDTO> UserMessages
    {
        get { return _userMessages; }
        set
        {
            _userMessages = value;
            OnPropertyChanged();
        }
    }

    public ChatSummaryDTO SelectedChat
    {
        get { return _selectedChat; }
        set
        {
            _selectedChat = value;
            OnPropertyChanged();
        }
    }
    public string CurrentUserName
    {
        get { return _currentUserName; }
        set
        {
            _currentUserName = value;
            OnPropertyChanged();
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
