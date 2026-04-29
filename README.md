Studious is a free, web-based flashcard application inspired by platforms like Quizlet. Built with Blazor Server and connected to a Microsoft Azure SQL database, it allows users to create accounts, build multiple study sets, and study their material through an interactive flip card experience — no subscription required.
Authors
Rachel Bell, Charles Myint, Paden Scharber — Middle Tennessee State University
Tech Stack

C#, Blazor Server (.NET), HTML, CSS
Bootstrap & Bootstrap Icons
Microsoft Azure SQL
Microsoft.Data.SqlClient
Blazorators LocalStorage
Visual Studio 2022, SQL Server Management Studio
GitHub

Features

User authentication — create an account, sign in, sign out
Create and manage multiple study sets
Add individual cards or bulk import via CSV or TXT file
Inline editing and deletion of cards
Delete entire study sets
Interactive flip card study mode with 3D animation
Set selection grid with subject themed icons

Known Issues

Database connection string is hardcoded — should be moved to a secure config file
Primary key was removed from FLASH_CARDS table during development — UPDATE and DELETE operations may be affected

How to Run
Clone the repo, open in Visual Studio 2022, and run the project. Requires a connection to the Azure SQL database.
