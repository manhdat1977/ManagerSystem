<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ManagerSystem.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="content-type" content="text/html; charset=UTF-8">
		<meta charset="utf-8">
		<title>Phòng KDDVKH - Quản trị hệ thống</title>
		<meta name="generator" content="Bootply" />
		<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
		<link href="bootstrap/css/bootstrap.min.css" rel="stylesheet">
		<!--[if lt IE 9]>
			<script src="//html5shim.googlecode.com/svn/trunk/html5.js"></script>
		<![endif]-->
		<link href="css/styles.css" rel="stylesheet">
        <style>
            @import url('https://fonts.googleapis.com/css?family=Open+Sans+Condensed:300');
            </style>
</head>
<body style="font-family:'Open Sans Condensed', sans-serif">
    <form id="form1" runat="server">
    <!--login modal-->
<div id="loginModal" class="modal show" tabindex="-1" role="dialog" aria-hidden="true">
  <div class="modal-dialog" style="width:310px">
  <div class="modal-content" style="width:auto">
      <div class="modal-header">         
         <%-- <h6 class="text-left" style="font-weight:bold">Đăng nhập</h6>       --%>
          <label class="text-left" style="font-weight:bold;font-size:20px;color:#337ab7">Đăng nhập</label>
      </div>
      <div class="modal-body">
            <div class="form-group">
              <input type="text" style="font-size:15px;width:100%" class="form-control input-small" placeholder="Tên đăng nhập" id="txtUser" runat="server" required>
            </div>
            <div class="form-group" style="margin-top:5px">
              <input type="password" style="font-size:15px;width:100%" class="form-control input-small" placeholder="Mật khẩu" id="txtPass" runat="server" required>
            </div>
            <div class="form-group">
              <asp:Button ID="btn_Login" Text="Đồng ý" runat="server" class="btn btn-primary btn-small btn-block"
                    onclick="btn_Login_Click" />   
            </div>
      </div>
     
  </div>
  </div>
</div>
	<!-- script references -->
		<script src="//ajax.googleapis.com/ajax/libs/jquery/2.0.2/jquery.min.js"></script>
		<script src="js/bootstrap.min.js"></script>

    </form>
</body>
</html>
