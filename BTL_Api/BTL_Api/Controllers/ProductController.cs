using BTL_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BTL_Api.Controllers
{
    [RoutePrefix("api/sanpham1")]
    public class ProductController : ApiController
    {
        // GET: san pham
        List<Sanpham1> emps = new List<Sanpham1>();

        [Route("get-all")]
        [HttpGet]
        public IEnumerable<Sanpham1> Get()
        {
            //viết code xử lý

            using (testEntities db = new testEntities())
            {
                //lấy về toàn bộ sản phẩm trong bảng product
                return db.Sanpham1.ToList();
            }
        }

        //timkiemtheo id
        //tìm kiếm theo tên
        [HttpGet]
        [Route("api/GetProductname/{name}")]
        public IHttpActionResult GetProductname(string name)
        {
            testEntities db = new testEntities();
            var data = db.Sanpham1.Where(x => x.TENSP.Contains(name) || name == null).ToList();
            return Ok(data);
        }

        //GET: api/Product/5
        [HttpGet]
        [Route("get-by-id/{id}")]//Đặt tên route
        public Sanpham1 Get(int id)
        {
            using (testEntities db = new testEntities())
            {
                return db.Sanpham1.FirstOrDefault(x => x.ID == id);
            }
        }
        //them
        // POST: api/Product
        [Route("create")]
        [HttpPost]
        public IEnumerable<Sanpham1> Post([FromBody]Sanpham1 p)
        {
            using (testEntities db = new testEntities())
            {
                    
                db.Sanpham1.Add(p);
                db.SaveChanges();
                return db.Sanpham1.ToList();
            }
        }

        //sửa
        // PUT: api/Projects/5
        [Route("update")]
        [HttpPut]
        public IEnumerable<Sanpham1> Put([FromBody] Sanpham1 p)
        {
            using (testEntities db = new testEntities())
            {
                Sanpham1 pr = db.Sanpham1.SingleOrDefault(x => x.ID == p.ID);

                pr.TENSP = p.TENSP;
                pr.IMAGE = p.IMAGE;
                pr.MALOAI = p.MALOAI;
                pr.XUATXU = p.XUATXU;
                pr.GIABAN = p.GIABAN;
                pr.SOLUONG = p.SOLUONG;
                pr.Description = p.Description;
                db.SaveChanges();
                return db.Sanpham1.ToList();

            }
        }
        // DELETE: api/Product/5
        [HttpDelete]
        [Route("delete/{id}")]
        public IEnumerable<Sanpham1> RemoveID(int id)
        {
            using (testEntities db = new testEntities())
            {
                Sanpham1 p = db.Sanpham1.FirstOrDefault(x => x.ID == id);
                db.Sanpham1.Remove(p);
                db.SaveChanges();
                return db.Sanpham1.ToList();
            }
        }
    }
}
