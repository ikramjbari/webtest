namespace API.Models{
public class UpdateTicketDTO{
       public  int Id {get; set;}
        public required string Description {get; set;}
        public bool Status {get; set;}
        public DateTime Date { get; set; } = DateTime.Now;
}
}