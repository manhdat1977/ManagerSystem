<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QuanLyCuocGoi.aspx.cs" Inherits="ManagerSystem.QuanLyCuocGoi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
 <h1>Quản lý tiếp nhận cuộc gọi</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<section class="content">
    <div class="row">
        <div class="col-md-6" runat="server" visible="false" id="Nhaplieu">
            <div class="box box-primary">
                <div class="box-header with-border">
                    <i class="fa fa-commenting-o"></i>
                    <h3 class="box-title">Thông tin cuộc gọi</h3>
                </div>
                <div class="form-horizontal">
                    <div class="box-body">
                        <div class="form-group">
                        <label class="col-sm-3 control-label">Danh bạ</label>
                        <div class="col-sm-4">
                            <div class="input-group input-group-sm">                                       
                                    <asp:TextBox runat="server" ID="txtDba" CssClass="form-control"></asp:TextBox>      
                                <span class="input-group-btn">
                                    <asp:Button runat="server" ID="btnTim" Text="Tìm" 
                                        CssClass="btn btn-primary btn-flat" onclick="btnTim_Click" />
                                </span> 
                            </div>
                        </div>
                        <label class="col-sm-1 control-label">KH</label>
                            <div class="col-sm-4">
                                <asp:TextBox runat="server" ID="txtKH" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <%--<div class="form-group">
                            <label class="col-sm-3 control-label">Khách hàng</label>
                            <div class="col-sm-9">
                                <asp:TextBox runat="server" ID="txtKH" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>--%>
                        <div class="form-group">
                            <label class="col-sm-3 control-label">Người gọi</label>
                            <div class="col-sm-9">
                                <asp:TextBox runat="server" ID="txtNgGoi" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-3 control-label">SĐT</label>
                            <div class="col-sm-9">
                                <asp:TextBox runat="server" ID="txtSDT" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                         <div class="form-group">
                            <label class="col-sm-3 control-label">Địa chỉ</label>
                            <div class="col-sm-9">
                                <asp:TextBox runat="server" ID="txtDC" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                         <div class="form-group">
                            <label class="col-sm-3 control-label">Quận</label>
                            <div class="col-sm-3">
                                <asp:DropDownList runat="server" ID="txtQuan" CssClass="form-control">
                                    <asp:ListItem Value=""></asp:ListItem>
                                    <asp:ListItem Value="03"></asp:ListItem>
                                    <asp:ListItem Value="Phú Nhuận"></asp:ListItem>
                                    <asp:ListItem Value="Bình Thạnh"></asp:ListItem>
                                    <asp:ListItem Value="Gò Vấp"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <label class="col-sm-3 control-label">Phường</label>
                            <div class="col-sm-3">
                                <asp:TextBox runat="server" ID="txtPhuong" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-3 control-label">Nội dung</label>
                            <div class="col-sm-9">
                                <asp:TextBox runat="server" ID="txtNoiDung" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-3 control-label">Phản hồi</label>
                            <div class="col-sm-9">
                                <asp:TextBox runat="server" ID="txtPhanHoi" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-3 control-label">Nhóm thông tin</label>
                            <div class="col-sm-9">
                                <asp:DropDownList runat="server" ID="dropNhomTT" CssClass="form-control">
                                    <asp:ListItem Value=""></asp:ListItem>
                                    <asp:ListItem Value="Giá biểu"></asp:ListItem>
                                    <asp:ListItem Value="Tiền nước"></asp:ListItem>
                                    <asp:ListItem Value="Đồng hồ nước"></asp:ListItem>
                                    <asp:ListItem Value="Bồi thường"></asp:ListItem>
                                    <asp:ListItem Value="Gắn mới, nâng dời"></asp:ListItem>
                                    <asp:ListItem Value="Sang tên"></asp:ListItem>
                                    <asp:ListItem Value="Định mức"></asp:ListItem>
                                    <asp:ListItem Value="Chì niêm"></asp:ListItem>
                                    <asp:ListItem Value="Tiêu thụ tăng cao"></asp:ListItem>
                                    <asp:ListItem Value="Nước yếu - Không nước"></asp:ListItem>
                                    <asp:ListItem Value="Nước đục"></asp:ListItem>
                                    <asp:ListItem Value="Chỉ số"></asp:ListItem>
                                    <asp:ListItem Value="Bể ống"></asp:ListItem>
                                    <asp:ListItem Value="Liên hệ công tác"></asp:ListItem>
                                    <asp:ListItem Value="Chuyển cuộc gọi"></asp:ListItem>
                                    <asp:ListItem Value="Khác"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="box-footer">
                            <asp:Button runat="server" ID="Button1" Text="Nhập lại" 
                                CssClass="btn btn-default col-md-3 pull-left" onclick="Button1_Click" />
                            <asp:Button runat="server" ID="btnLuu" Text="Lưu" 
                                CssClass="btn btn-primary col-md-3 pull-right" onclick="btnLuu_Click" />
                        </div>
                    </div>
                    </div>
                </div>
            </div>

         <div class="col-md-6">
            <div class="nav-tabs-custom">
                <ul class="nav nav-tabs">
                    <li class="active"><a href="#fa-icons" data-toggle="tab" aria-expanded="true">Tìm kiếm</a></li>
                    <li><a href="#glyphicons" data-toggle="tab" aria-expanded="true">Thống kê</a></li>
                </ul>
                <div class="tab-content">
                    <div class="tab-pane active" id="fa-icons">
                        <div class="form-group">
                            <label>Từ ngày</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </div>
                                <input type="text" class="form-control" data-inputmask="'alias': 'dd-mm-yyyy'" data-mask="" id="txtTuNgay" runat="server"/>
                            </div>
                        </div>
                        <div class="form-group">
                            <label>Đến ngày</label>
                            <div class="input-group">
                                <div class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </div>
                                <input type="text" class="form-control" data-inputmask="'alias': 'dd-mm-yyyy'" data-mask="" id="txtDenNgay" runat="server"/>
                            </div>
                        </div>            
                        <div class="box-footer text-center">
                             <asp:Button runat="server" ID="btnThongke" Text="Tìm" 
                                 CssClass="btn btn-primary" onclick="btnThongke_Click" />
                        </div>
                         <div class="form-group">
                            <asp:GridView CssClass="table table-bordered table-hover dataTable" runat="server" ID="grvTimKiem"></asp:GridView>
                        </div>
                    </div>
                    <div class="tab-pane" id="glyphicons">
                    <div class="from-group">
                     <%--  <asp:Button runat="server" ID="btnSort" Text="Sort" CssClass="btn btn-primary"  
                            onclick="btnSort_Click" />--%>
                            <asp:Button runat="server" ID="btnSort1" Text="Sort" 
        CssClass="btn btn-primary" onclick="btnSort1_Click"/>
                    </div>
                     <div class="form-group">
                      <asp:GridView runat="server" ID="grvCuocGoi" 
                            CssClass="table table-bordered table-hover dataTable" 
                            AutoGenerateColumns="False" 
                             onselectedindexchanged="grvCuocGoi_SelectedIndexChanged">
                              <Columns>
                                  <asp:BoundField DataField="Time" HeaderText="Time" />
                                  <asp:BoundField DataField="dtmf" HeaderText="SĐT" />
                                  <asp:BoundField DataField="Type" HeaderText="Loại" />
                                  <asp:BoundField DataField="Fullname" HeaderText="Key" />
                                  <asp:CommandField ButtonType="Button" HeaderText="Chọn" SelectText="Chọn" 
                                      ShowSelectButton="True" />
                              </Columns>
                        </asp:GridView>
                     </div>
                       
                    </div>
                </div>
            </div>
         </div>
     </div>
      
</section>
</asp:Content>
