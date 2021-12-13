<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetPic.aspx.cs" Inherits="ManagerSystem.GetPic" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>Phòng Kinh doanh dịch vụ khách hàng - Quản trị hệ thống</title>
    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
    <!-- Bootstrap 3.3.6 -->
    <link rel="stylesheet" href="../../bootstrap/css/bootstrap.min.css">
    <!-- Font Awesome -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.5.0/css/font-awesome.min.css">
    <!-- Ionicons -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/ionicons/2.0.1/css/ionicons.min.css">
    <!-- Theme style -->
    <link rel="stylesheet" href="../../dist/css/AdminLTE.min.css">
    <link rel="stylesheet" href="../../plugins/select2/select2.min.css">
    <link rel="stylesheet" href="../../plugins/datepicker/datepicker3.css">
    <link rel="stylesheet" href="../../plugins/datepicker/datepicker1.css">
    <!-- AdminLTE Skins. Choose a skin from the css/skins
       folder instead of downloading all of them to reduce the load. -->
    <link rel="stylesheet" href="../../dist/css/skins/_all-skins.min.css">
    <link href="bootstrapcustom.css" rel="stylesheet" type="text/css" />
    <link href="pager.css" rel="stylesheet" type="text/css" />
    <link href="affix.css" rel="stylesheet" type="text/css" />
    <%--<style>
            @import url('https://fonts.googleapis.com/css?family=Open+Sans+Condensed:300');
            </style>
    <style>
@import url('https://fonts.googleapis.com/css?family=Source+Sans+Pro');
</style>--%>
    <style>
        @import url('https://fonts.googleapis.com/css?family=Roboto');
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <div class="col-md-12">
                <div class="box box-default">
                    <div class="box-header with-border">
                        <div class="user-block">
                            <span class="username"><a href="#">Thông tin kiểm tra bằng hình ảnh</a></span>
                            <%--                            <span class="description">Shared publicly - 7:30 PM Today</span>--%>
                        </div>
                        <!-- /.user-block -->
                        <div class="box-tools">
                        </div>
                        <!-- /.box-tools -->
                    </div>
                    <div class="box-body">
                        <div class="form-group">
                            <asp:Button ID="btn_Zoom" class="btn pull-left" runat="server" Text="Zoom" OnClick="btn_Zoom_Click" />
                            <select class="form-control pull-left" id="txt_Zoom" runat="server">
                                <option value="10">10%</option>
                                <option value="20">20%</option>
                                <option value="30">30%</option>
                                <option value="40">40%</option>
                                <option value="50">50%</option>
                                <option value="60">60%</option>
                                <option value="70">70%</option>
                                <option value="80">80%</option>
                                <option value="90">90%</option>
                                <option value="100">100%</option>
                                <option value="110">110%</option>
                                <option value="120">120%</option>
                                <option value="130">130%</option>
                                <option value="140">140%</option>
                                <option value="150">150%</option>
                            </select>
                        </div>
                    </div>
                    <asp:ImageButton ID="Image1" runat="server" OnClick="tmp_Click" class="img-responsive pad" Width="50%" Height="50%" />
                </div>
            </div>
        </div>
        </div>
    </form>
</body>
</html>
