using GoldServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldServices.Services.Contracts
{
    public interface IClientService
    {
        void SignUp(string name, string password, string phone, string e_mail);
        Costumer Login(string phone, string password);
        Costumer Verfecation(string verfacation);
        List<Product> GetGifts();
        List<Company> GetCompanies();
        List<Category> GetCategories(int Company_id);
        List<Product> GetProducts(int cat_id);
        List<Kart> GetKarts();
        List<object> GetTopRated();
        void SendVerfecation(int Costumer_id,string VerfecationCode);
        void Order(int Costumer_id, int Product_id,float price);
        Product GetProductDetails(int Product_id);
        void AddCompany(string name, string image);
        void AddCategory(string name, int Company_id);
        void AddProduct(byte[] image, float wight, bool is_Gift, int catg_id, int Kart_id);

    }
}
