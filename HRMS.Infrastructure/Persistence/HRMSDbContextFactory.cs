using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace HRMS.Infrastructure.Persistence;

public class HRMSDbContextFactory : IDesignTimeDbContextFactory<HRMSDbContext>
{
    public HRMSDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<HRMSDbContext>();

        optionsBuilder.UseSqlServer(
            "Server=localhost\\SQLEXPRESS;Database=HRMSDb;Trusted_Connection=True;TrustServerCertificate=True");

        return new HRMSDbContext(optionsBuilder.Options);
    }
}