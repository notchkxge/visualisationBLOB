using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ArBackend.Api.Models.DTOs;

public class Upload3dModelDto
{
    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string Description { get; set; } = null!;

    [Required]
    public IFormFile File { get; set; } = null!;
}
