using System;
using System.Collections.Generic;
using System.Text;


namespace NewPostgresApp
{
    class BlogInitializer 
    {

        public void Aas(ApplicationContext context)
        {
            using (ApplicationContext db = new ApplicationContext())
            {

                var writer01 = new Writers { Name = "Adam", ID = Guid.Parse("15a96f15-5ebb-4764-8213-11dce2002ef5") };
                var writer02 = new Writers { Name = "Bob", ID = Guid.Parse("630e64fc-2334-468b-af6d-d08d753af05e") };
                var writer03 = new Writers { Name = "Charlie", ID = Guid.Parse("25e5551c-529b-4d81-9ded-fbda38a1f039") };

                var article01 = new Posts { Name = "First post", Content = "111", WriterId = writer01.ID, ID = Guid.NewGuid() };
                var article02 = new Posts { Name = "Second post", Content = "222", WriterId = writer01.ID, ID = Guid.NewGuid() };
                var article03 = new Posts { Name = "Third post", Content = "333", WriterId = writer01.ID, ID = Guid.NewGuid() };
                var article04 = new Posts { Name = "Fourth post", Content = "444", WriterId = writer02.ID, ID = Guid.NewGuid() };
                var article05 = new Posts { Name = "Fifth post", Content = "555", WriterId = writer02.ID, ID = Guid.NewGuid() };
                var article06 = new Posts { Name = "Sixth post", Content = "6*6", WriterId = writer02.ID, ID = Guid.NewGuid() };
                var article07 = new Posts { Name = "Seventh post", Content = "777", WriterId = writer03.ID, ID = Guid.NewGuid() };
                var article08 = new Posts { Name = "Eighth post", Content = "888", WriterId = writer03.ID, ID = Guid.NewGuid() };
                var article09 = new Posts { Name = "Ninth post", Content = "999", WriterId = writer03.ID, ID = Guid.NewGuid() };

                // добавляем их в бд
                db.Writers.AddRange(writer01, writer02, writer03);
                db.Posts.AddRange(article01, article02, article03, article04, article05, article06, article07, article08, article09);


                db.SaveChanges();
            }
        }
    }
}
