using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BTL_MVC.Models;

namespace BTL_MVC.Controllers
{
    public class HoaDonXuatsController : Controller
    {
        private Model1 db = new Model1();

        // GET: HoaDonXuats
        public ActionResult Index()
        {
            var hoaDonXuat = db.HoaDonXuat.Include(h => h.ChiTietHDX).Include(h => h.KhachHang).Include(h => h.NhanVien);
            return View(hoaDonXuat.ToList());
        }

        // GET: HoaDonXuats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDonXuat hoaDonXuat = db.HoaDonXuat.Find(id);
            if (hoaDonXuat == null)
            {
                return HttpNotFound();
            }
            return View(hoaDonXuat);
        }

        // GET: HoaDonXuats/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.ChiTietHDX, "MAHDX", "MAHDX");
            ViewBag.MAKH = new SelectList(db.KhachHang, "ID", "TENKH");
            ViewBag.MANV = new SelectList(db.NhanVien, "ID", "TENNV");
            return View();
        }

        // POST: HoaDonXuats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MAKH,MANV,NGAYXUAT,THANHTIEN")] HoaDonXuat hoaDonXuat)
        {
            if (ModelState.IsValid)
            {
                db.HoaDonXuat.Add(hoaDonXuat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.ChiTietHDX, "MAHDX", "MAHDX", hoaDonXuat.ID);
            ViewBag.MAKH = new SelectList(db.KhachHang, "ID", "TENKH", hoaDonXuat.MAKH);
            ViewBag.MANV = new SelectList(db.NhanVien, "ID", "TENNV", hoaDonXuat.MANV);
            return View(hoaDonXuat);
        }

        // GET: HoaDonXuats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDonXuat hoaDonXuat = db.HoaDonXuat.Find(id);
            if (hoaDonXuat == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.ChiTietHDX, "MAHDX", "MAHDX", hoaDonXuat.ID);
            ViewBag.MAKH = new SelectList(db.KhachHang, "ID", "TENKH", hoaDonXuat.MAKH);
            ViewBag.MANV = new SelectList(db.NhanVien, "ID", "TENNV", hoaDonXuat.MANV);
            return View(hoaDonXuat);
        }

        // POST: HoaDonXuats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MAKH,MANV,NGAYXUAT,THANHTIEN")] HoaDonXuat hoaDonXuat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoaDonXuat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.ChiTietHDX, "MAHDX", "MAHDX", hoaDonXuat.ID);
            ViewBag.MAKH = new SelectList(db.KhachHang, "ID", "TENKH", hoaDonXuat.MAKH);
            ViewBag.MANV = new SelectList(db.NhanVien, "ID", "TENNV", hoaDonXuat.MANV);
            return View(hoaDonXuat);
        }

        // GET: HoaDonXuats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDonXuat hoaDonXuat = db.HoaDonXuat.Find(id);
            if (hoaDonXuat == null)
            {
                return HttpNotFound();
            }
            return View(hoaDonXuat);
        }

        // POST: HoaDonXuats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HoaDonXuat hoaDonXuat = db.HoaDonXuat.Find(id);
            db.HoaDonXuat.Remove(hoaDonXuat);
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
    }
}
