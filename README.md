# DentistAppointment  [![Build status](https://ci.appveyor.com/api/projects/status/p8lk795haoqon1gs/branch/develop?svg=true)](https://ci.appveyor.com/project/VickyPenkova/payitforward/branch/develop)

Project setup:
1. Build the project
2. Delete the project.assets.json
3. Clean Solution
4. Go to Tools -> NuGet Package Manager -> Package Manager Console
5. Execute 'dotnet-restore'
6. Build Solution
7. Updata-Database

Data Seed:
 For'Update-Database' you should:
1. 'git pull origin develop'
2. Build solution
3. For'Start Up Project' -> "DataSeed" and for 'DefaultProject' -> 'DentistAppointment'
4. 'PM> Update-Database'
5. Run project 'DataSeed'


Deploy:
<a href="https://dashboard.heroku.com/new?template=dentistappointment">
  <img src="https://www.herokucdn.com/deploy/button.svg" alt="Deploy">
</a>



