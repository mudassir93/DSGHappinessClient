# <img src="https://github.com/mudassir93/DSGHappinessClient/blob/main/DSGHappinessClient.Utils/icon.png" width="71" height="71"/> DSGHappinessClient.Utils

DSGHappinessClient.Utils is a .Net Standard package which contains Util class.Util class contains some helper methods.

## Supported Platforms

* NET Standard 2.0

## Setup

To use, simply install nuget DSGHappinessClient.Utils nuget package into your project. 

###### Class

Utils

## Methods

// Return URL encoded string
- static string GetEncodedString(string str)

// Return Current UTC timestamp in required format
- static string GetCurrentUtcTimeStamp()

// Convert Dictionary to JSON string
- static string GetJsonString(Dictionary(string,string) dictionary)

// Return 16 character random string
- static string GetRandomString()

// Return SHA 512 hashed string
- static string GetSHA512(string str)


## Usage

var sha512 = Utils.GetSHA512("HelloWorld!");

## Exceptions

ArgumentException is implemented for all the required and conditional parameters for each class

## Dependencies:

* Newtonsoft.Json 

## License
[MIT](https://licenses.nuget.org/MIT)
