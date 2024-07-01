using System.Runtime.InteropServices.JavaScript;

namespace _2getherAPI.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("reise")]
public class Reise
{
    [Key]
    public int r_id { get; set; }
    
    [Column("r_name",TypeName = "varchar(254)")]
    public string r_Name { get; set; }

    [Column("r_beschreibung",TypeName = "varchar(254)")]
    public string r_Beschreibung { get; set; }

    [Column("r_bild",TypeName = "varchar(254)")]
    public string r_Bild { get; set; }
    
    [Column("r_startdate", TypeName = "timestamp")]
    public DateTime r_startDate { get; set; }

    [Column("r_enddate", TypeName = "timestamp")]
    public DateTime r_endDate { get; set; }
    
    
    public List<Reiseziel> Reiseziels { get; set; } = new List<Reiseziel>();

    public List<Teilnehmer> Teilnehmers { get; set; } = new List<Teilnehmer>();
    
}
