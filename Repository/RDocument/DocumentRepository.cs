using System;
using Backend.Models;

namespace Backend.Repository.RDocument;

public class DocumentRepository(QueueDbContext context): IDocumentRepository
{
    private readonly QueueDbContext _context = context;

    public void AddDocument(Document document)
    {
        _context.Document.Add(document);
    }

    public void DeleteDocument(Document document)
    {
        _context.Document.Remove(document);
    }

    public Document? GetDocumentById(int documentId)
    {
        return _context.Document.Find(documentId);
    }

    public List<Document> GetDocuments()
    {
        return _context.Document.ToList();
    }

    public List<Document> GetDocumentsByDepartment(int departmentId)
    {
        return _context.Document.Where(a => a.DepartmentId == departmentId).ToList();
    }

    public List<Document> GetDocumentsByName(string name, int departmentId)
    {
        return _context.Document.Where(a => a.Name.ToLower() == name.ToLower() && a.DepartmentId == departmentId).ToList();
    }

    public void UpdateDocument(Document document)
    {
        _context.Document.Update(document);
    }
}
