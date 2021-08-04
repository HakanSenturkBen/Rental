//using Business.Abstract;
//using Business.Concrete;
//using Core.Utilities.IoC;
//using Core.Utilities.Results;
//using Core.Utilities.Security.JWT;
//using DataAccess.Abstract;
//using DataAccess.Concrete.EntityFramework;
//using Entities.Concrete;
//using Entities.DTOs;
//using System;
//using System.Linq;


//namespace ConsoleUI
//{

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Car car = new Car();
//            Color color = new Color();
//            Brand brand = new Brand();
//            CarImage img = new CarImage();

//            CarImageManager image = new CarImageManager(new EfCarImageDal());
//            var liste = image.GetCarImageById(2);
//            foreach (CarImage item in liste.Data)
//            {
//                Console.WriteLine($"{item} ");
//            }
//            Console.ReadLine();
//            Console.WriteLine("araç id please"); img.CarId = int.Parse(Console.ReadLine());
//            img.ImagePath = "./assets";
//            Console.WriteLine("paht please"); img.ImagePath += Console.ReadLine();

//            img.Id = 0;
//            img.Date = DateTime.Now;
//            Console.WriteLine($"id:  { img.Id } , Araç id: { img.CarId} , path: {img.ImagePath} , date: {img.Date} {DateTime.Now}");
//            Console.WriteLine("image eklendi için enter --- çıkmak için ctrl+c");
//            Console.ReadLine();
//            var durum = image.Add(img);
//            if (durum.Success)
//            {
//                Console.WriteLine("image eklendi çıkmak için ctrl+c");
//            }
//            else
//            {
//                Console.WriteLine(durum.Message);
//            }
//            Console.ReadLine();

//            CustomerManager customer = new CustomerManager(new EfCustomerDal(), new EfAddressDal(), new EfCompanyDal(),
//                new AuthManager(new UserManager(new EfUserDal()), new JwtHelper()));


//            customer.Add(Musteri());

//            CarManager manager = new CarManager(new EfCarDal());
//            ColorManager cman = new ColorManager(new EfColorDal());
//            BrandManager bman = new BrandManager(new EfBrandDal());
//            var sonuc = manager.GetCarInfo(Business.Ordered.color);
//            foreach (var item in sonuc.Data)
//            {
//                Console.WriteLine(item);
//            }

//            Menu();
//            ConsoleKeyInfo choose;
//            do
//            {
//                choose = Console.ReadKey();
//                string secim = choose.Key.ToString();
//                switch (secim)
//                {
//                    case "D1":
//                        NesneAta(car);
//                        manager.Add(car);
//                        Console.WriteLine("nesne veri tabanına eklendi");
//                        Temizle();
//                        Menu();
//                        break;

//                    case "D2":
//                        Listele();
//                        Console.WriteLine("Güncellenecek oto için carId giriniz: ");
//                        int Id = int.Parse(Console.ReadLine());
//                        NesneAta(car);
//                        car.Id = Id;
//                        manager.Update(car);
//                        Console.WriteLine("nesne güncellendi");
//                        Temizle();
//                        Menu();
//                        break;

//                    case "D3":
//                        Listele();
//                        Console.WriteLine("Silinecek araç için carId giriniz: ");
//                        Id = int.Parse(Console.ReadLine());
//                        var data = manager.GetCarById(Id);
//                        car = data.Data;
//                        manager.Delete(car);
//                        Console.WriteLine("data silindi");
//                        Temizle();
//                        Menu();
//                        break;

//                    case "D4":
//                        Listele();
//                        break;

//                    case "D5":
//                        Console.WriteLine("Brand ismi giriniz");
//                        brand.BrandName = Console.ReadLine();
//                        brand.Id = 0;
//                        bman.Add(brand);
//                        Console.WriteLine("marka eklendi");
//                        Temizle();
//                        Menu();
//                        break;

