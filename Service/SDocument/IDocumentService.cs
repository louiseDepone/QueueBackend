using System;
using Backend.DTO;
using Backend.Models;
using Backend.Repository.RDocument;

namespace Backend.Service.SDocument;

public interface IDocumentService
{
  void AddDocument(CreateDocumentDTO document);
    void UpdateDocument(CreateDocumentDTO document, int id);
    void DeleteDocument(int document);
    Document? GetDocumentById(int id);
    List<Document> GetDocuments();

    List<Document> GetDocumentsByDepartment(int departmentId);
    List<Document> GetDocumentsByName(string name, int departmentId);
}
