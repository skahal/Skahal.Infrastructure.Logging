Skahal.Infrastructure.Logging
==================================

[![Build Status](https://travis-ci.org/skahal/Skahal.Infrastructure.Logging.png?branch=master)](https://travis-ci.org/skahal/Skahal.Infrastructure.Logging)

Skahal.Infrastructure.Framework.Logging.ILogStrategy's implementations.


--------

Features
===
- Log4net (`Log4netLogStrategy`)
- Mono support
- Fully tested on Windows and MacOSX
- Tests coveraged 
- Good (and well used) design patterns  

--------

Setup
===

PM> `Install-Package Skahal.Infrastructure.Logging.Log4net`

Using Log4netLogStrategy
===
Add log4net configuration to app.config/web.config. A basic configuration looks like:
```xml
<configuration>
  <configSections>
     <section name="log4net" type="log4net.Config.Log4NetConfigurationSectionHandler, log4net" />
```
```xml
 <log4net>
    <appender name="RollingFileAppender" type="log4net.Appender.RollingFileAppender">
      <file value="Logs/log.txt" />
      <appendToFile value="true" />
      <rollingStyle value="Size" />
      <maxSizeRollBackups value="10" />
      <maximumFileSize value="100KB" />
      <staticLogFileName value="true" />
      <ImmediateFlush value="true" />
      <layout type="log4net.Layout.PatternLayout">
        <conversionPattern value="%d{dd/MM/yy HH:mm:ss} [%level%] %m%newline" />
      </layout>
    </appender>
    <root>
      <level value="ALL" />
      <appender-ref ref="RollingFileAppender" />
    </root>
  </log4net>
```

In your app initialization, like global.asax, add:
```csharp
protected void Application_Start()
{
    LogService.Debug("Application starting...");
    LogService.Debug("Machine: {0}", Environment.MachineName);

    LogService.Debug("Bootstrap setup...");
    new WebBootstrap().Setup();

    LogService.Debug("Registering something...");
    // your app initilization code.
}
```

---



Roadmap
===
 - **Unity3d degug log**: `Unity3dLogStrategy`		
 		
 		
 
--------

How to improve it?
======

Create a fork of [Skahal.Infrastructure.Repositories](https://github.com/skahal/Skahal.Infrastructure.Logging/fork). 

Did you change it? [Submit a pull request](https://github.com/skahal/Skahal.Infrastructure.Logging/pull/new/master).


License
======

Licensed under the The MIT License (MIT).
In others words, you can use this library for developement any kind of software: open source, commercial, proprietary and alien.


Change Log
======
 - 0.5.0 First version.


