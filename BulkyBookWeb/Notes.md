# Notes

## Table of Contents
* [Introduction](#introduction)
* [Specific Notes](#specific-notes)
   * [Routing and Default Files](#routing-and-default-files)
   * [Tag Helpers](#tag-helpers)
3. [Examples](#examples)

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