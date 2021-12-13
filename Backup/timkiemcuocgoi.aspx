<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="timkiemcuocgoi.aspx.cs" Inherits="ManagerSystem.timkiemcuocgoi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
         <div class="col-md-3"></div>
         <div class="col-md-6">
         <div class="input-group input-group-md">
            <%--<input type="text" class="form-control" name="search" placeholder="Tìm theo danh bạ, mã lộ trình hoặc địa chỉ" />--%>
            <asp:TextBox runat="server" ID="txtSearch" CssClass="form-control" placeholder="Nhập số điện thoại tại đây"></asp:TextBox>
            <span class="input-group-btn">
            <asp:Button ID="btnTimCG" CssClass="btn btn-danger btn-flat" Text="Tìm" 
                 runat="server" onclick="btnTimCG_Click"/>
        </span>
    </div>
    </div>
    <div class="col-md-3"></div>
        <div class="col-md-12">
            <asp:GridView CssClass="table table-bordered table-hover dataTable" runat="server" 
                ID="grvListData" AutoGenerateColumns="False">
                 <Columns>
        <asp:BoundField DataField="sdt" HeaderText="Số điện thoại" />
        <asp:BoundField DataField="ten_nguoi_goi" HeaderText="Người gọi" />
        <asp:BoundField DataField="thoi_gian_goi_toi" HeaderText="Thời gian gọi" />
        <asp:BoundField DataField="noi_dung_cuoc_goi" HeaderText="Nội dung" />
        <asp:TemplateField>
            <ItemTemplate>
                <object type="application/x-shockwave-flash" data='dewplayer-vol.swf?mp3=File.ashx?Id=<%# Eval("Id") %>'
                    width="240" height="20" id="dewplayer">
                    <param name="wmode" value="transparent" />
                    <param name="movie" value='dewplayer-vol.swf?mp3=File.ashx?Id=<%# Eval("Id") %>'/>
                </object>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:HyperLinkField DataNavigateUrlFields="Id" Text = "Download" 
            DataNavigateUrlFormatString = "~/File.ashx?Id={0}" HeaderText="Download" />
    </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
