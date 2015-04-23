# VolunteerWebApp
Mvc ASP.NET Technical Assessment Project

In 2015 I was asked to complete the following technical assessment in 1 hour, this repo is my solution to that assessment.

Instructions:

The Organization needs an online directory that will store volunteers and their contact information. 
We are non-profit organization and need to be able to quickly find available volunteers to help in our cause.
A volunteer's profile will have a First Name, Last Name, Home Phone Number, Cell Phone Number, Home Address and we need to know their availability (Start Date and End Date).

Please implement the following functionalities using a basic Mvc ASP.NET application:
* Can create a volunteer
* Can delete a volunteer
* Can edit existing volunteer's information
* Can view existing volunteer's detailed information
* Can search the directory for a volunteer by First Name, Last Name and/or availability

Do not worry too much about the styling. Use the Entity Framework to create the database, run

    Install-Package EntityFramework 
  
to install the NuGet package in the Package Manager Console of your project.

Use the following connection string:

    <connectionStrings>
      <add name="VolunteerApp" connectionString="Data Source=(LocalDb)\v11.0;Integrated Security=SSPI;Initial Catalog=VolunteerApp;MultipleActiveResults=true" />
    </connectionStrings>

Coding style and project organization will be evalutated. Good luck!

