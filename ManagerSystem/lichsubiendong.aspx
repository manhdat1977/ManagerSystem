<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="lichsubiendong.aspx.cs" Inherits="ManagerSystem.lichsubiendong" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lịch sử biến động</title>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <!-- Tell the browser to be responsive to screen width -->
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- Font Awesome -->
    <link rel="stylesheet" href="plugins/fontawesome-free/css/all.min.css">
    <!-- Ionicons -->
    <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css">
    <!-- Tempusdominus Bbootstrap 4 -->
    <link rel="stylesheet" href="plugins/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css">
    <!-- iCheck -->
    <link rel="stylesheet" href="plugins/icheck-bootstrap/icheck-bootstrap.min.css">
    <!-- JQVMap -->
    <link rel="stylesheet" href="plugins/jqvmap/jqvmap.min.css">
    <!-- Theme style -->
    <link rel="stylesheet" href="dist/css/adminlte.min.css">
    <!-- overlayScrollbars -->
    <link rel="stylesheet" href="plugins/overlayScrollbars/css/OverlayScrollbars.min.css">
    <!-- Daterange picker -->
    <link rel="stylesheet" href="plugins/daterangepicker/daterangepicker.css">

    <!-- summernote -->
    <link rel="stylesheet" href="plugins/summernote/summernote-bs4.css">
    <!-- Google Font: Source Sans Pro -->
    <link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView DataKeyNames="Id" runat="server" CssClass="table table-bordered table-hover dataTable" ID="grid_LichSuBienDong" AutoGenerateColumns="False" OnRowCommand="grid_LichSuBienDong_RowCommand" OnRowDeleting="grid_LichSuBienDong_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="SDon" HeaderText="Số đơn" />
                    <asp:BoundField DataField="LDon" HeaderText="Loại đơn" />
                    <asp:BoundField DataField="NgayNhapDc" HeaderText="Ngày nhập" />
                    <asp:BoundField DataField="SBKeBD" HeaderText="Bảng kê" />
                    <asp:BoundField DataField="HLucBD" HeaderText="Hiệu lực" />
                    <asp:BoundField DataField="MLTrinh" HeaderText="MLT" />
                    <asp:BoundField DataField="KHang" HeaderText="Khách hàng" />
                    <asp:BoundField DataField="KHangDC" HeaderText="KH điều chỉnh" />
                    <asp:BoundField DataField="DChi" HeaderText="Địa chỉ" />
                    <asp:BoundField DataField="DChiDc" HeaderText="Địa chỉ điều chỉnh" />
                    <asp:BoundField DataField="Dchi_Truso" HeaderText="Địa chỉ trụ sở" />
                    <asp:BoundField DataField="Dchi_TrusoDC" HeaderText="Địa chỉ trụ sở điều chỉnh" />
                    <asp:BoundField DataField="MSthue" HeaderText="MST" />
                    <asp:BoundField DataField="MSthueDC" HeaderText="MST điều chỉnh" />
                    <asp:BoundField DataField="GBieu" HeaderText="Giá biểu" />
                    <asp:BoundField DataField="GBieuDc" HeaderText="Giá biểu ĐC" />
                    <asp:BoundField DataField="DMuc" HeaderText="Định mức" />
                    <asp:BoundField DataField="DMucDC" HeaderText="Định mức ĐC" />
                    <asp:BoundField DataField="CatDMTrung" HeaderText="Cắt trùng ĐM" />
                    <asp:ButtonField Text="Chọn" CommandName="Select" />
                    <asp:CommandField ButtonType="Link" ShowDeleteButton="true" DeleteText="Xóa" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
