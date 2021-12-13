using System;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.IO;
namespace ManagerSystem
{
    public partial class importimage : System.Web.UI.Page
    {
        ConnectDB condb = new ConnectDB();
        private SqlConnection _conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblmes.Visible = false;
            }

        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            DataTable _dt = new DataTable("dt_Image");
            _dt.Columns.Add("DBo", typeof(string));
            _dt.Columns.Add("BanVe", typeof(byte[]));
            Response.BufferOutput = false;
            foreach (HttpPostedFile file in file_upload.PostedFiles)
            {
                byte[] data = new byte[file.ContentLength];
                file.InputStream.Read(data, 0, file.ContentLength);
                _dt.Rows.Add(file.FileName.Substring(0, file.FileName.Length - 4), data);
            }
            _conn = condb.connectBanVe();
            _conn.Open();
            SqlCommand cmd = new SqlCommand("EXEC proc_import_image @tmp_Image,@count_insert out", _conn);
            cmd.CommandTimeout = 0;
            cmd.Parameters.Add("@count_insert", SqlDbType.Int);
            cmd.Parameters["@count_insert"].Direction = ParameterDirection.Output;
            SqlParameter _param = cmd.Parameters.AddWithValue("@tmp_Image", _dt);
            _param.SqlDbType = SqlDbType.Structured;
            _param.TypeName = "dt_Image";
            cmd.ExecuteNonQuery();
            Response.Redirect(Request.Url.AbsoluteUri);
            lblmes.Text = "Đã cập nhật được " + cmd.Parameters["@count_insert"].Value.ToString() + " /" + _dt.Rows.Count + " bản vẽ.";
            lblmes.Visible = true;
            _conn.Close();
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void btnImportError_Click(object sender, EventArgs e)
        {
            _conn = condb.connectBanVe();
            _conn.Open();
            string query = "EXEC [proc_BanVeSai]";
            SqlCommand _cmd = new SqlCommand(query, _conn);
            DataTable _dt = new DataTable();
            SqlDataAdapter _da = new SqlDataAdapter(_cmd);
            _da.Fill(_dt);
            BanVeLoi.DataSource = _dt;
            BanVeLoi.DataBind();
            _conn.Close();
        }
    }
}