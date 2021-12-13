<%@ Page Title="" Language="C#" MasterPageFile="~/Site_ver2.Master" AutoEventWireup="true" CodeBehind="exportfiletobilling.aspx.cs" Inherits="ManagerSystem.exportfiletobilling" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentCSS" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHeader" runat="server">
    <div class="container-fluid">
        <div class="row mb-2">
            <div class="col-sm-6">
                <h1>Cập nhật mã định danh</h1>
            </div>
            <div class="col-sm-6">
                <ol class="breadcrumb float-sm-right">
                    <li class="breadcrumb-item"><a href="#">Home</a></li>
                    <li class="breadcrumb-item active">Cập nhật mã định danh</li>
                </ol>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
        <div class="container-fluid">
            <div class="card">
                <div class="card-header">
                    <div class="card-title">
                        <label>Cập nhật mã định danh</label>
                    </div>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-1">
                            <asp:Button runat="server" Width="100%" ID="btnExport" Text="Export" OnClick="btnExport_Click" CssClass="btn btn-info" />

                        </div>
                        <div class="col-md-1">
                            <asp:Button runat="server" Width="100%" ID="btnViewData" Text="Xem danh sách" OnClick="btnViewData_Click" CssClass="btn btn-info" />

                        </div>
                        <div class="col-md-1">
                            <asp:Button runat="server" Width="100%" ID="btnUpdate" Text="Hủy check in" CssClass="btn btn-info" OnClick="btnUpdate_Click" />

                        </div>
                    </div>
                    <div class="row" style="margin-top:10px">
                        <asp:GridView runat="server" ID="gridData" CssClass="table table-bordered table-hover dataTable dtr-inline">
                            <HeaderStyle BackColor="#17a2b8" /> 
                        </asp:GridView>
                    </div>
                </div>
            </div>
            <div class="card">
                <div class="card-header">
                    <div class="card-title">
                        <label>Xóa mã định danh</label>
                    </div>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-1">
                            <asp:Button runat="server" Width="100%" ID="btnListDelete" Text="Export" CssClass="btn btn-danger" OnClick="btnListDelete_Click" />

                        </div>
                        <div class="col-md-1">
                            <asp:Button runat="server" Width="100%" ID="btnViewListDelete" Text="Xem danh sách" CssClass="btn btn-danger" OnClick="btnViewListDelete_Click" />

                        </div>
                        <div class="col-md-1">
                            <asp:Button runat="server" Width="100%" ID="btnHuyCheckIn" Text="Hủy check in" CssClass="btn btn-danger" OnClick="btnHuyCheckIn_Click" />

                        </div>
                    </div>
                    <div class="row" style="margin-top:10px">
                        <asp:GridView runat="server" ID="grdListDelete" CssClass="table table-bordered table-hover dataTable dtr-inline">
                            <HeaderStyle BackColor="#dc3545" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>

    </form>
</asp:Content>





