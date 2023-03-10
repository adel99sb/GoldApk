using GoldServices.Data;
using GoldServices.Models;
using GoldServices.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;

namespace GoldServices.Services
{
    public class ClientService : IClientService
    { 
        private readonly GoldDBContext goldDB = new();

        public void AddCategory(string name, int Company_id)
        {
           
            goldDB.Categories.Add(new Category
            {
                Name = name,
                IdCom = Company_id
            });
            Complete();
        }

        public void AddCompany(string name, string image)
        {
            goldDB.Companies.Add(new Company
            {
                Name = name,
                Pic = image
            });
            Complete();
        }

        public void AddProduct(byte[] image, float wight, bool is_Gift, int catg_id, int Kart_id)
        {
            goldDB.Products.Add(new Product
            {
                Pic = image,
                Wight = wight,
                IsGift = is_Gift,
                IdCat = catg_id,
                IdKart = Kart_id
            });
            Complete();
        }

        public List<Category> GetCategories(int Company_id)
        {
            return goldDB.Categories.Where(x => x.IdCom == Company_id).ToList();
        }

        public List<Company> GetCompanies()
        {
           return goldDB.Companies.ToList();
        }

        public List<Product> GetGifts()
        {
            return goldDB.Products.Where(x => x.IsGift == true).ToList();
        }

        public List<Kart> GetKarts()
        {
            return goldDB.Karts.ToList();
        }

        public Product GetProductDetails(int Product_id)
        {
            return (Product)goldDB.Products.Where(x => x.Id == Product_id);
        }

        public List<Product> GetProducts(int cat_id)
        {
            return goldDB.Products.Where(x => x.IdCat == cat_id).ToList();
        }

        public Costumer Login(string phone, string password)
        {
            try
            {
                return goldDB.Costumers.Where
                    (x => x.Phone == phone && x.Password == password).Single();
            }
            catch
            {
                 throw new Exception("erorr");
            }

        }

        public void Order(int Costumer_id, int Product_id, float price)
        {
            goldDB.Orders.Add(new Order
            {
                IdCos = Costumer_id
            ,
                IdPro = Product_id
            ,
                Price = price
            }
            );
            Complete();
        }

        public void SendVerfecation(int Costumer_id,string VerfecationCode)
        {
            try
            {
                string fromMail = "adelalsbaey.999@gmail.com";
                string password = "fqfdmstdhckjezhl";
                string toMail;
                MailMessage message = new();
                message.From = new MailAddress(fromMail);
                message.Subject = "Aleppo jewellery";
                toMail = goldDB.Costumers.Where(x => x.Id == Costumer_id).Single().EMail;
                message.To.Add(new MailAddress(toMail));
                message.Body =
                "<html><body><p dir=\"ltr\"> Your  Verfecation Code is:<br>" 
                + VerfecationCode+ "</p></body></html>";
                message.IsBodyHtml = true;

                var smtpclient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(fromMail, password),
                    EnableSsl = true
                };
                smtpclient.Send(message);
                

            }

            catch (SmtpException ex)
            {
                throw new ApplicationException
                  ("SmtpException has occured: " + ex.Message);
            }         
        }

        public void SignUp(string name, string password, string phone, string e_mail)
        {
            Costumer costumer = new Costumer()
            {
                Name = name
            ,
                Password = password
            ,
                Phone = phone
            ,
                EMail = e_mail
            ,
                VerfacationCode = GenerateRandom().ToString()
            };
            goldDB.Costumers.Add(costumer);
            Complete();
            SendVerfecation(costumer.Id,costumer.VerfacationCode);
        }

        public Costumer Verfecation(string verfacation)
        {
            try
            {
              return  goldDB.Costumers.Where(x => x.VerfacationCode == verfacation).Single();
            }
            catch
            {
                throw new Exception("erorr");
            }
        }
        void Complete()
        {
            goldDB.SaveChanges();
        }

        public List<object> GetTopRated()
        {
            return goldDB.Products.Join(goldDB.CosPros,
                 p => p.Id,
                 cp => cp.IdPro,
                 (p, cp) =>
                 new { p.Id, p.Pic, cp.Like }).OrderByDescending(x => x.Like).ToList<object>();            
            

        }

        private int GenerateRandom()
        {
            Random numberGen = new Random();
            int randomNumber = numberGen.Next(11111, 99999);
            return randomNumber;
        }
    }
}
