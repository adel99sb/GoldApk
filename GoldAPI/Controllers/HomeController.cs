using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GoldServices.Services.Contracts;
using GoldServices.Models;
using GoldServices.Services;

namespace GoldAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller,IClientService
	{
		private readonly ClientService service =new();

        [Route("/AddCategory")]
        public void AddCategory(string name, int Company_id)
		{
			service.AddCategory(name, Company_id);
		}

        [Route("/AddCompany")]
        public void AddCompany(string name, string image)
		{
			service.AddCompany(name, image);
		}

        [Route("/AddProduct")]
        public void AddProduct(byte[] image, float wight, bool is_Gift, int catg_id, int Kart_id)
		{
			service.AddProduct(image,wight,is_Gift,catg_id,Kart_id);
		}

        [Route("/GetCategories")]
        public List<Category> GetCategories(int Company_id)
		{
			return service.GetCategories(Company_id);
		}
		[Route("/GetCompanies")]
		public List<Company> GetCompanies()
		{
			return service.GetCompanies();
		}

        [Route("/GetGifts")]
        public List<Product> GetGifts()
		{
			return service.GetGifts();
		}

        [Route("/GetKarts")]
        public List<Kart> GetKarts()
		{
			return GetKarts();
		}

        [Route("/GetProductDetails")]
        public Product GetProductDetails(int Product_id)
		{
			return service.GetProductDetails(Product_id);
		}

        [Route("/GetProducts")]
        public List<Product> GetProducts(int cat_id)
		{
			return service.GetProducts(cat_id);
		}

        [Route("/GetTopRated")]
        public List<object> GetTopRated()
		{
			return service.GetTopRated();
		}

        [Route("/Login")]
        public Costumer Login(string phone, string password)
		{
			return service.Login(phone, password);	
		}

        [Route("/Order")]
        public void Order(int Costumer_id, int Product_id, float price)
		{
			service.Order(Costumer_id, Product_id, price);	
		}

        [Route("/SendVerfecation")]
        public void SendVerfecation(int Costumer_id,string VerfecationCode)
		{
			service.SendVerfecation(Costumer_id,VerfecationCode);
		}

        [Route("/SignUp")]
        public void SignUp(string name, string password, string phone, string e_mail)
		{
			service.SignUp(name,password,phone,e_mail);
		}

        [Route("/Verfecation")]
        public Costumer Verfecation(string verfacation)
		{
			return service.Verfecation(verfacation);
		}
	}
}
