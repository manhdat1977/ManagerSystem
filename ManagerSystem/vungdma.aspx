<%@ Page Title="" Language="C#" MasterPageFile="~/Site_ver2.Master" AutoEventWireup="true" CodeBehind="vungdma.aspx.cs" Inherits="ManagerSystem.vungdma" %>

<%@ Register Assembly="DevExpress.XtraReports.v12.2.Web, Version=12.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentCSS" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHeader" runat="server">
    <div class="container-fluid">
        <div class="row mb-2">
            <div class="col-sm-6">
                <h1>Năng suất KTV theo vùng DMA</h1>
            </div>
            <div class="col-sm-6">
                <ol class="breadcrumb float-sm-right">
                    <li class="breadcrumb-item"><a href="#">Home</a></li>
                    <li class="breadcrumb-item active">Năng suất KTV theo vùng DMA</li>
                </ol>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
        <div class="container-fluid">
            <div class="card card-default">
                <div class="card-body">
                    <div class="row">
                        <div class="col-sm-2">
                            <asp:DropDownList ID="dropKy" runat="server" CssClass="form-control" ForeColor="Black" Font-Bold="true">
                                <asp:ListItem Text="Chọn kỳ..."></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-2">
                            <asp:DropDownList ID="dropNam" runat="server" CssClass="form-control" ForeColor="Black" Font-Bold="true">
                                <asp:ListItem Text="Chọn năm..."></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-2" runat="server" id="divListKTV" visible="false">
                            <asp:DropDownList ID="dropKTV" runat="server" CssClass="form-control" ForeColor="Black" Font-Bold="true">
                                <asp:ListItem Text="Chọn kiểm tra viên..."></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-2">
                            <asp:Button runat="server" ID="btn_OK" Text="OK"
                                CssClass="btn btn-danger btn-flat" OnClick="btn_OK_Click" />
                        </div>
                        <div class="col-sm-4"></div>
                        <div class="col-sm-12"></div>
                        <div class="col-sm-12">
                            <div class="dataTables_wrapper form-inline dt-bootstrap">
                                <div class="row" style="margin-top: 10px; margin-bottom: 10px">
                                    <div class="col-md-12">
                                        <dx:ReportToolbar ID="ReportToolbar1" runat='server' ShowDefaultButtons='False'
                                            ReportViewerID="ReportViewer1">
                                            <Items>
                                                <dx:ReportToolbarButton ItemKind='Search' />
                                                <dx:ReportToolbarSeparator />
                                                <dx:ReportToolbarButton ItemKind='PrintReport' />
                                                <dx:ReportToolbarButton ItemKind='PrintPage' />
                                                <dx:ReportToolbarSeparator />
                                                <dx:ReportToolbarButton Enabled='False' ItemKind='FirstPage' />
                                                <dx:ReportToolbarButton Enabled='False' ItemKind='PreviousPage' />
                                                <dx:ReportToolbarLabel ItemKind='PageLabel' />
                                                <dx:ReportToolbarComboBox ItemKind='PageNumber' Width='65px'>
                                                </dx:ReportToolbarComboBox>
                                                <dx:ReportToolbarLabel ItemKind='OfLabel' />
                                                <dx:ReportToolbarTextBox ItemKind='PageCount' />
                                                <dx:ReportToolbarButton ItemKind='NextPage' />
                                                <dx:ReportToolbarButton ItemKind='LastPage' />
                                                <dx:ReportToolbarSeparator />
                                                <dx:ReportToolbarButton ItemKind='SaveToDisk' />
                                                <dx:ReportToolbarButton ItemKind='SaveToWindow' />
                                                <dx:ReportToolbarComboBox ItemKind='SaveFormat' Width='70px'>
                                                    <Elements>
                                                        <dx:ListElement Value='pdf' />
                                                        <dx:ListElement Value='xls' />
                                                        <dx:ListElement Value='xlsx' />
                                                        <dx:ListElement Value='rtf' />
                                                        <dx:ListElement Value='mht' />
                                                        <dx:ListElement Value='html' />
                                                        <dx:ListElement Value='txt' />
                                                        <dx:ListElement Value='csv' />
                                                        <dx:ListElement Value='png' />
                                                    </Elements>
                                                </dx:ReportToolbarComboBox>
                                            </Items>
                                            <Styles>
                                                <LabelStyle>
                                                    <Margins MarginLeft='3px' MarginRight='3px' />
                                                </LabelStyle>
                                            </Styles>
                                        </dx:ReportToolbar>
                                    </div>
                                    <div class="col-md-12">
                                        <dx:ReportViewer ID="ReportViewer1" runat="server"
                                            CssClass="table table-bordered table-striped dataTable"
                                            Report="<%# new ManagerSystem.rp_KTV_DMA() %>"
                                            ReportName="ManagerSystem.rp_KTV_DMA" Theme="Aqua">
                                        </dx:ReportViewer>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>


    </form>

</asp:Content>
