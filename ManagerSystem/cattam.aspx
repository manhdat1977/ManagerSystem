<%@ Page Title="" Language="C#" MasterPageFile="~/Site_ver2.Master" AutoEventWireup="true" CodeBehind="cattam.aspx.cs" Inherits="ManagerSystem.cattam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentCSS" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHeader" runat="server">
    <div class="container-fluid">
        <div class="row mb-2">
            <div class="col-sm-6">
                <h1>Cắt tạm</h1>
            </div>
            <div class="col-sm-6">
                <ol class="breadcrumb float-sm-right">
                    <li class="breadcrumb-item"><a href="#">Home</a></li>
                    <li class="breadcrumb-item active">Cắt tạm</li>
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
            <div class="col-sm-12" runat="server" id="ct" visible="false">
                <div class="card card-body pad table-responsive">
                    <div class="dataTables_wrapper form-inline dt-bootstrap">
                        <asp:GridView ID="grid_Cattam" runat="server"
                            CssClass="table table-bordered table-striped dataTable"
                            AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="NamLap" HeaderText="Năm" />
                                <asp:BoundField DataField="SoBK" HeaderText="Số bảng kê" />
                                <asp:BoundField DataField="bandoi" HeaderText="PBĐ" />
                                <asp:BoundField DataField="danhba" HeaderText="Danh bạ" />
                                <asp:BoundField DataField="mlt" HeaderText="MLT" />
                                <asp:BoundField DataField="tenkh" HeaderText="Khách hàng" />
                                <asp:BoundField DataField="diachi" HeaderText="Địa chỉ" />
                                <asp:BoundField DataField="thongtindocso" HeaderText="Thông tin đọc số" />
                                <asp:BoundField DataField="thongtinno" HeaderText="Thông tin nợ" />
                                <asp:BoundField DataField="trongai" HeaderText="Trở ngại" />
                                <asp:BoundField DataField="ngaycapnhat" HeaderText="Ngày cập nhật" />
                                <asp:BoundField DataField="ghichuhoancong" HeaderText="Ghi chú hoàn công" />
                            </Columns>
                            <HeaderStyle BackColor="#5976a5" Font-Bold="true" ForeColor="#ffffff" />

                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>

    </form>

</asp:Content>
