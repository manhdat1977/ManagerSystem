<%@ Page Title="" Language="C#" MasterPageFile="~/Site_ver2.Master" AutoEventWireup="true"
    CodeBehind="giaiquyetdon.aspx.cs" Inherits="ManagerSystem.giaiquyetdon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentCSS" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHeader" runat="server">
    <div class="container-fluid">
        <div class="row mb-2">
            <div class="col-sm-6">
                <h1>
                    Danh sách đơn chưa giải quyết</h1>
            </div>
            <div class="col-sm-6">
                <ol class="breadcrumb float-sm-right">
                    <li class="breadcrumb-item"><a href="#">Home</a></li>
                    <li class="breadcrumb-item active">Danh sách đơn chưa giải quyết</li>
                </ol>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="card card-info">
                <div class="card-header">
                    <div class="card-tools">
                        <button type="button" class="btn btn-tool" data-card-widget="collapse">
                            <i class="fas fa-minus"></i>
                        </button>
                    </div>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-2">
                            <asp:DropDownList runat="server" ID="dropSearch" CssClass="form-control select2 select2-hidden-accessible">
                                <asp:ListItem Text="Tìm theo..."></asp:ListItem>
                                <asp:ListItem Text="Danh bạ"></asp:ListItem>
                                <asp:ListItem Text="Số đơn"></asp:ListItem>
                                <asp:ListItem Text="Loại đơn"></asp:ListItem>
                                <asp:ListItem Text="Ngày nhận đơn"></asp:ListItem>
                                <asp:ListItem Text="Kiểm tra viên"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox runat="server" ID="txtSearch" CssClass="form-control" />
                        </div>
                        <asp:Button runat="server" ID="btnSearch" CssClass="btn btn-danger" Text="Tìm kiếm"
                            OnClick="btnSearch_Click" />
                    </div>
                    <br />
                    <div class="table-responsive">
                        <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>--%>
                        <asp:GridView runat="server" ID="gridDSDonChuaGQ" AllowPaging="true" PageSize="10"
                            CssClass="table no-margin" AutoGenerateColumns="False" OnRowCommand="gridDSDonChuaGQ_RowCommand"
                            DataKeyNames="MaSNDon" OnPageIndexChanging="gridDSDonChuaGQ_PageIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="Dbo" HeaderText="Danh bạ" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="SDon" HeaderText="Số đơn" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="LDon" HeaderText="Loại đơn" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="NgayNhanDon" HeaderText="Ngày cấp BN" DataFormatString="{0:dd/MM/yyyy}"
                                    ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="Khang" HeaderText="Khách hàng" />
                                <asp:BoundField DataField="Dchi" HeaderText="Địa chỉ" />
                                <asp:BoundField DataField="MaNVKtra" HeaderText="NV Kiểm tra" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="CheckImage" HeaderText="Hình ảnh" ItemStyle-HorizontalAlign="Center" />
                                <%-- <asp:TemplateField HeaderText="Image">
                                    <ItemTemplate>
                                        <asp:Image ID="image1" runat="server" ImageUrl='<%#"data:image/png;base64," + Convert.ToBase64String((byte[])Eval("Image")) %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:CommandField ShowSelectButton="True" HeaderText="Chọn" />
                                <%-- <asp:TemplateField HeaderText="Select">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="Lnk_Edit" runat="server" CommandName="Select" CausesValidation="false" CommandArgument="<%# Container.DataItemIndex %>">Select</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                            </Columns>
                            <PagerSettings PageButtonCount="15" />
                            <PagerStyle CssClass="pagination-ys" />
                        </asp:GridView>
                        <%--             </ContentTemplate>
                        </asp:UpdatePanel>--%>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-12">
            <div class="card card-info">
                <div class="card-header">
                    <h3 class="card-title">
                        Kết quả giải quyết hồ sơ</h3>
                </div>
                <div class="card-body">
                    <div class="form-group row">
                        <label class="col-md-1 col-form-label" style="text-align: right">
                            Nhập mã đơn</label>
                        <div class="col-md-1">
                            <asp:TextBox runat="server" ID="txtDba" CssClass="form-control" placeholder="Danh bạ"></asp:TextBox>
                        </div>
                        <div class="col-md-1">
                            <asp:TextBox runat="server" ID="txtSoDon" CssClass="form-control" placeholder="Danh bạ"></asp:TextBox>
                        </div>
                        <div class="col-md-1">
                            <asp:DropDownList runat="server" ID="dropLoaiDon" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-1">
                            <asp:TextBox placeholder="DD/MM/YYYY" onfocus="(this.type='date')" onblur="(this.type='text')"
                                runat="server" ID="txtNgayCapBN" CssClass="form-control" Style="line-height: normal"></asp:TextBox>
                        </div>
                        <div class="col-md-1">
                            <asp:Button ID="btnTim" runat="server" Text="Tìm" CssClass="form-control btn btn-danger"
                                OnClick="btnTim_Click" />
                        </div>
                    </div>
                </div>
                <div class="card-body">
                    <div class="form-group row">
                        <label class="col-md-1 col-form-label" style="text-align: right">
                            Khách hàng</label>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtKH" runat="server" CssClass="form-control" Enabled="false" ForeColor="#000"
                                Font-Bold="true"></asp:TextBox>
                        </div>
                        <label class="col-md-1 col-form-label" style="text-align: right">
                            Địa chỉ</label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtDC" runat="server" CssClass="form-control" Enabled="false" ForeColor="#000"
                                Font-Bold="true"></asp:TextBox>
                        </div>
                        <label class="col-md-1 col-form-label" style="text-align: right">
                            Nội dung đơn</label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtNoidungDon" runat="server" CssClass="form-control" Enabled="false"
                                ForeColor="#000" Font-Bold="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-md-1 col-form-label" style="text-align: right">
                            Nội dung biên bản</label>
                        <div class="col-md-10">
                            <asp:TextBox ID="txtNDBienBan" runat="server" CssClass="form-control" Enabled="false"
                                TextMode="MultiLine" ForeColor="#000" Font-Bold="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-md-1 col-form-label" style="text-align: right">
                            Thông tin đọc số</label>
                        <div class="col-md-2">
                            <asp:DropDownList runat="server" ID="dropTTDS" CssClass="form-control">
                                <asp:ListItem Text=""></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <label class="col-md-2 col-form-label" style="text-align: right">
                            Nhóm kết quả giải quyết</label>
                        <div class="col-md-2">
                            <asp:DropDownList runat="server" ID="dropNhomKQ" CssClass="form-control">
                                <asp:ListItem Text=""></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <label class="col-md-1 col-form-label" style="text-align: right">
                            Thái độ phục vụ</label>
                        <div class="col-md-2">
                            <asp:DropDownList runat="server" ID="dropThaiDo" CssClass="form-control">
                                <asp:ListItem Text="01. Tốt"></asp:ListItem>
                                <asp:ListItem Text="02. Chưa tốt"></asp:ListItem>
                                <asp:ListItem Text="03. Không tốt"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-md-1 col-form-label" style="text-align: right">
                            Kết quả giải quyết</label>
                        <div class="col-md-10">
                            <asp:TextBox CssClass="form-control" ID="txtKQGiaiQuyet" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label style="visibility: hidden">
                            dfdf</label>
                        <div class="checkbox">
                            <label>
                                <asp:CheckBox runat="server" ID="chkXepDon" />
                                1-Xếp đơn và giải quyết đúng hạn
                            </label>
                        </div>
                        <label style="visibility: hidden">
                            dfdf</label>
                        <div class="checkbox">
                            <label>
                                <asp:CheckBox runat="server" ID="chkPhoiHopCacDVi" />
                                2-Có phối hợp địa phương, PBĐ
                            </label>
                        </div>
                        <label style="visibility: hidden">
                            dfdf</label>
                        <div class="checkbox">
                            <label>
                                <asp:CheckBox runat="server" ID="chkChuyenLD" />
                                Chuyển lãnh đạo phòng duyệt
                            </label>
                        </div>
                        <label style="visibility: hidden">
                            dfdf</label>
                        <div class="col-md-2">
                            <asp:DropDownList runat="server" CssClass="form-control select2 select2-hidden-accessible"
                                ID="dropNguoiDuyet">
                                <asp:ListItem Text="Đặng Kim Chi" Value="CHIDK"></asp:ListItem>
                                <asp:ListItem Text="Trần Ngọc Cường" Value="CUONGTN" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Lê Quang Bình" Value="BINHLQ"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <center>
                        <asp:Button runat="server" CssClass="btn btn-danger" Text="Lưu" ID="btnLuu" OnClick="btnLuu_Click" /></center>
                </div>
                <div class="card-body">
                    <div class="col-md-12">
                    <center>
                    <div class="dataTables_wrapper form-inline dt-bootstrap">
                            <asp:GridView runat="server" ID="gridImage" CssClass="table table-bordered" DataKeyNames="ID"
                                AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" Width="100%"
                                BorderWidth="1px" CellPadding="3">
                                <Columns>
                                    <asp:HyperLinkField DataTextField="NgayCapNhat" DataNavigateUrlFields="ID" HeaderText="Hình ảnh"
                                        Target="_blank" DataNavigateUrlFormatString="~/GetPic.aspx?Id={0}" />
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
                    </center>
                        
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</asp:Content>
