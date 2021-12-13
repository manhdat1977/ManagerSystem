<%@ Page Title="" Language="C#" MasterPageFile="~/Site_ver2.Master" AutoEventWireup="true" CodeBehind="boithuong.aspx.cs" Inherits="ManagerSystem.boithuong" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentCSS" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHeader" runat="server">
    <div class="container-fluid">
        <div class="row mb-2">
            <div class="col-sm-6">
                <h1>Lập chiết tính bồi thường đồng hồ nước</h1>
            </div>
            <div class="col-sm-6">
                <ol class="breadcrumb float-sm-right">
                    <li class="breadcrumb-item"><a href="#">Home</a></li>
                    <li class="breadcrumb-item active">Bồi thường</li>
                </ol>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <form runat="server">
            <div class="row">
                <div class="col-md-12">
                    <div class="card card-info">
                        <div class="card-header">
                            <h3 class="card-title">Thông tin đơn thư nhận</h3>
                        </div>
                        <div class="form-horizontal">
                            <div class="card-body">
                                <div class="form-group row">
                                    <label class="col-md-1 col-form-label">Nhập mã đơn</label>
                                    <div class="col-md-10">
                                        <%--<asp:TextBox ID="txtKey" CssClass="form-control" runat="server" placeholder="Mã đơn gồm: Danh bạ - Số đơn - Loại đơn - Ngày nhận đơn"></asp:TextBox>                          --%>
                                        <div class="row">
                                            <div class="col-md-2">
                                                <asp:TextBox ID="txtDbo" CssClass="form-control input-sm" runat="server" placeholder="Danh bạ"
                                                    required ForeColor="#000" Font-Bold="true"></asp:TextBox>
                                            </div>
                                            <div class="col-md-1">
                                                <asp:TextBox ID="txtSdon" CssClass="form-control input-sm" runat="server" placeholder="Số đơn"
                                                    required ForeColor="#000" Font-Bold="true"></asp:TextBox>
                                            </div>
                                            <div class="col-md-1">
                                                <%--<asp:TextBox ID="txtLdon" CssClass="form-control" runat="server" placeholder="Loại đơn"></asp:TextBox>--%>
                                                <asp:DropDownList runat="server" ID="dropLoaiDon" CssClass="form-control input-sm" Width="100%"
                                                    Font-Bold="true" ForeColor="#000">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-md-2">
                                                <%--<asp:TextBox ID="datemask" CssClass="form-control pull-right" runat="server" data-inputmask="'alias': 'dd/mm/yyyy'"></asp:TextBox>--%>
                                                <%--<input runat="server" type="text" class="form-control" id="txtNgayCapBN" name="txtNgayCapBN"
                                                    placeholder="Ngày cấp BN" required style="color: #000; font-weight: bold" />--%>
                                                <asp:TextBox runat="server" required CssClass="form-control" ID="txtNgayCapBN" placeholder="Ngày cấp biên nhận" onfocus="(this.type='date')" onblur="(this.type='text')" Font-Bold="true"></asp:TextBox>
                                            </div>
                                            <div class="col-md-1">
                                                <asp:Button runat="server" Text="Tìm kiếm" ID="btnOK" CssClass="btn btn-info" Width="100%" />
                                            </div>
                                            <div class="col-md-1">
                                                <asp:Button runat="server" Text="Làm lại" ID="btnclear" CssClass="btn btn-info" Width="100%" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group row">

                                    <label class="col-md-1 col-form-label">
                                        Khách hàng</label>
                                    <div class="col-md-5">
                                        <asp:TextBox ID="txtKH" runat="server" CssClass="form-control" Enabled="false"
                                            ForeColor="#000" Font-Bold="true"></asp:TextBox>
                                    </div>
                                    <label class="col-md-1 col-form-label" style="text-align: right">
                                        Địa chỉ</label>
                                    <div class="col-sm-5">
                                        <asp:TextBox ID="txtDC" runat="server" CssClass="form-control" Enabled="false"
                                            ForeColor="#000" Font-Bold="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-md-1 col-form-label">
                                        Mã bồi thường</label>
                                    <div class="col-md-3">
                                        <asp:DropDownList runat="server" CssClass="form-control" ID="dropMaBoiThuong"></asp:DropDownList>
                                    </div>
                                    <label class="col-md-1 col-form-label" style="text-align: right">
                                        Điện thoại</label>
                                    <div class="col-sm-2">
                                        <asp:TextBox ID="txtDienThoai" runat="server" CssClass="form-control"
                                            ForeColor="#000" Font-Bold="true"></asp:TextBox>
                                    </div>
                                    <label class="col-md-1 col-form-label" style="text-align: right">
                                        Ngày lập</label>
                                    <div class="col-sm-2">
                                        <asp:TextBox ID="txtNgayLap" runat="server" CssClass="form-control"
                                            ForeColor="#000" Font-Bold="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-md-1 col-form-label">
                                        Lí do BT</label>
                                    <div class="col-sm-3">
                                        <asp:DropDownList runat="server" CssClass="form-control" ID="dropLiDo">
                                            <asp:ListItem Text="01. Bảo quản"></asp:ListItem>
                                            <asp:ListItem Text="02. Xây dựng"></asp:ListItem>
                                            <asp:ListItem Text="03. Gian lận"></asp:ListItem>
                                            <asp:ListItem Text="04. Khác"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <label class="col-md-1 col-form-label" style="text-align: right">
                                        Nội dung BT</label>
                                    <div class="col-md-2">
                                        <asp:TextBox ID="txtNoiDungBT" runat="server" CssClass="form-control"
                                            ForeColor="#000" Font-Bold="true"></asp:TextBox>
                                    </div>
                                    <label class="col-md-1 col-form-label" style="text-align: right">
                                        Ghi chú</label>
                                    <div class="col-md-2">
                                        <asp:TextBox ID="txtGhiChu" runat="server" CssClass="form-control" ForeColor="#000"
                                            Font-Bold="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="custom-file col-md-3">
                                        <asp:FileUpload runat="server" ID="uploadFile" />

                                        <%--<input type="file" class="custom-file-input" id="customFile" runat="server">
                                        <label class="custom-file-label" for="customFile">Đính kèm file</label>--%>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:Button runat="server" CssClass="btn btn-danger" Text="Upload file" ID="btnUpload" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </div>
</asp:Content>
