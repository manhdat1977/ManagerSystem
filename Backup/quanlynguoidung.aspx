<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="quanlynguoidung.aspx.cs" Inherits="ManagerSystem.quanlynguoidung" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
<label style="font-size:x-large; font-weight:bold">Danh sách người dùng</label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="box-body">
            <div class="col-sm-12" runat="server" id="box_grid">
                <div class="box box-body pad table-responsive">
                     <div class="dataTables_wrapper form-inline dt-bootstrap">
                        <asp:GridView runat="server" ID="grv_user" 
                             CssClass="table table-bordered table-striped dataTable" 
                             AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" 
                             BorderStyle="None" BorderWidth="1px" CellPadding="3">
                            <Columns>
                                <asp:BoundField DataField="fullname" HeaderText="Họ tên" />
                                <asp:BoundField DataField="username" HeaderText="Tài khoản" />
                                <asp:BoundField DataField="department" HeaderText="Phòng Ban Đội" />
                                <asp:BoundField DataField="accesscounter" HeaderText="Lượt truy cập" />
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
    </div>
</asp:Content>
