
using System.ComponentModel.DataAnnotations;

namespace ticketsservice.Models;

public class Ticket
{
    public long ID { get; set; }
    public long TicketNumber { get; set; }
    public Guid TicketID { get; set; }
    public Boolean? isDeleted { get; set; }
    public long CategoryID { get; set; }
    public DateTime? UpdatedDTM { get; set; }
    public DateTime? DatePurchased { get; set; }
    public DateTime CreatedDTM { get; set; }
    [Timestamp]
    public virtual byte[] RowVersion { get; set; }
    public Category Category {get; set;}
}