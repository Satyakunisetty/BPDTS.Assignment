1. Environment/Pre-requisites : 

      a. .Net Core 2.2
      
      b. Compatible with Visual studio 2017 & 2019 (In interest of time, have checked with these two visual studio versions)

2. Nuget Packages with their versions used :

<PackageReference Include="Microsoft.AspNetCore" Version="2.2.0" />
<PackageReference Include="Microsoft.AspNetCore.Mvc.Core" Version="2.2.5" />
<PackageReference Include="Microsoft.NET.Test.Sdk" Version="16.7.0" />
<PackageReference Include="NUnit3TestAdapter" Version="3.17.0" />
<PackageReference Include="Shouldly" Version="3.0.2" />
<PackageReference Include="SpecFlow" Version="3.3.74" />
<PackageReference Include="SpecFlow.NUnit" Version="3.3.74" />
<PackageReference Include="SpecFlow.Tools.MsBuild.Generation" Version="3.3.74" />

3. How to Build and Run the project

   a. Open the solution file with Visual studio either in 2017/2019
   b. Build the solution 
   c. Once the solution is successfully built, navigate to Test Explorer.
   d. Execute all scenarios from Test Explorer.

4. Implementation details are mentioned below.

   From the URL provided in the assignment http://bpdts-test-app-v2.herokuapp.com/, there are three operations that we can perform

      a. Get all User details using /users
      b. Get a specific user details by using /user/{id} 
      c. Get all users along with details using /city/{city}/users


   For each and every operation I have created a separate feature file and its corresponding StepDefinition file.

   a. GetUsers.feature

      This feature file is created to validate the following 
         i. to validate the provided status code (200) when the /users endpoint is called
         ii. check the users count from the response is >0


   b. GetUsersByCity.feature

      This feature file is created to validate the following 
         i. 200 Status code is shown even if we pass a valid or Invalid City name
         ii. If a valid City name is passed which is present from the list, all users belong to the city are fetched and a specific user details are validated
         iii. If a Invalid City name is passed, check the users count is 0

   c. GetUsersById.feature

      This feature file is created to validate the following 
         i. 200 Status code when a valid Id is passed
         ii. 400 Status code when a invalid Id is passed
         iii. If a valid Id is passed, specific user details are also validated.
         iv. If a Invalid Id is passed, validate the error message which gets displayed.


    Model class <user> is created under Models folder to contain user details coming from API response


   BpdtsServiceClient.cs is created to call specific operation(users, userByCityName, UserById) which are listed above



