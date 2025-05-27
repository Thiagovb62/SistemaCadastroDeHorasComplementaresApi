

using Microsoft.EntityFrameworkCore;
using SistemaCadastroDeHorasApi.Context;

namespace SistemaCadastroDeHorasApi.Migrations;

public static class MigrationExtension
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
        dbContext.Database.Migrate();
    }

}