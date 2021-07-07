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
    public class LoaiSanPhamsController : Controller
    {
        private Model1 db = new Model1();

        // GET: api/LoaiSanPham
        string BASE_URI = "http://localhost:50338/api/LoaiSanpham/";

        // GET: LoaiSanPhams
        public ActionResult Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BASE_URI);

                var getTask = client.GetAsync("get-all");
                getTask.Wait();

                var result = getTask.Result;
                List<LoaiSanPham> p = null;
                if (result.IsSuccessStatusCode)
                {
                    string data = result.Content.ReadAsStringAsync().Result;
                    p = JsonConvert.DeserializeObject<List<LoaiSanPham>>(data);
                }
                return View(p);
            }
        }

        // GET: LoaiSanPhams/Details/5
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
                LoaiSanPham room = null;
                if (result.IsSuccessStatusCode)
                {
                    string data = result.Content.ReadAsStringAsync().Result;
                    room = JsonConvert.DeserializeObject<LoaiSanPham>(data);
                }
                return View(room);
            }
        }
        //timkiem
        public ActionResult Timkiem(string name, int? page)
        {

            IEnumerable<LoaiSanPham> obj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:50338/api/loaisanpham/api/LoaiSanPhamtname/");
            var data = hc.GetAsync("GetProductname?name=" + name);
            data.Wait();
            var readdata = data.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<IEnumerable<LoaiSanPham>>();
                displaydata.Wait();
                obj = displaydata.Result;
            }
            return View(obj);
        }
        // GET: LoaiSanPhams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoaiSanPhams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TENLOAI")] LoaiSanPham loaiSanPham)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BASE_URI);

                    string data = JsonConvert.SerializeObject(loaiSanPham);
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

            return View(loaiSanPham);
        }

        // GET: LoaiSanPhams/Edit/5
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
                LoaiSanPham room = null;
                if (result.IsSuccessStatusCode)
                {
                    string data = result.Content.ReadAsStringAsync().Result;
                    room = JsonConvert.DeserializeObject<LoaiSanPham>(data);
                }
                return View(room);
            }
        }

        // POST: LoaiSanPhams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TENLOAI")] LoaiSanPham loaiSanPham)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BASE_URI);

                    string data = JsonConvert.SerializeObject(loaiSanPham);
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
            return View(loaiSanPham);
        }

        // GET: LoaiSanPhams/Delete/5
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
                LoaiSanPham room = null;
                if (result.IsSuccessStatusCode)
                {
                    string data = result.Content.ReadAsStringAsync().Result;
                    room = JsonConvert.DeserializeObject<LoaiSanPham>(data);
                }
                return View(room);
            }
        }
        // POST: LoaiSanPhams/Delete/5
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
