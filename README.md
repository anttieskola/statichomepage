# Description
Just my personal [homepage](https://www.anttieskola.com)

# Solution
Azure static web site running blazor web assembly
and using functions via https. Implementation is using
one kind of adaptation clean architecture.

## Solution is divided into 3 folders
- Presentation which references Application is kinda
  not referencing but depending Infrastructure also works.

- Application is currently not using database or anyting so
  there is only public mediator to be injected 
