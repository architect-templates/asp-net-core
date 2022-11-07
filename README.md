<p align="center">
  <picture>
    <source media="(prefers-color-scheme: dark)" srcset="https://cdn.architect.io/logo/horizontal-inverted.png">
    <source media="(prefers-color-scheme: light)" srcset="https://cdn.architect.io/logo/horizontal.png">
    <img width="320" alt="Architect Logo" src="https://cdn.architect.io/logo/horizontal.png">
  </picture>
</p>

<p align="center">
  A dynamic microservices framework for building, connecting, and deploying cloud-native applications.
</p>

---

<p align="center">
  <a href="//asp.net" target="blank"><img src="https://upload.wikimedia.org/wikipedia/commons/thumb/e/ee/.NET_Core_Logo.svg/768px-.NET_Core_Logo.svg.png" width="320" alt="ASP.net Logo" /></a>
</p>

<p align="center">
Free. Cross-platform. Open source.
A framework for building web apps and services with .NET and C#.
</p>

---

# ASP.net Core Starter Project
[ASP.net](https://asp.net/) is a popular web framework for handling both the frotned and backend of your application. This repository contains a small working ASP.net web server and api that is packaged into an Architect Component.

This starter application will show how easy it is to deploy an application both
locally and in a remote environment.

## Requirements
Before you can run this example application, you will need to install the [Architect CLI](https://github.com/architect-team/architect-cli).

## Running Locally
The `architect.yml` file is declarative, allowing the Architect Component it describes to be run in any environment, from local development to production.

Once the deployment has completed, you can reach your new service by going to https://app.localhost.architect.sh.

```sh
# Clone the repository and navigate to this directory
$ git clone git@github.com:architect-templates/asp-net-core.git
$ cd ./asp-net-core

# Deploy locally using the dev command
$ architect dev architect.yml
```
## Deploying to the Cloud

Want to try deploying this to a cloud environment? Architect's got you covered there, too! It only takes a minute to
[sign up for a free account](https://cloud.architect.io/signup).

You can then [deploy the application](https://docs.architect.io/getting-started/introduction/#deploy-to-the-cloud) by running the command below. Note that “example-environment” is the free environment that is created with your Architect account.

```sh
# Deploy to Architect Cloud
$ architect deploy architect.yml -e example-environment
```

# Architecture

## asp-net-core-shared
This is a shared library between the other two libraries. This allows you to share code, but most importantly models. C# is a statically typed language. So we should make sure to embrace that when possible. If you look inside the Model folder you will see a class called `Movie`. This allows us to make sure that anytime we send a movie to the API from the Web or vice versa, that the object conforms to the correct contract.

## asp-net-core-api
This is our API layer that handles actions taken by the user. At the moment it just handles the creation and querying of movies, but you can expand on it by adding your own controllers. Take a look at the ASP documentation for help. [Getting Started Guide](https://learn.microsoft.com/en-us/aspnet/core/tutorials/min-web-api?view=aspnetcore-6.0&tabs=visual-studio)

## asp-net-core-web
Our frontend interface that our users interact with directly. This is where all your frontend code goes. While we have chosen to keep things simple, you can feel free to add any additional webframeworks you want on top of this. Check out [Bootstrap](https://aspnetcore.readthedocs.io/en/stable/client-side/bootstrap.html).
