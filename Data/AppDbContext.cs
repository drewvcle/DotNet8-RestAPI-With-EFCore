using Microsoft.EntityFrameworkCore;
using TaskApiEnterprise.Models;

namespace TaskApiEnterprise.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<TaskItem> Tasks => Set<TaskItem>();
}
