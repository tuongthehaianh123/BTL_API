using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BTL_Api.Models;

namespace BTL_Api.Controllers
{
    [RoutePrefix("api/NhaCungCap")]
   
    public class NhaCungCapsController : ApiController
    {
       // GET: api/NhaCungCaps
        List<NhaCungCap> emps = new List<NhaCungCap>();

        [Route("get-all")]
        [HttpGet]
        public IEnumerable<NhaCungCap> Get()
        {
            //viết code xử lý

            using (testEntities db = new testEntities())
            {
                //lấy về toàn bộ sản phẩm trong bảng product
                return db.NhaCungCap.ToList();
            }
        }
        //timkiemtheo id
        //tìm kiếm theo tên
        [HttpGet]
        [Route("api/GetProductname/{name}")]
        public IHttpActionResult GetProductname(string name)
        {
            testEntities db = new testEntities();
            var data = db.NhaCungCap.Where(x => x.TENNCC.Contains(name) || name == null).ToList();
            return Ok(data);
        }

        // GET: api/NhaCungCaps/5
        [HttpGet]
        [Route("get-by-id/{id}")]//Đặt tên route
        public NhaCungCap Get(int id)
        {
            using (testEntities db = new testEntities())
            {
                return db.NhaCungCap.FirstOrDefault(x => x.ID == id);
            }
        }

        // PUT: api/NhaCungCaps/5
        [Route("update")]
        [HttpPut]
        public IEnumerable<NhaCungCap> Put([FromBody] NhaCungCap p)
        {
            using (testEntities db = new testEntities())
            {
                NhaCungCap pr = db.NhaCungCap.SingleOrDefault(x => x.ID == p.ID);

                pr.TENNCC = p.TENNCC;
                pr.DIACHI = p.DIACHI;
                pr.SODIENTHOAI = p.SODIENTHOAI;
                db.SaveChanges();
                return db.NhaCungCap.ToList();

            }
        }
        // POST: api/NhaCungCaps
        [Route("create")]
        [HttpPost]
        public IEnumerable<NhaCungCap> Post([FromBody]NhaCungCap p)
        {
            using (testEntities db = new testEntities())
            {

                db.NhaCungCap.Add(p);
                db.SaveChanges();
                return db.NhaCungCap.ToList();
            }
        }

        // DELETE: api/NhaCungCaps/5
        [HttpDelete]
        [Route("delete/{id}")]
        public IEnumerable<NhaCungCap> RemoveID(int id)
        {
            using (testEntities db = new testEntities())
            {
                NhaCungCap p = db.NhaCungCap.FirstOrDefault(x => x.ID == id);
                db.NhaCungCap.Remove(p);
                db.SaveChanges();
                return db.NhaCungCap.ToList();
            }
        }
    }
}
