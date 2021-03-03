using System;
using System.Linq;
using static System.Console;

namespace NewPostgresApp
{
    class Program
    {
       
        static void Main(string[] args)
        {
           
            
            
            // получение данных
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Database.EnsureCreated();



                // получаем объекты из бд и выводим на консоль

                var writers = db.Writers.ToList();
                var posts = db.Posts.ToList();
                WriteLine("Writers list:");
                foreach (Writers el in writers)
                {
                    WriteLine($" |Гуид: {el.ID}| Имя {el.Name}");
                }
                WriteLine("Posts list:");
                foreach (Posts el in posts)
                {
                    WriteLine($"|гуид:  { el.ID}| Название {el.Name} | Контент {el.Content} |гуид автора {el.WriterId}");
                }
                //db.Database.EnsureDeleted();  // Удаляю базу после всех действий

                //ChangeName(db);
                Delete2posts(db);
            }


            ReadLine();
        }

        private static void ChangeName(ApplicationContext db)
        {
            WriteLine("Введите имя писателя, которому собственное собираетесь его поменять");
            // Загрузить Writer с введенным именем
            var dbwriter = db.Writers
            .Where(c => c.Name == ReadLine())
            .FirstOrDefault();

            // Внести изменения
            WriteLine("На какое имя поменять?");
            dbwriter.Name = ReadLine();

            // Сохранить изменения
            db.SaveChanges();
            var writerss = db.Writers.ToList();
            foreach (Writers el in writerss)
            { WriteLine($"{el.Name} --- {el.ID}"); }
        }

        private static void Delete2posts(ApplicationContext db)
        {
            WriteLine("Введите имя писателя, у которого нужно поменять посты");
            // Загрузить Writer с введенным именем
            var dbwriter = db.Writers
            .Where(c => c.Name == ReadLine())
            .FirstOrDefault();

            WriteLine($"Данные подопытного:  {dbwriter.Name} | { dbwriter.ID}");
            foreach(Posts el in dbwriter.Posted)
            { Write($" {el.Name} "); }

            WriteLine("Удаляем у него два поста");
            db.Posts.Remove(dbwriter.Posted[0]);
            db.Posts.Remove(dbwriter.Posted[2]);

            WriteLine($"Данные подопытного:  {dbwriter.Name} | { dbwriter.ID}");
            foreach (Posts el in dbwriter.Posted)
            { Write($" {el.Name} "); }
            ReadLine();
        }
    }
}
