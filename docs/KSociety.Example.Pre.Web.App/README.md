![Logo](https://github.com/K-Society/KSociety.Example/blob/master/docs/K-Society__Logo_vs-negative.png)

[KSociety.Example Home](https://github.com/K-Society/KSociety.Example)

# KSociety.Example.Pre.Web.App

An essential example on how to use [KSociety.Example.Pre.Web.App](https://github.com/K-Society/KSociety.Example/tree/master/Src/01/01/Web/KSociety.Example.Pre.Web.App).

### How to use this example (for Windows)

1. Install [RabbitMQ](https://github.com/K-Society/KSociety.RabbitMQ.Install/releases)
2. Install [Log system](https://github.com/K-Society/KSociety.Log/releases)
3. Run KSociety.Log.Pre.Web.App.exe
4. Open web browser to the following address: http://localhost:61000
5. Run KSociety.Log.Srv.Host.exe
6. Run KSociety.Example.Pre.Console.Log.SinksRabbitMq.exe

### KSociety.Example.Pre.Web.App

This project contains a console application that generates 5 log messages:
```cs
logger.LogTrace("Your {0} message: {1}", "Trace", result);
logger.LogDebug("Your {0} message: {1}", "Debug", result);
logger.LogInformation("Your {0} message: {1}", "Information", result);
logger.LogWarning("Your {0} message: {1}", "Warning", result);
logger.LogError("Your {0} message: {1}", "Error", result);
```

All messages pass through [RabbitMQ](https://www.rabbitmq.com/) to the [log server](https://github.com/K-Society/KSociety.Log), after which the log server retransmits them to the [log web application](https://github.com/K-Society/KSociety.Log).


## License
The project is under Microsoft Reciprocal License [(MS-RL)](http://www.opensource.org/licenses/MS-RL)

## Dependencies

List of technologies, frameworks and libraries used for implementation:

- [.NET 6](https://dotnet.microsoft.com/download/dotnet/6.0) (platform). Note for Visual Studio users: **VS 2022** is required.
- [Microsoft.CSharp](Microsoft.CSharp) (Autofac is an IoC container for Microsoft .NET.)
- [Microsoft.Extensions.Logging.Abstractions](https://www.nuget.org/packages/Microsoft.Extensions.Logging.Abstractions/) (Logging abstractions for Microsoft.Extensions.Logging.)
- [Polly](https://www.nuget.org/packages/Polly) (Polly is a library that allows developers to express resilience and transient fault handling policies such as Retry)
- [RabbitMQ.Client](https://www.nuget.org/packages/RabbitMQ.Client) (The RabbitMQ .NET client is the official client library for C# (and, implicitly, other .NET languages).)