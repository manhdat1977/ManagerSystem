<%@ Page Title="" Language="C#" MasterPageFile="~/Site_ver2.Master" AutoEventWireup="true" CodeBehind="hoadondieuchinh.aspx.cs" Inherits="ManagerSystem.hoadondieuchinh" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentCSS" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHeader" runat="server">
     <div class="container-fluid">
        <div class="row mb-2">
            <div class="col-sm-6">
                <h1>Hóa đơn điều chỉnh</h1>
            </div>
            <div class="col-sm-6">
                <ol class="breadcrumb float-sm-right">
                    <li class="breadcrumb-item"><a href="#">Home</a></li>
                    <li class="breadcrumb-item active">Hóa đơn điều chỉnh</li>
                </ol>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">


    <div class="row">
            <div class="col-sm-3"></div>
            <div class="col-sm-6">
                <div class="input-group input-group-md">
                    <%--<input type="text" class="form-control" name="search" placeholder="Tìm theo danh bạ, mã lộ trình hoặc địa chỉ" />--%>
                    <asp:TextBox runat="server" ID="txtSearch" CssClass="form-control" placeholder="Nhập thông tin cần tìm tại đây..." ForeColor="Black"></asp:TextBox>

                    <span class="input-group-btn">
                        <asp:Button ID="btnTim" Text="Tìm" CssClass="btn btn-danger btn-flat" runat="server" OnClick="btnTim_Click" />
                    </span>
                </div>
                <p></p>
            </div>
            <div class="col-sm-3"></div>
            <div class="col-sm-12" runat="server" id="ct" visible="true">
                <div class="card card-body pad table-responsive">
                    <div class="dataTables_wrapper form-inline dt-bootstrap">
                        <asp:GridView ID="grid_HoaDonDieuChinh" runat="server"
                            CssClass="table table-bordered table-striped dataTable"
                            AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="ma_hoa_don" HeaderText="Mã hóa đơn" />
                                <asp:BoundField DataField="landieuchinh" HeaderText="Lần điều chỉnh" />
                                <asp:BoundField DataField="sophieudieuchinh" HeaderText="Số phiếu" />
                                <asp:BoundField DataField="ngaydieuchinh" HeaderText="Ngày điều chỉnh" />
                                <asp:BoundField DataField="ky" HeaderText="Kỳ" />
                                <asp:BoundField DataField="nam" HeaderText="Năm" />
                                <asp:BoundField DataField="khachhang" HeaderText="Khách hàng" />
                                <asp:BoundField DataField="diachi1" HeaderText="Số nhà" />
                                <asp:BoundField DataField="diachi2" HeaderText="Đường" />
                                <asp:BoundField DataField="diachi_truso" HeaderText="Địa chỉ trụ sở" />
                                <asp:BoundField DataField="tieuthu" HeaderText="Tiêu thụ" />
                                <asp:BoundField DataField="tiennuoc" HeaderText="Tiền nước" />
                                <asp:BoundField DataField="ThueGTGT" HeaderText="Thuế GTGT" />
                                <asp:BoundField DataField="PhiBVMT" HeaderText="Phí BVMT" />
                                <asp:BoundField DataField="TongCong" HeaderText="Tổng cộng" />
                                <asp:BoundField DataField="SoHoaDon" HeaderText="Số hóa đơn" />
                                <asp:BoundField DataField="SoPhatHanh" HeaderText="Số phát hành" />
                                <asp:BoundField DataField="Tieuthu_DC" HeaderText="Tiêu thụ điều chỉnh" />
                                <asp:BoundField DataField="tiennuoc_dc" HeaderText="Tiền nước điều chỉnh" />
                                <asp:BoundField DataField="thueGTGT_DC" HeaderText="Thuế điều chỉnh" />
                                <asp:BoundField DataField="PhiBVMT_DC" HeaderText="Phí điều chỉnh" />
                                <asp:BoundField DataField="TongCong_DC" HeaderText="Tổng cộng" />
                            </Columns>
                            <HeaderStyle BackColor="#5976a5" Font-Bold="true" ForeColor="#ffffff" />

                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
            </form>
</asp:Content>
