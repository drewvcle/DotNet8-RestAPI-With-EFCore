using TaskApiEnterprise.Dtos;
using TaskApiEnterprise.Models;
using TaskApiEnterprise.Repositories;

namespace TaskApiEnterprise.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _repo;

    public TaskService(ITaskRepository repo) => _repo = repo;

    public Task<List<TaskItem>> GetAllAsync() => _repo.GetAllAsync();

    public Task<TaskItem?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);

    public async Task<TaskItem> CreateAsync(CreateTaskDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Title))
            throw new ArgumentException("Title is required.");

        var task = new TaskItem { Title = dto.Title.Trim() };
        return await _repo.AddAsync(task);
    }

    public async Task<bool> UpdateAsync(int id, UpdateTaskDto dto)
    {
        var task = await _repo.GetByIdAsync(id);
        if (task is null) return false;

        if (string.IsNullOrWhiteSpace(dto.Title))
            throw new ArgumentException("Title is required.");

        task.Title = dto.Title.Trim();
        task.IsDone = dto.IsDone;
        await _repo.UpdateAsync(task);
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var task = await _repo.GetByIdAsync(id);
        if (task is null) return false;

        await _repo.DeleteAsync(task);
        return true;
    }
}
