using System;
using Backend.Models;

namespace Backend.Repository.RDocument;

public interface IDocumentRepository
{
    void AddDocument(Document document);
    void UpdateDocument(Document document);
    void DeleteDocument(Document document);
    Document? GetDocumentById(int documentId);
    List<Document> GetDocuments();
    List<Document> GetDocumentsByDepartment(int departmentId);
    List<Document> GetDocumentsByName(string name, int departmentId);


}
