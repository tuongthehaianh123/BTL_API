using BTL_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BTL_Api.Controllers
{
    [RoutePrefix("api/nhanvien")]
    public class NhannVienController : ApiController
    {
        // GET: api/NhannVien
      
        List<NhanVien> emps = new List<NhanVien>();
       [Route("get-all")]
        [HttpGet]
        public IEnumerable<NhanVien> Get()
        {
            //viết code xử lý

            using (testEntities db = new testEntities())
            {
                //lấy về toàn bộ 
                return db.NhanVien.ToList();
            }
        }
        //timkiemtheo id
        //tìm kiếm theo tên
        [HttpGet]
        [Route("api/GetNhanVienname/{name}")]
        public IHttpActionResult GetProductname(string name)
        {
            testEntities db = new testEntities();
            var data = db.NhanVien.Where(x => x.TENNV.Contains(name) || name == null).ToList();
            return Ok(data);
        }
        // GET: api/NhannVien/5
        [HttpGet]
        [Route("get-by-id/{id}")]
        public NhanVien Get(int id)
        {
            using (testEntities db = new testEntities())
            {
                return db.NhanVien.FirstOrDefault(x => x.ID == id);
            }
        }

        // POST: api/NhannVien
        [Route("create")]
        [HttpPost]
        public IEnumerable<NhanVien> Post([FromBody] NhanVien p)
        {
            using (testEntities db = new testEntities())
            {

                db.NhanVien.Add(p);
                db.SaveChanges();
                return db.NhanVien.ToList();
            }
        }
    // PUT: api/NhannVien/5
    [Route("update")]
    [HttpPut]
    public IEnumerable<NhanVien> Put([FromBody] NhanVien p)
    {
        using (testEntities db = new testEntities())
        {
            NhanVien pr = db.NhanVien.SingleOrDefault(x => x.ID == p.ID);

            pr.TENNV = p.TENNV;
            pr.CHUCVU = p.CHUCVU;
            pr.DIACHI = p.DIACHI;
            pr.SODIENTHOAI = p.SODIENTHOAI;
            pr.EMAIL = p.EMAIL;
            pr.TENTK = p.TENTK;
            pr.MK = p.MK;
            db.SaveChanges();
            return db.NhanVien.ToList();    

        }
    }

    // DELETE: api/NhannVien/5
    [HttpDelete]
    [Route("delete/{id}")]
    public IEnumerable<NhanVien> RemoveID(int id)
    {
        using (testEntities db = new testEntities())
        {
            NhanVien p = db.NhanVien.FirstOrDefault(x => x.ID == id);
            db.NhanVien.Remove(p);
            db.SaveChanges();
            return db.NhanVien.ToList();
       
        }
    }
}
}


