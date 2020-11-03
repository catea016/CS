# MongoDB Security App

A Console application connected to a MongoDB Collection - Users, which contain some common and sensitive data as well.

## Table of Contents
* [General info](#general-info)
* [Technologies](#technologies)
* [Setup](#setup)
## General info
This project goal is to configure a MongoDB database so that it can store sensitive data securely. The MongoDB "Users" is pre-populated with some data (name, password). Name is considered common data, while password is sensitive data which needs to be secured  via 2-way encryption.
After populating and securing the database, the application gets access to the database and outputs on the screen the decrypted version of the sensitive data stored. To summarize, in this project was:
* Created a MongoDB database which contain some secured sensitive data (protected via 2-way encryption);
* Created a console application which displays the data contained in the database (both common data and the decrypted sensitive data);
* Made sure that the sensitive data can only be accessed via this application.
## Technologies
Project is created with:
* MongoDB
* MongoDB Compass
* .NET/C#
* Visual Studio 2019
## Setup
To run this project, clone it and open using Microsoft Visual Studio. Access the .json file from the project to copy the database fields and use it on your local machine. Apply your database credentials in the code to connect the application with the database.
