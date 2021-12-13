<%@ Page Title="" Language="C#" MasterPageFile="~/Site_ver2.Master" AutoEventWireup="true"
    CodeBehind="send_sms.aspx.cs" Inherits="ManagerSystem.send_sms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentCSS" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHeader" runat="server">
    <div class="container-fluid">
        <div class="row mb-2">
            <div class="col-sm-6">
                <h1>
                    Gửi SMS</h1>
            </div>
            <div class="col-sm-6">
                <ol class="breadcrumb float-sm-right">
                    <li class="breadcrumb-item"><a href="#">Home</a></li>
                    <li class="breadcrumb-item active">Gửi SMS</li>
                </ol>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
                    <form id="Form1" runat="server">
    <div class="content">
        <div class="container-fluid">
            <div class="card card-default">
                <div class="card-body">
                    
                    <div class="col-md-12">
                        <div class="form-group row">
                            <label class="col-sm-2 col-form-label" style="text-align: right">
                                Nội dung tin nhắn</label>
                            <div class="col-md-10">
                                <input runat="server" value="TB cup nuoc: tu... gio den... gio ngay ... de cai tao ong cap nuoc tai khu vuc phuong... quan....Quy KH vui long du tru nuoc de su dung" class="form-control" id="txtNoiDung" />   
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-md-2 col-form-label" style="text-align: right">
                                Khu vực nhận tin</label>
                            <%--<asp:DropDownList CssClass="col-md-2 custom-select" ID="dropLoaiKhuVuc" runat="server">
                                <asp:ListItem Text="Vùng DMA" Value="VungDMA"></asp:ListItem>
                                <asp:ListItem Text="Quận - Phường" Value="QuanPhuong"></asp:ListItem>
                            </asp:DropDownList>--%>
                            <select class="col-md-2 custom-select" id="selectKhuVuc" runat="server">
                                <option>Vùng DMA</option>
                                <option>Quận - Phường</option>
                            </select>
                            <div class="col-md-8">
                                <%--<asp:TextBox CssClass="form-control" ID="txtKhuVuc" runat="server" placeholder="Vùng DMA: nhập tên vùng (VD: BT2102, BT1401) hoặc Quận phường: nhập mã quận+mã phường (ví dụ: 2102,1401)"></asp:TextBox>--%>
                                <input class="form-control" runat="server" id="txtKhuVuc" placeholder="Vùng DMA: nhập tên vùng (VD: BT2102, BT1401) hoặc Quận phường: nhập mã quận+mã phường (ví dụ: 2102,1401)" />
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-2 col-form-label" style="text-align: right">
                                Chọn dữ liệu</label>
                            <div class="col-md-3">
                               <%-- <asp:TextBox CssClass="form-control" ID="txtHoaDon" runat="server" placeholder="Chọn hóa đơn kỳ mới nhất đã đủ đợt (VD: HD_42021)"></asp:TextBox>--%>
                               <input type="text" class="form-control" id="txtHoaDon" runat="server" placeholder="Chọn hóa đơn kỳ mới nhất đã đủ đợt (VD: HD_42021)" />
                            </div>
                        </div>
                        <center>
                            <asp:Button ID="btnLoadData" runat="server" Text="Hiển thị dữ liệu" CssClass="btn btn-danger"
                                OnClick="btnLoadData_Click" />
                            <asp:Button runat="server" Text="Xuất ra excel" CssClass="btn btn-danger" ID="btnExportToExcel"
                                OnClick="btnExportToExcel_Click" />
                        </center>
                    </div>
                    
                    <!-- /.col -->

                    <div class="card-body table-responsive">
                        <asp:GridView runat="server" ID="gridData" 
                            CssClass="table table-hover text-nowrap" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="KHang" HeaderText="Khách hàng" />
                                <asp:BoundField DataField="dthoai_sms" HeaderText="Số điện thoại" />
                                <asp:BoundField DataField="qtt" HeaderText="Quận" />
                                <asp:BoundField DataField="ptt" HeaderText="Phường" />
                                <asp:BoundField DataField="vungdma" HeaderText="DMA" />
                                <asp:BoundField DataField="noidung" HeaderText="Nội dung tin nhắn" />
                            </Columns>
                        </asp:GridView>
                    </div>
                   </form>
                </div>
                <!-- /.row -->
            </div>
        </div>
    </div>
</asp:Content>
