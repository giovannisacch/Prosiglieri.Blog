using Prosiglieri.Blog.Infra;
using Microsoft.EntityFrameworkCore;

namespace Prosiglieri.Blog.API
{
    public static class ProgramExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using BlogDbContext dbContext =
                scope.ServiceProvider.GetRequiredService<BlogDbContext>();

            dbContext.Database.Migrate();
        }
    }
}
