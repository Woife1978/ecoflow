using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("ecoflowdevice")]
public class EcoflowDevice
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }

    [Required]
    [Column("sn")]
    public string Sn { get; set; } = string.Empty;

    [Required]
    [Column("online")]
    public int Online { get; set; }

    [Column("productname")]
    public string? ProductName { get; set; }
}