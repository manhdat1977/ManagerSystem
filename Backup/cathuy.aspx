<%@ Page Title="" Language="C#" MasterPageFile="~/Site_ver2.Master" AutoEventWireup="true" CodeBehind="cathuy.aspx.cs" Inherits="ManagerSystem.cathuy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentCSS" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHeader" runat="server">
        <div class="container-fluid">
        <div class="row mb-2">
            <div class="col-sm-6">
                <h1>Cắt hủy</h1>
            </div>
            <div class="col-sm-6">
                <ol class="breadcrumb float-sm-right">
                    <li class="breadcrumb-item"><a href="#">Home</a></li>
                    <li class="breadcrumb-item active">Cắt hủy</li>
                </ol>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
        <div class="row">
            <div class="col-sm-3"></div>
            <div class="col-sm-2">
                <asp:DropDownList runat="server" ID="dropSearch" CssClass="form-control" ForeColor="Black" Font-Bold="true">
                    <asp:ListItem Text="Tìm theo..."></asp:ListItem>
                    <asp:ListItem Text="Danh bạ"></asp:ListItem>
                    <asp:ListItem Text="Địa chỉ"></asp:ListItem>
                    <asp:ListItem Text="Mã lộ trình"></asp:ListItem>
                    <asp:ListItem Text="Tên khách hàng"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-sm-4">
                <div class="input-group input-group-md">
                    <%--<input type="text" class="form-control" name="search" placeholder="Tìm theo danh bạ, mã lộ trình hoặc địa chỉ" />--%>
                    <asp:TextBox runat="server" ID="txtSearch" CssClass="form-control" placeholder="Nhập thông tin cần tìm tại đây..." ForeColor="Black"></asp:TextBox>

                    <span class="input-group-btn">
                        <asp:Button ID="btnTim" CssClass="btn btn-danger btn-flat" runat="server"
                            Text="Tìm" OnClick="btnTim_Click" />
                    </span>
                </div>
                <p></p>
            </div>
            <div class="col-sm-3"></div>
            <div class="col-sm-12" runat="server" id="ch" visible="false">
                <div class="card card-body pad table-responsive">
                    <div class="dataTables_wrapper form-inline dt-bootstrap">
                        <asp:GridView ID="grid_Cathuy" runat="server"
                            CssClass="table table-bordered table-striped dataTable"
                            AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="NamLapPhieu" HeaderText="Năm" />
                                <asp:BoundField DataField="NgayLapPhieu" HeaderText="Ngày lập" />
                                <asp:BoundField DataField="NgayCatHuy" HeaderText="Ngày cắt hủy" />
                                <asp:BoundField DataField="KyHluc" HeaderText="Hiệu lực" />
                                <asp:BoundField DataField="SoPhieu" HeaderText="Số phiếu" />
                                <asp:BoundField DataField="Dbo" HeaderText="Danh bạ" />
                                <asp:BoundField DataField="LT" HeaderText="MLT" />
                                <asp:BoundField DataField="HoTen" HeaderText="Khách hàng" />
                                <asp:BoundField DataField="DiaChi" HeaderText="Địa chỉ" />
                                <asp:BoundField DataField="CSoGo" HeaderText="Chỉ số gỡ" />
                                <asp:BoundField DataField="LyDoLLenhCat" HeaderText="Lý do cắt" />
                                <asp:BoundField DataField="HThucCat" HeaderText="Hình thức cắt" />
                                <asp:BoundField DataField="TTCatHuy" HeaderText="Thông tin cắt hủy" />
                            </Columns>
                            <HeaderStyle BackColor="#5976a5" Font-Bold="true" ForeColor="#ffffff" />

                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </form>

</asp:Content>
