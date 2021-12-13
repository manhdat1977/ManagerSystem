<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ketquadonthu.aspx.cs" Inherits="ManagerSystem.ketquadonthu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
 <h1>Kết quả giải quyết hồ sơ</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="row">
 <div class="col-md-12">
   <div class="col-xs-3">
       <label class="control-label">Danh bạ</label>
        <div class="input-group input-group-sm">
          <asp:TextBox runat="server" ID="txtDba" CssClass="form-control"></asp:TextBox>
          <span class="input-group-btn"><asp:Button runat="server" ID="btn_Tim" 
                CssClass="btn btn-danger btn-flat" Text="Tìm" onclick="btn_Tim_Click" /></span>     
       </div>              
    </div>
     <div class="col-xs-3">
       <label class="control-label">Khách hàng</label>
          <asp:TextBox runat="server" ID="txtKH" CssClass="form-control input-sm"></asp:TextBox>
      </div>              
     <div class="col-xs-3">
       <label class="control-label">Địa chỉ</label>
          <asp:TextBox runat="server" ID="txtDC" CssClass="form-control input-sm"></asp:TextBox>
       </div>              
        <div class="col-xs-2">
                <label class="control-label">Mã lộ trình</label>
              <asp:TextBox runat="server" ID="txtMLT" CssClass="form-control input-sm"></asp:TextBox>
         </div>              
    </div>


<div class="col-md-12">
<p></p>
    <asp:GridView runat="server" ID="gridKetQua" 
        CssClass="table table-bordered table-hover dataTable" CellPadding="4" ForeColor="#333333" 
        GridLines="None" >
        <AlternatingRowStyle BackColor="White" />
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />
        
    </asp:GridView>

</div>
</div>
</asp:Content>
