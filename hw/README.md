Logger

How to build and run(ubuntu):
1. install [dotnet sdk](https://dotnet.microsoft.com/download)
2. clone this repo and cd to 'Hw' directory
3. install [Sqlite package](https://www.nuget.org/packages/System.Data.SQLite) with NuGet
Use your IDE(I used Rider), or command line to do it
```
dotnet add package System.Data.SQLite --version 1.0.110
``` 
4. build and run(you better to use ide on this step)

``` 
/usr/share/dotnet/dotnet /path/to/solution/folder/Hw/hw/bin/Debug/netcoreapp2.2/hw.dll
```