using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI
{
    public class DropboxClient
    {
        private string ACCESS_TOKEN = "sl.BWj5-MwImjrmf-Bl0shGOjfrptxyUOOMlzWRJEpcbDk0KA4n1rxZ0luaZUv5tpJq3rT6Q5I6BKxqaLQSgBtPoguXbmcmNoflAqF5tcPUh7FQ9gwqocIDYe_aJ1gFFQAUX8qRjxg";
        private HttpClient _client;

        public DropboxClient()
        {
            _client = new HttpClient();
        }

        public JObject UploadFile(string filePath, string dropboxPath)
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
            return JObject.Parse(response.Content.ReadAsStringAsync().Result);
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

        public JObject DeleteFile(string dropboxPath)
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
            return JObject.Parse(response.Content.ReadAsStringAsync().Result);
        }
    }
}
