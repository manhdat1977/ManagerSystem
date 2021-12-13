<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="baochiso.aspx.cs" Inherits="ManagerSystem.baochiso" %>

<%@ Register Assembly="DevExpress.XtraReports.v12.2.Web, Version=12.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <center>
        <label id="Top" style="font-size: x-large">
            Báo chỉ số nước</label>
    </center>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="row">
            <div class="col-md-12">
                <div class="box box-info">
                    <div class="box-header with-border">
                        <div class="form-horizontal">
                            <div class="box-body">
                                <div class="input-group input-group-sm col-md-3">
                                    <asp:TextBox type="text" class="form-control" runat="server" ID="txtDbo" placeholder="Nhập danh bạ tại đây"></asp:TextBox>
                                    <span class="input-group-btn">
                                        <asp:Button class="btn btn-info btn-flat" runat="server" ID="btnSearch" Text="Tìm danh bạ"
                                            OnClick="btnSearch_Click"></asp:Button>
                                    </span>
                                </div>
                                <p>
                                </p>
                                <div class="form-group">
                                    <label class="col-md-2 control-label">
                                        Khách hàng
                                    </label>
                                    <div class="col-md-4">
                                        <asp:TextBox runat="server" ID="txtKH" CssClass="form-control" Enabled="false"></asp:TextBox>
                                    </div>
                                    <label class="col-md-2 control-label">
                                        MLT
                                    </label>
                                    <div class="col-md-2">
                                        <asp:TextBox runat="server" ID="txtMLT" CssClass="form-control" Enabled="false"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-2 control-label">
                                        Só nhà
                                    </label>
                                    <div class="col-md-4">
                                        <asp:TextBox runat="server" ID="txtDchi1" CssClass="form-control" Enabled="false"></asp:TextBox>
                                    </div>
                                    <label class="col-md-2 control-label">
                                        Đường
                                    </label>
                                    <div class="col-md-4">
                                        <asp:TextBox runat="server" ID="txtDchi2" CssClass="form-control" Enabled="false"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-2 control-label">
                                        SĐT
                                    </label>
                                    <div class="col-md-4">
                                        <asp:TextBox runat="server" ID="txtSDT" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <label class="col-md-2 control-label">
                                        Chỉ số mới
                                    </label>
                                    <div class="col-md-4">
                                        <asp:TextBox runat="server" ID="txtCSoMoi" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="box-footer">
                                <asp:Button CssClass="btn btn-info pull-right" runat="server" ID="btnThem" Text="Thêm"
                                    OnClick="btnThem_Click" />
                                <asp:Label CssClass="control-label" Visible="false" runat="server" ID="lblAlert"
                                    ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-12">
                <div class="box box-danger">
                    <div class="box-header with-border">
                        <h3 class="box-title">
                            Danh sách báo chỉ số</h3>
                    </div>
                    <div class="form-horizontal">
                        <div class="box-body">
                            <div class="form-group">
                                <label class="col-md-2 control-label">
                                    Từ ngày</label>
                                <div class="col-md-2">
                                    <%--<asp:TextBox CssClass="form-control" ID="txtFrom" runat="server"></asp:TextBox>--%>
                                    <input type="text" class="form-control pull-right" id="datepicker" name="datepicker">
                                </div>
                                <label class="col-md-2 control-label">
                                    Đến ngày</label>
                                <div class="col-md-2">
                                    <%--<asp:TextBox CssClass="form-control" ID="txtTo" runat="server"></asp:TextBox>--%>
                                    <input type="text" class="form-control pull-right" id="datepicker1" name="datepicker1">
                                </div>
                                <asp:Button runat="server" Text="OK" ID="btnFilter" CssClass="btn btn-danger" OnClick="btnFilter_Click" />
                            </div><center>
                            <dx:ReportToolbar ID="ReportToolbar1" runat='server' ShowDefaultButtons='False'
                                ReportViewerID="rprv_BaoChiSo" Theme="Aqua" Visible="false">
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
                                    <dx:ReportToolbarTextBox IsReadOnly='True' ItemKind='PageCount' />
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
                            <dx:ReportViewer ID="rprv_BaoChiSo" runat="server" Visible="false"
                                Report="<%# new ManagerSystem.rp_BaoChiSo() %>" 
                                ReportName="ManagerSystem.rp_BaoChiSo">
                            </dx:ReportViewer></center>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
