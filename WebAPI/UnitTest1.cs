namespace WebAPI
{
    public class Tests
    {
        private string ACCESS_TOKEN = "sl.BWUpFog5v1PlgQQ0SEYY50wHx5arPp6htKbd5dVeK4k9n-etlFqJ-O2piCr4c11Wj-AgDuspryd72xxjQ9SbeaeV1h9IPo9NDuxgo1Er-oBxJYPmXOsKQfdg5jVTaH_9u24QoH4";

        [Test, Order(1)]
        public void CanUploadFile()
        {
            // Set up the HTTP client and request
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://content.dropboxapi.com/2/files/upload"),
                Headers = {
                    { "Authorization", $"Bearer {ACCESS_TOKEN}" },
                    { "Dropbox-API-Arg", "{\"autorename\":false,\"mode\":\"overwrite\",\"mute\":false,\"path\":\"/WebAPI/test.txt\",\"strict_conflict\":false}" }
                },
                Content = new StreamContent(new FileStream("../../../test.txt", FileMode.Open)),
            };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            // Send the request and get the response
            var response = client.SendAsync(request).Result;

            // Ensure that the file was successfully uploaded by checking the status code
            Assert.IsTrue(response.IsSuccessStatusCode);
        }
        [Test,Order(2)]
        public void CanGetFileMetadata()
        {
            // Set up the HTTP client and request
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://api.dropboxapi.com/2/files/get_metadata"),
                Headers = {
                    { "Authorization", $"Bearer {ACCESS_TOKEN}" }
                },
                Content = new StringContent("{\"path\": \"/WebAPI/test.txt\"}", Encoding.UTF8, "application/json")
            };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Send the request and get the response
            var response = client.SendAsync(request).Result;
            var responseJson = JObject.Parse(response.Content.ReadAsStringAsync().Result);

            // Ensure that the response contains the metadata for the file
            JToken sizeToken, modifiedToken;
            Assert.IsTrue(responseJson.TryGetValue("size", out sizeToken));
            Assert.IsTrue(responseJson.TryGetValue("name", out modifiedToken));
        }
        [Test,Order(3)]
        public void CanDeleteFile()
        {
            // Set up the HTTP client and request
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://api.dropboxapi.com/2/files/delete"),
                Headers = {
                    { "Authorization", $"Bearer {ACCESS_TOKEN}" },
                },
                Content = new StringContent("{\"path\": \"/WebAPI/test.txt\"}", Encoding.UTF8, "application/json")
            };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            
            // Send the request and get the response
            var response = client.SendAsync(request).Result;

            // Ensure that the file was successfully deleted by checking the status code
            Assert.IsTrue(response.IsSuccessStatusCode);
        }
    }
}