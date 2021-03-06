using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Quanlybansach.Models;

namespace Quanlybansach.Controllers
{
    public class KhachhangsController : Controller
    {
        private QLBSDBcontext db = new QLBSDBcontext();

        // GET: Khachhangs
        public ActionResult Index()
        {
            return View(db.Khachhangs.ToList());
        }

        // GET: Khachhangs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Khachhang khachhang = db.Khachhangs.Find(id);
            if (khachhang == null)
            {
                return HttpNotFound();
            }
            return View(khachhang);
        }

        // GET: Khachhangs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Khachhangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "makh,tenkh,taikhoan,matkhau,email,diachi,dienthoai")] Khachhang khachhang)
        {
            if (ModelState.IsValid)
            {
                db.Khachhangs.Add(khachhang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(khachhang);
        }

        // GET: Khachhangs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Khachhang khachhang = db.Khachhangs.Find(id);
            if (khachhang == null)
            {
                return HttpNotFound();
            }
            return View(khachhang);
        }

        // POST: Khachhangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "makh,tenkh,taikhoan,matkhau,email,diachi,dienthoai")] Khachhang khachhang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khachhang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(khachhang);
        }

        // GET: Khachhangs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Khachhang khachhang = db.Khachhangs.Find(id);
            if (khachhang == null)
            {
                return HttpNotFound();
            }
            return View(khachhang);
        }

        // POST: Khachhangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Khachhang khachhang = db.Khachhangs.Find(id);
            db.Khachhangs.Remove(khachhang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            try
            {
                //upload file thanh cong va file co du lieu
                if (file.ContentLength > 0)
                {
                    //Your code
                    string _FileName = "Khachhang.xlsx";
                    //duong dan luu file
                    string _path = Path.Combine(Server.MapPath("~/Uploads/Excels"), _FileName);
                    //luu file len server
                    file.SaveAs(_path);
                    DataTable dt = ReadDataFromExcelFile(_path);
                    CopyDataByBulk(dt);
                }
            }
            catch (Exception)
            {
                //neu upload file that bai
            }
            return RedirectToAction("Index");
        }

        //doc file excel tra ve du lieu dang datatable
        public DataTable ReadDataFromExcelFile(string filepath)
        {
            string connectionString = "";
            string fileExtention = filepath.Substring(filepath.Length - 4).ToLower();
            if (fileExtention.IndexOf("xlsx") == 0)
            {
                connectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + filepath + ";Extended Properties=\"Excel 12.0 Xml;HDR=NO\"";
            }
            else if (fileExtention.IndexOf("xls") == 0)
            {
                connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filepath + ";Extended Properties=Excel 8.0";
            }

            // Tạo đối tượng kết nối
            OleDbConnection oledbConn = new OleDbConnection(connectionString);
            DataTable data = null;
            try
            {
                // Mở kết nối
                oledbConn.Open();

                // Tạo đối tượng OleDBCommand và query data từ sheet có tên "Sheet1"
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Sheet1$]", oledbConn);

                // Tạo đối tượng OleDbDataAdapter để thực thi việc query lấy dữ liệu từ tập tin excel
                OleDbDataAdapter oleda = new OleDbDataAdapter();

                oleda.SelectCommand = cmd;

                // Tạo đối tượng DataSet để hứng dữ liệu từ tập tin excel
                DataSet ds = new DataSet();

                // Đổ đữ liệu từ tập excel vào DataSet
                oleda.Fill(ds);

                data = ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // Đóng chuỗi kết nối
                oledbConn.Close();
            }
            return data;
        }
        //copy large data from datatable to sqlserver
        private void CopyDataByBulk(DataTable dt)
        {
            //lay ket noi voi database luu trong file webconfig
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["QLBSDBcontext"].ConnectionString);
            SqlBulkCopy bulkcopy = new SqlBulkCopy(con);
            con.Open();
            bulkcopy.DestinationTableName = "Khachhangs";
            bulkcopy.ColumnMappings.Add(0, "makh");
            bulkcopy.ColumnMappings.Add(1, "tenkh");
            bulkcopy.ColumnMappings.Add(2, "taikhoan");
            bulkcopy.ColumnMappings.Add(3, "matkhau");
            bulkcopy.ColumnMappings.Add(3, "email");
            bulkcopy.ColumnMappings.Add(3, "diachi");
            bulkcopy.ColumnMappings.Add(3, "dienthoai");
            


            bulkcopy.WriteToServer(dt);
            con.Close();
        }
        public ActionResult DownloadFile()
        {
            //duong dan chua file muon download
            string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/Excels/";
            //chuyen file sang dang byte
            byte[] fileBytes = System.IO.File.ReadAllBytes(path + "Khachhang.xlsx");
            //ten file khi download ve
            string fileName = "Khachhang.xlsx";
            //tra ve file
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }
}

 