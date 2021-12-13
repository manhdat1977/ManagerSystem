<%@ Page Title="" Language="C#" MasterPageFile="~/Site_ver2.Master" AutoEventWireup="true" CodeBehind="inbiendong.aspx.cs" Inherits="ManagerSystem.inbiendong" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentCSS" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHeader" runat="server">
    <div class="container-fluid">
        <div class="row mb-2">
            <div class="col-sm-6">
                <h1>In biến động</h1>
            </div>
            <div class="col-sm-6">
                <ol class="breadcrumb float-sm-right">
                    <li class="breadcrumb-item"><a href="#">Home</a></li>
                    <li class="breadcrumb-item active">In biến động</li>
                </ol>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
        <div class="container-fluid">
            <div class="card card-default">
                <div class="form-horizontal">
                    <div class="card-body">
                        <div class="row">
                            <div class="col-2">
                                <label>Nhập số bảng kê</label>
                                    <asp:TextBox runat="server" ID="txtSoBKe"></asp:TextBox>
                            </div>
                            <div class="col-2">
                                <label>Kỳ in bảng kê</label>
                                <asp:TextBox runat="server" ID="txtKyIn"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                 <label>Người ký</label>
                                <asp:DropDownList CssClass="form-control select2 select2-hidden-accessible" ID="dropNguoiKy" runat="server">
                                            <asp:ListItem Text="Đặng Kim Chi" Value="DANG KIM CHI"></asp:ListItem>
                                            <asp:ListItem Text="Lê Quang Bình" Value="LE QUANG BINH"></asp:ListItem>
                                            <asp:ListItem Text="Đặng Ngọc Hà" Value="DANG NGOC HA"></asp:ListItem>
                                            <asp:ListItem Text="Trần Ngọc Cường" Value="TRAN NGOC CUONG"></asp:ListItem>
                                            <asp:ListItem Text="Nguyễn Văn Đắng" Value="NGUYEN VAN DANG"></asp:ListItem>
                                        </asp:DropDownList>
                            </div>
                            <div class="col-1">
                                <label style="visibility:hidden">sd</label>
                                <asp:Button runat="server" ID="btnLoad" Text="Tải danh sách" OnClick="btnLoad_Click" CssClass="btn btn-danger" />
                            </div>
                            <div class="col-1">
                                  <label style="visibility:hidden">sd</label>
                                <asp:Button runat="server" ID="btnView" Text="Xem danh sách" CssClass="btn btn-danger" OnClick="btnView_Click" />
                            </div>
                            <div class="col-1">
                                 <label style="visibility:hidden">sd</label>
                                <asp:Label CssClass="control-label" runat="server" ID="lblMess" Visible="false" ForeColor="Red"></asp:Label>
                            </div>                          
                            <div class="col-md-12">
                                <div class="dataTables_wrapper form-inline dt-bootstrap">
                                    <asp:GridView runat="server" ID="grdLoadData" AutoGenerateColumns="True" CssClass="table table-bordered table-hover dataTable">
                                        <Columns>
                                            <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>

    </form>
</asp:Content>
