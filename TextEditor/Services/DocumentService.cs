// Services/DocumentService.cs
public interface IDocumentService
{
    Task<List<Document>> GetAllDocumentsAsync();
    Task<Document?> GetDocumentByIdAsync(int id);
    Task<Document> CreateDocumentAsync(Document document);
    Task<Document?> UpdateDocumentAsync(Document document);
    Task<bool> DeleteDocumentAsync(int id);
    Task<List<Document>> GetDocumentsByFolderIdAsync(int folderId);
    Task<List<Document>> GetDocumentsWithoutFolderAsync();
    Task<int> GetDocumentCountByFolderIdAsync(int folderId);
}

public class DocumentService : IDocumentService
{
    private List<Document> _documents = new();
    private int _nextId = 1;

    public Task<List<Document>> GetAllDocumentsAsync()
    {
        return Task.FromResult(_documents.OrderByDescending(d => d.LastModifiedDate).ToList());
    }

    public Task<Document?> GetDocumentByIdAsync(int id)
    {
        var doc = _documents.FirstOrDefault(d => d.Id == id);
        return Task.FromResult(doc);
    }

    public Task<Document> CreateDocumentAsync(Document document)
    {
        document.Id = _nextId++;
        document.CreatedDate = DateTime.Now;
        document.LastModifiedDate = DateTime.Now;
        _documents.Add(document);
        return Task.FromResult(document);
    }

    public Task<Document?> UpdateDocumentAsync(Document document)
    {
        var existing = _documents.FirstOrDefault(d => d.Id == document.Id);
        if (existing != null)
        {
            existing.Title = document.Title;
            existing.Content = document.Content;
            existing.LastModifiedDate = DateTime.Now;
            return Task.FromResult<Document?>(existing);
        }
        return Task.FromResult<Document?>(null);
    }

    public Task<bool> DeleteDocumentAsync(int id)
    {
        var doc = _documents.FirstOrDefault(d => d.Id == id);
        if (doc != null)
        {
            _documents.Remove(doc);
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }

    public Task<List<Document>> GetDocumentsByFolderIdAsync(int folderId)
    {
        var docs = _documents.Where(d => d.FolderId == folderId)
                            .OrderByDescending(d => d.LastModifiedDate)
                            .ToList();
        return Task.FromResult(docs);
    }

    public Task<List<Document>> GetDocumentsWithoutFolderAsync()
    {
        var docs = _documents.Where(d => d.FolderId == null)
                            .OrderByDescending(d => d.LastModifiedDate)
                            .ToList();
        return Task.FromResult(docs);
    }

    public Task<int> GetDocumentCountByFolderIdAsync(int folderId)
    {
        var count = _documents.Count(d => d.FolderId == folderId);
        return Task.FromResult(count);
    }
}