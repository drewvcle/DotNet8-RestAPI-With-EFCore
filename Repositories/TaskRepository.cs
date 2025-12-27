using Microsoft.EntityFrameworkCore;
using TaskApiEnterprise.Data;
using TaskApiEnterprise.Models;

namespace TaskApiEnterprise.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly AppDbContext _db;

    public TaskRepository(AppDbContext db) => _db = db;

    public Task<List<TaskItem>> GetAllAsync() =>
        _db.Tasks.OrderByDescending(t => t.CreatedUtc).ToListAsync();

    public Task<TaskItem?> GetByIdAsync(int id) =>
        _db.Tasks.FirstOrDefaultAsync(t => t.Id == id);

    public async Task<TaskItem> AddAsync(TaskItem task)
    {
        _db.Tasks.Add(task);
        await _db.SaveChangesAsync();
        return task;
    }

    public async Task<bool> UpdateAsync(TaskItem task)
    {
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(TaskItem task)
    {
        _db.Tasks.Remove(task);
        await _db.SaveChangesAsync();
        return true;
    }
}
