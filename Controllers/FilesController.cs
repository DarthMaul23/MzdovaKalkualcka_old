using System;
using Microsoft.AspNetCore.Mvc;
using TestAPI.Services;
using TestAPI.Controllers;
using TestAPI.Models;
using static System.Guid;

namespace TestAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FilesController : Controller
{

    FilesService _FilesService;

    public FilesController(FilesService filesService){
        _FilesService = filesService;
    }

    [HttpPost]
    [Route("/Files/UploadFile")]
    public IActionResult UploadFile(Guid fileName, IFormFile file)
    {

        _FilesService.uploadNewFile(fileName, file);

        return Ok();
    }

    [HttpPost]
    [Route("/Files/UploadFiles")]
    public IActionResult UploadFiles(Guid fileName, List<IFormFile> file)
    {

        _FilesService.uploadNewFilesList(fileName, file);

        return Ok();
    }

}