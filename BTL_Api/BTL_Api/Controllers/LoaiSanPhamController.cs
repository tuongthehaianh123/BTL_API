using BTL_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BTL_Api.Controllers
{
    [RoutePrefix("api/loaisanpham")]
    public class LoaiSanPhamController : ApiController
    {
        // GET: api/LoaiSanPham
        List<LoaiSanPham> emps = new List<LoaiSanPham>();
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<LoaiSanPham> Get()
        {
            //viết code xử lý

            using (testEntities db = new testEntities())
            {
                //lấy về toàn bộ sản phẩm trong bảng product
                return db.LoaiSanPham.ToList();
            }
        }
        //timkiemtheo id
        // GET: api/LoaiSanPham/5
        [HttpGet]
        [Route("get-by-id/{id}")]
        public LoaiSanPham Get(int id)
        {
            using (testEntities db = new testEntities())
            {
                return db.LoaiSanPham.FirstOrDefault(x => x.ID == id);
            }
        }
        //tìm kiếm theo tên
        [HttpGet]
        [Route("api/LoaiSanPhamtname/{name}")]
        public IHttpActionResult GetProductname(string name)
        {
            testEntities db = new testEntities();
            var data = db.LoaiSanPham.Where(x => x.TENLOAI.Contains(name) || name == null).ToList();
            return Ok(data);
        }


        //them
        // POST: api/LoaiSanPham
        [Route("create")]
        [HttpPost]
        public IEnumerable<LoaiSanPham> Post([FromBody]LoaiSanPham h)
        {
            using (testEntities db = new testEntities())
            {
                db.LoaiSanPham.Add(h);
                db.SaveChanges();
                return db.LoaiSanPham.ToList();
            }
        }

        //sửa
        // PUT: api/loaisanpham/5
        [Route("update")]
        [HttpPut]
        public IEnumerable<LoaiSanPham> Put([FromBody] LoaiSanPham h)
        {
            using (testEntities db = new testEntities())
            {
                LoaiSanPham pr = db.LoaiSanPham.SingleOrDefault(x => x.ID == h.ID);

                pr.TENLOAI = h.TENLOAI;
                db.SaveChanges();
                return db.LoaiSanPham.ToList();

            }
        }


        // DELETE: api/LoaiSanPham/5
        [HttpDelete]
        [Route("delete/{id}")]
        public IEnumerable<LoaiSanPham> RemoveID(int id)
        {
            using (testEntities db = new testEntities())
            {
                LoaiSanPham h = db.LoaiSanPham.FirstOrDefault(x => x.ID == id);
                db.LoaiSanPham.Remove(h);
                db.SaveChanges();
                return db.LoaiSanPham.ToList();
            }
        }
    }
}
