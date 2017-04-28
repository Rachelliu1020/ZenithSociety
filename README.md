# ZenithSociety
The Zenith Society is a family oriented non-for-profit organization that holds events during the week. The leader of the group, Mr. John Doe, wishes to have a website that displays the events from Monday to Sunday of the current week. 

## Server-side Web running on Azure:
http://zenithwebsite20170401034739.azurewebsites.net/

Admin user:
* user name: a
* password: P@$$w0rd

ASP.NET Core 1.0

## Client-side Web running on Azure:
http://zenithclientside.azurewebsites.net/

Angular 2

## Author: Rachel (Rui) Liu

Task #1 – ASP.NET Core 1.0

The home page of the website displays the list of current events to anonymous users, with dates adjusted to represent only events during the current week. When an administrator logs-into the website he/she is able to fulfill the following functions:
1. Manage a lookup table that stores activities that are organized by the group
2. add / edit / and delete events

Activity:
* Activity Id
* Activity Description
* CreationDate    

Event:
* Event Id
* Event from date and time
* Event to date and time
* Entered by username
* Activity
* Creation Date
* IsActive

Task #2 – manage users and roles

build a UI in the MVC application that will enable the administrator to add/delete roles and add/remove users from a role. The Member role is of special interest because your code automatically adds any registered user to the Member role. Only users that belong to the Member role can see events for past and future weeks. Of course, the administrator can remove a user from the Member role.
Your code needs to ensure that account “a” is never deleted or removed from the Admin role. Otherwise, if this happens, then the admin functionality of your web app may be inaccessible. You should also ensure that the Admin role cannot be deleted.
Note that a user can belong to one or more roles.

Task #3  – Create Web API services for all data

Add Web API controllers to serve activity, event, and account data as RESTful services. These services should enable registration and authentication of users. 

Task #4  – Angular-ize some parts of the application

The page that displays the schedule by week will be served by an index.html page that is powered by AngularJS 2.0.  It utilizes the Web API service to obtain data. 
The current week schedule is visible to anonymous users. However, if a user is authenticated and belongs to either the Admin or Member roles, then he/she can click on button ‘<’ to see the schedule for a previous week or button ‘>’ to see the schedule for a future week.



