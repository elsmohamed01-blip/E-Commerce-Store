using AspSooQcom.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AspSooQcom.Controllers
{
    public class HomeController : Controller
    {
        MahrantkContext db = new MahrantkContext();

        public IActionResult Index()
        {

            IndexVM result = new IndexVM();

            result.Cateogries = db.Catogries.ToList();
            result.Products = db.Products.ToList();
            result.Reviews = db.Reviews.ToList();
            result.LatesProducts = db.Products.OrderByDescending(x => x.Price).Take(8).ToList();

            return View(result);
        }
        [HttpGet]
        public IActionResult ProductSearch(string xname)
        {
            var Products = new List<Product>();

            if (string.IsNullOrEmpty(xname))
            {
                Products = db.Products.ToList();
            }
            else
                Products = db.Products.Where(x => x.Name.Contains(xname)).ToList();

            return View(Products);
        }
        public IActionResult Cateogry()
        {
            var cato = db.Catogries.ToList();


            return View(cato);
        }
        public IActionResult Product(int id)
        {
            var cato = db.Products.Where(x => x.CatId == id).ToList();

            return View(cato);
        }
        [HttpGet]
        public IActionResult Sendreview(string Name,string email,string adress,string mobill,string description)
        {
            {
                db.Reviews.Add(new Review { Name = Name, Email = email, Adress = adress,Mobill = mobill, Description = description });
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }
        public IActionResult ProductShow(int id)
        {
            var cato = db.Products.Include(x => x.Cat).Include(x => x.ProductImages).FirstOrDefault(x => x.Id == id);

            return View(cato);
        }
        [Authorize]
        public IActionResult Cart()
        {
            var result = db.Carts.Include(x => x.Product).Where(x => x.UserId == User.Identity.Name).ToList();
            return View(result);
        }
        [Authorize]
        public IActionResult AddCart(int id)
        {
            var price = db.Products.Find(id).Price;


            var item = db.Carts.FirstOrDefault(x => x.ProductId == id && x.UserId == User.Identity.Name);
            if (item != null)

                item.Qty += 1;

            else
                db.Carts.Add(new Cart { ProductId = id, UserId = User.Identity.Name, Qty = 1, Price = price });
            db.SaveChanges();

            return RedirectToAction("Index");


        }
        [HttpPost]
        [Authorize]
        public IActionResult AddOrder(Order model)
        {

            var o = new Order
            {
                Name = model.Name,
                Aderss = model.Aderss,
                Email = model.Email,
                Mobile = model.Mobile,
                DataTime = model.DataTime,
                IsonlineParid = model.IsonlineParid,
                UserId = User.Identity.Name };

            var Cartitems = db.Carts.Where(x => x.UserId == User.Identity.Name).ToList();

            if(!Cartitems.Any())
                {
                return RedirectToAction("index", "Cart");
                }
            int total = 0;

            foreach (var item in Cartitems)
            {
                o.AddorderDeatils.Add(new AddorderDeatil { Qty = item.Qty, Price = item.Price, Productid = item.ProductId });
                total +=(int) (item.Qty * item.Price);
            }

            db.Orders.Add(o);

            db.Carts.RemoveRange(Cartitems);
            db.SaveChanges();

            var sb = new System.Text.StringBuilder();
            sb.AppendLine($"طلب جديد من عميل: {o.Name}");
            sb.AppendLine($"رقم الهاتف: {o.Mobile}");
            sb.AppendLine($"البريد الالكتروني: {o.Email}");
            sb.AppendLine($"العنوان: {o.Aderss}");
            sb.AppendLine($"تاريخ وصول الطلب: {o.DataTime}");
            sb.AppendLine();
            sb.AppendLine("*تفاصيل الطلب*");
            sb.AppendLine("--------------------");

            foreach (var item in Cartitems)
            {
              
                var product = db.Products.FirstOrDefault(p => p.Id == item.ProductId);
                string productName = product != null ? product.Name : "منتج";

                int subtotal = (int)(item.Qty * item.Price);

                sb.AppendLine($"-{productName} × {item.Qty} = {subtotal} جنية");

            }
            sb.AppendLine("-----------------");
            sb.AppendLine($"الاجمالي الكلي : {total}جنية");
            sb.AppendLine("تم تسجيل الطلب بنجاح");

            string encodedMessage = Uri.EscapeDataString(sb.ToString());
            string sellerPhone = "201029638961";

            string whatsappUrl = $"https://api.whatsapp.com/send?phone={sellerPhone}&text={encodedMessage}";


            return Redirect(whatsappUrl);
        }
        [HttpPost]
        public IActionResult RemoveFromCart(int id)
        {
            var item = db.Carts.FirstOrDefault(x => x.ProductId == id );

            if (item != null)
            {
                db.Carts.Remove(item);
                db.SaveChanges();
            }

            return RedirectToAction("Cart"); // إعادة توجيه إلى صفحة السلة بعد الحذف
        }
        [Authorize]
        public IActionResult Orders()
        {
            var order = db.Orders.Include(x => x.AddorderDeatils).ThenInclude(x => x.Product).Where(x => x.UserId == User.Identity.Name).ToList();

            return View(order);
        }
        public IActionResult EndOrsers()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public IActionResult AddToCart(int id, int quantity)
        {
            if (quantity <= 0)
            {
                return BadRequest("يجب أن تكون الكمية أكبر من صفر");
            }

            var product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound("المنتج غير موجود.");
            }

            var item = db.Carts.FirstOrDefault(x => x.ProductId == id && x.UserId == User.Identity.Name);
            if (item != null)
            {
                // تحديث الكمية إذا كان المنتج موجوداً في السلة
                item.Qty += quantity;
            }
            else
            {
                // إضافة المنتج الجديد إلى السلة
                db.Carts.Add(new Cart
                {
                    ProductId = id,
                    UserId = User.Identity.Name,
                    Qty = quantity,
                    Price = product.Price
                });
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    
       


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
