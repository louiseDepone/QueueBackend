using System;
using Backend.DTO;
using Backend.Models;
using Backend.Repository.RDocument;
using Backend.Service.SDerpartment;

namespace Backend.Service.SDocument;

public class DocumentService(IDocumentRepository documentRepository, IDepartmentService departmentService) : IDocumentService
{
  private readonly IDocumentRepository _documentRepository = documentRepository;
  private readonly IDepartmentService _departmentService = departmentService;

    public void AddDocument(CreateDocumentDTO document)
    {
        try
        {
            _departmentService.GetDepartmentById(document.DepartmentId);
            List<Document> docs = GetDocumentsByName(document.Name, document.DepartmentId);
            if (docs.Count > 0)
            {
                throw new Exception("Document already exists");
            }
            Document newDocument = new()
            {
                Name = document.Name,
                DepartmentId = document.DepartmentId
            };
            _documentRepository.AddDocument(newDocument);
            
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    public void DeleteDocument(int id)
    {
        try
        {
            var document = GetDocumentById(id);
            _documentRepository.DeleteDocument(document);
            
        }
        catch (System.Exception)
        {
            
            throw;
        }

    }

    public Document? GetDocumentById(int id)
    {
        try
        {
            var document = _documentRepository.GetDocumentById(id);

            if (document == null)
            {
                throw new Exception("Document not found");
            }
            return document;
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    public List<Document> GetDocuments()
    {
        try
        {
            return _documentRepository.GetDocuments();
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }

    public List<Document> GetDocumentsByDepartment(int departmentId)
    {
        try
        {
            _departmentService.GetDepartmentById(departmentId);
            return _documentRepository.GetDocumentsByDepartment(departmentId);
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    public List<Document> GetDocumentsByName(string name, int departmentId)
    {
        try
        {
            _departmentService.GetDepartmentById(departmentId);
            return _documentRepository.GetDocumentsByName(name, departmentId);
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    public void UpdateDocument(CreateDocumentDTO document, int id)
    {
        try
        {
            _departmentService.GetDepartmentById(document.DepartmentId);
            var documentToUpdate = GetDocumentById(id);
            documentToUpdate.Name = document.Name;
            documentToUpdate.DepartmentId = document.DepartmentId;
            _documentRepository.UpdateDocument(documentToUpdate);
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}
