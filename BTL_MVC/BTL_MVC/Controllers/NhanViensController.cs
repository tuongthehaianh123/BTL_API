using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using BTL_MVC.Models;
using Newtonsoft.Json;

namespace BTL_MVC.Controllers
{
    public class NhanViensController : Controller
    {
        private Model1 db = new Model1();
        // GET: api/NhanViens
        string BASE_URI = "http://localhost:50338/api/nhanvien/";

        // GET: NhanViens
        public ActionResult Index()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BASE_URI);

                var getTask = client.GetAsync("get-all");
                getTask.Wait();

                var result = getTask.Result;
                List<NhanVien> p = null;
                if (result.IsSuccessStatusCode)
                {
                    string data = result.Content.ReadAsStringAsync().Result;
                    p = JsonConvert.DeserializeObject<List<NhanVien>>(data);
                }
                return View(p);
            }
        }
        //timkiem
        public ActionResult Timkiem(string name, int? page)
        {

            IEnumerable<NhanVien> obj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:50338/api/nhanvien/api/GetNhanVienname/");
            var data = hc.GetAsync("GetProductname?name=" + name);
            data.Wait();
            var readdata = data.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<IEnumerable<NhanVien>>();
                displaydata.Wait();
                obj = displaydata.Result;
            }
            return View(obj);
        }
        // GET: NhanViens/Details/5
        public ActionResult Details(int? id)
        {
            using (var client = new HttpClient())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                client.BaseAddress = new Uri(BASE_URI);

                var getTask = client.GetAsync("get-by-id/" + id);
                getTask.Wait();

                var result = getTask.Result;
                NhanVien room = null;
                if (result.IsSuccessStatusCode)
                {
                    string data = result.Content.ReadAsStringAsync().Result;
                    room = JsonConvert.DeserializeObject<NhanVien>(data);
                }
                return View(room);
            }
        }

        // GET: NhanViens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NhanViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TENNV,CHUCVU,DIACHI,SODIENTHOAI,EMAIL,TENTK,MK")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BASE_URI);

                    string data = JsonConvert.SerializeObject(nhanVien);
                    StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

                    var putTask = client.PostAsync("create", content);
                    putTask.Wait();

                    var result = putTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }

            return View(nhanVien);
        }

        // GET: NhanViens/Edit/5
        public ActionResult Edit(int? id)
        {
            using (var client = new HttpClient())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                client.BaseAddress = new Uri(BASE_URI);

                var getTask = client.GetAsync("get-by-id/" + id);
                getTask.Wait();

                var result = getTask.Result;
                NhanVien room = null;
                if (result.IsSuccessStatusCode)
                {
                    string data = result.Content.ReadAsStringAsync().Result;
                    room = JsonConvert.DeserializeObject<NhanVien>(data);
                }
                return View(room);
            }
        }
        // POST: NhanViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TENNV,CHUCVU,DIACHI,SODIENTHOAI,EMAIL,TENTK,MK")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BASE_URI);

                    string data = JsonConvert.SerializeObject(nhanVien);
                    StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

                    var putTask = client.PutAsync("update", content);
                    putTask.Wait();

                    var result = putTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(nhanVien);
        }


        // GET: nhanviens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BASE_URI);

                var getTask = client.GetAsync("get-by-id/" + id);
                getTask.Wait();

                var result = getTask.Result;
                NhanVien room = null;
                if (result.IsSuccessStatusCode)
                {
                    string data = result.Content.ReadAsStringAsync().Result;
                    room = JsonConvert.DeserializeObject<NhanVien>(data);
                }
                return View(room);
            }
        }

        // POST: nhanviens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BASE_URI);

                var deleteTask = client.DeleteAsync("delete/" + id);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return View();
        }

       

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
