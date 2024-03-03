

namespace orderservice.Models;

public class Order
{
    public long ID { get; set; }
    public Guid OrderID { get; set; }
    public Boolean? isDeleted { get; set; } = false;
    public long TicketID { get; set; }
    public string Description {get; set;} = "";
    public long UserID { get; set; }
    public decimal Price {get; set;}
    public virtual byte[]? RowVersion { get; set; }
}