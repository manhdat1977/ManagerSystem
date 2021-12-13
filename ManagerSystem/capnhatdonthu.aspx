<%@ Page Title="" Language="C#" MasterPageFile="~/Site_ver2.Master" AutoEventWireup="true"
    CodeBehind="capnhatdonthu.aspx.cs" Inherits="ManagerSystem.capnhatdonthu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentCSS" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHeader" runat="server">
    <div class="container-fluid">
        <div class="row mb-2">
            <div class="col-sm-6">
                <h1>Cập nhật đơn thư</h1>
            </div>
            <div class="col-sm-6">
                <ol class="breadcrumb float-sm-right">
                    <li class="breadcrumb-item"><a href="#">Home</a></li>
                    <li class="breadcrumb-item active">Cập nhật đơn thư</li>
                </ol>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <form runat="server">
            <div class="row">
                <div class="col-md-12">
                    <div class="card card-info">
                        <div class="card-header">
                            <h3 class="card-title">Thông tin đơn thư nhận</h3>
                        </div>
                        <div class="form-horizontal">
                            <div class="card-body">
                                <div class="form-group row">
                                    <label class="col-md-1 col-form-label">Nhập mã đơn</label>
                                    <div class="col-md-10">
                                        <%--<asp:TextBox ID="txtKey" CssClass="form-control" runat="server" placeholder="Mã đơn gồm: Danh bạ - Số đơn - Loại đơn - Ngày nhận đơn"></asp:TextBox>                          --%>
                                        <div class="row">
                                            <div class="col-md-2">
                                                <asp:TextBox ID="txtDbo" CssClass="form-control input-sm" runat="server" placeholder="Danh bạ"
                                                    required ForeColor="#000" Font-Bold="true"></asp:TextBox>
                                            </div>
                                            <div class="col-md-1">
                                                <asp:TextBox ID="txtSdon" CssClass="form-control input-sm" runat="server" placeholder="Số đơn"
                                                    required ForeColor="#000" Font-Bold="true"></asp:TextBox>
                                            </div>
                                            <div class="col-md-1">
                                                <%--<asp:TextBox ID="txtLdon" CssClass="form-control" runat="server" placeholder="Loại đơn"></asp:TextBox>--%>
                                                <asp:DropDownList runat="server" ID="txtLdon" CssClass="form-control input-sm" Width="100%"
                                                    Font-Bold="true" ForeColor="#000">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-md-2">
                                                <%--<asp:TextBox ID="datemask" CssClass="form-control pull-right" runat="server" data-inputmask="'alias': 'dd/mm/yyyy'"></asp:TextBox>--%>
                                                <%--<input runat="server" type="text" class="form-control" id="txtNgayCapBN" name="txtNgayCapBN"
                                                    placeholder="Ngày cấp BN" required style="color: #000; font-weight: bold" />--%>
                                                    <asp:TextBox runat="server" required CssClass="form-control" ID="txtNgayCapBN" placeholder="Ngày cấp biên nhận" onfocus="(this.type='date')" onblur="(this.type='text')" Font-Bold="true"></asp:TextBox>
                                            </div>
                                            <div class="col-md-1">
                                                <asp:Button runat="server" Text="Tìm kiếm" ID="btnOK" CssClass="btn btn-info" Width="100%"
                                                    OnClick="btnOK_Click" />
                                            </div>
                                            <div class="col-md-1">
                                                <asp:Button runat="server" Text="Làm lại" ID="btnclear" CssClass="btn btn-info" Width="100%"
                                                    OnClick="btnclear_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-md-1 col-form-label">
                                        PBĐ yêu cầu</label>
                                    <div class="col-md-2">
                                        <asp:TextBox ID="txtPBD" runat="server" CssClass="form-control" Enabled="false"
                                            ForeColor="#000" Font-Bold="true"></asp:TextBox>
                                    </div>
                                    <label class="col-md-1 col-form-label" style="text-align: right">
                                        Văn bản</label>
                                    <div class="col-sm-2">
                                        <asp:TextBox ID="txtVB" runat="server" CssClass="form-control" Enabled="false"
                                            ForeColor="#000" Font-Bold="true"></asp:TextBox>
                                    </div>
                                    <label class="col-md-1 col-form-label" style="text-align: right">
                                        Ngày lập</label>
                                    <div class="col-sm-2">
                                        <asp:TextBox ID="txtNgayLap" runat="server" CssClass="form-control" Enabled="false"
                                            ForeColor="#000" Font-Bold="true"></asp:TextBox>
                                    </div>
                                    <label class="col-md-1 col-form-label" style="text-align: right">
                                        Hợp đồng</label>
                                    <div class="col-md-2">
                                        <asp:TextBox ID="txtHD" runat="server" CssClass="form-control" Enabled="false"
                                            ForeColor="#000" Font-Bold="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-md-1 col-form-label">
                                        Khách hàng</label>
                                    <div class="col-md-5">
                                        <asp:TextBox ID="txtKH" runat="server" CssClass="form-control" Enabled="false"
                                            ForeColor="#000" Font-Bold="true"></asp:TextBox>
                                    </div>
                                    <label class="col-md-1 col-form-label" style="text-align: right">
                                        Địa chỉ</label>
                                    <div class="col-sm-5">
                                        <asp:TextBox ID="txtDC" runat="server" CssClass="form-control" Enabled="false"
                                            ForeColor="#000" Font-Bold="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-md-1 col-form-label">
                                        Nội dung đơn</label>
                                    <div class="col-sm-5">
                                        <asp:TextBox ID="txtNDDon" runat="server" CssClass="form-control input-sm" Enabled="false"
                                            ForeColor="#000" Font-Bold="true"></asp:TextBox>
                                    </div>
                                    <label class="col-md-1 col-form-label" style="text-align: right">
                                        Mã lộ trình</label>
                                    <div class="col-md-2">
                                        <asp:TextBox ID="txtMLT" runat="server" CssClass="form-control" Enabled="false"
                                            ForeColor="#000" Font-Bold="true"></asp:TextBox>
                                    </div>
                                    <label class="col-md-1 col-form-label" style="text-align: right">
                                        Số điện thoại</label>
                                    <div class="col-md-2">
                                        <asp:TextBox ID="txtSDT" runat="server" CssClass="form-control" ForeColor="#000"
                                            Font-Bold="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                    <div class="col-md-12">
                        <div class="card card-info">
                            <div class="card-header">
                                <h3 class="card-title" id="TTKT">Thông tin kiểm tra</h3>
                            </div>
                            <div class="form-horizontal">
                                <div class="card-body">
                                    <div class="form-group row">
                                        <label class="col-md-2 col-form-label">
                                            Nhân viên KT chính</label>
                                        <div class="col-md-1">
                                            <asp:DropDownList runat="server" ID="dropNVKtraChinh" Width="100%" ForeColor="#000"
                                                Font-Bold="true" CssClass="form-control" AutoPostBack="True">
                                            </asp:DropDownList>
                                        </div>
                                        <label class="col-md-2 col-form-label" style="text-align: right">
                                            Nhân viên KT phối hợp</label>
                                        <div class="col-md-1">
                                            <asp:DropDownList runat="server" ID="dropNVKtraPH" Width="100%" CssClass="form-control input-sm"
                                                ForeColor="#000" Font-Bold="true">
                                            </asp:DropDownList>
                                        </div>
                                        <label class="col-md-1 col-form-label" style="text-align: right">
                                            Ngày nhận HS</label>
                                        <div class="col-md-1">
                                            <input type="text" runat="server" class="js-date form-control" id="txtNgaynhanHS"
                                                name="datepicker" style="color: #000; font-weight: bold" />
                                        </div>
                                        <label class="col-md-1 col-form-label" style="text-align: right">
                                            Ngày trả HS</label>
                                        <div class="col-md-1">
                                            <input type="text" runat="server" class="js-date form-control" id="txtNgaytraHS"
                                                name="datepicker" style="color: #000; font-weight: bold" />
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="col-md-2 control-label">
                                            Nội dung biên bản</label>
                                        <div class="col-sm-9">
                                            <textarea id="txtNDBienBan" class="form-control input-sm" rows="1" cols="1" runat="server"
                                                style="color: #000; font-weight: bold"></textarea>
                                            <%--<asp:TextBox runat="server" ID="txtNDBienBan" CssClass="form-control"></asp:TextBox>--%>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="col-md-2 col-form-label">
                                            Mã ngành nghề</label>
                                        <div class="col-md-1">
                                            <asp:TextBox ID="txtMNN" runat="server" CssClass="form-control" ForeColor="#000"
                                                Font-Bold="true"></asp:TextBox>
                                        </div>
                                        <label class="col-md-2 col-form-label" style="text-align: right">
                                            Mã ngành nghề điều chỉnh</label>
                                        <div class="col-md-1">
                                            <asp:TextBox ID="txtMnnDC" runat="server" CssClass="form-control" ForeColor="#000"
                                                Font-Bold="true"></asp:TextBox>
                                        </div>

                                        <div class="custom-control custom-checkbox col-md-2" style="text-align: center">
                                            <asp:CheckBox runat="server" ID="chkCoBamChi" />
                                            <label for="chkCoBamChi">Có bấm chì</label>
                                        </div>
                                        <div class="custom-control custom-checkbox col-md-2">
                                            <asp:CheckBox runat="server" ID="chkDeXuatTruyThu" />
                                            <label for="chkDeXuatTruyThu">Đề xuất xử lý truy thu</label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="card card-info">
                            <div class="card-header">
                                <h3 class="card-title" id="Bottom">Tiêu chí kiểm tra</h3>
                            </div>
                            <div class="form-horizontal">
                                <div class="card-body">
                                    <div class="form-group row">
                                        <div class="custom-control custom-checkbox col-md-2">
                                            <asp:CheckBox runat="server" ID="chkDuChi" />
                                            <label for="chkDuChi">1-Đủ 2 chì</label>
                                        </div>
                                        <div class="custom-control custom-checkbox col-md-2">
                                            <asp:CheckBox runat="server" ID="chkCoMaVach" />
                                            <label for="chkCoMaVach">2-Có dán mã vạch</label>
                                        </div>
                                        <div class="custom-control custom-checkbox col-md-2">
                                            <asp:CheckBox runat="server" ID="chkDungMucDich" />
                                            <label for="chkDungMucDich">3-Đúng mục đích sử dụng</label>
                                        </div>
                                        <div class="custom-control custom-checkbox col-md-2">
                                            <asp:CheckBox runat="server" ID="chkDHNHoatDongBT" />
                                            <label for="chkDHNHoatDongBT">4-ĐHN hoạt động bình thường</label>
                                        </div>
                                        <div class="custom-control custom-checkbox col-md-2">
                                            <asp:CheckBox runat="server" ID="chkViTriDHN" />
                                            <label for="chkViTriDHN">5-Vị trí ĐHN (T.Lợi ktra, Đ.số...)</label>                                       
                                        </div>
                                        <div class="custom-control custom-checkbox col-md-2">
                                            <asp:CheckBox runat="server" ID="chkChayNguoc" />
                                            <label for="chkChayNguoc">6-Chạy ngược/Gắn ngược</label>
                                        </div>
                                        <div class="custom-control custom-checkbox col-md-2">
                                            <asp:CheckBox runat="server" ID="chkTonGiao" />
                                            <label for="chkTonGiao">7-Tôn giáo</label>
                                        </div>
                                        <div class="custom-control custom-checkbox col-md-2">
                                            <asp:CheckBox runat="server" ID="chkHoDanToc" />
                                            <label for="chkHoDanToc">8-Hộ dân tộc</label>
                                        </div>
                                        <div class="custom-control custom-checkbox col-md-2">
                                            <asp:CheckBox runat="server" ID="chkTruongHoc" />
                                            <label for="chkTruongHoc">9-Trường học</label>
                                        </div>
                                        <div class="custom-control custom-checkbox col-md-2">
                                            <asp:CheckBox runat="server" ID="chkYTe" />
                                            <label for="chkYTe">10-Cơ sở y tế, bệnh viện</label>
                                        </div>
                                        <div class="custom-control custom-checkbox col-md-2">
                                            <asp:CheckBox runat="server" ID="chkChungCu" />
                                            <label for="chkChungCu">Hồ sơ gốc</label>
                                        </div>
                                        <div class="custom-control custom-checkbox col-md-2">
                                            <asp:CheckBox runat="server" ID="chkNhaDongCua" />
                                            <label for="chkNhaDongCua">Ghi chú nhà đóng cửa</label>
                                        </div>
                                        <div class="custom-control custom-checkbox col-md-2">
                                            <asp:CheckBox runat="server" ID="chkGiengCoVan" />
                                            <label for="chkGiengCoVan">Giếng (có gắn van)</label>
                                        </div>
                                        <div class="custom-control custom-checkbox col-md-2">
                                            <asp:CheckBox runat="server" ID="chkGiengKoVan" />
                                            <label for="chkGiengKoVan">Giếng (không gắn van)</label>
                                        </div>
                                        <div class="custom-control custom-checkbox col-md-2">
                                            <asp:CheckBox runat="server" ID="chkLapGieng" />
                                            <label for="chkLapGieng">Đồng ý lấp giếng</label>
                                        </div>
                                    </div>
                                </div>
                                <div class="card-footer text-center">
                                    <asp:Button runat="server" Text="Cập nhật" ID="btnLuu" CssClass="btn btn-info" style="width:10%"
                                        OnClick="btnLuu_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12" runat="server" id="hide_form" visible="false">
                        <div class="box box-solid box-danger">
                            <div class="box-header with-border">
                                <h3 class="box-title">Thông tin ẩn</h3>
                            </div>
                            <div class="form-horizontal">
                                <div class="box-body">
                                    <div class="form-group">
                                        <label class="col-sm-1 control-label">
                                            Nhóm KN</label>
                                        <div class="col-sm-1">
                                            <asp:TextBox ID="txtNhomKN" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <label class="col-sm-1 control-label">
                                            QTT</label>
                                        <div class="col-sm-1">
                                            <asp:TextBox ID="txtQTT" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <label class="col-sm-1 control-label">
                                            PTT</label>
                                        <div class="col-sm-1">
                                            <asp:TextBox ID="txtPTT" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <label class="col-sm-1 control-label">
                                            Co</label>
                                        <div class="col-sm-1">
                                            <asp:TextBox ID="txtCo" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <label class="col-sm-1 control-label">
                                            GB</label>
                                        <div class="col-sm-1">
                                            <asp:TextBox ID="txtGB" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <label class="col-sm-1 control-label">
                                            DM</label>
                                        <div class="col-sm-1">
                                            <asp:TextBox ID="txtDM" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-1 control-label">
                                            Dot</label>
                                        <div class="col-sm-1">
                                            <asp:TextBox ID="txtDot" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
        </form>
    </div>
</asp:Content>
