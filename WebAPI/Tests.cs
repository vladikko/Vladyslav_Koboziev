namespace WebAPI
{

    public class Tests
    {
        [Test, Order(1)]
        public void CanUploadFile()
        {
            var client = new DropboxClient();
            var metadata = client.UploadFile("../../../test.txt", "/WebAPI/test.txt");

            // Ensure that the response contains the metadata for the file
            JToken nameToken, content_hashToken;
            Assert.IsTrue(metadata.TryGetValue("name", out nameToken));
            Assert.IsTrue(metadata.TryGetValue("content_hash", out content_hashToken));
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
            var metadata = client.DeleteFile("/WebAPI/test.txt");

            // Ensure that the response contains the metadata for the file
            JToken sizeToken, modifiedToken, errorToken;
            Assert.IsTrue(metadata.TryGetValue("size", out sizeToken));
            Assert.IsTrue(metadata.TryGetValue("name", out modifiedToken));
            Assert.IsFalse(metadata.TryGetValue("error", out errorToken));
        }
    }
}
