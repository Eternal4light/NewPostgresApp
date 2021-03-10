using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewPostgresApp
{
    public interface IContextFactory
    {
        ApplicationContext GetContext();
    }


    public class ContextFactory : IContextFactory
    {
        public ApplicationContext GetContext()
        {
            var builder = new DbContextOptionsBuilder();

            builder.UseNpgsql("Host=localhost;Port=5432;Database=usersdb5;Username=postgres;Password=postgres");

            return new ApplicationContext();
        }
    }
}
