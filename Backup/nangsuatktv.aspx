<%@ Page Title="" Language="C#" MasterPageFile="~/Site_ver2.Master" AutoEventWireup="true"
    CodeBehind="nangsuatktv.aspx.cs" Inherits="ManagerSystem.nangsuatktv" %>

<%@ Register Assembly="DevExpress.XtraReports.v12.2.Web, Version=12.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentCSS" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHeader" runat="server">
    <div class="container-fluid">
        <div class="row mb-2">
            <div class="col-sm-6">
                <h1>
                    Năng suất</h1>
            </div>
            <div class="col-sm-6">
                <ol class="breadcrumb float-sm-right">
                    <li class="breadcrumb-item"><a href="#">Home</a></li>
                    <li class="breadcrumb-item active">Năng suất</li>
                </ol>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <div class="card card-default">
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label>
                                        Từ ngày</label>
                                    <%--<div class="input-group">
                                    <div class="input-group-addon">
                                        <i class="fa fa-calendar"></i>
                                    </div>
                                    <input type="text" class="js-date form-control" maxlength="10" name="datepicker" id="datepicker" />
                                </div>--%>
                                    <div class="input-group">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text"><i class="far fa-calendar-alt"></i></span>
                                        </div>
                                        <asp:TextBox runat="server" CssClass="form-control" ID="datepicker" placeholder="DD/MM/YYYY"
                                            onfocus="(this.type='date')" onblur="(this.type='text')"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label>
                                        Đến ngày</label>
                                    <div class="input-group">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text"><i class="far fa-calendar-alt"></i></span>
                                        </div>
                                        <asp:TextBox runat="server" CssClass="form-control" ID="datepicker1" placeholder="DD/MM/YYYY"
                                            onfocus="(this.type='date')" onblur="(this.type='text')"></asp:TextBox>
                                        <%--<input type="text" class="js-date form-control" maxlength="10" name="datepicker1" id="datepicker1" />--%>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-1" runat="server" id="print">
                                <div class="form-group">
                                    <label style="visibility: hidden">
                                        đf</label>
                                    <div class="inbut-group">
                                        <center>
                                            <asp:Button runat="server" Text="IN" class="btn btn-secondary" ID="btn_NangSuat"
                                                Font-Size="15px" OnClick="btn_NangSuat_Click" />
                                        </center>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-1" runat="server" id="view">
                                <div class="form-group">
                                    <label style="visibility: hidden">
                                        đf</label>
                                    <div class="input-group">
                                        <asp:Button runat="server" Text="Xem" class="btn btn-secondary" ID="btnView" OnClick="btnView_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12" runat="server" id="box_view" visible="false">
                            <div class="box-body pad table-responsive">
                                <div class="dataTables_wrapper form-inline dt-bootstrap">
                                    <center>
                                        <asp:GridView CssClass="table table-bordered table-hover" runat="server" BorderColor="Black"
                                            ID="gridThongtinchiso" AutoGenerateColumns="False" BackColor="Red" BorderStyle="Solid"
                                            BorderWidth="1px" CellPadding="3" CellSpacing="2" ShowFooter="true">
                                            <Columns>
                                                <asp:BoundField DataField="ten_nvkt" HeaderText="Tên nhân viên" />
                                                <asp:BoundField DataField="donKH" HeaderText="Đơn khách hàng" />
                                                <asp:BoundField DataField="PBD" HeaderText="Theo yêu cầu Phòng-Ban-Đội" />
                                                <asp:BoundField DataField="KH_Phong" HeaderText="Kế hoạch phòng" />
                                                <asp:BoundField DataField="KDDVKH_CTDS" HeaderText="6 chỉ tiêu đọc số" />
                                                <asp:BoundField DataField="sum" HeaderText="Tổng cộng" />
                                            </Columns>
                                            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                            <RowStyle ForeColor="#000000" BackColor="#FFF7E7" />
                                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#FFF1D4" />
                                            <SortedAscendingHeaderStyle BackColor="#B95C30" />
                                            <SortedDescendingCellStyle BackColor="#F1E5CE" />
                                            <SortedDescendingHeaderStyle BackColor="#93451F" />
                                        </asp:GridView>
                                    </center>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12" runat="server" id="box_grid" visible="false">
                            <div class="box box-body pad table-responsive">
                                <div class="dataTables_wrapper form-inline dt-bootstrap">
                                    <center>
                                        <dx:ReportToolbar ID="rptoolbarNangSuat" runat='server' ShowDefaultButtons='False'
                                            ReportViewerID="rprvNangSuat" Visible="False">
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
                                        <dx:ReportViewer ID="rprvNangSuat" runat="server" CssClass="table dataTable" Report="<%# new ManagerSystem.reportNangSuat() %>"
                                            ReportName="ManagerSystem.reportNangSuat" Visible="False">
                                        </dx:ReportViewer>
                                    </center>
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
