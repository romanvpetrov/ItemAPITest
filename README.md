This is an MSTest project for an items API for a code assessment

The tests include tests for some basic CRUD operations and a few edge cases for the POST method.

### Assumptions
* The tests are based on just the information given in the coding assessment. There are other requirements and situations that were not defined so a few decisions had to be made by me to what accounts a failing scenario
* There could be many more tests written depending on the stage of testing this API is in


### Questions for the code reviewer
* How should the API respond when an empty sku is sent?
* How should the API respond to special characters?
* What are the character limits for each field?
* Should there be more validation on price and other fields? If so more tests could be written for that

### Instructions to run the tests
1. Clone the respository locally
2. Open the project in the latest Visual Studio
3. In the Test Explorer, click Run All Tests in View
