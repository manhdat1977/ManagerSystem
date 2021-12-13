<%@ Page Title="" Language="C#" MasterPageFile="~/Site_ver2.Master" AutoEventWireup="true" CodeBehind="hethan.aspx.cs" Inherits="ManagerSystem.hethan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentCSS" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHeader" runat="server">
    <div class="container-fluid">
        <div class="row mb-2">
            <div class="col-sm-6">
                <h1>Danh sách hết hạn</h1>
            </div>
            <div class="col-sm-6">
                <ol class="breadcrumb float-sm-right">
                    <li class="breadcrumb-item"><a href="#">Home</a></li>
                    <li class="breadcrumb-item active">Danh sách hết hạn</li>
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
                    <div class="card card-primary">
                        <div class="form-horizontal">
                            <div class="card-body">
                                <div class="form-group row">
                                    <asp:DropDownList runat="server" CssClass="form-control col-md-1" ID="dropTimKiem" AutoPostBack="true" OnSelectedIndexChanged="dropTimKiem_SelectedIndexChanged">
                                        <asp:ListItem Text="Tìm theo..."></asp:ListItem>
                                        <asp:ListItem Text="Danh bạ"></asp:ListItem>
                                        <asp:ListItem Text="Ngày hết hạn"></asp:ListItem>
                                    </asp:DropDownList>
                                    <div class="col-md-3">
                                        <div class="input-group input-group-md">
                                            <asp:TextBox runat="server" ID="txtDbo" CssClass="form-control"></asp:TextBox>
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" runat="server" id="iconDate" visible="false" ><i class="far fa-calendar-alt"></i></span>
                                            </div>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtNgayHetHan" Visible="false" placeholder="DD/MM/YYYY" onfocus="(this.type='date')" onblur="(this.type='text')"></asp:TextBox>
                                            <span class="input-group-append">
                                                <asp:Button CssClass="btn btn-info btn-flat" OnClick="btnTimKiem_Click" runat="server" ID="btnTimKiem" Text="Tìm kiếm" Width="100%" />
                                            </span>
                                        </div>
                                    </div>

                                </div>
                                <div class="form-group row">
                                    <label class="col-md-1 col-form-label">Ngày cập nhật</label>
                                    <div class="input-group col-md-4">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text"><i class="far fa-calendar-alt"></i></span>
                                        </div>
                                        <asp:TextBox runat="server" CssClass="form-control" ID="datepicker1" placeholder="DD/MM/YYYY" onfocus="(this.type='date')" onblur="(this.type='text')"></asp:TextBox>
                                        <%--<input type="text" class="js-date form-control" maxlength="10" name="datepicker1" id="datepicker1" />--%>
                                    </div>
                                    <div class="col-md-1">
                                        <asp:Button runat="server" Text="Xem danh sách" CssClass="btn btn-info" ID="OK" OnClick="OK_Click" Width="100%" />
                                    </div>
                                    <div class="col-md-1">
                                        <asp:Button runat="server" Text="Export" CssClass="btn btn-info" ID="btnExport" OnClick="btnExport_Click" Width="100%" />
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <asp:GridView ID="grd_DS_HetHan" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered">
                                        <Columns>
                                            <asp:BoundField DataField="DBo" HeaderText="Danh bạ" />
                                            <asp:BoundField DataField="MaLT" HeaderText="MLT" />
                                            <asp:BoundField DataField="DThoai" HeaderText="Điện thoại" />
                                            <asp:BoundField DataField="KH" HeaderText="Khách hàng" />
                                            <asp:BoundField DataField="DC" HeaderText="Địa chỉ" />
                                            <asp:BoundField DataField="MaLoaiSo" HeaderText="Loại sổ" />
                                            <asp:BoundField DataField="MaNKhau" HeaderText="Số chứng từ" />
                                            <asp:BoundField DataField="TSNKhau" HeaderText="Tổng nhân khẩu" />
                                            <asp:BoundField DataField="NKDCap" HeaderText="Nhân khẩu được cấp" />
                                            <asp:BoundField DataField="NgayHetHan" HeaderText="Ngày hết hạn" DataFormatString="{0:dd/MM/yyyy}" />
                                            <asp:BoundField DataField="SoPhong" HeaderText="Số phòng" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
