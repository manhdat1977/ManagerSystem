<%@ Page Title="" Language="C#" MasterPageFile="~/Site_ver2.Master" AutoEventWireup="true" CodeBehind="thongkeSOT.aspx.cs" Inherits="ManagerSystem.thongkeSOT" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentCSS" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHeader" runat="server">
    <div class="container-fluid">
        <div class="row mb-2">
            <div class="col-sm-6">
                <h1>Thống kê</h1>
            </div>
            <div class="col-sm-6">
                <ol class="breadcrumb float-sm-right">
                    <li class="breadcrumb-item"><a href="#">Home</a></li>
                    <li class="breadcrumb-item active">Thống kê</li>
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
                    <div class="row">
                        <div class="row">
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label style="visibility: hidden">fgfg</label>
                                    <asp:DropDownList runat="server" CssClass="form-control" ID="dropLoaiThongKe">
                                        <asp:ListItem Text="Chọn loại thống kê...."></asp:ListItem>
                                        <asp:ListItem Text="Tất cả"></asp:ListItem>
                                        <asp:ListItem Text="Chưa hoàn công"></asp:ListItem>
                                        <asp:ListItem Text="Hoàn công"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label style="visibility: hidden">fgfg</label>
                                    <asp:DropDownList runat="server" ID="dropFindTieuChi" CssClass="form-control">
                                        <asp:ListItem Text="Chọn loại tiêu chí"></asp:ListItem>
                                        <asp:ListItem Text="Tất cả"></asp:ListItem>
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
                            </div>
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
                            <div class="col-md-1">
                                <div class="form-group">
                                    <label style="visibility: hidden">fdf</label>
                                    <asp:Button runat="server" CssClass="btn btn-primary" Text="Thống kê" ID="btnThongKe" OnClick="btnThongKe_Click" />
                                </div>
                            </div>
                            <div class="col-md-1">
                                <div class="form-group">
                                    <label style="visibility: hidden">dfdf</label>
                                    <asp:Button runat="server" CssClass="btn btn-primary" Text="Export" ID="btnExport" OnClick="btnExport_Click" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <asp:GridView runat="server" ID="gridThongKe" CssClass="table table-bordered" AutoGenerateColumns="False" DataKeyNames="ID">
                                <Columns>
                                    <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="SoPhieu" HeaderText="Số phiếu" />
                                    <asp:BoundField DataField="Dbo" HeaderText="Danh bạ" />
                                    <asp:BoundField DataField="KHang" HeaderText="Khách hàng" />
                                    <asp:BoundField DataField="NguoiLienLac" HeaderText="Người báo" />
                                    <asp:BoundField DataField="DChi" HeaderText="Địa chỉ" />
                                    <asp:BoundField DataField="NoidungKHBao" HeaderText="Nội dung khác hàng báo" />
                                    <asp:BoundField DataField="NoiDungSuaChua" HeaderText="Nội dung sửa chữa" />
                                    <asp:BoundField DataField="ThoigianNhanHS" HeaderText="Ngày nhận hồ sơ" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField DataField="ThoiGianHoanThanh" HeaderText="Ngày hoàn thành" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField DataField="NhanVienThucHien" HeaderText="Nhân viên thực hiện" />
                                    <asp:BoundField DataField="DanhGia" HeaderText="Đánh giá" />
                                    <asp:BoundField DataField="HoanCong" HeaderText="Hoàn công" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
