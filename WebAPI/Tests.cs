namespace WebAPI
{

    public class Tests
    {
        [Test, Order(1)]
        public void CanUploadFile()
        {
            var client = new DropboxClient();
            client.UploadFile("../../../test.txt", "/WebAPI/test.txt");
        }

        [Test, Order(2)]
        public void CanGetFileMetadata()
        {
            var client = new DropboxClient();
            var metadata = client.GetFileMetadata("/WebAPI/test.txt");

            // Ensure that the response contains the metadata for the file
            JToken sizeToken, modifiedToken;
            Assert.IsTrue(metadata.TryGetValue("size", out sizeToken));
            Assert.IsTrue(metadata.TryGetValue("name", out modifiedToken));
        }

        [Test, Order(3)]
        public void CanDeleteFile()
        {
            var client = new DropboxClient();
            client.DeleteFile("/WebAPI/test.txt");
        }
    }
}
