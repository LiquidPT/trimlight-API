This is a test console app and library to connect to the Trimlight Edge APIs. I've done this in C# to start with as that is the language I'm most familiar with. Once I have it working and cleaned up in C#, I'll look at adapting it to other languages. It is, however, still a work in progress

# Trimlight API documentation
As of November 30, 2024 the document published by Trimlight is incorrect, particularly in how authentication works. When emailling to get your client secret and client ID, they will sent the updated doc. I don't know why they haven't published it

# Projects

## TrimlightData
This is the main project that contains all of the API data objects and repository code. 

## TrimlightTest
A test console app that reads the client ID and client secret from configuation, and then calls the `TrimlightData` library. Right now calls are hardcoded for testing purposes