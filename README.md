
# Lab9_LINQ Readme
## Summary
This project is a C# program that utilizes LINQ (Language-Integrated Query) to work with location data stored in a JSON file. The program reads the JSON file, deserializes it into C# objects, and performs various LINQ queries to analyze the data and provide useful information about locations, neighborhoods, and their appearances in the dataset.

Visuals
As this is a console application, there are no graphical visuals to display. However, the program outputs the results of different LINQ queries to the console, allowing the user to see the analysis performed on the location data.

How to Use
First, ensure you have a valid JSON file containing location data in the specified format (see the FeatureCollection, Location, Geometry, and Properties classes in the code).

Open the C# project in your preferred IDE (e.g., Visual Studio) and compile the code.

Run the compiled application, and it will start processing the location data.

The program will provide the following outputs:

a. Part 1: Count the appearances of each neighborhood and display the results.

b. Part 2: Display the names of all non-empty neighborhoods.

c. Part 3: Display the names of all distinct neighborhoods.

d. Part 4: Display the names of all distinct neighborhoods (alternative method).

e. Part 5: Execute various LINQ queries to demonstrate different ways of obtaining neighborhood data.

Relevant Details
The program uses the System.Text.Json namespace for JSON serialization and deserialization.
The JSON file path is hardcoded in the Main method. Ensure that the file exists in the specified location or modify the path accordingly.
The program defines several LINQ queries in separate methods to demonstrate different querying techniques.
