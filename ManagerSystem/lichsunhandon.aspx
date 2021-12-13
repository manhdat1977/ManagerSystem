<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="lichsunhandon.aspx.cs" Inherits="ManagerSystem.lichsunhandon" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lịch sử nhận đơn</title>
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
    <div class="card-body">
        <div id="example2_wrapper" class="dataTables_wrapper form-inline dt-bootstrap">
            <div class="row">
                <div class="col-sm-12">
                    <asp:GridView CssClass="table table-bordered table-hover dataTable"
                        runat="server" ID="gridLoadHistory" AutoGenerateColumns="False"
                        DataKeyNames="id"
                        OnRowDeleting="gridLoadHistory_RowDeleting"
                        OnRowCommand="gridLoadHistory_RowCommand">
                            <Columns>
                            <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ngày nhận">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNNDon" runat="server" Text='<%# Eval("NNDon") %>'>></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Danh bạ">
                                      <ItemTemplate>
                                        <asp:Label ID="lblDBo" runat="server" Text='<%# Eval("Dbo") %>'>></asp:Label>
                                      </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Số đơn">
                                      <ItemTemplate>
                                        <asp:Label ID="lblSDon" runat="server" Text='<%# Eval("SDon") %>'>></asp:Label>
                                      </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Loại đơn">
                                      <ItemTemplate>
                                        <asp:Label ID="lblLDon" runat="server" Text='<%# Eval("LDon") %>'>></asp:Label>
                                      </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Nội dung đơn">
                                      <ItemTemplate>
                                        <asp:Label ID="lblNDDon" runat="server" Text='<%# Eval("NDDon") %>'>></asp:Label>
                                      </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nhân viên nhận HS">
                                      <ItemTemplate>
                                        <asp:Label ID="lblMaNV" runat="server" Text='<%# Eval("MaNV") %>'>></asp:Label>
                                      </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nhân viên kiểm tra">
                                      <ItemTemplate>
                                        <asp:Label ID="lblMaNVKtra" runat="server" Text='<%# Eval("MaNVKtra") %>'>></asp:Label>
                                      </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Không kiểm tra">
                                      <ItemTemplate>
                                        <asp:Label ID="lblKhongKiemTra" runat="server" Text='<%# Eval("KhongKiemTra") %>'>></asp:Label>
                                      </ItemTemplate>
                                </asp:TemplateField>
                                <asp:ButtonField Text="Chọn" CommandName="Select"  />
                                 <asp:CommandField ButtonType="Link" ShowDeleteButton="true" DeleteText="Xóa"/>
                            </Columns>
                            
                        </asp:GridView>
                </div>
            </div>

          </div>
    </div>
    </form>
</body>
</html>
