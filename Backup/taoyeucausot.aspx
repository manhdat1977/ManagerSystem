<%@ Page Title="" Language="C#" MasterPageFile="~/Site_ver2.Master" AutoEventWireup="true" CodeBehind="taoyeucausot.aspx.cs" Inherits="ManagerSystem.taoyeucausot" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentCSS" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHeader" runat="server">
    <div class="container-fluid">
        <div class="row mb-2">
            <div class="col-sm-6">
                <h1>Tạo yêu cầu</h1>
            </div>
            <div class="col-sm-6">
                <ol class="breadcrumb float-sm-right">
                    <li class="breadcrumb-item"><a href="#">Home</a></li>
                    <li class="breadcrumb-item active">Tạo yêu cầu</li>
                </ol>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
        <div class="card card-primary">
            <div class="form-horizontal" runat="server">
                <div class="card-body">
                    <div class="form-group row">
                        <label class="col-md-1 col-form-label" style="text-align: right">Số phiếu</label>
                        <div class="col-md-1">
                            <asp:TextBox runat="server" ID="txtSoPhieu" CssClass="form-control"></asp:TextBox>
                        </div>
                        <asp:Label class="col-md-2 col-form-label" Style="text-align: left" runat="server" ID="lblSoPhieu"></asp:Label>
                        <label class="col-md-1 col-form-label" style="text-align: right">Danh bạ</label>
                        <div class="col-md-2">
                            <div class="input-group input-group-md">
                                <asp:TextBox CssClass="form-control" ID="txtDba" runat="server"></asp:TextBox>
                                <span class="input-group-append">
                                    <asp:Button Width="100%" ID="btnDba" class="btn btn-info btn-flat" runat="server" Text="Tìm" OnClick="btnDba_Click" />
                                </span>
                            </div>
                        </div>
                        <label class="col-md-1 col-form-label" style="text-align: right">MLT</label>
                        <div class="col-md-1">
                            <asp:TextBox runat="server" ID="txtMLT" CssClass="form-control" Enabled="false"></asp:TextBox>
                        </div>

                    </div>
                    <div class="form-group row">
                        <label class="col-md-1 col-form-label" style="text-align: right">Khách hàng</label>
                        <div class="col-md-5">
                            <asp:TextBox runat="server" ID="txtKH" CssClass="form-control" Enabled="false"></asp:TextBox>
                        </div>
                        <label class="col-md-1 col-form-label" style="text-align: right">Địa chỉ</label>
                        <div class="col-md-5">
                            <asp:TextBox runat="server" ID="txtDC" CssClass="form-control" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-md-1 col-form-label" style="text-align: right">Người báo</label>
                        <div class="col-md-2">
                            <asp:TextBox runat="server" ID="txtNguoiBao" CssClass="form-control"></asp:TextBox>
                        </div>
                        <label class="col-md-1 col-form-label" style="text-align: right">SĐT</label>
                        <div class="col-md-2">
                            <asp:TextBox runat="server" ID="txtSDT" CssClass="form-control"></asp:TextBox>
                        </div>
                        <label class="col-md-1 col-form-label" style="text-align: right">Nội dung</label>
                        <div class="col-md-2">
                            <asp:TextBox runat="server" ID="txtNoiDung" CssClass="form-control"></asp:TextBox>
                        </div>
                        <label class="col-md-1 col-form-label" style="text-align: right">Ghi chú</label>
                        <div class="col-md-2">
                            <asp:TextBox runat="server" ID="txtGhiChu" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="card-footer" style="text-align: center">
                    <asp:Button CssClass="btn btn-primary" runat="server" ID="btnCapNhat" Text="Cập nhật" OnClick="btnCapNhat_Click" />
                </div>


            </div>
        </div>
    </form>
</asp:Content>
