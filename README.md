# WebUI

This test suite contains tests for adding and deleting job titles in a web application using Selenium and ChromeDriver.
## Prerequisites

* Selenium.WebDriver NuGet package
* ChromeDriver

## Running the Tests

* Open the solution in Visual Studio and build the project to restore any NuGet packages.
* Run the tests either through Visual Studio or by using the ```dotnet test``` command in the terminal.

## Test Cases

1. Add new job: This test case navigates to the Job Titles page under the Admin section, clicks on the Add button, and adds a new job title with a job description and a note. The changes are then saved.

2. Check changes on Job Titles page: This test case verifies that the newly added job title is visible on the Job Titles page.

3. Delete job: This test case selects the newly added job title and clicks the Delete Selected button to delete it. The test then verifies that the job has been removed from the Job Titles page.