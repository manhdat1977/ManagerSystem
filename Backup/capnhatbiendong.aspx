<%@ Page Title="" Language="C#" MasterPageFile="~/Site_ver2.Master" AutoEventWireup="true" CodeBehind="capnhatbiendong.aspx.cs" Inherits="ManagerSystem.capnhatbiendong" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentCSS" runat="server">
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
                                <th style="text-align: center; vertical-align: middle; width:12%">Nhân viên nhận hồ sơ</th>
                                <th style="width: 15%"><asp:Label runat="server" ID="lblNVNhanHS"></asp:Label></th>
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
                                        <asp:TextBox runat="server" ID="txtNgayCapBN" CssClass="form-control" data-inputmask="'alias': 'dd/mm/yyyy'" data-mask=""
                                            AutoPostBack="true" OnTextChanged="txtNgayCapBN_TextChanged"></asp:TextBox></td>
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
                               <th  style="text-align: center; vertical-align: middle; width: 8%">
                                    <asp:CheckBox runat="server" ID="chkInbienDong" Text="In biến động" Checked="true" />
                               </th>
                                <th style="width: 5%">
                                    <asp:Button runat="server" ID="btnLuu" CssClass="btn btn-danger" Text="Lưu" OnClick="btnLuu_Click"/>
                                </th>
                                <th style="width: 8%">
                                    <asp:Button runat="server" ID="btnThongTinGQD" CssClass="btn btn-danger" Text="Thông tin GQĐ" OnClick="btnThongTinGQD_Click" OnClientClick="document.forms[0].target = '_blank';" /></th>
                                <th style="text-align: center; vertical-align: middle; width: 15%">
                                    <asp:CheckBox runat="server" ID="chkCatDMTrung" Text="Cắt ĐM trùng chứng từ/CVĐ" /></th>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>

            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                    <p>Loading</p>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="col-md-12" runat="server" id="divSHK" visible="false">
                        <div class="card">
                            <%--  <div class="box-header with-border">
            </div>--%>
                            <div class="card-body">
                                <asp:Label runat="server" ID="txtTongNKDCap" Visible="false" CssClass="control-label" Font-Bold="true" ForeColor="Red"></asp:Label>
                                <p></p>
                                <asp:GridView CssClass="table table-bordered table-hover dataTable"
                                    runat="server" ID="gridSHK" DataKeyNames="ID"
                                    AutoGenerateColumns="False" OnRowCommand="gridSHK_RowCommand"
                                    AllowPaging="True" OnPageIndexChanging="gridSHK_PageIndexChanging"
                                    PageSize="1" ShowFooter="True" OnRowDataBound="gridSHK_RowDataBound"
                                    OnRowDeleting="gridSHK_RowDeleting">
                                    <Columns>
                                        <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Loại chứng từ" HeaderStyle-Width="7%">
                                            <ItemTemplate><%#Eval("MaLoaiSo") %></ItemTemplate>
                                            <FooterTemplate>
                                                <asp:DropDownList runat="server" ID="dropLoaiChungtu" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dropLoaiChungtu_SelectedIndexChanged">
                                                    <%--<asp:ListItem Text="HK08"></asp:ListItem>
                            <asp:ListItem Text="HK09"></asp:ListItem>
                            <asp:ListItem Text="HK11"></asp:ListItem>
                            <asp:ListItem Text="HK12"></asp:ListItem>
                            <asp:ListItem Text="KT03"></asp:ListItem>
                            <asp:ListItem Text="KT04"></asp:ListItem>
                            <asp:ListItem Text="XNTT"></asp:ListItem>--%>
                                                </asp:DropDownList>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Chú thích">
                                            <ItemTemplate><%#Eval("ChuThich")%></ItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox runat="server" ID="txtChuThich" CssClass="form-control" AutoPostBack="true"></asp:TextBox>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="QP">
                                            <ItemTemplate><%#Eval("QP")%></ItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox runat="server" ID="txtQP" CssClass="form-control"></asp:TextBox>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ShowHeader="false">
                                            <ItemTemplate>
                                                <%-- <asp:Label runat="server" Text='<%# Eval("SoCTDKDM")%>' ID="lblSoCTDKDM"></asp:Label>--%>
                                                <asp:HiddenField runat="server" Value='<%# Eval("MaCTDKDM")%>' ID="lblMaCTDKDM" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Số chứng từ đăng ký">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Text='<%# Eval("SoCTDKDM")%>' ID="lblSoCTDKDM"></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox runat="server" ID="txtSoCTDKDM" CssClass="form-control"></asp:TextBox>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Tổng NK">
                                            <ItemTemplate><%#Eval("TSNKhau")%></ItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox runat="server" ID="txtTSNKhau" CssClass="form-control"></asp:TextBox>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="NK cấp">
                                            <ItemTemplate><%#Eval("NKDCap")%></ItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox runat="server" ID="txtNKDCap" CssClass="form-control"></asp:TextBox>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Số phòng">
                                            <ItemTemplate><%#Eval("SoPhong")%></ItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox runat="server" ID="txtSoPhong" CssClass="form-control"></asp:TextBox>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Ghi chú">
                                            <ItemTemplate><%#Eval("GChu")%></ItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox runat="server" ID="txtGChu" CssClass="form-control"></asp:TextBox>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Ngày hết hạn">
                                            <ItemTemplate><%#Eval("NgayHetHan", "{0:dd/MM/yyyy}")%></ItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox runat="server" ID="txtNgayHetHan" CssClass="form-control" data-inputmask="'alias': 'dd/mm/yyyy'" data-mask=""></asp:TextBox>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <FooterTemplate>
                                                <asp:Button runat="server" CausesValidation="False" Text="Thêm" CommandName="AddNew" CssClass="btn btn-danger"></asp:Button>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:ButtonField ButtonType="Link" Text="Chọn" CommandName="Select"  />--%>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <%-- <asp:Button runat="server" ID="btnSelect" CommandName="Select" CssClass="btn btn-success" Text="Chọn" CausesValidation="False"/>--%>
                                                <asp:ImageButton ImageUrl="~/Images/finger.png" runat="server" ID="btnSelect" CommandName="Select" CausesValidation="False" Width="30px" Height="30px" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--   <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="~/Images/basket.png" runat="server" ID="btnDelete" CommandName="Delete" CausesValidation="False" Width="30px" Height="30px" />
                        </ItemTemplate>
                      </asp:TemplateField>--%>
                                        <asp:CommandField ButtonType="Image" ShowDeleteButton="true" DeleteText="Xóa" DeleteImageUrl="~/Images/basket-resize.png" />
                                    </Columns>
                                    <%-- <SelectedRowStyle BackColor="#FF9933" />--%>
                                    <PagerStyle CssClass="pagination-ys" />
                                </asp:GridView>
                            </div>
                            <div class="box-footer">
                                <a runat="server" id="linkSHK" visible="false" target="_blank">
                                    <asp:Label runat="server" ID="lblLink" Visible="false" ForeColor="Red"></asp:Label>
                                </a>
                                <asp:Label runat="server" Visible="false" ForeColor="Red" ID="lblStatus"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12" runat="server" id="divCMND" visible="false">
                        <div class="card">
                            <div class="card-body">
                                <asp:GridView CssClass="table table-bordered table-hover dataTable" runat="server" ID="gridCMND"
                                    AutoGenerateColumns="False" AllowPaging="True" DataKeyNames="CMND"
                                    OnPageIndexChanging="gridCMND_PageIndexChanging" PageSize="1"
                                    ShowFooter="True" OnRowCommand="gridCMND_RowCommand"
                                    OnRowDeleting="gridCMND_RowDeleting">
                                    <Columns>
                                        <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:BoundField DataField="SoCTDKDM" HeaderText="Số chứng từ đăng ký" />
                         <asp:BoundField DataField="LoaiCMND" HeaderText="Loại CMND" />
                         <asp:BoundField DataField="CMND" HeaderText="CMND" />
                         <asp:BoundField DataField="SoPhong" HeaderText="Số phòng" />
                         <asp:BoundField DataField="GhiChu" HeaderText="Diễn giải" />
                         <asp:BoundField DataField="KhongCMND" HeaderText="Không CMND" />--%>
                                        <asp:TemplateField HeaderText="Loại CMND">
                                            <ItemTemplate><%#Eval("LoaiCMND")%></ItemTemplate>
                                            <FooterTemplate>
                                                <asp:DropDownList runat="server" ID="dropLoaiCMND" CssClass="form-control">
                                                    <asp:ListItem Text="1. Có 9 số"></asp:ListItem>
                                                    <asp:ListItem Text="2. Có 12 số"></asp:ListItem>
                                                </asp:DropDownList>
                                            </FooterTemplate>
                                            <%--<FooterTemplate><asp:TextBox runat="server" ID="txtLoaiCMND" CssClass="form-control"></asp:TextBox></FooterTemplate>--%>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="CMND">
                                            <ItemTemplate><%#Eval("CMND")%></ItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox runat="server" ID="txtCMND" CssClass="form-control"></asp:TextBox>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Số phòng">
                                            <ItemTemplate><%#Eval("SoPhong")%></ItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox runat="server" ID="txtSoPhong" CssClass="form-control"></asp:TextBox>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Diễn giải">
                                            <ItemTemplate><%#Eval("GhiChu")%></ItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox runat="server" ID="txtGhiChu" CssClass="form-control"></asp:TextBox>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Không CMND">
                                            <ItemTemplate><%#Eval("KhongCMND")%></ItemTemplate>
                                            <FooterTemplate>
                                                <asp:CheckBox runat="server" ID="chkKhongCMND" CssClass="form-control" BorderStyle="None"></asp:CheckBox>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <FooterTemplate>
                                                <asp:Button ID="btnAddCMND" runat="server" CausesValidation="False" Text="Thêm" CommandName="AddNewCMND" CssClass="btn btn-danger"></asp:Button>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <%--   <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="~/Images/basket.png" runat="server" ID="btnDeleteCMND" CommandName="DeleteCMND" CausesValidation="False" Width="30px" Height="30px" />
                        </ItemTemplate>
                      </asp:TemplateField>--%>
                                        <asp:CommandField ButtonType="Image" ShowDeleteButton="true" DeleteText="Xóa" DeleteImageUrl="~/Images/basket-resize.png" />
                                    </Columns>
                                    <PagerStyle CssClass="pagination-ys" />
                                </asp:GridView>
                            </div>
                            <asp:Label ID="lblSoCT" runat="server" Visible="false"></asp:Label>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>       
    </form>
</asp:Content>
