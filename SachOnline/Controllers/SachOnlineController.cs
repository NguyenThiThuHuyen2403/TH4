using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SachOnline.Models;

namespace SachOnline.Controllers
{
    public class SachOnlineController : Controller
    {
        // GET: SachOnline
        QLBanSachEntities data = new QLBanSachEntities();
        
        /// <summary> /// LaySachMoi /// </summary>
        // <param name="count">int</param>
        /// <returns>List</returns>
        private List<SACH> LaySachMoi(int count)
        {
            return data.SACHes.OrderByDescending(a => a.NgayCapNhat).Take(count).ToList();
        }
        // GET: SachOnline
        public ActionResult Index()
        {
            //Lay 6 quyen sach moi
            var listSachMoi = LaySachMoi(6); 
            return View(listSachMoi);
        }
        public ActionResult ChuDePartial()
        {
            var listChuDe = from cd in data.CHUDEs select cd; 
            return PartialView(listChuDe);
        }
        private List<SACH> LaySachBanNhieu(int count = 6)
        {
            return data.SACHes.OrderByDescending(item => item.SoLuongBan).Take(count).ToList();
        }
        public ActionResult SachBanNhieuPartial()
        {
            var ds = LaySachBanNhieu(6);
            return PartialView(ds);
        }
        public ActionResult NavPartial()
        {
            return PartialView();
        }
        public ActionResult SachTheoChuDe(int id)
        {
            var sach = from s in data.SACHes where s.MaCD==id select s;
            return View(sach);
        }
        public ActionResult SachTheoNhaXuatBan(int id)
        {
            var nhaxuatban = from s in data.SACHes where s.MaNXB == id select s;
            return View(nhaxuatban);
        }
        public ActionResult NhaXuatBanPartial()
        {
            var listNhaXuatBan = from cd in data.NHAXUATBANs select cd; 
            return PartialView(listNhaXuatBan);
        }
        public ActionResult ChiTietSach(int id)
        {
            var sach = from s in data.SACHes where s.MaSach == id select s;
            return View(sach.Single());
        }
       
    }


}

 
