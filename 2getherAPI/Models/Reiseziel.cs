using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2getherAPI.Models;


[Table("reiseziel")]
public class Reiseziel
{
    [Key]
    public int rz_id { get; set; }
    
    public int r_id { get; set; }
    
    [Column("rz_name", TypeName= "varchar(254)")]
    public string rz_Name { get; set; }
    
    [Column("rz_beschreibung", TypeName= "varchar(254)")]
    public string rz_Beschreibung { get; set; }
    
    [Column("rz_bild", TypeName= "varchar(254)")]
    public string rz_Bild { get; set; }
    
    
    
    [ForeignKey("r_id")]
    public Reise Reise { get; set; }
}