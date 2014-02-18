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

v. Add the *ScriptLoaderHttpModule* to the *web.config* (optional see #6)
```xml
<system.webServer>
  <modules runAllManagedModulesForAllRequests="false">
    <add name="ScriptLoaderHttpModule" type="Ember.Web.ScriptLoaderHttpModule" preCondition="managedHandler" />
  </modules>    
</system.webServer>
```

vi. You can bypass the *HttpModule* and handle the `ScriptManager.ResolveScriptReference` in codebehind (see [Default.aspx.cs](https://github.com/EmberConsultingGroup/ScriptManagerHandler/blob/master/Website/Default.aspx.cs)). The disadvantage to this is that you must handle the event for all pages with a *ScriptManager*, requiring you to repeat your code. Or you could depend on a *MasterPage* with one *ScriptManager* if your site is designed that way.

vii. Alternatively compile the [ScriptLoaderHttpModule, ScriptManagerExtensions, and ScriptManifest](https://github.com/EmberConsultingGroup/ScriptManagerHandler/tree/master/Ember.Web) into your own assembly.

#### Aside
If you don't mind combining all your scripts into one *CompositeScript*, you can use the *CompositeScript* feature of *ScriptManager*. This way a change to ***any*** file in the composite will force all combined scripts to reload on the client.
```xml
<asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release">
  <CompositeScript>
    <Scripts>
      <asp:ScriptReference Path="~/Scripts/part1.js" />
      <asp:ScriptReference Path="~/Scripts/part2.js" />
    </Scripts>
  </CompositeScript>
</asp:ScriptManager>
```

* The downside to this is that all of the scripts in the composite will be reloaded, not just the changed file.
* The upside is that scripts in the composite will always be reloaded when they are modified, without doing anything else.


#### Benefits
* Manage your script file versions in one place
* Continue to handle loading your scripts via ScriptManager
* Do not do global search and replace on markup
* Be confident you are updating a script everywhere it's used
* Does not require any build step to rewrite source or files
* Does not require URL rewrite on your web server
