using Asp.NetCore5._0_MovieSiteProject.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore5._0_MovieSiteProject.Data
{
    public static class DataSeeding //veri tabanın silsekte data seeding sayesinde veriler çalışcak 
    {
        public static void Seed(IApplicationBuilder app) //uygulama veri eklerken otamatik olarak veri eklencekm 
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<Context>();

            context.Database.Migrate(); //oluşturulan vri tabanları otomatik kaydetme 

            //bilgileri ekleme veri tabanına 
            var genres = new List<Genre>()
                  {
                 new Genre{  Name="Dram" },
                 new Genre{Name="Gerilim"},
                 new Genre{Name="Bilim Kurgu"},
                 new Genre{Name="Gizem"},
                 new Genre{ Name="Komedi"},
                 new Genre{ Name="Fantastik"},
                  };


            var movies = new List<Movie>()
            {
                new Movie{ Genres=new List<Genre>{ genres[2],new Genre() { Name="Macera"} }, Title="11.22.63" , Description="11.22.63, Stephen King'in 22/11/63 kitabından esinlenmiş, sekiz bölümden oluşan Amerikalı bilimkurgu ve gerilim televizyon mini dizisidir. Dizi, J. J. Abrams, Bridget Carpenter ve Bryan Burk tarafından yönetici olarak üretilmiş ilk olarak 15 Şubat 2016'da Hulu üzerinden yayınlanmıştır." ,  ImageUrl="11.22.63.jpg" },
                new Movie{Genres=new List<Genre>{ genres[1],new Genre() { Name="Romantik"},genres[3]},Title="Behind Her Eyes" , Description="Behind Her Eyes, 17 Şubat 2021'de Netflix'te prömiyeri yapılan ve Sarah Pinborough tarafından aynı adlı 2017 romanından uyarlanan Steve Lightfoot tarafından yaratılan İngiliz kara kara doğaüstü psikolojik gerilim web dizisi. Hewson ve Robert Aramayo. " ,ImageUrl="behindhereyes.jpg" },
                new Movie{Genres=new List<Genre>{ genres[0],new Genre() { Name="Aksiyon"},genres[1]},Title="La Case De Papel" , Description="Álex Pina tarafından yaratılan İspanya yapımı bir soygun ve suç dizisi. Dizi, profosör liderliğindeki ekibin İspanya Kraliyet Darphanesi'ni ve İspanya Merkez Bankası'nı soymasını konu edinir." ,ImageUrl="indir.jfif" },
                new Movie{Genres=new List<Genre>{ genres[2],genres[5]},Title="Interstellar" , Description="Elif Türker" , ImageUrl="film4.jfif" },
                new Movie{Genres=new List<Genre>{ genres[4],genres[0]},Title="Esaretin Bedeli" , Description="Eray Türker" , ImageUrl="esaret.jfif" },
                new Movie{Genres=new List<Genre>{ genres[5],genres[0]}, Title="Yeşil Yol" , Description="Ali Osman Topcuoglu" ,  ImageUrl="yesilyol.jfif" }
            };


            var users = new List<User>()
            {
                new User(){ UserName = "Mine Topcuoglu", Mail = "MT@gmail.com", Password = "1", ImageUrl = "person1.jpg" },
                 new User(){ UserName = "Elif Topcuoglu", Mail = "ETT@gmail.com", Password = "1", ImageUrl = "person3.jpg" },
                new User(){ UserName = "Emre Topcuoglu",  Mail = "ET@gmail.com",Password = "1", ImageUrl = "person2.jpg",
                Person = new Person()
                {
                    Name="Person",
                    Biography="tanıtım1",

                },
                },
                 new User(){ UserName = "Gönül Topcuoglu",  Mail = "GT@gmail.com",Password = "1", ImageUrl = "person4.jpg",
                Person = new Person()
                {
                    Name="Person2",
                    Biography="tanıtım2",

                },
                 }
               
           


        
           
            };

            var person = new List<Person>()
            {
               new Person()
                {
                    Name = "Person",
                    Biography = "tanıtım1",
                    User=users[0]

                },
                new Person()
                {
                    Name = "Person2",
                    Biography = "tanıtım2",             
                    User=users[1]

                },
            };

            var crews = new List<Crew>() 
            {
              new Crew()
              {
               Movie=movies[0],Person=person[0],Job="yönetmen",
             
              },
               new Crew()
               {
                     Movie=movies[0],Person=person[1],Job="yönetmen yardımcısı",
               }
            };

            var cast = new List<Cast>()
            {
                new Cast()
               {
                     Movie=movies[0],Person=person[0],Name="Oyuncu Adı" , Character="Karakter 1 ",

               },
                  new Cast()
               {
                     Movie=movies[0],Person=person[1],Name="Oyuncu Adı 2" , Character="Karakter 2 ",

               }
            };

            if (context.Database.GetPendingMigrations().Count() == 0)   //oluşturulan tablonun veri  sayısı eklenmiş mi
            {

                if (context.Genres.Count() == 0) //kayıt versa tekrar eklemeye gerek yok
                {
                    context.Genres.AddRange(genres);  //addrange liste eklemeye yarayan 


                }


                if (context.Movies.Count() == 0) //kayıt versa tekrar eklemeye gerek yok
                {
                    context.Movies.AddRange(movies);

                }

                if (context.Users.Count() == 0) //kayıt versa tekrar eklemeye gerek yok
                {
                    context.Users.AddRange(users);

                }

                if (context.Persons.Count() == 0) //kayıt versa tekrar eklemeye gerek yok
                {
                    context.Persons.AddRange(person);

                }
                if (context.Crews.Count() == 0) //kayıt versa tekrar eklemeye gerek yok
                {
                    context.Crews.AddRange(crews);

                }
                if (context.Casts.Count() == 0) //kayıt versa tekrar eklemeye gerek yok
                {
                    context.Casts.AddRange(cast);

                }



                context.SaveChanges();
            }
        }

    }
}
