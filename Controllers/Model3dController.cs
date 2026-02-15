using ArBackend.Api.Data;
using ArBackend.Api.Models;
using ArBackend.Api.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

//using Microsoft.EntityFrameworkCore;

namespace ArBackend.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Model3DController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Model3DController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> UploadModelDto([FromForm] Upload3dModelDto dto)
        {
            if (dto.File == null || dto.File.Length == 0)
            {
                return BadRequest("The file is missing or empty !");
            }

            var extension = Path.GetExtension(dto.File.FileName).ToLowerInvariant();
            if (string.IsNullOrEmpty(extension) || (extension != "obj"))
                return BadRequest("Invalid file type. Only file .obj");

            //stroring the file a a new MemoryStream
            using var MemoryStream = new MemoryStream();
            await dto.File.CopyToAsync(MemoryStream);

            //MemoryStream.Position = 0;
            //create a new isntance of the class Model3d
            var model3d = new Model3d
            {
                Name = dto.Name,
                Data = MemoryStream.ToArray(), //convert the file into bytes with ToArray
                Description = dto.Description,
            };
            //apply the changes into the db
            _context.Model3Ds.Add(model3d);
            await _context.SaveChangesAsync();

            return Ok(new { id = model3d.Id, Name = model3d.Name });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Model3d>> GetModel3d(int id)
        {
            var model = await _context.Model3Ds.FindAsync(id);
            if (model == null)
                return NotFound();
            return model;
        }
    }
}
