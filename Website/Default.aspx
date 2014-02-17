<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Website.Default" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/common.js" />
        </Scripts>
    </asp:ScriptManager>
    <div>
        <h1>Script Manager Handler Example</h1>
        <h3>Demonstration of loading stylesheets with <pre>ScriptManager</pre> and a manifest file to handle invalidating client cache (cache busting).</h3>
    </div>
    </form>
</body>
</html>
