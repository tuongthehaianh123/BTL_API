using BTL_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BTL_Api.Controllers
{
    [RoutePrefix("api/hoadoanxuat")]
    public class HoaDonXuatController : ApiController
    {
        // GET: 
        List<HoaDonXuat> emps = new List<HoaDonXuat>();

        [Route("get-all")]
        [HttpGet]
        public IEnumerable<HoaDonXuat> Get()
        {
            //viết code xử lý

            using (testEntities db = new testEntities())
            {
                //lấy về toàn bộ sản phẩm trong bảng product
                return db.HoaDonXuat.ToList();
            }
        }
     
   
   
        //timkiemtheo id
        [HttpGet]
        [Route("get-by-id/{id}")]//Đặt tên route
        public HoaDonXuat Get(int id)
        {
            using (testEntities db = new testEntities())
            {
                return db.HoaDonXuat.FirstOrDefault(x => x.ID == id);
            }
        }

   

        // POST: api/HoaDonXuat
        public IEnumerable<HoaDonXuat> Post([FromBody] HoaDonXuat p)
        {
            using (testEntities db = new testEntities())
            {

                db.HoaDonXuat.Add(p);
                db.SaveChanges();
                return db.HoaDonXuat.ToList();
            }
        }

        // PUT: api/HoaDonXuat/5
        [Route("update")]
        [HttpPut]
        public IEnumerable<HoaDonXuat> Put([FromBody] HoaDonXuat p)
        {
            using (testEntities db = new testEntities())
            {
                HoaDonXuat pr = db.HoaDonXuat.SingleOrDefault(x => x.ID == p.ID);

                pr.MAKH = p.MAKH;
                pr.MANV = p.MANV;
                pr.NGAYXUAT = p.NGAYXUAT;
                pr.THANHTIEN = p.THANHTIEN;
               
                db.SaveChanges();
                return db.HoaDonXuat.ToList();

            }
        }

        // DELETE: api/HoaDonXuat/5
        [HttpDelete]
        [Route("delete/{id}")]
        public IEnumerable<HoaDonXuat> RemoveID(int id)
        {
            using (testEntities db = new testEntities())
            {
                HoaDonXuat p = db.HoaDonXuat.FirstOrDefault(x => x.ID == id);
                db.HoaDonXuat.Remove(p);
                db.SaveChanges();
                return db.HoaDonXuat.ToList();
            }
        }
    }
}

