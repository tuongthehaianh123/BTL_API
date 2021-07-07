using BTL_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BTL_Api.Controllers
{
    [RoutePrefix("api/khachhang")]
    public class KhachHangController : ApiController
    {
        // GET: api/KhachHang

        List<KhachHang> emps = new List<KhachHang>();
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<KhachHang> Get()
        {
            //viết code xử lý

            using (testEntities db = new testEntities())
            {
                //lấy về toàn bộ 
                return db.KhachHang.ToList();
            }
        }
        //timkiemtheo id
        //tìm kiếm theo tên
        [HttpGet]
        [Route("api/GetKhachHangname/{name}")]
        public IHttpActionResult GetProductname(string name)
        {
            testEntities db = new testEntities();
            var data = db.KhachHang.Where(x => x.TENKH.Contains(name) || name == null).ToList();
            return Ok(data);
        }
        // GET: api/KhachHang/5
        [HttpGet]
        [Route("get-by-id/{id}")]//Đặt tên route
        public KhachHang Get(int id)
        {
            using (testEntities db = new testEntities())
            {
                return db.KhachHang.FirstOrDefault(x => x.ID == id);
            }
        }

        // POST: api/KhachHang
        [Route("create")]
        [HttpPost]
        public IEnumerable<KhachHang> Post([FromBody] KhachHang p)
        {
            using (testEntities db = new testEntities())
            {

                db.KhachHang.Add(p);
                db.SaveChanges();
                return db.KhachHang.ToList();
            }
        }
        // PUT: api/KhachHang/5
        [Route("update")]
        [HttpPut]
        public IEnumerable<KhachHang> Put([FromBody] KhachHang p)
        {
            using (testEntities db = new testEntities())
            {
                KhachHang pr = db.KhachHang.SingleOrDefault(x => x.ID == p.ID);

                pr.TENKH = p.TENKH;
                pr.SODIENTHOAI = p.SODIENTHOAI;
                pr.DIACHI = p.DIACHI;
                pr.TENTK = p.TENTK;
                pr.MK = p.MK;
                db.SaveChanges();
                return db.KhachHang.ToList();

            }
        }

        // DELETE: api/KhachHang/5
        [HttpDelete]
        [Route("delete/{id}")]
        public IEnumerable<KhachHang> RemoveID(int id)
        {
            using (testEntities db = new testEntities())
            {
                KhachHang p = db.KhachHang.FirstOrDefault(x => x.ID == id);
                db.KhachHang.Remove(p);
                db.SaveChanges();
                return db.KhachHang.ToList();
            }
        }
    }
}
