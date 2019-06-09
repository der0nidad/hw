Logger

How to build and run(ubuntu):
1. install [dotnet sdk](https://dotnet.microsoft.com/download)
2. clone this repo and cd to parent 'hw' directory
3. install [Sqlite package](https://www.nuget.org/packages/System.Data.SQLite) with NuGet
Use your IDE(I used Rider), or command line to do it
```
dotnet add package System.Data.SQLite --version 1.0.110
``` 
4. build and run(you better to use ide on this step)

``` 
/usr/share/dotnet/dotnet /home/hvatrsh/RiderProjects/hw/hw/bin/Debug/netcoreapp2.2/hw.dll -conn-string "Data Source=filename.db; Version=3;"

```
5. Connection string passes via command line arguments, for example -conn-string "Data Source=filename.db; Version=3;"