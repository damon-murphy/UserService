# User API

Process:
* I started with a ASP.NET Core API template (WeatherForecast) and expanded this out.
I added a BaseController with the intention of expanding out shared controller functionality but didn't have time to complete this.
* First, I added MediatR and replaced the Weather API with a User API and added a Command and CommandHandler.
* Then I decided to move to getting FluentValidation set up to filter out bad requsts for this Command.
* Following this I set up a couple of tests with XUnit to see if validation was working as intended.
* After this, I added a domain layer to handle my domain logic, including a UserManager. 
* I added an interface for the manager with intentions to later test here, but didn't quickly ran out of time for these tests.
* I then moved on to the repository layer, setting up my repository and DB context. I used an Azure SQL Database with a secrets.json for the connection string.
* After dealing with a really unhelpful error (turns out EF doesn't like it if a class library is using a different version of EF but it won't tell you that outright)
I was then able to create Users so I made a quick Query and did a small amount of cleanup.
