using System.ComponentModel.DataAnnotations;

namespace API.Models.Domain
{
    public class Ticket{
       [Key]
        public int Id {get; set;}
        public required string Description {get; set;}
        public bool Status {get; set;}
        public DateTime Date { get; set; } = DateTime.Now;
        
    }
}