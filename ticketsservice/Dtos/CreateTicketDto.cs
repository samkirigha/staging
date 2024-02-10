

namespace ticketsservice.Dtos;

public class CreateTicketDto
{
    public long TicketNumber { get; set; }
    public long CategoryID { get; set; }
    public DateTime? DatePurchased { get; set; }
    public decimal Price { get; set; }
}