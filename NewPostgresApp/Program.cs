using System;
using System.Collections.Generic;
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

                // ShowEverything(db);

                ShowTableWrToPost(db);


                //db.Database.EnsureDeleted();  // Удаляю базу после всех действий

                //ChangeName(db);
                //Delete2posts(db);
                //AddNewPost(db);
            }


            ReadLine();
        }

        private static void ShowTableWrToPost(ApplicationContext db)
        {
            var writers = db.Writers.ToList();
            var posts = db.Posts.ToList();

            var result = from ps in posts
                         join wr in writers on ps.WriterId equals wr.ID

                         group ps by wr.Name into g

                         select new { WrName = g.Key, PostNames = String.Join(", ", g.Select(x => x.Name).ToList()) };
                         

            foreach ( var item in result)
            {
                WriteLine($"{item.WrName} -- {item.PostNames}");
                
            }
            ReadLine();
        }

        private static void ShowEverything(ApplicationContext db)
        {
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
            WriteLine("Введите имя писателя, у которого нужно удалить посты");
            // Загрузить Writer с введенным именем
            var dbwriter = db.Writers
            .Where(c => c.Name == ReadLine())
            .FirstOrDefault();

            WriteLine($"Данные подопытного:  {dbwriter.Name} | { dbwriter.ID}");

            foreach(Posts el in dbwriter.Posted) { Write($" {el.Name} "); }
            
            // Внести изменения
            WriteLine();
            WriteLine("Удаляем у него два поста");
            db.Posts.Remove(dbwriter.Posted[0]);
            db.Posts.Remove(dbwriter.Posted[2]);
 
            // Сохранить изменения
            db.SaveChanges();
            WriteLine("Изменения сохранены");

            //проверка
            var dbwriter2 = db.Writers
            .Where(c => c.Name == dbwriter.Name)
            .FirstOrDefault();

            WriteLine($"Данные подопытного:  {dbwriter2.Name} | { dbwriter2.ID}");
            foreach (Posts el in dbwriter2.Posted)
            { Write($" {el.Name} "); }
            ReadLine();
        }
        private static void AddNewPost(ApplicationContext db)
        {
            WriteLine("Введите имя писателя, которому нужно добавить пост");
            // Загрузить Writer с введенным именем
            var dbwriter = db.Writers
            .Where(c => c.Name == ReadLine())
            .FirstOrDefault();

            WriteLine($"Данные подопытного:  {dbwriter.Name} | { dbwriter.ID}");
            foreach (Posts el in dbwriter.Posted)
            { Write($" {el.Name} "); }
            
            // Внести изменения
            WriteLine();
            WriteLine("Введите название поста");
            string pName = ReadLine();
            WriteLine("Введите содержание поста");
            string pContent = ReadLine();
            Guid pId = Guid.NewGuid();
            Guid writerGuid = dbwriter.ID;

            var newPost = new Posts() { ID = pId, Name = pName, Content = pContent, WriterId = dbwriter.ID };

            // Сохранить изменения
            db.Posts.Add(newPost);
            db.SaveChanges();

            //проверка
            var dbwriter2 = db.Writers
            .Where(c => c.Name == dbwriter.Name)
            .FirstOrDefault();

            WriteLine($"Данные подопытного:  {dbwriter2.Name} | { dbwriter2.ID}");
            foreach (Posts el in dbwriter2.Posted)
            { Write($" {el.Name} "); }
            WriteLine();
            WriteLine("Данные поста");
            WriteLine($"|{newPost.ID} | {newPost.Name} | {newPost.Content} | {newPost.WriterId}");
            ReadLine();
        }
    }
}
