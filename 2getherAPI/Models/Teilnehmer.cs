using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2getherAPI.Models;


[Table("teilnehmer")]
public class Teilnehmer
{
    [Key]
    public string t_username { get; set; }
    
    
    public List<Reise> Reises { get; set; } = new List<Reise>();
}