#NinjaBone
This project started with inspiration of [NinjaBone](https://github.com/tretton37/NinjaBook) but the main goal was to see if it's possible to build
an mobile application driven by a REST service with jquery template. I'm not sure that this is the prefered way so the main goal for me right now is
to use the application for some experiment. The UI, javascript integration and the test is crap but there are some things that I do like.

##Service Stack for creating REST-ful services
_[Service Stack](http://www.servicestack.net/) is a modern, code-first, DTO-driven, WCF replacement web services framework encouraging best-practices for creating DRY, high-perfomance, scalable REST web services_

- I like the way the abstraction layer for creating a service works with the Command, Response and the actual service implementation
- I like the way of how to handle caching for the service in CachedNinjaService where the cache provider is injected to the service

*NOTE* I replaced the dependency injection of Service Stack with AutoFac as a proof of concept and it was pretty easy as long as the _ServiceHost_ is internal

The REST implementation is located under NinjaBone.Api 

[Example of hello world using ServiceStack](http://www.servicestack.net/ServiceStack.Hello/)

##Autofac
_[Autofac](http://code.google.com/p/autofac/) is an IoC container for Microsoft .NET. It manages the dependencies between classes so that applications stay easy to change as they grow in size and complexity. This is achieved by treating regular .NET classes as components._

- It's very simple to configure see the ServiceModule even if you're new to IoC containers
- Integration with MVC and classic webforms
- The possibility to register the module in web.config with environmental specific data like the property _UseDummyService_ in web.config

## mvc-mini-profiler
_[mvc-mini-profiler](http://code.google.com/p/mvc-mini-profiler/) is a simple but effective mini-profiler for ASP.NET MVC and ASP.NET._

- Free
- Very easy to integrate in the website
- Support for multiple databases

I don't think that this profile will replace profilers like Überproof or .dottrace but it give a quick hint if the page is kosher.