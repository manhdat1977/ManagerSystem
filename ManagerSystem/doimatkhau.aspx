<%@ Page Title="" Language="C#" MasterPageFile="~/Site_ver2.Master" AutoEventWireup="true" CodeBehind="doimatkhau.aspx.cs" Inherits="ManagerSystem.doimatkhau" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentCSS" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHeader" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
<div class="row">
        <div class="col-md-3"></div>
    <div class="col-md-6">
         <div class="input-group input-group-md">
            <%--<input type="text" class="form-control" name="search" placeholder="Tìm theo danh bạ, mã lộ trình hoặc địa chỉ" />--%>
            <asp:TextBox runat="server" ID="txtDoiMK" CssClass="form-control" 
                 placeholder="Nhập mật khẩu mới tại đây" TextMode="Password"></asp:TextBox>
            <span class="input-group-btn">
            <asp:Button ID="btn_DoiMK" CssClass="btn btn-danger btn-flat" runat="server" 
                 Text="Cập nhật" onclick="btn_DoiMK_Click" />
        </span>
    </div>
    <p></p>
    </div>
    <div class="col-md-3"></div>
</div>
    </form>

</asp:Content>
