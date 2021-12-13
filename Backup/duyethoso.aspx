<%@ Page Title="" Language="C#" MasterPageFile="~/Site_ver2.Master" AutoEventWireup="true"
    CodeBehind="duyethoso.aspx.cs" Inherits="ManagerSystem.duyethoso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentCSS" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHeader" runat="server">
    <div class="container-fluid">
        <div class="row mb-2">
            <div class="col-sm-6">
                <h1>
                    Danh sách hồ sơ kiểm tra</h1>
            </div>
            <div class="col-sm-6">
                <ol class="breadcrumb float-sm-right">
                    <li class="breadcrumb-item"><a href="#">Home</a></li>
                    <li class="breadcrumb-item active">Danh sách hồ sơ kiểm tra</li>
                </ol>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <div class="card card-info">
                    <div class="card-body">
                        <div class="form-group row">
                            <asp:Button CssClass="btn btn-success" data-toggle="modal" data-target="#modal-default"
                                runat="server" Text="Hồ sơ đã duyệt" ID="btnDuyet" OnClick="btnDuyet_Click" />
                            <asp:Button CssClass="btn btn-danger" data-toggle="modal" data-target="#modal-default"
                                runat="server" Text="Hồ sơ chưa duyệt" ID="btnChuaDuyet" OnClick="btnChuaDuyet_Click" />
                        </div>
                        <div class="row" id="TimHSDuyet" runat="server">
                            <div class="col-md-3">
                                <asp:TextBox runat="server" ID="txtSearchDbo" CssClass="form-control" Visible="false"></asp:TextBox>
                            </div>
                            <asp:Button runat="server" ID="btnSearch" CssClass="btn btn-success" Text="Tìm danh bạ"
                                Visible="false" OnClick="btnSearch_Click" />
                            <asp:Button runat="server" ID="btnSearchChuaDuyet" CssClass="btn btn-danger" Text="Tìm danh bạ"
                                Visible="false" OnClick="btnSearchChuaDuyet_Click" />
                        </div>
                        <div class="table-responsive">
                            <asp:GridView ID="gridDuyet" AllowPaging="True" runat="server" CssClass="table dataTables_wrapper form-inline dt-bootstrap"
                                AutoGenerateColumns="False" DataKeyNames="ID" Visible="False" OnPageIndexChanging="gridDuyet_PageIndexChanging"
                                HeaderStyle-BackColor="#205081" HeaderStyle-ForeColor="White">
                                <Columns>
                                    <asp:BoundField DataField="NoiDung" HeaderText="Nội dung duyệt" />
                                    <asp:BoundField DataField="NgayDuyet" HeaderText="Ngày duyệt" />
                                    <asp:BoundField DataField="MaSNDon" HeaderText="Mã đơn" />
                                    <asp:BoundField DataField="NguoiChuyenHS" HeaderText="Người chuyển HS" />
                                    <asp:BoundField DataField="NgayChuyenHS" HeaderText="Ngày chuyển HS" />
                                    <asp:BoundField DataField="NguoiDuyet" HeaderText="Người duyệt" />
                                </Columns>
                                <PagerSettings PageButtonCount="15" />
                                <PagerStyle CssClass="pagination-ys" />
                            </asp:GridView>
                            <asp:GridView ID="gridChuaDuyet" AllowPaging="true" PageSize="10" runat="server"
                                CssClass="table dataTables_wrapper form-inline dt-bootstrap" AutoGenerateColumns="False"
                                DataKeyNames="MaSNDon" Visible="False" HeaderStyle-BackColor="#dd4b39" HeaderStyle-ForeColor="White"
                                OnRowCommand="gridChuaDuyet_RowCommand" OnPageIndexChanging="gridChuaDuyet_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField DataField="NDKNai" HeaderText="Nội dung khiếu nại" />
                                    <asp:BoundField DataField="MaNVKtra" HeaderText="Nhân viên kiểm tra" />
                                    <asp:BoundField DataField="NgayChuyenHS" HeaderText="Ngày chuyển" />
                                    <asp:BoundField DataField="NguoiChuyenHS" HeaderText="Người chuyển" />
                                    <asp:CommandField ShowSelectButton="True" SelectText="Chi tiết" />
                                </Columns>
                                <PagerSettings PageButtonCount="15" />
                                <PagerStyle CssClass="pagination-ys" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-12" id="divcontent" runat="server" visible="false">
                <div class="card card-danger">
                    <div class="card-header with-border">
                        <h3 class="card-title">
                            Thông tin hồ sơ</h3>
                        <asp:Label runat="server" ID="txtID" Visible="false"></asp:Label>
                    </div>
                    <div class="card-body">
                        <div class="form-group row">
                            <label class="col-md-1 col-form-label" style="text-align: right">
                                Danh bạ</label>
                            <div class="col-md-2">
                                <asp:TextBox runat="server" ID="txtDba" CssClass="form-control" Enabled="false" Font-Bold="true"></asp:TextBox>
                            </div>
                            <label class="col-md-1 col-form-label" style="text-align: right">
                                Số đơn</label>
                            <div class="col-md-2">
                                <asp:TextBox runat="server" ID="txtSoDon" CssClass="form-control" Enabled="false"
                                    Font-Bold="true"></asp:TextBox>
                            </div>
                            <label class="col-md-1 col-form-label" style="text-align: right">
                                Loại đơn</label>
                            <div class="col-md-2">
                                <asp:TextBox runat="server" ID="txtLDon" CssClass="form-control" Enabled="false"
                                    Font-Bold="true"></asp:TextBox>
                            </div>
                            <label class="col-md-1 col-form-label" style="text-align: right">
                                Ngày cấp</label>
                            <div class="col-md-1">
                                <asp:TextBox runat="server" ID="txtNgayCapBN" CssClass="form-control" Enabled="false"
                                    Font-Bold="true"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="card-body">
                        <div class="form-group row">
                            <label class="col-md-1 col-form-label" style="text-align: right">
                                Khách hàng</label>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtKH" runat="server" CssClass="form-control" Enabled="false" ForeColor="#000"
                                    Font-Bold="true"></asp:TextBox>
                            </div>
                            <label class="col-md-1 col-form-label" style="text-align: right">
                                Địa chỉ</label>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtDC" runat="server" CssClass="form-control" Enabled="false" ForeColor="#000"
                                    Font-Bold="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-md-1 col-form-label" style="text-align: right">
                                Nội dung đơn</label>
                            <div class="col-md-10">
                                <asp:TextBox ID="txtNoidungDon" runat="server" CssClass="form-control" Enabled="false"
                                    ForeColor="#000" Font-Bold="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-md-1 col-form-label" style="text-align: right">
                                Nội dung biên bản</label>
                            <div class="col-md-10">
                                <asp:TextBox ID="txtNDBienBan" runat="server" CssClass="form-control" Enabled="false"
                                    TextMode="MultiLine" ForeColor="#000" Font-Bold="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-md-1 col-form-label" style="text-align: right">
                                Đề xuất xử lý</label>
                                <div class=col-md-10">
                                <asp:TextBox CssClass="form-control" ID="txtDeXuat" runat="server" Enabled="false"></asp:TextBox>
                                </div>
                            
                        </div>
                        <div class="form-group row">
                            <label class="col-md-1 col-form-label" style="text-align: right">
                                Nội dung xử lý</label>
                            <div class="col-md-10">
                                <asp:TextBox CssClass="form-control" ID="txtNDXuLy" runat="server"></asp:TextBox></div>
                        </div>
                    </div>
                    <div class="form-group">
                        <center>
                            <asp:Button runat="server" CssClass="btn btn-danger" Text="Lưu" ID="btnLuu" OnClick="btnLuu_Click" /></center>
                    </div>
                    <%--Display image--%>
                    <div class="box-body">
                        <div class="dataTables_wrapper form-inline dt-bootstrap">
                            <asp:GridView runat="server" ID="gridImage" CssClass="table table-bordered table-hover dataTable"
                                DataKeyNames="ID" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC"
                                BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                <Columns>
                                    <asp:HyperLinkField DataTextField="NgayCapNhat" DataNavigateUrlFields="ID" HeaderText="Hình ảnh"
                                        Target="_blank" DataNavigateUrlFormatString="~/GetPic.aspx?Id={0}" />
                                </Columns>
                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                <RowStyle ForeColor="#000066" />
                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#00547E" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</asp:Content>
