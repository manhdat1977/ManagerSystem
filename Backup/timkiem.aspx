<%@ Page Title="" Language="C#" MasterPageFile="~/Site_ver2.Master" AutoEventWireup="true"
    CodeBehind="timkiem.aspx.cs" Inherits="ManagerSystem.timkiem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentCSS" runat="server">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        $("[src*=plus]").live("click", function () {
            $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", "minus.png");
        });
        $("[src*=minus]").live("click", function () {
            $(this).attr("src", "plus.png");
            $(this).closest("tr").next().remove();
        });
        $(document).ready(function () {
            var table = $('#example').DataTable({
                "scrollY": "100px",
                "paging": false
            });

            $('a.toggle-vis').on('click', function (e) {
                e.preventDefault();

                // Get the column API object
                var column = table.column($(this).attr('data-column'));

                // Toggle the visibility
                column.visible(!column.visible());
            });
        });
    </script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
    <script>
        window.jQuery || document.write('<script src="../bower_components/jquery/dist/jquery.min.js"><\/script>')
        </script>
    <script src="JQuery/jQuery.print.js"></script>
    <script type='text/javascript'>
        //<![CDATA[
        jQuery(function ($) {
            'use strict';
            $("#ele4").find('button').on('click', function () {
                //Print ele4 with custom options
                $("#ele4").print({
                    //Use Global styles
                    globalStyles: false,
                    //Add link with attrbute media=print
                    mediaPrint: false,
                    //Custom stylesheet
                    stylesheet: "http://fonts.googleapis.com/css?family=Inconsolata",
                    //Print in a hidden iframe
                    iframe: false,
                    //Don't print this
                    noPrintSelector: ".avoid-this",
                    deferred: $.Deferred().done(function () { console.log('Printing done', arguments); })
                });
            });
        });
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHeader" runat="server">
    <div class="container-fluid">
        <div class="row mb-2">
            <div class="col-sm-6">
                <h1>Tìm kiếm</h1>
            </div>
            <div class="col-sm-6">
                <ol class="breadcrumb float-sm-right">
                    <li class="breadcrumb-item"><a href="#">Home</a></li>
                    <li class="breadcrumb-item active">Tìm kiếm</li>
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
                    <div class="card card-info">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-3"></div>
                                <div class="col-md-2">
                                    <asp:DropDownList runat="server" ID="dropSearch" CssClass="form-control" ForeColor="Black"
                                        Font-Bold="true">
                                        <asp:ListItem Text="Tìm theo..."></asp:ListItem>
                                        <asp:ListItem Text="Danh bạ"></asp:ListItem>
                                        <asp:ListItem Text="Địa chỉ"></asp:ListItem>
                                        <asp:ListItem Text="Mã lộ trình"></asp:ListItem>
                                        <asp:ListItem Text="Tên khách hàng"></asp:ListItem>
                                        <asp:ListItem Text="Hợp đồng"></asp:ListItem>
                                        <asp:ListItem Text="Số điện thoại"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-3">
                                    <div class="input-group input-group-md">
                                        <%--<input type="text" class="form-control" name="search" placeholder="Tìm theo danh bạ, mã lộ trình hoặc địa chỉ" />--%>
                                        <asp:TextBox runat="server" ID="txtSearch" CssClass="form-control" placeholder="Nhập thông tin cần tìm tại đây..."
                                            ForeColor="Black"></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:Button ID="btnTim" CssClass="btn btn-danger btn-flat" runat="server" Text="Tìm"
                                                OnClick="btnTim_Click" />
                                        </span>
                                    </div>
                                    <p>
                                    </p>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="card-body pad table-responsive">
                                        <div class="dataTables_wrapper form-inline dt-bootstrap">
                                            <asp:GridView ID="gridSearch" runat="server" DataKeyNames="DB" CssClass="table table-bordered table-hover"
                                                AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="gridSearch_PageIndexChanging"
                                                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                                                CellPadding="3" OnRowCommand="gridSearch_RowCommand" OnRowDataBound="gridSearch_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Lịch sử đơn">
                                                        <ItemTemplate>
                                                            <img alt="" style="cursor: pointer" src="plus.png" />
                                                            <asp:Panel ID="pnlChildGrid" runat="server" Style="display: none">
                                                                <asp:GridView runat="server" ID="gridHistory" CssClass="table table-bordered table-hover dataTable"
                                                                    AutoGenerateColumns="False" BorderColor="Black">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="NDKNai" HeaderText="Nội dung khiếu nại" />
                                                                        <asp:BoundField DataField="NgayNhanDon" HeaderText="Ngày nhận HS" />
                                                                        <asp:BoundField DataField="NTHSo" HeaderText="Ngày trả HS" />
                                                                        <asp:BoundField DataField="TTin_KiemTra" HeaderText="TT kiểm tra" />
                                                                        <asp:BoundField DataField="KQGQuyet" HeaderText="Kết quả giải quyết" />
                                                                        <asp:BoundField DataField="MaNVKTra" HeaderText="NV Kiểm tra" />
                                                                    </Columns>
                                                                    <HeaderStyle BackColor="#3c8dbc" Font-Bold="True" ForeColor="#ffffff" HorizontalAlign="Center"
                                                                        VerticalAlign="Middle" />
                                                                    <RowStyle BackColor="#d7e3ea" ForeColor="#000000" />
                                                                </asp:GridView>
                                                            </asp:Panel>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="DB" HeaderText="Danh bạ" ItemStyle-VerticalAlign="Middle">
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <ItemStyle VerticalAlign="Middle"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="HD" HeaderText="HĐ" ItemStyle-VerticalAlign="Middle">
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <ItemStyle VerticalAlign="Middle"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="MaLT" HeaderText="MLT">
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="GB" HeaderText="GB">
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="DM" HeaderText="ĐM">
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="DThoai_SMS" HeaderText="Điện thoại">
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="KH" HeaderText="Khách hàng">
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="DC" HeaderText="Địa chỉ">
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="SoThan" HeaderText="Số thân">
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Co" HeaderText="Cỡ">
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="DMA" HeaderText="DMA">
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:ButtonField ButtonType="Button" Text="Bản vẽ" CommandName="Select" HeaderText="Xem" />
                                                    <asp:ButtonField ButtonType="Button" Text="Tiêu thụ" CommandName="View" HeaderText="Xem" />
                                                    <asp:ButtonField ButtonType="Button" Text="Hóa đơn" CommandName="HDN" HeaderText="Xem" />
                                                    <%--<asp:ButtonField ButtonType="Button" Text="Hoạ độ" CommandName="Click" HeaderText="Xem" />   --%>
                                                </Columns>
                                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                                <PagerSettings PageButtonCount="15" />
                                                <PagerStyle CssClass="pagination-ys" />
                                                <RowStyle ForeColor="#000" />
                                                <SelectedRowStyle BackColor="#ff5050" />
                                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                <SortedDescendingHeaderStyle BackColor="#00547E" />
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <div id="ele4">
                                        <button class="avoid-this" runat="server" id="printImg" visible="false">
                                            Print
                                        </button>
                                        <asp:Image ID="Image1" runat="server" Width="80%" Height="80%" CssClass="form-control" Visible="false" ImageAlign="Middle" />
                                    </div>
                                </div>
                                <div class="col-md-12" id="box_HDN" runat="server">
                                    <div class="card card-default pad table-responsive">
                                        <asp:GridView runat="server" ID="grid_HDN" CssClass="table table-bordered table-hover dataTable"
                                            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                                            CellPadding="3">
                                            <FooterStyle BackColor="White" ForeColor="#000066" />
                                            <HeaderStyle BackColor="#666699" Font-Bold="True" ForeColor="White" />
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
                            <div class="row" id="toolsearch" runat="server" visible="false">
                                    <div class="col-md-3">
                                        <div class="card card-default">
                                            <div class="card-header with-border">
                                                <h3 class="card-title">Thông tin danh bạ</h3>
                                            </div>
                                            <div class="card-body" style="color: #000000">
                                                <div class="form-group row">
                                                    <label class="col-md-4 col-form-label">
                                                        Danh bạ</label>
                                                    <asp:TextBox runat="server" ID="txtDba" CssClass="form-control" Enabled="false"></asp:TextBox>
                                                </div>
                                                <div class="form-group row">
                                                    <label class="col-md-4 col-form-label">
                                                        Khách hàng</label>
                                                    <asp:TextBox runat="server" ID="txtKH" CssClass="form-control" Enabled="false"></asp:TextBox>
                                                </div>
                                                <div class="form-group row">
                                                    <label runat="server" id="lblSDT" class="col-md-4 col-form-label">
                                                        SĐT</label>
                                                    <asp:TextBox runat="server" ID="txtSDT" CssClass="form-control" Enabled="false"></asp:TextBox>
                                                </div>
                                                <div class="form-group row">
                                                    <label class="col-md-4 col-form-label">
                                                        Địa chỉ</label>
                                                    <asp:TextBox runat="server" ID="txtDChi" CssClass="form-control" Enabled="false"></asp:TextBox>
                                                </div>
                                                <div class="form-group row">
                                                    <label class="col-md-4 col-form-label">
                                                        MLT</label>
                                                    <asp:TextBox runat="server" ID="txtMLT" CssClass="form-control" Enabled="false"></asp:TextBox>
                                                </div>

                                                <div class="form-group row">
                                                    <label runat="server" id="lblSoThan" class="col-md-4 col-form-label">
                                                        Số thân</label>
                                                    <asp:TextBox runat="server" ID="txtSoThan" CssClass="form-control" Enabled="false"></asp:TextBox>
                                                </div>

                                                <div class="form-group row">
                                                    <label class="col-md-4 col-form-label">
                                                        Cỡ</label>
                                                    <asp:TextBox runat="server" ID="txtCo" CssClass="form-control" Enabled="false"></asp:TextBox>
                                                </div>
                                                <div class="form-group row">
                                                    <label class="col-md-4 col-form-label">
                                                        DMA</label>
                                                    <asp:TextBox runat="server" ID="txtDMA" CssClass="form-control" Enabled="false"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-9">
                                        <div class="card card-default">
                                            <div class="card-header with-border">
                                                <h3 class="card-title">Thông tin chỉ số</h3>
                                            </div>
                                            <div class="card-body">
                                                <div class="input-group input-group-md">
                                                    <asp:DropDownList runat="server" ID="dropNam" CssClass="form-control">
                                                    </asp:DropDownList>
                                                    <span class="input-group-btn">
                                                        <asp:Button runat="server" ID="btnChiso" CssClass="btn btn-primary" Text="Xem chỉ số"
                                                            OnClick="btnChiso_Click" />
                                                    </span>
                                                </div>
                                            </div>
                                            <div class="card card-body">
                                                <asp:GridView runat="server" ID="gridChiSo" CssClass="table table-bordered table-hover dataTable"
                                                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                                                    CellPadding="3">
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
                    </div>
                </div>

            </div>
        </div>
    </form>
</asp:Content>
