using DemoClasswork1.DataAccess;
using DemoClasswork1.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace DemoClasswork1.Pages.Cart
{
    public class IndexModel : PageModel
    {
        private readonly DemoClasswork1.DataAccess.NorthwindContext _context;
        private readonly IConfiguration Configuration;

        public IndexModel(NorthwindContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }
        [BindProperty]
        public List<Item> cart { get; set; }
        public double Total { get; set; }
        [BindProperty]
        public List<int> CartItem { get; set; }
        public int TotalQuantity { get; set; }
        public void OnGet(List<int> CartItem, int TotalQuantity)
        {
            cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            Total = (double)cart.Sum(i => i.Product.UnitPrice * i.Quantity);
            TotalQuantity = TotalQuantity;
        }

        public IActionResult OnPost(List<int> CartItem)
        {
            var product = _context.Products.ToList();
            cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            foreach (var item in CartItem)
            {
                if (cart==null)
                {
                    cart = new List<Item>();
                    cart.Add(new Item
                    {
                        Product = product.First(i=> i.ProductId == item),
                        Quantity = 1
                    });
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                }
                else
                {
                    int index = Exists(cart, item);
                    if (index == -1)
                    {
                        cart.Add(new Item
                        {
                            Product = product.First(i => i.ProductId == item),
                            Quantity = 1
                        });
                    }
                    else
                    {
                        cart[index].Quantity++;
                    }
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                }
            }
           
            return RedirectToPage("Index", cart);
        }

        public IActionResult OnGetDelete(int id)
        {
            cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = Exists(cart, id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToPage("Index", cart);
        }


        public DataAccess.Product find(int id)
        {
            return _context.Products.Where(p => p.ProductId == id).FirstOrDefault();
        }


        private int Exists(List<Item> cart, int id)
        {
            for (var i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.ProductId == id)
                {
                    return i;
                }
            }
            return -1;
        }
    }

    public class Item
    {
        public DataAccess.Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
