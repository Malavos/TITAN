# TITAN

Titan is a .Net Core 2.0 Api made for the application GIBE MONEY.


## Manage your secrets

To properly connect to MongoDB, you need to set the connection string in your secrets, like so:

```JSON
{
  "Localhost": {
    "String": "mongodb://YOUR_USER:YOUR_PASSWORD@YOUR_ADDRESS:YOUR_PORT/YOUR_DATABASE?YOUR_OPTIONS"
  }
}
```

Here it is a more pratical example:

```JSON
{
  "Localhost": {
    "String": "mongodb://root:password@localhost:32768/admin?retryWrites=true"
  }
}
```


To check out your secrets, right click in the project in the Solution Explorer -> Api, and select "Manage User Secrets". You can add as many secrets you want. But you have to define in the code below, at the class `Startup.cs`, in the function `        public void ConfigureServices(IServiceCollection services)`, as in:

```C#
	new MongoProvider().SetConnectionString(Configuration["YOUR_PROJECT:YOUR_PROPERTY"]);
```

In the examples given, the correct way would be as in:

```C#
	new MongoProvider().SetConnectionString(Configuration["Localhost:String"]);
```
