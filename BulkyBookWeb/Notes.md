# Notes

## Table of Contents
* [Introduction](#introduction)
* [Specific Notes](#specific-notes)
   * [Routing and Default Files](#routing-and-default-files)
   * [Tag Helpers and Actions](#tag-helpers-and-actions)
   * [Hot Reload](#hot-reload)
* [Database](#database)
   * [Model Creation](#model-creation)
   * [Connection to SSMS](#connection-to-ssms)
   * [Run the Migration to SSMS](#run-the-migration-to-ssms)
* [Category CRUD Operations](#category-crud-operations)
   * [Dealing with the Category Controller](#dealing-with-the-category-controller)
   * [Entity Framework Core](#entity-framework-core)

---

## Introduction
These notes cover the basics of ASP.NET Core, including its architecture, dependency injection, and how to set up a simple MVC project. This is an MVC application not a razor page application.
Will do a separate udemy course integrating ASP.Net Core with React.

---

## Specific Notes
### Routing and Default Files
Details of MVC, associated Routing and the default files/architecture.

**Key points**:
- If you have a View with a certain heading (which is called an action) e.g. Home, then the associated Controller, which dictates the logic to the interface via this page has to have the name of the action at the start before "Controller" e.g. HomeController
- The "Shared" Views are used for partial views, which are similar to components in C# (i.e. a view within a view that can be placed in multiple locations).
- _Layout is often the default master page of the application, but if this doesn't exits, can add it in the form of a Razor View doc. This is where the bootstrap is declared and header/containers are created. It acts like a template for the web app.
- @RenderBody() is used to declare the html bits inside the views.
- _ValidationScriptsPartial is where scripts e.g. JS ones and validations are added.
- _ViewImports lets you add namespaces, which are automatically accessible across all files.
- _ViewStart determins what the master page is for the template etc.

### Tag Helpers and Actions
Details of Tag Helpers in the HTML files.

**Key points**:
- Included in the HTML files, where asp-controller and asp-action are, they help set up the url.
- They are declared in the _ViewImports file and are basically items that have been adopted from other languages/frameworks e.g. angular to help asp.net core development.
- Tag Helpers are made for server side rendering.
- Actions use type `IActionResult` which is a generic return type rather than specific `ViewResult` for an MVC app or `PageResult` for a Razor page.
- Using the Action Results, it is a parent class for many derived classes with associated helpers. e.g. NotFoundResult, PartialViewResult, JsonResult, FileContentResult etc.

### Hot Reload
Details of making UI updates and seeing them on screen via "Hot Reload".

**Key points**:
- If you have the website running, but make some visual changes, you can reload the content by clicking the fire emoji in VS.
- By clicking on the right arrow next to it and selecting "Hot Reload on File Save", it automatically updates the UI after any updates are saved.
- You just need to refresh the UI and the changes are reflected.

## Database
### Model Creation
Details of creating the model in the project.

**Key points**:
- In ASP.Net Core, Entity Framework core is used to manipulate the data rather than using Stored Procedures in SSMS.
- Create a model, by right clicking on "Models" and "Add..". Select "Class".
- To quickly type a property, type "prop" and double hit tab. This gives a generic `public int MyProperty { get; set; }` statement.
- To make a property the primary key, add `[Key]` above that property.
- If a property has to be required (i.e. is not null), then use `[Required]` above it.

### Connection to SSMS
Details of how to create a DB inside of SSMS without manually creating it.

**Key points**:
- The connection string should be included in `appsettings.json` rather than hardcoded somewhere in the main project.
- As connecting is so common, the log name is "ConnectionStrings". "DefaultConnection" is to set up the default database connection.
- Input the server name as it is found in SSMS and the name of the database you want to create.
- To separate json items here, include a ";" inbetween each value.
- Connecting to the DB can be done by creating a class for the DB context with Entity Framework Core.
- It is good practice to create a folder for any data related changes that are not models.
- To download Entity Framework Core, this can be done via NuGet Packages as the version should match the .net Core you are using.
- If there are issues, check th package inside the `.csproj` file which can be done by right clicking on the project name and selecting "edit project file".
- To create the constructor for the connection, use the shortcut "ctor" + tab to create the default snippet.
- Parameters are required inside the constructor to pass onto the base class which is the "DbContext" in this case.
- To create the table inside SSMS, a "DbSet" is required for each.
- There are 2 models for working with entity core - Code First or Database First. We're using Code First as we are creating code on the model and creating a DB from it.
- `Program.cs` should be used here to configure the services that should be used in the app.
- Install SQLServer.EntityFrameworkCore in NuGet package manager as this is required.
- Add the following line: `builder.Services.AddDbContext<ApplicationDBContext>();`, where the context requires a class file/type and as options are required inside the parameters, type in `options => options.UseSqlServer()`
- Inside the rounded brackets include the connection string from the `appsettings.json file`, which can called like so `builder.Configuration.GetConnectionString("DefaultConnection")`

### Run the Migration to SSMS
Details of how to migrate the tables and databases for the first time to SSMS.

**Key points**:
- Migrations are done like so: `add-migration [InsertRelevantChangeInfoWithNoSpaces]`.
- A "Migrations" folder has been created which shows all migrations made.
- 2 methods are found in each migration - the Up method is what needs to happen inside the migration, whereas the Down method is if something goes down, the changes need to be rolled back.
- If you agree with the migration, then you can push it to the dm with `update-database`.

## Category CRUD Operations
### Dealing with the Category Controller
Details of how to create a controller for a category.

**Key points**:
- For creating a controller, add an empty Mvc application to the "Controller" folder and make sure to add "Controller" add the end of the name, as this is a requirement for the system.
- Each controller pages has an index action, but for the home controller, it has its own page called `index.cshtml`. Just replicate this with a Views page of the same start name of the controller and add an "index" page. You can also right click on the controller over the `Index()` part and click "Add View..:".
- Select the Razor View option, which is not empty, but when inside the razor view menu, select Template "Empty (without model)" at the start, but there are "Create", "Delete" etc. templates which are of use.
- A partial view (reusable components that allow you to render a portion of HTML content within a larger view e.g. nav bar) can also be selected but it does not let you use a layout page, but this is not done at this stage.
- Use a layout page - which, if left blank, uses the default settings in the "Shared" folder.
- By clicking "Add", it will scan for view dependencies and then will create the view inside a new suitable folder.
- In `_Layout.cshtml`, add the page as `<a class="nav-link text-dark" asp-area="" asp-controller="Category" asp-action="Index">Category</a>` with the controller name and the index is the action.
- Note: I am doing this part without the connection to my SSMS DB, so can't add or test dummy data.

### Entity Framework Core
Details of how to use entity framework core to deal with data.

**Key points**:
- Due to dependency injection, we do not need to create an object of our Categories Model, which is seen in `Program.cs` where a service "AddDbContext" acts as if it is sending the object.
- Create a `private readonly` var to save any database context associated with the controller locally. Due to dependency injection, we can call a class with the `ApplicationDbContext` type as this was declared as a service at the start.
- Convert the database table called Categories' records into a list and this can be returned via the view, as seen in `CategoryController.cs`, but it also needs to be added to the relevant `index.cshtml` view.
- In the relevant view page, we need to capture the model from the controller `@model IEnumerable<Category>`, where model needs to be in lowercase and the type given is the type the database table is in the controller.
- We can call these model values, by using C# in the view page where @ allows for some C# and when calling the model, it should now start with an uppercase "M".
- You can call the object table columns by just putting an "@" at the start.

### Dealing with the Category View
Details of how to create a view for a category.

**Key points**:
- Note: If editing the razor pages, will have to add `AddRazorRuntimeCompilation()` to show the immediate reflection of changes during development without having to restart the app. If this does not appear - make sure you have the "Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation" NuGet package.
- Bootswatch creates themes from bootstrap, which will help with styling - will skip this section of the project.