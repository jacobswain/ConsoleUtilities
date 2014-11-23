ConsoleUtilities
================

A simple way to format table data when printing to the console

Install from NuGet: 

```
PM> Install-Package TableFormatter
```


##Example 1

###Setup
```

var table = new ConsoleTable(new [] {"FirstName", "LastName"});
table.AddRow(new []{"Jacob", "Swain"});
table.AddRow(new []{"Ethan", "Swain"});
table.AddRow(new []{"Amie", "Swain"});
table.AddRow(new []{"Madison", "Swain"});  
table.WriteToConsole(); 
Console.Read(); 

```


###Output

```
++++++++++++++++++++++++++++
|  FirstName  |  LastName  |
++++++++++++++++++++++++++++
|  Jacob      |  Swain     |
++++++++++++++++++++++++++++
|  Ethan      |  Swain     |
++++++++++++++++++++++++++++
|  Amie       |  Swain     |
++++++++++++++++++++++++++++
|  Madison    |  Swain     |
++++++++++++++++++++++++++++

```

##Example 2

### Setup for Alternative Formatting

```

var settings = new ConsoleTableSettings ('|', '-'); 
var table = new ConsoleTable(new [] {"FirstName", "LastName"}, settings);
table.AddRow(new []{"Jacob", "Swain"});
table.AddRow(new []{"Ethan", "Swain"});
table.AddRow(new []{"Amie", "Swain"});
table.AddRow(new []{"Madison", "Swain"});  
table.WriteToConsole(); 
Console.Read(); 
			
```

###Output

```
---------------------------
|  FirstName  |  LastName  |
---------------------------
|  Jacob      |  Swain     |
---------------------------
|  Ethan      |  Swain     |
---------------------------
|  Amie       |  Swain     |
---------------------------
|  Madison    |  Swain     |
---------------------------

```