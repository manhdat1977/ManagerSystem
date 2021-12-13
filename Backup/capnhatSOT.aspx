<%@ Page Title="" Language="C#" MasterPageFile="~/Site_ver2.Master" AutoEventWireup="true" CodeBehind="capnhatSOT.aspx.cs" Inherits="ManagerSystem.capnhatSOT" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentCSS" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHeader" runat="server">
    <div class="container-fluid">
        <div class="row mb-2">
            <div class="col-sm-6">
                <h1>Cập nhật hoàn công</h1>
            </div>
            <div class="col-sm-6">
                <ol class="breadcrumb float-sm-right">
                    <li class="breadcrumb-item"><a href="#">Home</a></li>
                    <li class="breadcrumb-item active">Cập nhật hoàn công</li>
                </ol>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
        <div class="card card-primary ">
            <div class="form-horizontal" runat="server">
                <div class="card-body">
                    <div class="form-group row">
                        <asp:DropDownList runat="server" CssClass="form-control col-md-1" ID="dropTimKiem">
                            <asp:ListItem Text="Tìm theo..."></asp:ListItem>
                            <asp:ListItem Text="Danh bạ"></asp:ListItem>
                            <asp:ListItem Text="Số phiếu"></asp:ListItem>
                            <asp:ListItem Text="Địa chỉ"></asp:ListItem>
                        </asp:DropDownList>
                        <div class="col-md-5">
                            <div class="input-group input-group-md">
                                <asp:TextBox runat="server" ID="txtTimKiem" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-append">
                                    <asp:Button CssClass="btn btn-info btn-flat" OnClick="btnTimKiem_Click" runat="server" ID="btnTimKiem" Text="Tìm kiếm" Width="100%" />
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-md-1 col-form-label" style="text-align: right">Số phiếu</label>
                        <div class="col-md-1">
                            <asp:TextBox runat="server" ID="txtSoPhieu" CssClass="form-control" Enabled="false"></asp:TextBox>
                        </div>
                        <asp:Label class="col-md-2 col-form-label" Style="text-align: left" runat="server" ID="lblSoPhieu" Enabled="false"></asp:Label>
                        <label class="col-md-1 col-form-label" style="text-align: right">Danh bạ</label>
                        <div class="col-md-2">
                            <asp:TextBox CssClass="form-control" ID="txtDba" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                        <label class="col-md-1 col-form-label" style="text-align: right">MLT</label>
                        <div class="col-md-1">
                            <asp:TextBox runat="server" ID="txtMLT" CssClass="form-control" Enabled="false"></asp:TextBox>
                        </div>

                    </div>
                    <div class="form-group row">
                        <label class="col-md-1 col-form-label" style="text-align: right">Khách hàng</label>
                        <div class="col-md-5">
                            <asp:TextBox runat="server" ID="txtKH" CssClass="form-control" Enabled="false"></asp:TextBox>
                        </div>
                        <label class="col-md-1 col-form-label" style="text-align: right">Địa chỉ</label>
                        <div class="col-md-5">
                            <asp:TextBox runat="server" ID="txtDC" CssClass="form-control" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-md-1 col-form-label" style="text-align: right">Người báo</label>
                        <div class="col-md-2">
                            <asp:TextBox runat="server" ID="txtNguoiBao" CssClass="form-control" Enabled="false"></asp:TextBox>
                        </div>
                        <label class="col-md-1 col-form-label" style="text-align: right">SĐT</label>
                        <div class="col-md-1">
                            <asp:TextBox runat="server" ID="txtSDT" CssClass="form-control" Enabled="false"></asp:TextBox>
                        </div>
                        <label class="col-md-1 col-form-label" style="text-align: right">Nội dung</label>
                        <div class="col-md-3">
                            <asp:TextBox runat="server" ID="txtNoiDung" CssClass="form-control" Enabled="false"></asp:TextBox>
                        </div>
                        <label class="col-md-1 col-form-label" style="text-align: right">Ghi chú</label>
                        <div class="col-md-2">
                            <asp:TextBox runat="server" ID="txtGhiChu" CssClass="form-control" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-md-1 col-form-label" style="text-align: right">Tiêu chí</label>
                        <div class="col-md-3">
                            <asp:DropDownList runat="server" ID="dropTieuChi" CssClass="form-control">
                                <asp:ListItem Text="Đội thi công sửa chữa"></asp:ListItem>
                                <asp:ListItem Text="Đội thi công đã kiểm tra không có rò rỉ"></asp:ListItem>
                                <asp:ListItem Text="Khách hàng tự sửa chữa"></asp:ListItem>
                                <asp:ListItem Text="Đang chờ kết quả xử lý"></asp:ListItem>
                                <asp:ListItem Text="Đội thi công đã dò bể"></asp:ListItem>
                                <asp:ListItem Text="Nhà vắng chủ"></asp:ListItem>
                                <asp:ListItem Text="Khách hàng hẹn lại"></asp:ListItem>
                                <asp:ListItem Text="Khách hàng không đồng ý làm"></asp:ListItem>
                                <asp:ListItem Text="Khách hàng không báo"></asp:ListItem>
                                <asp:ListItem Text="Khách hàng khiếu nại đồng hồ nước"></asp:ListItem>
                                <asp:ListItem Text="Không tìm thấy điểm bể"></asp:ListItem>
                                <asp:ListItem Text="Trở ngại"></asp:ListItem>
                                <asp:ListItem Text="Khác"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <label class="col-md-2 col-form-label" style="text-align: right">Nội dung sửa chữa</label>
                        <div class="col-md-6">
                            <asp:TextBox runat="server" ID="txtNDSuaChua" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-md-1 col-form-label" style="text-align: right">Nhân viên thực hiện</label>
                        <div class="col-md-3">
                            <asp:TextBox runat="server" ID="txtNVThucHien" CssClass="form-control"></asp:TextBox>
                        </div>
                        <label class="col-md-2 col-form-label" style="text-align: right">Đánh giá</label>
                        <div class="col-md-2">
                            <asp:DropDownList runat="server" ID="dropDanhGia" CssClass="form-control">
                                <asp:ListItem Text=""></asp:ListItem>
                                <asp:ListItem Text="Rất hài lòng"></asp:ListItem>
                                <asp:ListItem Text="Hài lòng"></asp:ListItem>
                                <asp:ListItem Text="Không hài lòng"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-2">
                            <div class="checkbox">
                                <label>
                                    <asp:CheckBox runat="server" ID="chkHoanCong" />Hoàn công</label>
                            </div>
                        </div>
                    </div>
                    <div class="card-footer" style="text-align: center">
                        <asp:Button runat="server" ID="btnCapNhatHoanCong" Text="Cập nhật hoàn công" CssClass="btn btn-primary" OnClick="btnCapNhatHoanCong_Click" />
                        <asp:Label ID="lblID" runat="server" Visible="false"></asp:Label>
                    </div>
                    <div class="col-md-12">
                        <asp:GridView runat="server" CssClass="table table-bordered" DataKeyNames="ID" ID="gridCapNhatHoanCong" AutoGenerateColumns="false" OnRowCommand="gridCapNhatHoanCong_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="SoPhieu" HeaderText="Số phiếu" />
                                <asp:BoundField DataField="Dbo" HeaderText="Danh bạ" />
                                <asp:BoundField DataField="KHang" HeaderText="Khách hàng" />
                                <asp:BoundField DataField="DChi" HeaderText="Địa chỉ" />
                                <asp:BoundField DataField="NoidungKHBao" HeaderText="Nội dung khác hàng báo" />
                                <asp:BoundField DataField="NoiDungSuaChua" HeaderText="Nội dung sửa chữa" />
                                <asp:BoundField DataField="ThoigianNhanHS" HeaderText="Ngày nhận hồ sơ" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:BoundField DataField="ThoiGianHoanThanh" HeaderText="Ngày hoàn thành" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:BoundField DataField="NhanVienThucHien" HeaderText="Nhân viên thực hiện" />
                                <asp:BoundField DataField="DanhGia" HeaderText="Đánh giá" />
                                <asp:BoundField DataField="HoanCong" HeaderText="Hoàn công" />
                                <asp:ButtonField ButtonType="Link" Text="Chọn" CommandName="Select" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </form>

</asp:Content>
