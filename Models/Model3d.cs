namespace ArBackend.Api.Models;

public class Model3d
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public byte[] Data { get; set; } = Array.Empty<byte>();
    public string? ContentType { get; set; }
    public string? Description { get; set; }
    //s
}
