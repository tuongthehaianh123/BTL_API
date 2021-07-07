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
using System.IO;
using System.Net.Http;
namespace BTL_MVC.Controllers
{
    public class Sanpham1Controller : Controller
    {
        private Model1 db = new Model1();

        // GET: api/SanPham
        string BASE_URI = "http://localhost:50338/api/sanpham1/";
        // GET: Sanpham1
        public ActionResult Index()//cái này ms gọi api
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BASE_URI);

                var getTask = client.GetAsync("get-all");
                getTask.Wait();

                var result = getTask.Result;
                List<Sanpham1> p = null;
                if (result.IsSuccessStatusCode)
                {
                    string data = result.Content.ReadAsStringAsync().Result;
                    p = JsonConvert.DeserializeObject<List<Sanpham1>>(data);
                }
                return View(p);
            }
        }

        // GET: Sanpham1/Details/5
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
                Sanpham1 room = null;
                if (result.IsSuccessStatusCode)
                {
                    string data = result.Content.ReadAsStringAsync().Result;
                    room = JsonConvert.DeserializeObject<Sanpham1>(data);
                }
                return View(room);
            }
        }

        // GET: Sanpham1/Create

        // GET: Project/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Project/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IMAGE,Description,TENSP,SOLUONG,MALOAI,XUATXU,GIABAN")] SanPhamViewModel sanpham1)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BASE_URI);

                    string data = JsonConvert.SerializeObject(sanpham1);
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

            return View(sanpham1);
        }
        public ActionResult Timkiem(string name, int? page)
        {

            IEnumerable<Sanpham1> obj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:50338/api/sanpham1/api/GetProductname/");
            var data = hc.GetAsync("GetProductname?name=" + name);
            data.Wait();
            var readdata = data.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<IEnumerable<Sanpham1>>();
                displaydata.Wait();
                obj = displaydata.Result;
            }
            return View(obj);
        }
        // GET: Sanpham1/Edit/5
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
                Sanpham1 room = null;
                if (result.IsSuccessStatusCode)
                {
                    string data = result.Content.ReadAsStringAsync().Result;
                    room = JsonConvert.DeserializeObject<Sanpham1>(data);
                }
                return View(room);
            }
        }

        // POST: Sanpham1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IMAGE,Description,TENSP,SOLUONG,MALOAI,XUATXU,GIABAN")] Sanpham1 sanpham1)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BASE_URI);

                    string data = JsonConvert.SerializeObject(sanpham1);
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
            return View(sanpham1);
        }

        // GET: Sanpham1/Delete/5
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
                Sanpham1 room = null;
                if (result.IsSuccessStatusCode)
                {
                    string data = result.Content.ReadAsStringAsync().Result;
                    room = JsonConvert.DeserializeObject<Sanpham1>(data);
                }
                return View(room);
            }
        }
        // POST: Sanpham1/Delete/5
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
