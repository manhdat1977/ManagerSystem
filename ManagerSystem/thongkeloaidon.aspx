<%@ Page Title="" Language="C#" MasterPageFile="~/Site_ver2.Master" AutoEventWireup="true" CodeBehind="thongkeloaidon.aspx.cs" Inherits="ManagerSystem.thongkeloaidon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentCSS" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHeader" runat="server">
    <div class="container-fluid">
        <div class="row mb-2">
            <div class="col-sm-6">
                <h1>Thống kê khiếu nại - điều chỉnh định mức</h1>
            </div>
            <div class="col-sm-6">
                <ol class="breadcrumb float-sm-right">
                    <li class="breadcrumb-item"><a href="#">Home</a></li>
                    <li class="breadcrumb-item active">Sổ nhận đơn</li>
                </ol>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-6">
                    <div class="card card-danger">
                        <div class="card-header">
                            <h3 class="card-title">Chọn ngày thống kê</h3>
                        </div>
                        <div class="card-body">
                            <div class="form-group">
                                <label>Từ ngày:</label>
                                <div class="input-group">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="far fa-calendar-alt"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtTuNgay" placeholder="DD/MM/YYYY" onfocus="(this.type='date')" onblur="(this.type='text')"></asp:TextBox>
                                </div>
                                <!-- /.input group -->
                            </div>
                            <div class="form-group">
                                <label>Đến ngày:</label>
                                <div class="input-group">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="far fa-calendar-alt"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtDenNgay" placeholder="DD/MM/YYYY" onfocus="(this.type='date')" onblur="(this.type='text')"></asp:TextBox>
                                </div>
                                <!-- /.input group -->
                            </div>
                            <div class="card-footer">
                                <asp:Button runat="server" ID="btnSubmit" Text="OK"
                                    CssClass="btn btn-danger pull-right" OnClick="btnSubmit_Click" />
                                <%--<button type="submit" class="btn btn-info pull-right" id="btn" runat="server">Sign in</button>--%>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="card card-danger">
                        <div class="card-header">
                            <h3 class="card-title">Kết quả</h3>
                        </div>
                        <div runat="server" class="form-horizontal">
                            <div class="card-body">
                                <div class="form-group">
                                    <label class="col-sm-4 control-label">Đơn khiếu nại: </label>
                                    <div class="col-sm-8 control-label">
                                        <asp:Label runat="server" ID="lblDKN" Text="" CssClass="pull-left" Font-Bold="true"></asp:Label>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-4 control-label">Đã giải quyết: </label>
                                    <div class="col-sm-8 control-label">
                                        <asp:Label runat="server" ID="lblDonChuyenPBD" Text="" CssClass="pull-left" Font-Bold="true"></asp:Label>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-4 control-label">Sang tên-Định mức: </label>
                                    <div class="col-sm-8 control-label">
                                        <asp:Label runat="server" ID="lblSTDM" Text="" CssClass="pull-left" Font-Bold="true"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
