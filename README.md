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

### Ui.Platform
Project containing all javascript and style libraries
used in the front end.

### UI.Components
Project to contain applications UI-components as a separate
library so it could be reused in the future. This depends
on the platform library

### Ui
The actual Blazor web assembly application. This contains
the sites pages and components that are specific to this
experiment.

## Application

### XApplication

### PresentationModels
Library of the public models used in the application.
This is referenced the mostly by all components
in the application. Here I wanted to try out
C# 9.0 record type.

## Infrastructure

### Configuration
All configuration in the application comes by using this
component to retrieve data from Azure Keyvault.

### TableStorage
I wanted to try out using table storage for data instead
like always using a real SQL or NOSQL database.

### Functions
Static websites backend functions.

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

## Component lifecycle from source (code behind)
// Summary:
//     Method invoked when the component has received parameters from its parent in
//     the render tree, and the incoming values have been assigned to properties.
//
// Returns:
//     A System.Threading.Tasks.Task representing any asynchronous operation.
protected virtual Task OnParametersSetAsync()

// Summary:
//     Method invoked when the component is ready to start, having received its initial
//     parameters from its parent in the render tree.
protected virtual void OnInitialized()

// Summary:
//     Method invoked when the component is ready to start, having received its initial
//     parameters from its parent in the render tree. Override this method if you will
//     perform an asynchronous operation and want the component to refresh when that
//     operation is completed.
//
// Returns:
//     A System.Threading.Tasks.Task representing any asynchronous operation.
protected virtual Task OnInitializedAsync()

// Summary:
//     Method invoked after each time the component has been rendered.
//
// Parameters:
//   firstRender:
//     Set to true if this is the first time Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender(System.Boolean)
//     has been invoked on this component instance; otherwise false.
//
// Remarks:
//     The Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender(System.Boolean)
//     and Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync(System.Boolean)
//     lifecycle methods are useful for performing interop, or interacting with values
//     received from @ref. Use the firstRender parameter to ensure that initialization
//     work is only performed once.
protected virtual void OnAfterRender(bool firstRender)

// Summary:
//     Method invoked after each time the component has been rendered. Note that the
//     component does not automatically re-render after the completion of any returned
//     System.Threading.Tasks.Task, because that would cause an infinite render loop.
//
// Parameters:
//   firstRender:
//     Set to true if this is the first time Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender(System.Boolean)
//     has been invoked on this component instance; otherwise false.
//
// Returns:
//     A System.Threading.Tasks.Task representing any asynchronous operation.
//
// Remarks:
//     The Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender(System.Boolean)
//     and Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync(System.Boolean)
//     lifecycle methods are useful for performing interop, or interacting with values
//     received from @ref. Use the firstRender parameter to ensure that initialization
//     work is only performed once.
protected virtual Task OnAfterRenderAsync(bool firstRender)

## IDisposable
Blazor components can implement IDisposable to dispose of resources when the component
is removed from the UI. A Razor component can implement IDispose by using the @implements
directive. (@implements IDisposable)

## IAsyncDisposable

## JSInteropt
- docs: https://docs.microsoft.com/en-us/aspnet/core/blazor/javascript-interoperability/call-javascript-from-dotnet?view=aspnetcore-5.0#blazor-javascript-isolation-and-object-references
- Basic way is to include the script after the app in the index.html page
  but then it would require always to update the index if even tho
  you most likely will write code in component library or elsewhere.

- Advanced way is to load it dynamically. This way must create either
  a module or an object that you dynamically load.

### JSInteropt - Basic way
- IJSRuntime is the normal interface, where you call some function that
  exists. You can call like standard functions directly like for example:
  ``await JS.InvokeVoidAsync("console.log", "hello console");``
  or another example:
  ``await JS.InvokeVoidAsync("alert", "hello alert");``
  
- Note, that if function returns value that must be known and defined.

**Maybe the only annyoing thing in this is that it must be a function that we call**
I did try to execute a lambda to get a property from an object, but it won't work...

### JSInteropt - Advanced way (JS Isolation)
- IJSObjectReference is the advanced interface what you can use to dynamically
  load reference to an Javascript object. Then call it's method and such.
  Example loading:
  ``var module = await JS.InvokeAsync("import", "pathToJavascriptObject")``
  Example invoking:

  From testing seems to work to export objects or functions.
  
  JS Module documentation: https://developer.mozilla.org/en-US/docs/Web/JavaScript/Guide/Modules