//                    case "D6":
//                        Console.WriteLine("Color ismi giriniz");
//                        color.ColorName = Console.ReadLine();
//                        color.Id = 0;
//                        cman.Add(color);
//                        Console.WriteLine("renk eklendi");
//                        Temizle();
//                        Menu();
//                        break;

//                    default:
//                        Console.WriteLine("Lütfen menüden seçim yapınız / çıkmak için escape" + secim);
//                        Menu();
//                        break;
//                }

//            } while (choose.Key != ConsoleKey.Escape);





//            EfCarDal cardals = new EfCarDal();
//            var result = cardals.GetAll();
//            Console.WriteLine(result.ToList());
//            Console.Write(car);
//        }

//        private static void Listele()
//        {
//            CarManager manager = new CarManager(new EfCarDal());
//            var sonuc = manager.GetAll();
//            Console.WriteLine();
//            foreach (var item in sonuc.Data)
//            {
//                Console.WriteLine(item);
//            }
//            Console.WriteLine();
//        }

//        private static void Temizle()
//        {
//            Console.ReadLine();
//            Console.Clear();
//        }

//        private static void NesneAta(Car car)
//        {
//            Console.WriteLine("brandId giriniz: ");
//            car.BrandId = int.Parse(Console.ReadLine());
//            Console.WriteLine("colorId giriniz: ");
//            car.ColorId = int.Parse(Console.ReadLine());
//            car.Active = true;
//            car.CreateDate = DateTime.Now;
//            Console.WriteLine("Daily Price giriniz: ");
//            car.DailyPrice = int.Parse(Console.ReadLine());
//            Console.WriteLine("description giriniz: ");
//            car.Description = Console.ReadLine();
//            Console.WriteLine("ModelYear giriniz: ");
//            car.ModelYear = Console.ReadLine();
//            car.Id = 0;
//            Console.WriteLine("girilen bilgiler");
//            Console.Write(car);
//        }

//        private static void Menu()
//        {
//            Console.WriteLine("Seçiminiz :");
//            Console.WriteLine("1 - Yeni Kayıt :");
//            Console.WriteLine("2 - Kayıt Düzeltme :");
//            Console.WriteLine("3 - Kayıt Silme :");
//            Console.WriteLine("4 - Listele :");
//            Console.WriteLine("5 - Brand Ekle :");
//            Console.WriteLine("6 - Color ekle :");
//            Console.WriteLine();
//            Console.WriteLine("Çıkış için escape");
//            Console.WriteLine();
//            Console.Write("Seçiminiz : ");
//            Console.WriteLine();

//        }
//        private static CustomerDto Musteri()
//        {
//            CustomerDto custom = new CustomerDto();
//            Console.WriteLine("Ad Soyad giriniz: "); custom.Name = Console.ReadLine();
//            Console.WriteLine("Email adresi giriniz"); custom.Email = Console.ReadLine();
//            Console.WriteLine("telefon numarası giriniz"); custom.PhoneNumber = Console.ReadLine();
//            Console.WriteLine("parola giriniz"); custom.Password = Console.ReadLine();
//            Console.WriteLine("Vatandaşlık numarası giriniz"); custom.CitizenShipNumber = Console.ReadLine();
//            Console.WriteLine("Şirket adı giriniz"); custom.CompanyName = Console.ReadLine();
//            Console.WriteLine("Vergi dairesi adı"); custom.TaxOfficeName = Console.ReadLine();
//            Console.WriteLine("Vergi numarası"); custom.TaxNumber = Console.ReadLine();
//            Console.WriteLine("Şirket telefon numarası"); custom.CoPhoneNumber = Console.ReadLine();
//            Console.WriteLine("Adres"); custom.Address = Console.ReadLine();
//            Console.WriteLine("Şehir"); custom.City = Console.ReadLine();
//            Console.WriteLine("Ülke"); custom.State = Console.ReadLine();
//            return custom;
//        }

//    }

//}
