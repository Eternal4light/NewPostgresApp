using System;
using System.Linq;

namespace NewPostgresApp
{
    class Program
    {
       
        static void Main(string[] args)
        {
            // добавление данных
            var bi = new BlogInitializer();
            //bi.FillDB();
            
            
            // получение данных
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Database.EnsureCreated();
                 
                

                // получаем объекты из бд и выводим на консоль
                
                var writers = db.Writers.ToList();
                var posts = db.Posts.ToList();
                Console.WriteLine("Writers list:");
                foreach (Writers el in writers)
                {
                    Console.WriteLine($" |Гуид: {el.ID}| Имя {el.Name}");
                }
                Console.WriteLine("Posts list:");
                foreach (Posts el in posts)
                {
                    Console.WriteLine($"|гуид:  { el.ID}| Название {el.Name} | Контент {el.Content} |гуид автора {el.WriterId}");
                }
                db.Database.EnsureDeleted();  // Удаляю базу после всех действий
            }

            Console.ReadLine();
        }
    }
}
