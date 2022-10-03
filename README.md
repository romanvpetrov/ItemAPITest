This is an MSTest project for an items API for a code assessment

The tests include tests for some basic CRUD operations and a few edge cases for the POST method.

### Assumptions
* The tests are based on just the information given in the coding assessment. There are other requirements and situations that were not defined so a few decisions had to be made by me to what accounts a failing scenario
* There could be many more tests written depending on the stage of testing this API is in
* One very important thing due to lack of information about this API is knowing who the end user will be, how this will be used, and whether the way this API has been implemented provide real value to them


### Questions for the code reviewer
* Who is the user of this application? What is their end goal by using this API? The answer to this will help determine many of the following questions and whether the tests are sufficient to ensure the quality of the system.
* How should the API respond when an empty sku is sent?
* How should the API respond to special characters?
* What are the character limits for each field?
* Should there be more validation on price and other fields? If so more tests could be written for that

### Instructions to run the tests
1. Clone the respository locally
2. Open the project in the latest Visual Studio
3. In the Test Explorer, click Run All Tests in View
