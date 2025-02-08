using System;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository.RDocument;

public class DocumentRepository(QueueDbContext context): IDocumentRepository
{
    private readonly QueueDbContext _context = context;

    public void AddDocument(Document document)
    {
        _context.Document.Add(document);
        _context.SaveChanges();
    }

    public void DeleteDocument(Document document)
    {
        _context.Document.Remove(document);
        _context.SaveChanges();
    }

    public Document? GetDocumentById(int documentId)
    {
        return _context.Document.Include(
            a => a.Department
        ).FirstOrDefault(a => a.Id == documentId);
    }

    public List<Document> GetDocuments()
    {
        return _context.Document.Include(
            a => a.Department
        ).ToList();
    }

    public List<Document> GetDocumentsByDepartment(int departmentId)
    {
        return _context.Document.Where(a => a.DepartmentId == departmentId).ToList();
    }

    public List<Document> GetDocumentsByName(string name, int departmentId)
    {
        return _context.Document.Where(a => a.Name.ToLower() == name.ToLower() && a.DepartmentId == departmentId).Include(
            a => a.Department
        ).ToList();
    }

    public void UpdateDocument(Document document)
    {
        _context.Document.Update(document);
        _context.SaveChanges();
    }
}
