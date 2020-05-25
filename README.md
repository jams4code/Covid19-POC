# Covid19-POC
This is a POC that I realized to make a project proposal.

# Get Started
You can have a live demo available here: https://covid19-bd.azurewebsites.net/#/home

With the code?
1. Clone the repository
2. Open the project in VS or VS Code. 
3. Launch it
(The first launch can take time as it will download the dependency for Angular (npm install) and then start the front-end)
4. Enjoy it

# Architecture

## Code
I like to use Clean-Architecture to do my projects.
To explain it simply, the clean-architecture is built by separating the code into 4 layers:
- Domain (Entities/Objects => Enterprise logic)
- Application (Business Logic)
- Infrastructure (Database, Configuration (Entity-Framework),...) 
- Presentation (API, Client => Front-End = Angular in our case)

![Image of CleanArchitecture](https://github.com/jams4code/Covid19-POC/blob/master/shape-half.png?raw=true)

You can learn more about it at https://www.youtube.com/watch?v=5OtUm1BLmG0 a video of 1 hour that will change your life.

### With this architecture you will learn:
- [CQRS with MediatR (Command Query Responsibility Segregation)](https://github.com/jbogard/MediatR)
- [Validation with FluentValidation](https://fluentvalidation.net/)
- Automated testing with [xUnit.net](https://xunit.net/), [Moq](https://github.com/Moq/moq4/wiki/Quickstart), and [Shoudly](https://shouldly.readthedocs.io/en/latest/)
- ...
Cleaner code starts now :).

## Application
#### 3-Tier architecture
###### Back-End
**.Net Core 3.1**
###### Front-End
**Angular 9**
###### Database
**SQL Server**



# Final product
You can see a version of the MVP (Minimum Valuable Product) here: https://covidx.azurewebsites.net/
