using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class SachController : ApiController
    {
        DBSachDataContext db = new DBSachDataContext();
        [HttpGet]
        public List<Sach> GetSachLists()
        {
            return db.Saches.ToList();
        }
        [HttpGet]
        public Sach GetFood(int id)
        {
            return db.Saches.FirstOrDefault(x => x.Id == id);
        }
        [HttpPost]
        public bool InsertNewSach(string title, string content, string authorname, float price)
        {
            try
            {
                Sach sach = new Sach();
                sach.Title = title;
                sach.Content = content;
                sach.AuthorName = authorname;
                sach.Price = price;
                db.Saches.InsertOnSubmit(sach);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        [HttpPut]
        public bool UpdateSach(int id, string title, string content, string authorname, float price)
        {
            try
            {

                Sach sach = db.Saches.FirstOrDefault(x => x.Id == id);
                if (sach == null) return false;//không tồn tại false
                sach.Title = title;
                sach.Content = content;
                sach.AuthorName = authorname;
                sach.Price = price;
                db.SubmitChanges();//xác nhận chỉnh sửa
                return true;
            }
            catch
            {
                return false;
            }
        }
        [HttpDelete]
        public bool DeleteSach(int id)
        {

            //lấy food tồn tại ra
            Sach sach = db.Saches.FirstOrDefault(x => x.Id == id);
            if (sach == null) return false;
            db.Saches.DeleteOnSubmit(sach);
            db.SubmitChanges();
            return true;
        }
    }
}
