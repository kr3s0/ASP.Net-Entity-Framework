
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RKBank.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>@ViewBag.Title - RKBank</title>
    <link href="~/Content/Site.css" rel="stylesheet" type="text/css" />
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="~/Scripts/modernizr-2.8.3.js"></script>
</head>
<body style="font-family: Arial, Helvetica, sans-serif; font-size: small">
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a href="/klijent" class="navbar-brand">Klijent</a>
                <a href="/kartica" class="navbar-brand">Kartica</a>
                <a href="/kredit" class="navbar-brand">Kredit</a>
                <a href="/osiguranje" class="navbar-brand">Osiguranje</a>
                <a href="/imovinskoosiguranje" class="navbar-brand">Imovinsko</a>
                <a href="/putnoosiguranje" class="navbar-brand">Putno</a>
                <a href="/zivotnoosiguranje" class="navbar-brand">Zivotno</a>
            </div>
            <a href="/Register.aspx" class="navbar-brand navbar-right">Register</a>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                </ul>
            </div>
        </div>
    </div>
    <div class="container body-content">
        <form id="form1" runat="server">
          <div>
             <h4 style="font-size: medium">Log In</h4>
             <hr />
             <asp:PlaceHolder runat="server" ID="LoginStatus" Visible="false">
                <p>
                   <asp:Literal runat="server" ID="StatusText" />
                </p>
             </asp:PlaceHolder>
             <asp:PlaceHolder runat="server" ID="LoginForm" Visible="false">
                <div style="margin-bottom: 10px">
                   <asp:Label runat="server" AssociatedControlID="UserName">User name</asp:Label>
                   <div>
                      <asp:TextBox runat="server" ID="UserName" />
                   </div>
                </div>
                <div style="margin-bottom: 10px">
                   <asp:Label runat="server" AssociatedControlID="Password">Password</asp:Label>
                   <div>
                      <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                   </div>
                </div>
                <div style="margin-bottom: 10px">
                   <div>
                      <asp:Button runat="server" OnClick="SignIn" Text="Log in" />
                   </div>
                </div>
             </asp:PlaceHolder>
             <asp:PlaceHolder runat="server" ID="LogoutButton" Visible="false">
                <div>
                   <div>
                      <asp:Button runat="server" OnClick="SignOut" Text="Log out" />
                   </div>
                </div>
             </asp:PlaceHolder>
          </div>
       </form>
     </div>
     <script src="~/Scripts/jquery-3.3.1.min.js"></script>
     <script src="~/Scripts/bootstrap.min.js"></script>
</body>
</html>
