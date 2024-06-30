namespace _2getherAPI.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("reise")]
public class Reise
{
    [Key]
    public int r_id { get; set; }

    public int z_id { get; set; }

    [Column("r_name",TypeName = "varchar(254)")]
    public string r_Name { get; set; }

    [Column("r_beschreibung",TypeName = "varchar(254)")]
    public string r_Beschreibung { get; set; }

    [Column("r_bild",TypeName = "varchar(254)")]
    public string r_Bild { get; set; }
}
