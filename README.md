# Description
Just my personal [homepage](https://www.anttieskola.com)

# Solution
Azure static web site running blazor web assembly
and using functions via https. Implementation is using
one kind of adaptation clean architecture.

This is mostly learning the basics of Blazor application and
the differencies between just a web assembly vs core hosted.

## Solution is divided into 3 folders
- Presentation which references Application is kinda
  not referencing but depending Infrastructure also works.
- Application is the application layer that presentation
  uses thru mediator.
- Infrastructure is the infrastructure layer containing
  Functions/REST-api and storage for data using table
  storage.

## Presentation

## Application

## Infrastructure

# Deployment
Application is deployed using Github action. This will
build and deploy the Ui + Ui.Functions into Azure static
web application. When I commit the code to main branch.

Used storage and keyvault are installed manually using
Azure portal.

# Own notes for learning

## Component lifecycle
1. OnParametersSet
2. OnInitialized
3. OnAfterRender(bool firstRender)

## IDisposable
Blazor components can implement IDisposable to dispose of resources when the component
is removed from the UI. A Razor component can implement IDispose by using the @implements
directive. (@implements IDisposable)
