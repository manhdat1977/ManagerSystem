<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="lichsukiemtra.aspx.cs" Inherits="ManagerSystem.lichsukiemtra" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <title>Lịch sử kiểm tra</title>
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
       <div class="row">
           <div class="col-md-12">
               <asp:GridView runat="server" ID="gridLichSuKtra" CssClass="table table-bordered" AutoGenerateColumns="False">
                   <Columns>
                       <asp:BoundField DataField="SDon" HeaderText="Số đơn" />
                       <asp:BoundField DataField="LDon" HeaderText="Loại đơn" />
                       <asp:BoundField DataField="NhomKN" HeaderText="Nhóm khiếu nại" />
                       <asp:BoundField DataField="NNHso" HeaderText="Ngày nhận hồ sơ" />
                       <asp:BoundField DataField="NTHso" HeaderText="Ngày trả hồ sơ" />
                       <asp:BoundField DataField="TTin_KiemTra" HeaderText="Thông tin kiểm tra" />
                       <asp:BoundField DataField="KQGQuyet" HeaderText="Kết quả giải quyết" />
                       <asp:BoundField DataField="MaNVKTra" HeaderText="Nhân viên kiểm tra" />
                   </Columns>
               </asp:GridView>
           </div>
       </div>
    </form>
</body>
</html>
