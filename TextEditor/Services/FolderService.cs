// Services/FolderService.cs
using TextEditor.Models;  // Add this line

namespace TextEditor.Services
{
    public interface IFolderService
    {
        Task<List<Folder>> GetAllFoldersAsync();
        Task<Folder?> GetFolderByIdAsync(int id);
        Task<Folder> CreateFolderAsync(Folder folder);
        Task<Folder?> UpdateFolderAsync(Folder folder);
        Task<bool> DeleteFolderAsync(int id);
    }

    public class FolderService : IFolderService
    {
        private List<Folder> _folders = new();
        private int _nextId = 1;

        public Task<List<Folder>> GetAllFoldersAsync()
        {
            return Task.FromResult(_folders.OrderBy(f => f.Name).ToList());
        }

        public Task<Folder?> GetFolderByIdAsync(int id)
        {
            var folder = _folders.FirstOrDefault(f => f.Id == id);
            return Task.FromResult(folder);
        }

        public Task<Folder> CreateFolderAsync(Folder folder)
        {
            folder.Id = _nextId++;
            folder.CreatedDate = DateTime.Now;
            _folders.Add(folder);
            return Task.FromResult(folder);
        }

        public Task<Folder?> UpdateFolderAsync(Folder folder)
        {
            var existing = _folders.FirstOrDefault(f => f.Id == folder.Id);
            if (existing != null)
            {
                existing.Name = folder.Name;
                existing.Description = folder.Description;
                return Task.FromResult<Folder?>(existing);
            }
            return Task.FromResult<Folder?>(null);
        }

        public Task<bool> DeleteFolderAsync(int id)
        {
            var folder = _folders.FirstOrDefault(f => f.Id == id);
            if (folder != null)
            {
                _folders.Remove(folder);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}