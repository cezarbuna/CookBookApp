# CookBookApp
SEF project

Here are the instructions for downloading all the necessary programs/tools for correctly running our web application:

1.NET 

Visual Studio Community 2022: https://visualstudio.microsoft.com/vs/community/ 

In the Installer, check the following workloads before installing: 

ASP.NET and web development 

.NET desktop development 

Data storage and processing 

.NET 6 SDK x64: https://dotnet.microsoft.com/en-us/download  


SSMS: https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15   

SQL Server LocalDb 2017: https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb?view=sql-server-ver15  

2. Node 

Node: https://nodejs.org/en/download/ - Download the LTS version 

You can make sure you have installed Node correctly by opening a Powershell terminal and typing ‘node --version’ and the version number should appear as an output 

Make sure you also have npm installed by typing ‘npm --version’ 

 

3. Angular 

Angular: Type and run the command ‘npm i -g @angular/cli’ 

Make sure you have Angular Cli installed by running the command ‘ng --version’ 

4.Any text editor or IDE for the angular project

Visual Studio Code: https://code.visualstudio.com/ 

Webstorm (this was used for building our front-end) : https://www.jetbrains.com/webstorm/download/


HERE are the instructions for running our app

1.Configuring your database connection

You need log into SSMS and get your local server connection string and, after cloning our repository go into 
the CookBook.sln in the CookBook folder, open it with Visual Studio and paste your connection string in 2 different places:
  a. In the CookBookDbContext.cs file, in the OnConfiguring() method, after the "@Server=(paste your connection string here);"
  b. In the appsetting.json at ConnectionStrings, do the same as above

2.Running the web API

Open the CookBook.sln file and after opening it with visual studio, click the run play button which sits at the top of the screen, right in the middle(maybe a bit to the left)
After running it, this will open the swagger interface(a helper tool for our web API)

!!! NOTE: THE API MUST BE RUNNING FOR THE FRONT-END TO HAVE ANY FUNCTIONALITY !!! MAKE SURE IT IS RUNNING

3.Running the front-end

Open the CookBookFE project as a webstorm or visual studio code project
After opening it, navigate to the project's correct directory in the terminal and type in the
ng serve command. This command will run the project at localhost:4200(probably).
Go there and you will see our full project
