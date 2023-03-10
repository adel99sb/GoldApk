using GoldAdmin.Models;
using Newtonsoft.Json;

namespace GoldAdmin.Data
{
    internal class Services
    {
        private readonly HttpClient client = new();
        public Services()
        {
            client.BaseAddress = new Uri("https://localhost:7281/");
        }
        public bool AddCategory(Category category)
        {
            HttpResponseMessage response;
            response = client.PostAsync("AddCategory?name=" + category.Name +
                                                    "&Company_id=" + category.IdCom
                                                    , null).Result;
            return response.IsSuccessStatusCode;
        }

        public bool AddCompany(Company company)
        {
            HttpResponseMessage response;
            response = client.PostAsync("AddCompany?name=" + company.Name +
                                                  "&image=" + company.Pic
                                                  , null).Result;
            return response.IsSuccessStatusCode;
            //response = cl.DeleteAsync(Uri).Result;
        }

        public bool AddProduct(Product product)
        {
            HttpResponseMessage response;
            response = client.PostAsync("AddProduct?image=" + product.Pic
                                                 + "&wight=" + product.Wight
                                                 + "&is_Gift=" + product.IsGift
                                                 + "&catg_id=" + product.IdCat
                                                 + "&Kart_id=" + product.IdKart
                                            , null).Result;
            return response.IsSuccessStatusCode;
        }

        public List<Category> GetCategories(int Company_id)
        {
            List<Category> model = null;
            HttpResponseMessage response;
            response = client.GetAsync("GetCategories?image=" + Company_id).Result;
            var jsonString = response.Content.ReadAsStringAsync();
            jsonString.Wait();
            model = JsonConvert.DeserializeObject<List<Category>>(jsonString.Result);
            return model;
        }
        public List<Company> GetCompanies()
        {
            List<Company> model = null;
            HttpResponseMessage response;
            response = client.GetAsync("GetCompanies").Result;
            var jsonString = response.Content.ReadAsStringAsync();
            jsonString.Wait();
            model = JsonConvert.DeserializeObject<List<Company>>(jsonString.Result);
            return model;
        }

        public List<Product> GetGifts()
        {
            List<Product> model = null;
            HttpResponseMessage response;
            response = client.GetAsync("GetGifts").Result;
            var jsonString = response.Content.ReadAsStringAsync();
            jsonString.Wait();
            model = JsonConvert.DeserializeObject<List<Product>>(jsonString.Result);
            return model;
        }

        public List<Kart> GetKarts()
        {
            List<Kart> model = null;
            HttpResponseMessage response;
            response = client.GetAsync("GetKarts").Result;
            var jsonString = response.Content.ReadAsStringAsync();
            jsonString.Wait();
            model = JsonConvert.DeserializeObject<List<Kart>>(jsonString.Result);
            return model;
        }

        public Product GetProductDetails(int Product_id)
        {
            Product model = null;
            HttpResponseMessage response;
            response = client.GetAsync("GetProductDetails?Product_id=" + Product_id).Result;
            var jsonString = response.Content.ReadAsStringAsync();
            jsonString.Wait();
            model = JsonConvert.DeserializeObject<Product>(jsonString.Result);
            return model;
        }

        public List<Product> GetProducts(int cat_id)
        {
            List<Product> model = null;
            HttpResponseMessage response;
            response = client.GetAsync("GetProducts?cat_id=" + cat_id).Result;
            var jsonString = response.Content.ReadAsStringAsync();
            jsonString.Wait();
            model = JsonConvert.DeserializeObject<List<Product>>(jsonString.Result);
            return model;
        }

        public List<object> GetTopRated()
        {
            List<object> model = null;
            HttpResponseMessage response;
            response = client.GetAsync("GetTopRated").Result;
            var jsonString = response.Content.ReadAsStringAsync();
            jsonString.Wait();
            model = JsonConvert.DeserializeObject<List<object>>(jsonString.Result);
            return model;
        }

        public Costumer Login(string phone, string password)
        {
            Costumer model = null;
            HttpResponseMessage response;
            response = client.GetAsync("Login?phone=" + phone + "&password=" + password).Result;
            var jsonString = response.Content.ReadAsStringAsync();
            jsonString.Wait();
            model = JsonConvert.DeserializeObject<Costumer>(jsonString.Result);
            return model;
        }

        public bool Order(int Costumer_id, int Product_id, float price)
        {
            HttpResponseMessage response;
            response = client.PostAsync("Order?Costumer_id=" + Costumer_id +
                                             "&Product_id=" + Product_id +
                                             "&price=" + price
                                             , null).Result;
            return response.IsSuccessStatusCode;
        }

        public bool SendVerfecation(int Costumer_id, string VerfecationCode)
        {
            HttpResponseMessage response;
            response = client.PostAsync("SendVerfecation?Costumer_id=" + Costumer_id +
                                                        "&VerfecationCode=" + VerfecationCode
                                                        , null).Result;
            return response.IsSuccessStatusCode;
        }

        public bool SignUp(Costumer costumer)
        {
            HttpResponseMessage response;
            response = client.PostAsync("SignUp?name=" + costumer.Name +
                                                  "&password=" + costumer.Password +
                                                  "&phone=" + costumer.Phone +
                                                  "&e_mail=" + costumer.EMail
                                                  , null).Result;
            return response.IsSuccessStatusCode;
        }

        public Costumer Verfecation(string verfacation)
        {
            Costumer model = null;
            HttpResponseMessage response;
            response = client.GetAsync("Verfecation?verfacation=" + verfacation).Result;
            var jsonString = response.Content.ReadAsStringAsync();
            jsonString.Wait();
            model = JsonConvert.DeserializeObject<Costumer>(jsonString.Result);
            return model;
        }

    }
}
