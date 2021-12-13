<%@ Page Title="" Language="C#" MasterPageFile="~/Site_ver2.Master" AutoEventWireup="true" CodeBehind="importimage.aspx.cs" Inherits="ManagerSystem.importimage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentCSS" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHeader" runat="server">
 <div class="container-fluid">
        <div class="row mb-2">
            <div class="col-sm-6">
                <h1>
                    Cập nhật bản vẽ</h1>
            </div>
            <div class="col-sm-6">
                <ol class="breadcrumb float-sm-right">
                    <li class="breadcrumb-item"><a href="#">Home</a></li>
                    <li class="breadcrumb-item active">Cập nhật bản vẽ</li>
                </ol>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
  <div class="row">
        <div class="card-body">
            <div class="col-md-2">
                <asp:FileUpload runat="server" ID="file_upload" AllowMultiple="true" />
                <asp:Button runat="server" ID="btnImport" CssClass="btn btn-danger"
                    Text="Cập nhật" OnClick="btnImport_Click" />
                <asp:Button runat="server" ID="btnImportError" CssClass="btn btn-danger"
                    Text="Cập nhật lỗi" OnClick="btnImportError_Click" />
            </div>
            <asp:Label runat="server" ID="lblmes" Visible="false" ForeColor="red"></asp:Label>
        </div>
        <div class="card-body">
            <div class="col-md-12">
                <asp:GridView ID="BanVeLoi" runat="server" HorizontalAlign="Center" AutoGenerateColumns="False" CssClass="table table-bordered">
                    <Columns>
                        <asp:TemplateField HeaderText="STT">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Dbo" HeaderText="Danh bạ" />
                        <asp:BoundField DataField="NgayCapNhat" HeaderText="Ngày cập nhật" />
                    </Columns>

                </asp:GridView>
            </div>

        </div>
    </div>
</asp:Content>
