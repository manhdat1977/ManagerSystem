<%@ Page Title="" Language="C#" MasterPageFile="~/Site_ver2.Master" AutoEventWireup="true" CodeBehind="dontrongngay.aspx.cs" Inherits="ManagerSystem.dontrongngay" %>

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

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentHeader" runat="server">
    <div class="container-fluid">
        <div class="row mb-2">
            <div class="col-sm-6">
                <h1>Đơn trong ngày</h1>
            </div>
            <div class="col-sm-6">
                <ol class="breadcrumb float-sm-right">
                    <li class="breadcrumb-item"><a href="#">Home</a></li>
                    <li class="breadcrumb-item active">Đơn trong ngày</li>
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
                        <div class="col-md-2">
                            <div class="form-group">
                                <label>Từ ngày</label>
                                <div class="input-group">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="far fa-calendar-alt"></i></span>
                                    </div>
                                    <asp:TextBox runat="server" CssClass="form-control" ID="datepicker" placeholder="DD/MM/YYYY" onfocus="(this.type='date')" onblur="(this.type='text')"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label>Đến ngày</label>
                                <div class="input-group">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="far fa-calendar-alt"></i></span>
                                    </div>
                                    <asp:TextBox runat="server" CssClass="form-control" ID="datepicker1" placeholder="DD/MM/YYYY" onfocus="(this.type='date')" onblur="(this.type='text')"></asp:TextBox>
                                    <%--<input type="text" class="js-date form-control" maxlength="10" name="datepicker1" id="datepicker1" />--%>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="box-danger">
                                <%-- <div class="box-header">
                <h3> </h3>
            </div>--%>
                            </div>
                            <div class="box-body">
                                <div class="form-group">
                                    <label style="visibility: hidden">AAA</label>
                                    <div class="input-group">
                                        <%--<button type="submit" class="btn btn-primary">Submit</button>--%>
                                        <asp:Button runat="server" Text="Tìm" class="btn btn-info" ID="btn_Tim" Width="80%"
                                            OnClick="btn_Tim_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-3"></div>
                        <div class="box-body">

                            <div class="col-sm-12" runat="server" id="box_grid">
                                <%--        <div class="box box-solid box-danger">
            <div class="box-header">
                <h3 class="box-title">Danh sách đơn trong ngày</h3>
            </div>

            <div class="box-body">--%>
                                <h3>Kiểm tra viên sau khi đã kiểm tra click vào nút "Cập nhật" để kết thúc quy trình xử lý ngoài hiện trường</h3>
                                <div class="dataTables_wrapper dt-bootstrap4">
                                    <asp:GridView runat="server"
                                        CssClass="table table-bordered table-hover dataTable dtr-inline" ID="grvData"
                                        BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"
                                        CellPadding="1" AutoGenerateColumns="False" DataKeyNames="masndon"
                                        OnRowCommand="grvData_RowCommand" OnRowDataBound="grvData_RowDataBound">
                                        <Columns>
                                            <%--<asp:BoundField DataField="BPYeuCau" HeaderText="PBĐ yêu cầu" />--%>
                                            <%--<asp:BoundField DataField="NNDon" HeaderText="Ngày nhận đơn" />--%>
                                            <%--<asp:ButtonField ButtonType="Button" Text="Hoạ đồ" CommandName="Click" HeaderText="Xem" />      --%>

                                            <asp:TemplateField HeaderText="Lịch sử đơn">
                                                <ItemTemplate>
                                                    <img alt="" style="cursor: pointer" src="plus.png" />
                                                    <asp:Panel ID="pnlChildGrid" runat="server" Style="display: none">
                                                        <asp:GridView runat="server" ID="gridHistory" CssClass="table table-bordered table-hover dataTable dtr-inline" AutoGenerateColumns="False" BorderColor="Black">
                                                            <Columns>
                                                                <asp:BoundField DataField="NDKNai" HeaderText="Nội dung khiếu nại" />
                                                                <asp:BoundField DataField="NgayNhanDon" HeaderText="Số đơn - Ngày nhận đơn" />
                                                                <asp:BoundField DataField="NTHSo" HeaderText="Ngày trả HS" />
                                                                <asp:BoundField DataField="TTin_KiemTra" HeaderText="TT kiểm tra" />
                                                                <asp:BoundField DataField="KQGQuyet" HeaderText="Kết quả giải quyết" />
                                                                <asp:BoundField DataField="MaNVKTra" HeaderText="NV Kiểm tra" />
                                                            </Columns>
                                                            <HeaderStyle BackColor="#3c8dbc" Font-Bold="True" ForeColor="#ffffff" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            <RowStyle BackColor="#d7e3ea" ForeColor="#000000" />
                                                        </asp:GridView>
                                                    </asp:Panel>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="dbo" HeaderText="Danh bạ"
                                                HeaderStyle-HorizontalAlign="Center">
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="mLTrinh" HeaderText="MLT"
                                                HeaderStyle-HorizontalAlign="Center">
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DThoaiKH" HeaderText="SĐT" />
                                            <asp:BoundField DataField="Khang" HeaderText="Khách hàng"
                                                HeaderStyle-HorizontalAlign="Center">
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Dchi" HeaderText="Địa chỉ" />
                                            <asp:BoundField DataField="Sdon" HeaderText="Số đơn - Ngày nhận đơn" />
                                            <asp:BoundField DataField="NDDon" HeaderText="Nội dung" />
                                            <asp:BoundField DataField="MaNV" HeaderText="NV Nhận đơn - NV KTra" />
                                            <asp:BoundField DataField="Gchu" HeaderText="Ghi chú" />
                                            <asp:BoundField DataField="XuLy" HeaderText="Trạng thái" />
                                            <asp:BoundField DataField="NgayXuLy" HeaderText="Ngày xử lý" />
                                            <asp:ButtonField ButtonType="Button" Text="Bản vẽ" CommandName="Select" HeaderText="Xem" />
                                            <asp:ButtonField ButtonType="Button" Text="Tiêu thụ" CommandName="View" HeaderText="Xem" />
                                            <asp:ButtonField ButtonType="Button" Text="Hóa đơn" CommandName="HoaDon" HeaderText="Xem" />
                                            <asp:ButtonField ButtonType="Button" Text="Cập nhật" CommandName="XuLyDon" HeaderText="Đã nhận và xử lý" />
                                        </Columns>

                                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                        <HeaderStyle BackColor="#3c8dbc" Font-Bold="True" ForeColor="#ffffff" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                        <RowStyle BackColor="#e8f4ec" />
                                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#000000" />
                                        <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                        <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                        <SortedDescendingHeaderStyle BackColor="#002876" />
                                    </asp:GridView>
                                </div>


                            </div>
                        </div>
                        <p></p>
                        <div class="col-md-12" id="box_HDN" runat="server" visible="false">
                            <div class="box box-warning box-body pad table-responsive">
                                <div class="box-header with-border">
                                    <h3 class="box-title">Danh sách hóa đơn</h3>
                                </div>
                                <asp:GridView runat="server" ID="grid_HDN"
                                    CssClass="table table-bordered table-hover dataTable" BackColor="White"
                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
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
                        <div class="col-md-12">
                            <center><asp:Image ID="Image1" Runat="server" Width="600px" Height="800px" CssClass="form-control" Visible="false" /></center>
                        </div>
                        <p></p>
                        <div class="col-md-12">
                            <div class="col-md-12" id="toolsearch" runat="server" visible="false">

                                <div class="col-md-12">
                                    <div class="box box-primary">
                                        <div class="box-header with-border">
                                            <h3 class="box-title">Thông tin chỉ số</h3>
                                            <asp:TextBox runat="server" ID="txtDba" CssClass="form-control" Enabled="false" Visible="false"></asp:TextBox>
                                        </div>
                                        <div class="box-body">
                                            <div class="input-group input-group-md">
                                                <asp:DropDownList runat="server" ID="dropNam" CssClass="form-control">
                                                </asp:DropDownList>
                                                <span class="input-group-btn">
                                                    <asp:Button runat="server" ID="btnChiso" CssClass="btn btn-primary" Text="Xem chỉ số" OnClick="btnChiso_Click" />
                                                </span>
                                            </div>
                                        </div>
                                        <div class="box box-body">
                                            <asp:GridView runat="server" ID="gridChiSo"
                                                CssClass="table table-bordered table-hover dataTable"
                                                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                                                CellPadding="3">
                                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                <RowStyle ForeColor="#000066" />
                                                <%-- <selectedrowstyle backcolor="#669999" font-bold="true" forecolor="white" />--%>
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
