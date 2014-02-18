ScriptManager Handler
=============================

If you are using [ScriptManager](http://msdn.microsoft.com/en-us/library/system.web.ui.scriptmanager(v=vs.110).aspx) to load scripts for an [ASP.NET WebForms](http://www.asp.net/web-forms) application, you may need a convenient way to invalidate client cache (cache busting) when scripts are updated.

This approach allows you to manage a single manifest file where you maintain a list of the javascript files that you want to version. When the files are loaded via *ScriptManager* a custom [HttpHandler](http://msdn.microsoft.com/en-us/library/ms227675(v=vs.85).aspx) handles the [HttpApplication.PreRequestHandlerExecute](http://msdn.microsoft.com/en-us/library/system.web.httpapplication.prerequesthandlerexecute(v=vs.110).aspx) event and appends a version stamp to the url of each script being requested.

#### Getting it to work
i. Add the path to your manifest file in your *web.config*.
```xml
<appSettings>
  <add key="ScriptManifestPath" value="~/App_Data/ScriptManifest.xml"/>
</appSettings>
```
ii. Add a *ScriptManifest.xml* file to your *~/App_Data* folder or wherever you specified above.

iii. Add the names of your script files (name only, no path or extension) and versions to the *ScriptManifest.xml* file.
```xml
<scripts>
  <script name="common" v="1.5"/>
</scripts>
```
iv. Compile and reference [Ember.Web](http://github.com/EmberConsultingGroup/ScriptManagerHandler/tree/master/Ember.Web) in your web application.

v. Add the *ScriptLoaderHttpModule* to the *web.config*
```xml
<system.webServer>
  <modules runAllManagedModulesForAllRequests="false">
    <add name="ScriptLoaderHttpModule" type="Ember.Web.ScriptLoaderHttpModule" preCondition="managedHandler" />
  </modules>    
</system.webServer>
```

vi. Alternatively compile the [ScriptLoaderHttpModule](http://github.com/EmberConsultingGroup/ScriptManagerHandler/blob/master/Ember.Web/ScriptLoaderHttpModule.cs) and [ScriptManagerExtensions](http://github.com/EmberConsultingGroup/ScriptManagerHandler/blob/master/Ember.Web/ScriptManagerExtensions.cs) into your own assembly.

#### Benefits
* Manage your script file versions in one place
* Continue to handle loading your scripts via ScriptManager
* Do not do global search and replace on markup
* Be confident you are updating a script everywhere it's used
* Does not require any build step to rewrite source or files
* Does not require URL rewrite on your web server
