<%@ Page Title="" Language="C#" MasterPageFile="~/Site_ver2.Master" AutoEventWireup="true" CodeBehind="capnhatsdt.aspx.cs" Inherits="ManagerSystem.capnhatsdt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentCSS" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHeader" runat="server">
    <div class="container-fluid">
        <div class="row mb-2">
            <div class="col-sm-6">
                <h1>Cập nhật số điện thoại</h1>
            </div>
            <div class="col-sm-6">
                <ol class="breadcrumb float-sm-right">
                    <li class="breadcrumb-item"><a href="#">Home</a></li>
                    <li class="breadcrumb-item active">Cập nhật số điện thoại</li>
                </ol>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <div class="card card-blue">
                        <div class="card-body">
                            <div class="form-group">
                                <label>Danh bạ</label>
                                <%--
                                --%>
                                <div class="input-group input-group-md">
                                    <asp:TextBox runat="server" ID="txtDba" CssClass="form-control col-md-2"></asp:TextBox>
                                    <span class="input-group-append">
                                        <asp:Button runat="server" Text="Tìm kiếm" CssClass="btn btn-danger" ID="btnTimKiem" OnClick="btnTimKiem_Click" />
                                    </span>
                                </div>
                            </div>
                            <div class="form-group">
                                <label>Số điện thoại</label>
                                <asp:TextBox runat="server" ID="txtSDT" CssClass="form-control col-md-2" Enabled="false"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>Số điện thoại mới</label>
                                <asp:TextBox runat="server" ID="txtSDT_Moi" CssClass="form-control col-md-2"></asp:TextBox>
                            </div>
                        </div>
                        <div class="card-footer">
                            <asp:Button runat="server" Text="Cập nhật" CssClass="btn btn-danger" ID="btnCapNhat" OnClick="btnCapNhat_Click" />
                            <asp:Label runat="server" Visible="false" ForeColor="Red" ID="lblStatus"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

</asp:Content>
