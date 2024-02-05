

namespace ticketsservice.Dtos;

public class CreateTicketDto
{
    public long TicketNumber { get; set; }
    public Guid TicketID { get; set; }
    public Boolean? isDeleted { get; set; }
    public long CategoryID { get; set; }
    public DateTime? UpdatedDTM { get; set; }
    public DateTime? DatePurchased { get; set; }
    public DateTime? DeletedDTM { get; set; }
    public DateTime CreatedDTM { get; set; }
}