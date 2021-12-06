# DSGHappinessClient.Models

DSGHappinessClient.Models is a .Net Standard package which contains Model Classes for DSG Happiness Client

## Supported Platforms

* NET Standard 2.0

## Setup

To use, simply install nuget DSGHappinessClient.Models nuget package into your project. 

###### Models

- Application

- Header

- Transaction

- User

- VotingRequest

### Common Method

Dictionary(string,string) GetDictionary();
 

## Usage

Initialize VotingRequest Class and pass all the paramters in it

var request = new VotingRequest(
                  new User("", "", "", ""),
                  new Header(Utils.GetCurrentTimeStamp(),"", "", "", "", RequestType.RequestTransactionWithoutMicroApp),
                  new Application("", "", "", "", "", ""),
                  new Transaction("", "", "", "", "")
                );

## Exceptions

ArgumentException is implemented for all the required and conditional parameters for each class

## Dependencies:

* Newtonsoft.Json 

## License
[MIT](https://licenses.nuget.org/MIT)
