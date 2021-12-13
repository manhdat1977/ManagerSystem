<%@ Page Title="" Language="C#" MasterPageFile="~/Site_ver2.Master" AutoEventWireup="true" CodeBehind="donnhantrongngay.aspx.cs" Inherits="ManagerSystem.donnhantrongngay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentCSS" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHeader" runat="server">
    <div class="container-fluid">
        <div class="row mb-2">
            <div class="col-sm-6">
                <h1>Danh sách đơn trong ngày</h1>
            </div>
            <div class="col-sm-6">
                <ol class="breadcrumb float-sm-right">
                    <li class="breadcrumb-item"><a href="#">Home</a></li>
                    <li class="breadcrumb-item active">Danh sách đơn trong ngày</li>
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
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="box-danger">
                            </div>
                            <div class="box-body">
                                <div class="form-group">
                                    <label style="visibility: hidden">AAA</label>
                                    <div class="input-group">
                                        <asp:Button runat="server" Text="Tìm" class="btn btn-info" ID="btn_Tim" Width="80%" OnClick="btn_Tim_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-3"></div>
                    </div>
                </div>
                <div class="card-body">
                    <div class="dataTables_wrapper dt-bootstrap4">
                        <div class="row">
                            <div class="col-md-12 col-md-6">
                                <div id="example1_filter" class="dataTables_filter">
                                    <label>
                                        Search:
                                        <%--<input type="search" class="form-control form-control-sm" placeholder="" aria-controls="example1">--%>
                                        <asp:TextBox CssClass="form-control form-control-md" placeholder="Nhập mã nhân viên cần tìm" runat="server" ID="txtSearch"></asp:TextBox>

                                    </label>
                                    <asp:Button ID="txtFindByName" runat="server" CssClass="btn btn-info" Text="Tìm" Width="10%" OnClick="txtFindByName_Click" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <asp:GridView ID="gridData" CssClass="table table-bordered table-striped dataTable dtr-inline" runat="server" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="dbo" HeaderText="Danh bạ" />
                                        <asp:BoundField DataField="Khang" HeaderText="Khách hàng" />
                                        <asp:BoundField DataField="DThoaiKH" HeaderText="Điện thoại" />
                                        <asp:BoundField DataField="Dchi" HeaderText="Địa chỉ" />
                                        <%--<asp:BoundField DataField="QTT" HeaderText="Quận" />
                                        <asp:BoundField DataField="PTT" HeaderText="Phường" />--%>
                                        <asp:BoundField DataField="SDon" HeaderText="Số đơn" />
                                        <asp:BoundField DataField="LDon" HeaderText="Loại đơn" />
                                        <asp:BoundField DataField="NNDon" HeaderText="Ngày nhận " />
                                        <asp:BoundField DataField="nddon" HeaderText="Nội dung" />
                                        <asp:BoundField DataField="BPYeuCau" HeaderText="BP yêu cầu" />
                                        <asp:BoundField DataField="NhomKN" HeaderText="Nhóm khiếu nại" />
                                        <asp:BoundField DataField="GBieu" HeaderText="Giá biểu" />
                                        <asp:BoundField DataField="DMuc" HeaderText="Định mức" />
                                        <asp:BoundField DataField="GChu" HeaderText="Ghi chú" />
                                        <asp:BoundField DataField="MaNV" HeaderText="Nhân viên nhận HS" />
                                        <asp:BoundField DataField="MaNVKtra" HeaderText="Nhân viên kiểm tra" />
                                        <asp:BoundField DataField="KhongKiemTra" HeaderText="Không kiểm tra" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
