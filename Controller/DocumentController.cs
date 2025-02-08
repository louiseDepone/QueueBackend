using Backend.DTO;
using Backend.Models;
using Backend.Service.SDocument;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controller;

[Route("[controller]")]
[ApiController]
public class DocumentController(IDocumentService documentService): ControllerBase
{
    private readonly IDocumentService _documentService = documentService;

    // add a document
    [HttpPost("AddDocument")]
    public ActionResult<Document> AddDocument(CreateDocumentDTO documentDTO)
    {
        try
        {
            _documentService.AddDocument(documentDTO);
            return Ok("Document Successfully Added");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
            throw;
        }
    }

    // get a;; documents
    [HttpGet("GetAllDocuments")]
    public ActionResult<List<Document>> GetAllDocuments()
    {
        try
        {
            return Ok(_documentService.GetDocuments());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
            throw;
        }
    }

    // get a document by id
    [HttpGet("GetDocument/{id:int}")]
    public ActionResult<Document> GetDocumentById(int id)
    {
        try
        {
            return Ok(_documentService.GetDocumentById(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
            throw;
        }
    }

    // update a document
    [HttpPut("UpdateDocument/{id:int}")]
    public ActionResult UpdateDocument(CreateDocumentDTO documentDTO, int id)
    {
        try
        {
            _documentService.UpdateDocument(documentDTO, id);
            return Ok("Document Updated");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
            throw;
        }
    }

    // delete a document
    [HttpDelete("DeleteDocument/{id:int}")]
    public ActionResult DeleteDocument(int id)
    {
        try
        {
            _documentService.DeleteDocument(id);
            return Ok("Document Deleted");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
            throw;
        }
    }

    // get documents by department
    [HttpGet("GetDocumentsByDepartment/{departmentId:int}")]
    public ActionResult<List<Document>> GetDocumentsByDepartment(int departmentId)
    {
        try
        {
            return Ok(_documentService.GetDocumentsByDepartment(departmentId));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
            throw;
        }
    }

    // get documents by name
    [HttpGet("GetDocumentsByName/{name}/{departmentId:int}")]
    public ActionResult<List<Document>> GetDocumentsByName(string name, int departmentId)
    {
        try
        {
            return Ok(_documentService.GetDocumentsByName(name, departmentId));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
            throw;
        } 
    }

    
}