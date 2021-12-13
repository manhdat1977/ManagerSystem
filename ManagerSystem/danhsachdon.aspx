<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="danhsachdon.aspx.cs" Inherits="ManagerSystem.danhsachdon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
  .hiddencol
  {
    display: none;
  }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <label id="Top" style="font-size:x-large">Danh sách đơn đã nhập trong ngày </label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Button ID="btnThemMoi" runat="server" Text="+ Thêm đơn mới" CssClass="btn btn-btn-default btn-google" />
<div class="row">
     <div class="col-sm-12">
    <div class="box-body pad table-responsive">
        <div class="dataTables_wrapper form-inline dt-bootstrap">
        <asp:GridView runat="server" ID="gridDanhSach" 
                CssClass="table table-bordered table-hover" AutoGenerateColumns="False" 
                DataKeyNames="id" BackColor="White" BorderColor="#CCCCCC" 
                BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                onrowcommand="gridDanhSach_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:BoundField DataField="MaSNdon" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                <asp:BoundField DataField="Dbo" HeaderText="Danh bạ" />
                <asp:BoundField DataField="Khang" HeaderText="Khách hàng" />
                <asp:BoundField DataField="DChi" HeaderText="Địa chỉ" />
                <asp:BoundField DataField="SDon" HeaderText="Số đơn" />
                <asp:BoundField DataField="LDon" HeaderText="Loại đơn" />
                <asp:BoundField DataField="NgayNhanDon" HeaderText="Ngày nhận đơn" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="MaBPYeuCau" HeaderText="PBĐ yêu cầu" />
                <asp:BoundField DataField="TTin_Kiemtra" HeaderText="Thông tin kiểm tra" />
                <asp:BoundField DataField="MaKQ" HeaderText="Mã kết quả" />
                <asp:BoundField DataField="KQGQuyet" HeaderText="Kết quả giải quyết" />
                <asp:BoundField DataField="MaNVKTra" HeaderText="Nhân viên kiểm tra" />
                <asp:ButtonField CommandName="Sua" Text="Sửa" ButtonType="Button" />
                <asp:ButtonField CommandName="Xoa" Text="Xóa" ButtonType="Button" /> 
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
        </div>
    </div>
</div>
</div>
</asp:Content>
