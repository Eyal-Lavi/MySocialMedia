using MySocialMedia.Common.DBTables.MessageDTOs;
using MySocialMedia.Common.DTOs.UserDTOs;
using MySocialMedia.Common.DTOs.utlisDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace MySocialMedia.Client.Services
{
    public class ApiService
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly string _apiURL = "https://localhost:7121/api";

        public ApiService(string apiURL)
        {
            _apiURL = apiURL;
        }
        public async Task<LoginResponseDTO> LogInAsync(UserLoginDTO loginDataToSend)
        {
            string json = JsonSerializer.Serialize(loginDataToSend);

            var content = new StringContent(json, Encoding.UTF8 , "application/json");
            
            HttpResponseMessage response = await client.PostAsync($"{_apiURL}/users/login", content);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true 
                };

                return JsonSerializer.Deserialize<LoginResponseDTO>(responseBody, options);
            }
            else
            {
                string errorResponse = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error: {response.StatusCode}, Details: {errorResponse}");
            }
        }
        public async Task<bool> RegisterAsync(UserCreationDTO userCreation)
        {
            string json = JsonSerializer.Serialize(userCreation);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync($"{_apiURL}/users/register", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                string errorResponse = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error: {response.StatusCode}, Details: {errorResponse}");
            }
        }
        public async Task<List<UserMessageDTO>> GetMessagesAsync(string token , string targetUser)
        {
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.GetAsync($"{_apiURL}/messages/allMessages?targetUser={targetUser}");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                return JsonSerializer.Deserialize<List<UserMessageDTO>>(responseBody, options);
            }
            else
            {
                string errorResponse = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error: {response.StatusCode}, Details: {errorResponse}");
            }
        }
        public async Task SendMessageAsync(string token, UserMessageCreationDTO messageCreationDTO)
        {
            string json = JsonSerializer.Serialize(messageCreationDTO);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync($"{_apiURL}/messages/send" , content);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
            }
            else
            {
                string errorResponse = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error: {response.StatusCode}, Details: {errorResponse}");
            }
        }
    }
}
