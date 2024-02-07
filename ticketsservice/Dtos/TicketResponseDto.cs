

namespace ticketsservice.Dtos;

public class TicketResponseDto
{
    public long ID { get; set; }
    public long TicketNumber { get; set; }
    public Guid TicketID { get; set; }
    public Boolean? isDeleted { get; set; }
    public long CategoryID { get; set; }
    public DateTime? DatePurchased { get; set; }
}