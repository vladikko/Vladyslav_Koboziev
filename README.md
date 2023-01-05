# Tests for Dropbox API Client

This repository contains tests for a Dropbox API client. The tests are written using the [NUnit](https://nunit.org/) framework.

## Prerequisites

- [.NET Core](https://dotnet.microsoft.com/download)
- [NUnit Test Adapter](https://marketplace.visualstudio.com/items?itemName=NUnitDevelopers.NUnit3TestAdapter) (if running the tests from Visual Studio)

## Running the tests

To run the tests from the command line, follow these steps:

1. Navigate to the root directory of the repository.
2. Run the following command:

```
dotnet test
```


To run the tests from Visual Studio, follow these steps:

1. Open the solution in Visual Studio.
2. In the Test Explorer window, click "Run All".

## Additional notes

Make sure to set the `ACCESS_TOKEN` field in the `DropboxClient` class to a valid Dropbox API access token before running the tests. You can obtain an access token by [creating a Dropbox API app](https://www.dropbox.com/developers/apps/create) and following the steps in the "Generate an access token" section of the [Dropbox API documentation](https://www.dropbox.com/developers/documentation/http/overview).

The tests assume that a file named "test.txt" exists in the root directory of the repository. The tests will perform actions on this file, including uploading and deleting it.
