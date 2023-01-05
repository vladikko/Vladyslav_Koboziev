using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI
{
    public class DropboxClient
    {
        private string ACCESS_TOKEN = "sl.BWUpFog5v1PlgQQ0SEYY50wHx5arPp6htKbd5dVeK4k9n-etlFqJ-O2piCr4c11Wj-AgDuspryd72xxjQ9SbeaeV1h9IPo9NDuxgo1Er-oBxJYPmXOsKQfdg5jVTaH_9u24QoH4";
        private HttpClient _client;

        public DropboxClient()
        {
            _client = new HttpClient();
        }

        public void UploadFile(string filePath, string dropboxPath)
        {
            // Set up the HTTP request
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://content.dropboxapi.com/2/files/upload"),
                Headers = {
                    { "Authorization", $"Bearer {ACCESS_TOKEN}" },
                    { "Dropbox-API-Arg", $"{{\"autorename\":false,\"mode\":\"overwrite\",\"mute\":false,\"path\":\"{dropboxPath}\",\"strict_conflict\":false}}" }
                },
                Content = new StreamContent(new FileStream(filePath, FileMode.Open)),
            };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            // Send the request and get the response
            var response = _client.SendAsync(request).Result;

            // Ensure that the file was successfully uploaded by checking the status code
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to upload file");
            }
        }

        public JObject GetFileMetadata(string dropboxPath)
        {
            // Set up the HTTP request
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://api.dropboxapi.com/2/files/get_metadata"),
                Headers = {
                    { "Authorization", $"Bearer {ACCESS_TOKEN}" }
                },
                Content = new StringContent($"{{\"path\": \"{dropboxPath}\"}}", Encoding.UTF8, "application/json")
            };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Send the request and get the response
            var response = _client.SendAsync(request).Result;
            return JObject.Parse(response.Content.ReadAsStringAsync().Result);
        }

        public void DeleteFile(string dropboxPath)
        {
            // Set up the HTTP request
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://api.dropboxapi.com/2/files/delete"),
                Headers = {
                    { "Authorization", $"Bearer {ACCESS_TOKEN}" }
                },
                Content = new StringContent($"{{\"path\": \"{dropboxPath}\"}}", Encoding.UTF8, "application/json")
            };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            // Send the request and get the response
            var response = _client.SendAsync(request).Result;

            // Ensure that the file was successfully deleted by checking the status code
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to delete file");
            }
        }
    }
}
