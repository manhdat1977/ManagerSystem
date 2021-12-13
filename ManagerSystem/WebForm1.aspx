<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ManagerSystem.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form runat="server">
<asp:FileUpload ID="FileUpload1" runat="server" />
<br /><br />
<asp:Button runat="server" ID="btnUpload" Text="Upload" OnClick="btnUpload_Click" />
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    <asp:HyperLink ID="hyperlink" runat="server">View Uploaded Image</asp:HyperLink>

    </form>

</body>
</html>
