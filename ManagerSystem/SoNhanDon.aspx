<%@ Page Title="" Language="C#" MasterPageFile="~/Site_ver2.Master" AutoEventWireup="true" CodeBehind="SoNhanDon.aspx.cs" Inherits="ManagerSystem.SoNhanDon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentCSS" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHeader" runat="server">
    <div class="container-fluid">
        <div class="row mb-2">
            <div class="col-sm-6">
                <h1>Cập nhật đơn khách hàng</h1>
            </div>
            <div class="col-sm-6">
                <ol class="breadcrumb float-sm-right">
                    <li class="breadcrumb-item"><a href="#">Home</a></li>
                    <li class="breadcrumb-item active">Sổ nhận đơn</li>
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
                        <div class="card-body table-responsive no-padding no-border">
                            <table class="table table-bordered" style="background-color: #87CEEB">
                                <tbody>
                                    <tr>
                                        <th style="text-align: center" colspan="4">Đơn thư Phòng KD-DVKH</th>
                                        <th style="text-align: center" colspan="2">Công văn bảng kê đề nghị của PBĐ</th>
                                    </tr>
                                    <tr>
                                        <th style="text-align: center">Loại đơn</th>
                                        <th style="text-align: center">Số đơn</th>
                                        <th style="text-align: center">Ngày</th>
                                        <th style="text-align: center">Theo yêu cầu PBĐ</th>
                                        <th style="text-align: center">Số văn bản</th>
                                        <th style="text-align: center">Ngày lập</th>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center">
                                            <asp:DropDownList CssClass="form-control" ID="dropLoaidon" runat="server">
                                                <asp:ListItem Text="KN"></asp:ListItem>
                                                <asp:ListItem Text="DC"></asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtSoDon" CssClass="form-control"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtNgay" CssClass="form-control"></asp:TextBox></td>
                                        <td>
                                            <asp:DropDownList ID="dropPBD" runat="server" CssClass="form-control">
                                                <asp:ListItem Text="01- Khách hàng"></asp:ListItem>
                                                <asp:ListItem Text="02- Đơn thư trên WEB"></asp:ListItem>
                                                <asp:ListItem Text="03- Quản lý đồng hồ nước"></asp:ListItem>
                                                <asp:ListItem Text="04- Phòng Tổ chức - Hành Chánh"></asp:ListItem>
                                                <asp:ListItem Text="05- Ban Giám đốc"></asp:ListItem>
                                                <asp:ListItem Text="06- Phòng Thu ngân"></asp:ListItem>
                                                <asp:ListItem Text="07- Kinh doanh dịch vụ khách hàng"></asp:ListItem>
                                                <asp:ListItem Text="08- Quản lí giảm nước không doanh thu"></asp:ListItem>
                                                <asp:ListItem Text="09- Phòng Kỷ thuật"></asp:ListItem>
                                                <asp:ListItem Text="10- Thi công tu bổ"></asp:ListItem>
                                                <asp:ListItem Text="11- Phòng kế hoạch vật tư"></asp:ListItem>
                                                <asp:ListItem Text="12- Ban Quản lý dự án"></asp:ListItem>
                                                <asp:ListItem Text="15- Sửa bể"></asp:ListItem>
                                                <asp:ListItem Text="16- Tự Kiểm tra trên địa bàn"></asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtSoVanBan" CssClass="form-control"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtNgayLap" CssClass="form-control"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <th style="text-align: center" colspan="4">Nội dung đơn hoặc yêu cầu của Phòng, Ban, Đội</th>
                                        <th style="text-align: center" colspan="2">Nhóm thông tin</th>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtNoiDung"></asp:TextBox></td>
                                        <td colspan="2">
                                            <asp:DropDownList runat="server" ID="dropNhomThongTin" CssClass="form-control"></asp:DropDownList></td>
                                    </tr>
                                </tbody>
                            </table>

                        </div>
                        <div class="form-horizontal" style="background-color: #87CEEB">
                            <div class="card-body">
                                <div class="form-group row">
                                    <label class="col-md-1 col-form-label" style="text-align: left">Danh bạ</label>
                                    <div class="col-md-2">
                                        <asp:TextBox runat="server" ID="txtDanhBa" CssClass="form-control"></asp:TextBox>
                                        <asp:Button runat="server" ID="btnTimDBa" Text="Tìm danh bạ"
                                            CssClass="btn btn-danger" OnClick="btnTimDBa_Click"></asp:Button>
                                    </div>
                                    <label class="col-md-1 col-form-label" style="text-align: right">Hợp đồng</label>
                                    <div class="col-md-2">
                                        <asp:TextBox runat="server" ID="txtHopDong" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <label class="col-md-1 col-form-label" style="text-align: right">Lộ trình</label>
                                    <div class="col-md-2">
                                        <asp:TextBox runat="server" ID="txtLoTrinh" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <label class="col-md-1 col-form-label" style="text-align: right">Điện thoại 1</label>
                                    <div class="col-md-2">
                                        <asp:TextBox runat="server" ID="txtSDT1" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-md-1 col-form-label" style="text-align: left">Khách hàng</label>
                                    <div class="col-md-5">
                                        <asp:TextBox runat="server" ID="txtKH" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <label class="col-md-1 col-form-label" style="text-align: right">Địa chỉ</label>
                                    <div class="col-md-2">
                                        <asp:TextBox runat="server" ID="txtDiaChi" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <label class="col-md-1 col-form-label" style="text-align: right">Điện thoại 2</label>
                                    <div class="col-md-2">
                                        <asp:TextBox runat="server" ID="txtSDT2" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-md-1 col-form-label" style="text-align: left">Quận</label>
                                    <div class="col-md-1">
                                        <asp:TextBox runat="server" ID="txtQuan" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <label class="col-md-1 col-form-label" style="text-align: right">Giá biểu</label>
                                    <div class="col-md-1">
                                        <asp:TextBox runat="server" ID="txtGB" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <label class="col-md-1 col-form-label" style="text-align: right">Định mức</label>
                                    <div class="col-md-1">
                                        <asp:TextBox runat="server" ID="txtDMuc" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <label class="col-md-1 col-form-label" style="text-align: right">Email</label>
                                    <div class="col-md-2">
                                        <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <label class="col-md-1 col-form-label" style="text-align: right">Điện thoại 3</label>
                                    <div class="col-md-2">
                                        <asp:TextBox runat="server" ID="txtSDT3" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-md-1 col-form-label" style="text-align: left">Phường</label>
                                    <div class="col-md-1">
                                        <asp:TextBox runat="server" ID="txtPhuong" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <label class="col-md-1 col-form-label" style="text-align: left">Ghi chú</label>
                                    <div class="col-md-3">
                                        <asp:TextBox runat="server" ID="txtGhiChu" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <label class="col-md-1 col-form-label" style="text-align: right">Xác nhận nợ</label>
                                    <div class="col-md-2">
                                        <asp:TextBox runat="server" ID="txtXacNhanNo" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <label class="col-md-1 col-form-label" style="text-align: right">Hiệu lực</label>
                                    <div class="col-md-2">
                                        <asp:TextBox runat="server" ID="txtHieuLuc" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-md-2" style="width: 10%">
                                        <div class="checkbox">
                                            <label>
                                                <asp:CheckBox runat="server" ID="chkChuaCoDBa" AutoPostBack="true"
                                                    OnCheckedChanged="chkChuaCoDBa_CheckedChanged" />
                                                Chưa có danh bạ
                                            </label>
                                        </div>
                                    </div>
                                    <div class="col-md-2" style="width: 10%">
                                        <div class="checkbox">
                                            <label>
                                                <asp:CheckBox runat="server" ID="chkKhongKTra" />
                                                Không kiểm tra
                                            </label>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="checkbox">
                                            <label>
                                                <asp:CheckBox runat="server" ID="chkSMS" />
                                                Nhận tin nhắn SMS
                                            </label>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-12" style="text-align: center">
                                        <asp:Button ID="btnIn" Text="In biên nhận" CssClass="btn btn-danger"
                                            runat="server" OnClick="btnIn_Click" OnClientClick="aspnetForm.target ='_blank';" />
                                        <asp:Button ID="btnLichSu" Text="Lịch sử nhận đơn" CssClass="btn btn-danger"
                                            runat="server" OnClick="btnLichSu_Click" OnClientClick="document.forms[0].target = '_blank';" />
                                        <asp:Button ID="btnLSBienDong" Text="Lịch sử biến động" CssClass="btn btn-danger"
                                            runat="server" OnClientClick="document.forms[0].target = '_blank';" OnClick="btnLSBienDong_Click" />
                                        <asp:Button ID="btnCapNhat" Text="Cập nhật" CssClass="btn btn-danger" Visible="False"
                                            runat="server" OnClick="btnCapNhat_Click" />
                                    </div>
                                </div>
                                <asp:Label runat="server" ID="lblMessage" Visible="false" ForeColor="Red" Font-Bold="true"></asp:Label>
                                <div class="form-group has-success">
                                    <label class="col-md-2 control-label" style="text-align: left">
                                        <i class="fa fa-check"></i>
                                        Chứng từ kèm theo:</label>
                                </div>
                                <div class="form-group row">
                                    <div class="col-md-1">
                                        <div class="checkbox">
                                            <label>
                                                <asp:CheckBox runat="server" ID="chkHoaDon" />Hóa đơn</label>
                                        </div>
                                    </div>
                                    <div class="col-md-2" style="width: 12%">
                                        <div class="checkbox">
                                            <label>
                                                <asp:CheckBox runat="server" ID="chkHKKT3" />Hộ khẩu hoặc KT3</label>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="checkbox">
                                            <label>
                                                <asp:CheckBox runat="server" ID="chkSTTru" />Sổ tạm trú hoặc Giấy XN tạm trú</label>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="checkbox">
                                            <label>
                                                <asp:CheckBox runat="server" ID="chkHDThueNha" />HĐ thuê nhà hoặc CQ nhà</label>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="checkbox">
                                            <label>
                                                <asp:CheckBox runat="server" ID="chkGiayCapSoNha" />Giấy cấp hoặc đổi số nhà</label>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="checkbox">
                                            <label>
                                                <asp:CheckBox runat="server" ID="chkXacNhanSoNha" />Giấy xác nhận hai số nhà là một</label>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-md-2">
                                        <div class="checkbox">
                                            <label>
                                                <asp:CheckBox runat="server" ID="chkGDKKD" />Giấy đăng ký kinh doanh</label>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="checkbox">
                                            <label>
                                                <asp:CheckBox runat="server" ID="chkMST" />Giấy chứng nhận MST</label>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="checkbox">
                                            <label>
                                                <asp:CheckBox runat="server" ID="chkGiayUngThuan" />Giấy ưng thuận đứng tên ĐHN</label>
                                        </div>
                                        <div class="checkbox">
                                            <asp:Label ID="lblMaNVKTra" runat="server" Visible="false"></asp:Label>
                                            <asp:Label ID="lblID" runat="server" Visible="false"></asp:Label>
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
