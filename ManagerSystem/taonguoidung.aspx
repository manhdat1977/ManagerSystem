<%@ Page Title="" Language="C#" MasterPageFile="~/Site_ver2.Master" AutoEventWireup="true" CodeBehind="taonguoidung.aspx.cs" Inherits="ManagerSystem.taonguoidung" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentCSS" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHeader" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <div class="box box-info">
                        <div class="card card-primary">
                            <div class="card card-header">
                                <h3 class="card-title">Đăng ký thông tin người dùng</h3>
                            </div>
                            <form role="form" runat="server">
                                <div class="card-body">
                                    <div class="form-group">
                                        <label class="col-md-4 control-label">Họ tên</label>
                                        <div class="col-md-4">
                                            <asp:TextBox CssClass="form-control" runat="server" ID="txtHoTen" required></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-4 control-label">Tài khoản</label>
                                        <div class="col-md-4">
                                            <asp:TextBox CssClass="form-control" runat="server" ID="txtUser" required></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-4 control-label">Mật khẩu</label>
                                        <div class="col-md-4">
                                            <asp:TextBox CssClass="form-control" runat="server" ID="txtPass" TextMode="Password" required></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-4 control-label">Phân quyền</label>
                                        <div class="col-md-4">
                                            <asp:DropDownList ID="dropPermission" runat="server" CssClass="form-control">
                                                <asp:ListItem Text="KTV"></asp:ListItem>
                                                <asp:ListItem Text="NVVP-CSKH"></asp:ListItem>
                                                <asp:ListItem Text="NVVP-KT"></asp:ListItem>
                                                <asp:ListItem Text="TT-CSKH"></asp:ListItem>
                                                <asp:ListItem Text="TT-KT"></asp:ListItem>
                                                <asp:ListItem Text="TP-PP"></asp:ListItem>
                                                <asp:ListItem Text="PBD"></asp:ListItem>
                                                <asp:ListItem Text="Admin"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="card-footer">
                                    <asp:Button ID="btnOK" runat="server" Text="OK" CssClass="btn btn-primary"
                                        OnClick="btnOK_Click" />
                                    <label class="control-label" runat="server" id="success">Tạo người dùng thành công</label>
                                    <label class="control-label" runat="server" id="error">Tạo người dùng thất bại</label>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
