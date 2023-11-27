using ShopCart_CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopCart_CodeFirst.Controllers
{
    public class BookController : Controller
    {
        // GET: Book

        private readonly BookContext db = new BookContext();
        public ActionResult GetListBooks()
        {
            var listbook = from b in db.Books select b;
            return View(listbook.ToList());
        }

        public ActionResult CreateBook()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateBook(Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Books.Add(book);
                    db.SaveChanges();
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Error Save Data");
            }

            //Trả về trang xem danh sách Book Mới
            var listBook = from s in db.Books select s;
            return View("GetListBooks", listBook);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var viewModel = db.Books.Include("Chapters").SingleOrDefault(s => s.BookId == id);
            if (viewModel == null)
            {
                return HttpNotFound();  
            }
            return View(viewModel);
        }

        [HttpPost]
        public JsonResult AddToCart(int id)
        {
            List<CartItem> listCartItem;
            //Process Add To Cart
            if (Session["ShoppingCart"] == null)
            {
                //Create New Shopping Cart Session
                listCartItem = new List<CartItem>();
                listCartItem.Add(new CartItem
                {
                    Quality = 1,
                    productOrder = db.Books.Find(id)
                });
                Session["ShoppingCart"] = listCartItem;
            }
            else
            {
                bool flag = false;
                listCartItem = (List<CartItem>)Session["ShoppingCart"];
                foreach (CartItem item in listCartItem)
                {
                    if (item.productOrder.BookId == id)
                    {
                        item.Quality++;
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                    listCartItem.Add(new CartItem
                    {
                        Quality = 1,

                        productOrder = db.Books.Find(id)

                    });
                Session["ShoppingCart"] = listCartItem;
            }
            //Count item in shopping cart
            int cartcount = 0;
            List<CartItem> ls = (List<CartItem>)Session["ShoppingCart"];
            foreach (CartItem item in ls)
            {
                cartcount += item.Quality;
            }
            return Json(new { ItemAmount = cartcount });
        }

        public ActionResult ShoppingCart()
        {
            return View();
        }
    }
}