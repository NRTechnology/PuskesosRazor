using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PuskesosRazor.Models
{
  public class Desa
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    public string Nama { get; set; } = string.Empty;

    [Required]
    public string Kode { get; set; } = string.Empty;

    [Required]
    public Kecamatan? Kecamatan { get; set; }
  }
}
