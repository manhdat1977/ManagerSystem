<%@ Page Title="" Language="C#" MaintainScrollPositionOnPostback="true" MasterPageFile="~/Site_ver2.Master" AutoEventWireup="true" CodeBehind="capnhatbiendong.aspx.cs" Inherits="ManagerSystem.capnhatbiendong" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentCSS" runat="server">
    <script type="text/javascript">
        function hoten_blur(id) {
            var hoten = document.getElementById(id);
            hoten.style.backgroundColor = "#99CCFF";
        }
        function SoCTDK_blur(id) {
            var SoCTDK = document.getElementById(id);
            SoCTDK.style.backgroundColor = "#99CCFF";
        }
        function DC_ThuongTru_blur(id) {
            var DC_ThuongTru = document.getElementById(id);
            DC_ThuongTru.style.backgroundColor = "#99CCFF";
        }
        function CCCD_blur(id) {
            var CCCD = document.getElementById(id);
            CCCD.style.backgroundColor = "#99CCFF";
        }
        function CMND_blur(id) {
            var CMND = document.getElementById(id);
            CMND.style.backgroundColor = "#99CCFF";
        }
        function Ngheo_CanNgheo_blur(id) {
            var Ngheo_CanNgheo = document.getElementById(id);
            Ngheo_CanNgheo.style.backgroundColor = "#99CCFF";
        }
        function Loai_CDM_blur(id) {
            var Loai_CDM = document.getElementById(id);
            Loai_CDM.style.backgroundColor = "#99CCFF";
        }
        function ThoiHanTamTru_blur(id) {
            var ThoiHanTamTru = document.getElementById(id);
            ThoiHanTamTru.style.backgroundColor = "#99CCFF";
        }
        function DBo_CatDinhMuc_blur(id) {
            var DBo_CatDinhMuc = document.getElementById(id);
            DBo_CatDinhMuc.style.backgroundColor = "#99CCFF";
        }
        function Phong_blur(id) {
            var Phong = document.getElementById(id);
            Phong.style.backgroundColor = "#99CCFF";
        }
        function GhiChu_blur(id) {
            var GhiChu = document.getElementById(id);
            GhiChu.style.backgroundColor = "#99CCFF";
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHeader" runat="server">
    <div class="container-fluid">
        <div class="row mb-2">
            <div class="col-sm-6">
                <h1>Cập nhật biến động</h1>
            </div>
            <div class="col-sm-6">
                <ol class="breadcrumb float-sm-right">
                    <li class="breadcrumb-item"><a href="#">Home</a></li>
                    <li class="breadcrumb-item active">Cập nhật biến động</li>
                </ol>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
        <asp:Label runat="server" ID="lblMessage" ForeColor="Red" Font-Bold="true" Visible="false"></asp:Label>
        <div class="row">
            <div class="col-md-12">
                <div class="card card-danger">
                    <%--  <div class="box-header">
                    <center>
                        <h3 class="box-title" style="font-weight:bold">NHẬP THÔNG TIN NHẬN ĐƠN</h3>
                    </center>
                </div>--%>
                    <div class="card-body table-responsive no-padding no-border">
                        <table class="table table-bordered" style="background-color: #99CCFF">
                            <tr style="border-style: none">
                                <th style="text-align: center; vertical-align: middle; width: 12%">Nhân viên nhận hồ sơ</th>
                                <th style="width: 15%">
                                    <asp:Label runat="server" ID="lblNVNhanHS"></asp:Label></th>
                                <th></th>
                            </tr>
                        </table>
                        <table class="table table-bordered" style="background-color: #99CCFF">
                            <tbody>
                                <tr>
                                    <th style="text-align: center" colspan="4">NHẬP THÔNG TIN NHẬN ĐƠN</th>
                                    <th style="text-align: center" colspan="6">THÔNG TIN LẬP ĐIỀU CHỈNH BIẾN ĐỘNG</th>
                                </tr>
                                <tr>
                                    <th style="text-align: center; width: 9%">Danh bạ</th>
                                    <th style="text-align: center; width: 8%" class="style1">Số đơn</th>
                                    <th style="text-align: center; width: 9%">Loại đơn</th>
                                    <th style="text-align: center; width: 8%">Ngày cấp BN</th>
                                    <th></th>
                                    <th style="text-align: center">Nhóm thông tin</th>
                                    <th style="text-align: center; width: 8%">Số BK</th>
                                    <th style="text-align: center">Hiệu lực</th>
                                    <th style="text-align: center">Ngày in BK</th>
                                    <th style="text-align: center">Ngày nhập ĐC</th>
                                    <th style="text-align: center">Nhân viên ĐC</th>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtDba" CssClass="form-control"></asp:TextBox></td>
                                    <td class="style1">
                                        <asp:TextBox runat="server" ID="txtSDon" CssClass="form-control"></asp:TextBox></td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="dropLDon" CssClass="form-control">
                                            <asp:ListItem Text="DC"></asp:ListItem>
                                            <asp:ListItem Text="KN"></asp:ListItem>
                                            <asp:ListItem Text="CVD"></asp:ListItem>
                                            <asp:ListItem Text="GM"></asp:ListItem>
                                        </asp:DropDownList></td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtNgayCapBN" CssClass="form-control" placeholder="DD/MM/YYYY" onfocus="(this.type='date')" onblur="(this.type='text')">
                                            AutoPostBack="true" OnTextChanged="txtNgayCapBN_TextChanged"></asp:TextBox>
                                        
                                    </td>
                                    <td>
                                        <asp:Button runat="server" ID="btnLoadData" Text="Nhập" CssClass="btn btn-danger" OnClick="btnLoadData_Click" /></td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtNhomTT" CssClass="form-control" Enabled="false"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtSoBK" CssClass="form-control" Enabled="false"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtHieuLuc" CssClass="form-control" Enabled="false"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtNgayInBK" CssClass="form-control" Enabled="false"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtNgayNhapDC" CssClass="form-control" Enabled="false"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtNhanVienDC" CssClass="form-control" Enabled="false"></asp:TextBox></td>
                                </tr>
                            </tbody>
                        </table>
                        <table class="table table-bordered" style="background-color: #99CCFF">
                            <tbody>
                                <tr>
                                    <th style="text-align: center" colspan="8">THÔNG TIN TRÊN HÓA ĐƠN</th>
                                </tr>
                                <tr>
                                    <th style="text-align: center; vertical-align: middle">Lộ trình</th>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtMLT" CssClass="form-control" Enabled="false"></asp:TextBox></td>
                                    <th style="text-align: center; vertical-align: middle">Mã NN</th>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtMNN" CssClass="form-control" Enabled="false"></asp:TextBox></td>
                                    <th style="text-align: center; vertical-align: middle">Mã Ng/Nghề ĐC</th>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtMNNDC" CssClass="form-control"></asp:TextBox></td>
                                    <th style="text-align: center; vertical-align: middle">Số điện thoại</th>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtSDT" CssClass="form-control" Enabled="false"></asp:TextBox></td>
                                </tr>
                            </tbody>
                        </table>
                        <table class="table table-bordered" style="background-color: #99CCFF">
                            <tbody>
                                <tr>
                                    <th style="text-align: center; width: 12%">Khách hàng</th>
                                    <th style="text-align: center; width: 12%">Địa chỉ đặt đồng hồ</th>
                                    <th style="text-align: center; width: 12%">Địa chỉ trụ sở</th>
                                    <th style="text-align: center; width: 5%">Mã số thuế</th>
                                    <th style="text-align: center; width: 2%">GB</th>
                                    <th style="text-align: center; width: 2%">ĐMHN</th>
                                    <th style="text-align: center; width: 2%">ĐM</th>
                                    <th style="text-align: center; width: 2%">%SH</th>
                                    <th style="text-align: center; width: 2%">%HCSN</th>
                                    <th style="text-align: center; width: 2%">%SX</th>
                                    <th style="text-align: center; width: 2%">%KD</th>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtKH" CssClass="form-control" Enabled="false"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtDCDatDH" CssClass="form-control" Enabled="false"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtDCTSo" CssClass="form-control" Enabled="false"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtMST" CssClass="form-control" Enabled="false"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtGB" CssClass="form-control" Enabled="false"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtDMHN" CssClass="form-control" Enabled="false"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtDM" CssClass="form-control" Enabled="false"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtSH" CssClass="form-control" Enabled="false"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtHCSN" CssClass="form-control" Enabled="false"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtSX" CssClass="form-control" Enabled="false"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtKD" CssClass="form-control" Enabled="false"></asp:TextBox></td>
                                </tr>
                                <tr style="background-color: #99CCFF">
                                    <th style="text-align: center" colspan="10">NHẬP THÔNG TIN ĐIỀU CHỈNH</th>
                                </tr>
                                <tr style="background-color: Orange">
                                    <th style="text-align: center; width: 12%">Khách hàng</th>
                                    <th style="text-align: center; width: 12%">Địa chỉ đặt đồng hồ</th>
                                    <th style="text-align: center; width: 12%">Địa chỉ trụ sở</th>
                                    <th style="text-align: center; width: 5%">Mã số thuế</th>
                                    <th style="text-align: center; width: 2%">GB</th>
                                    <th style="text-align: center; width: 2%">ĐMHN</th>
                                    <th style="text-align: center; width: 2%">ĐM</th>
                                    <th style="text-align: center; width: 2%">%SH</th>
                                    <th style="text-align: center; width: 2%">%HCSN</th>
                                    <th style="text-align: center; width: 2%">%SX</th>
                                    <th style="text-align: center; width: 2%">%KD</th>
                                </tr>
                                <tr style="background-color: #3399FF">
                                    <td>
                                        <asp:TextBox runat="server" ID="txtKH_DC" CssClass="form-control" BackColor="#3399FF" BorderStyle="None" ForeColor="Black" Font-Bold="true"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtDCDatDH_DC" CssClass="form-control" BackColor="#3399FF" BorderStyle="None" ForeColor="Black" Font-Bold="true"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtDCTSo_DC" CssClass="form-control" BackColor="#3399FF" BorderStyle="None" ForeColor="Black" Font-Bold="true"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtMST_DC" CssClass="form-control" BackColor="#3399FF" BorderStyle="None" ForeColor="Black" Font-Bold="true"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtGB_DC" CssClass="form-control" BackColor="#3399FF" BorderStyle="None" ForeColor="Black" Font-Bold="true"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtDMHN_DC" CssClass="form-control" BackColor="#3399FF" BorderStyle="None" ForeColor="Black" Font-Bold="true"></asp:TextBox></td>

                                    <td>
                                        <asp:TextBox runat="server" ID="txtDM_DC" CssClass="form-control" BackColor="#3399FF" BorderStyle="None" ForeColor="Black" Font-Bold="true"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtSH_DC" CssClass="form-control" BackColor="#3399FF" BorderStyle="None" ForeColor="Black" Font-Bold="true"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtHCSN_DC" CssClass="form-control" BackColor="#3399FF" BorderStyle="None" ForeColor="Black" Font-Bold="true"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtSX_DC" CssClass="form-control" BackColor="#3399FF" BorderStyle="None" ForeColor="Black" Font-Bold="true"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtKD_DC" CssClass="form-control" BackColor="#3399FF" BorderStyle="None" ForeColor="Black" Font-Bold="true"></asp:TextBox></td>
                                </tr>
                            </tbody>
                        </table>
                        <table class="table table-bordered" style="background-color: #99CCFF; border-style: none">
                            <tr style="border-style: none">
                                <th style="text-align: center; vertical-align: middle; width: 8%">Diễn giải</th>
                                <th>
                                    <asp:TextBox runat="server" ID="txtDienGiai" CssClass="form-control"></asp:TextBox></th>
                                <th style="text-align: center; vertical-align: middle; width: 8%">
                                    <asp:CheckBox runat="server" ID="chkInbienDong" Text="In biến động" Checked="true" />
                                </th>
                                <th style="width: 5%">
                                    <asp:Button runat="server" ID="btnLuu" CssClass="btn btn-danger" Text="Lưu" OnClick="btnLuu_Click" />
                                </th>
                                <th style="width: 5%">
                                    <asp:Button runat="server" ID="btnUpdate" CssClass="btn btn-danger" Text="Cập nhật" Visible="false" OnClick="btnUpdate_Click"/>
                                </th>
                                <th style="width: 8%">
                                    <asp:Button runat="server" ID="btnThongTinGQD" CssClass="btn btn-danger" Text="Thông tin GQĐ" OnClick="btnThongTinGQD_Click" OnClientClick="document.forms[0].target = '_blank';" />
                                </th>
                                <th style="width: 8%">
                                    <asp:Button runat="server" ID="btnThongTinBD" CssClass="btn btn-danger" Text="Thông tin biến dộng" OnClientClick="document.forms[0].target = '_blank';" OnClick="btnThongTinBD_Click" />
                                </th>
                                <th style="text-align: center; vertical-align: middle; width: 15%">
                                    <asp:CheckBox runat="server" ID="chkCatDMTrung" Text="Cắt ĐM trùng chứng từ/CVĐ" /></th>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            <!--------------BEGIN DỮ LIỆu SHK VÀ CMND----------------------------->
            <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                    <p>Loading</p>
                </ProgressTemplate>
            </asp:UpdateProgress>--%>
            <!-- --------------------------END DỮ LIỆu SHK VÀ CMND--------------->

            <!--begin cccd-->
<%--            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>--%>
                    <div class="col-md-12">
                        <div class="box">
                            <div class="box-body">
                                <asp:Label runat="server" ID="txtTongNKDCap" Visible="false" CssClass="control-label"
                                    Font-Bold="true" ForeColor="Red"></asp:Label>
                                <p>
                                </p>
                                <div class="card-body table-responsive p-0">
                                    <asp:GridView ID="grd_CanCuocCongDan" class="table table-bordered table-hover dataTable" BorderColor="Black" BorderWidth="1px"
                                        Style="word-break: break-all; word-wrap: break-word" runat="server" AutoGenerateColumns="false"
                                        DataKeyNames="ID" OnRowUpdating="grd_CanCuocCongDan_RowUpdating" OnRowDeleting="grd_CanCuocCongDan_RowDeleting"
                                        ShowFooter="true">
                                        <Columns>
                                            <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Số hộ khẩu<br />Tạm trú">
                                                <ItemTemplate>
                                                    <asp:TextBox CssClass="form-control" ID="SoCTDK" Font-Size="12px" Width="80px" Style="text-align: center; border: none"
                                                        TextMode="MultiLine" runat="server" Text='<%# Bind("SoCTDK") %>'  onblur="SoCTDK_blur(this.id)"
                                                        Rows="1" />
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox CssClass="form-control" ID="txtSoCTDK" Font-Size="14px" Width="80px" Style="text-align: center; border: none"
                                                        TextMode="MultiLine" runat="server" Rows="1" />
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Địa chỉ thường trú">
                                                <ItemTemplate>
                                                    <asp:TextBox CssClass="form-control" ID="DC_ThuongTru" Font-Size="14px" Width="130px" Style="border: none"
                                                        TextMode="MultiLine" runat="server" Text='<%# Bind("DC_ThuongTru") %>'  Rows="1" onblur="DC_ThuongTru_blur(this.id)"/>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox CssClass="form-control" ID="txtDC_ThuongTru" Font-Size="14px" Width="130px" Style="border: none"
                                                        TextMode="MultiLine" runat="server" Rows="1" />
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Họ tên">
                                                <ItemTemplate>
                                                    <asp:TextBox CssClass="form-control" ID="HoTen" Font-Size="14px" Width="110px" Style="border: none" TextMode="MultiLine"
                                                        runat="server" Text='<%# Bind("HoTen") %>'  Rows="1" onblur="hoten_blur(this.id)" />
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox CssClass="form-control" ID="txtHoTen" Font-Size="14px" Width="110px" Style="border: none" TextMode="MultiLine"
                                                        runat="server" Rows="1"/>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Căn cước" ControlStyle-Width="90px">
                                                <ItemTemplate>
                                                    <asp:TextBox CssClass="form-control" ID="CCCD" Font-Size="14px" Width="90px" Style="text-align: center; border: none"
                                                        runat="server" Text='<%# Bind("CCCD") %>' onblur="CCCD_blur(this.id)" />
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox CssClass="form-control" ID="txtCCCD" Font-Size="14px" Width="120px" Style="text-align: center; border: none"
                                                        runat="server" />
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Chứng minh">
                                                <ItemTemplate>
                                                    <asp:TextBox CssClass="form-control" ID="CMND" Font-Size="12px" Width="90px" Style="text-align: center; border: none"
                                                        runat="server" Text='<%# Bind("CMND") %>' onblur="CMND_blur(this.id)"/>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox CssClass="form-control" ID="txtCMND" Font-Size="14px" Width="100px" Style="text-align: center; border: none"
                                                        runat="server" />
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Hộ nghèo">
                                                <ItemTemplate>
                                                    <asp:DropDownList CssClass="form-control" ID="Ngheo_CanNgheo" Font-Size="14px" Width="100px" Style="text-align: center; border: none"
                                                        runat="server" Text='<%# Bind("Ngheo_CanNgheo") %>' onblur="Ngheo_CanNgheo_blur(this.id)" >
                                                        <asp:ListItem Text="Loại" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="Bình thường" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Nghèo" Value="1"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:DropDownList CssClass="form-control" ID="txtNgheo_CanNgheo" Font-Size="14px" Width="100px" Style="text-align: center; border: none"
                                                        runat="server">
                                                        <asp:ListItem Text="Bình thường" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Nghèo" Value="1"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Loại Cấp ĐM">
                                                <ItemTemplate>
                                                    <asp:DropDownList CssClass="form-control" ID="Loai_CDM" Font-Size="14px" Width="100px" Style="text-align: center; border: none"
                                                        runat="server" Text='<%# Bind("Loai_CDM") %>' onblur="Loai_CDM_blur(this.id)">
                                                        <asp:ListItem Text="Loại" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="Thường trú" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Tạm trú" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="Cắt chuyển định mức" Value="3"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:DropDownList CssClass="form-control" ID="txtLoai_CDM" Font-Size="14px" Width="100px" Style="text-align: center; border: none"
                                                        runat="server">
                                                        <asp:ListItem Text="Thường trú" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Tạm trú" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="Cắt chuyển định mức" Value="3"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Hạn tạm trú">
                                                <ItemTemplate>
                                                    <asp:TextBox CssClass="form-control" ID="ThoiHanTamTru" Font-Size="14px" Width="130px" Style="text-align: center; border: none"
                                                        runat="server" Text='<%# Bind("ThoiHanTamTru") %>' data-inputmask="'alias': 'dd/mm/yyyy'" TextMode="Date" onblur="ThoiHanTamTru_blur(this.id)" />
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox CssClass="form-control" ID="txtThoiHanTamTru" Font-Size="14px" Width="130px" Style="text-align: center; border: none"
                                                        runat="server" data-inputmask="'alias': 'dd/mm/yyy'" TextMode="Date" />
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="DB cắt ĐM">
                                                <ItemTemplate>
                                                    <asp:TextBox CssClass="form-control" ID="DBo_CatDinhMuc" Font-Size="14px" Width="100px" Style="text-align: center; border: none"
                                                        runat="server" Text='<%# Bind("DBo_CatDinhMuc") %>' onblur="DBo_CatDinhMuc_blur(this.id)"  />
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox CssClass="form-control" ID="txtDBo_CatDinhMuc" Font-Size="14px" Width="100px" Style="text-align: center; border: none"
                                                        runat="server" />
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Phòng">
                                                <ItemTemplate>
                                                    <asp:TextBox CssClass="form-control" ID="Phong" Font-Size="14px" Width="40px" Style="text-align: center; border: none"
                                                        runat="server" Text='<%# Bind("Phong") %>' onblur="Phong_blur(this.id)" />
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox CssClass="form-control" ID="txtPhong" Font-Size="14px" Width="40px" Style="text-align: center; border: none"
                                                        runat="server" />
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Ghi chú">
                                                <ItemTemplate>
                                                    <asp:TextBox CssClass="form-control" ID="GhiChu" Font-Size="14px" Width="100px" Style="border: none" TextMode="MultiLine"
                                                        runat="server" Text='<%# Bind("GhiChu") %>' onblur="GhiChu_blur(this.id)" />
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox CssClass="form-control" ID="txtGhiChu" Font-Size="14px" Width="100px" Style="border: none" TextMode="MultiLine"
                                                        runat="server" Rows="1" />
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="" FooterStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Button ID="Button1" CommandName="Update" Text="Cập nhật" runat="server" CssClass="btn btn-google"></asp:Button>
                                                    <asp:Button ID="Button2" CommandName="Delete" Text="Xóa" runat="server" CssClass="btn btn-google"></asp:Button>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Button runat="server" ID="Add" CommandName="Add" Text="Bổ sung" OnClick="Add_Click" CssClass="btn btn-google" />
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
<%--                </ContentTemplate>
            </asp:UpdatePanel>--%>
            <!--end cccd-->
        </div>
    </form>
    <!-- jQuery -->
</asp:Content>
