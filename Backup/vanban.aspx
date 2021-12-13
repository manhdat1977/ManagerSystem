<%@ Page Title="" Language="C#" MasterPageFile="~/Site_ver2.Master" AutoEventWireup="true" CodeBehind="vanban.aspx.cs" Inherits="ManagerSystem.lichdulieu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentCSS" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHeader" runat="server">
    <div class="container-fluid">
        <div class="row mb-2">
            <div class="col-sm-6">
                <h1>Văn bản</h1>
            </div>
            <div class="col-sm-6">
                <ol class="breadcrumb float-sm-right">
                    <li class="breadcrumb-item"><a href="#">Home</a></li>
                    <li class="breadcrumb-item active">Văn bản</li>
                </ol>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-12" runat="server">
                    <div class="card card-info">
                        <div class="card-body">
                            <div class="input-group" runat="server" id="upload">
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                                <div class="input-group-append">
                                    <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="Upload" CssClass="btn btn-danger btn-flat" />
                                </div>
                            </div>
                            <div class="dataTables_wrapper form-inline dt-bootstrap">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Font-Bold="True"
                                    CssClass="table table-bordered table-hover dataTable">
                                    <Columns>
                                        <asp:HyperLinkField DataTextField="Name" HeaderText="Tên văn bản" DataNavigateUrlFields="ID" Target="_blank" DataNavigateUrlFormatString="~/loadpdf.aspx?Id={0}" />

                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>

                </div>
                <div class="col-md-12">
                </div>
            </div>
        </div>
        <hr />
        <div>
            <asp:Literal ID="ltEmbed" runat="server" />
        </div>

    </form>
</asp:Content>
