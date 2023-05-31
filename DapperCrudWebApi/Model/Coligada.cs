using System.ComponentModel.DataAnnotations;

namespace DapperCrudWebApi.Model
{
  public class Coligada
  {
    [Required()]
    public int Id { get; set; }
    [Required()]
    [MaxLength(20)]
    public string? Code { get; set; }
    public string? Description { get; set; }
    [MaxLength(50)]
    public string? RecCreatedBy { get; set; }
    public DateTime RecCreatedOn { get; set; } = DateTime.Now;
  }

  public class ColigadaContainer
  {
    public int Count { get; set; }
    public List<Coligada>? Coligadas { get; set; }
  }
}
