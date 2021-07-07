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
    public class KhachHangsController : Controller
    {
        private Model1 db = new Model1();
        // GET: api/KhachHangs
        string BASE_URI = "http://localhost:50338/api/khachhang/";

        // GET: KhachHangs
        public ActionResult Index()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BASE_URI);

                var getTask = client.GetAsync("get-all");
                getTask.Wait();

                var result = getTask.Result;
                List<KhachHang> p = null;
                if (result.IsSuccessStatusCode)
                {
                    string data = result.Content.ReadAsStringAsync().Result;
                    p = JsonConvert.DeserializeObject<List<KhachHang>>(data);
                }
                return View(p);
            }
        }
        //timkiem
        public ActionResult Timkiem(string name, int? page)
        {

            IEnumerable<KhachHang> obj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:50338/api/khachhang/api/GetKhachHangname/");
            var data = hc.GetAsync("GetProductname?name=" + name);
            data.Wait();
            var readdata = data.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<IEnumerable<KhachHang>>();
                displaydata.Wait();
                obj = displaydata.Result;
            }
            return View(obj);
        }
        // GET: KhachHangs/Details/5
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
                KhachHang room = null;
                if (result.IsSuccessStatusCode)
                {
                    string data = result.Content.ReadAsStringAsync().Result;
                    room = JsonConvert.DeserializeObject<KhachHang>(data);
                }
                return View(room);
            }
        }

        // GET: KhachHangs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KhachHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TENKH,SODIENTHOAI,DIACHI,TENTK,MK")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BASE_URI);

                    string data = JsonConvert.SerializeObject(khachHang);
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

            return View(khachHang);
        }

        // GET: KhachHangs/Edit/5
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
                KhachHang room = null;
                if (result.IsSuccessStatusCode)
                {
                    string data = result.Content.ReadAsStringAsync().Result;
                    room = JsonConvert.DeserializeObject<KhachHang>(data);
                }
                return View(room);
            }
        }

        // POST: KhachHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TENKH,SODIENTHOAI,DIACHI,TENTK,MK")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BASE_URI);

                    string data = JsonConvert.SerializeObject(khachHang);
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
            return View(khachHang);
        }

        // GET: KhachHangs/Delete/5
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
                KhachHang room = null;
                if (result.IsSuccessStatusCode)
                {
                    string data = result.Content.ReadAsStringAsync().Result;
                    room = JsonConvert.DeserializeObject<KhachHang>(data);
                }
                return View(room);
            }
        }

        // POST: KhachHangs/Delete/5
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
