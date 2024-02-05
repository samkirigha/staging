
using System.ComponentModel.DataAnnotations;

namespace ticketsservice.Models;

public class Category
{
    public long ID { get; set; }
    public Guid CategoryID { get; set; }
    public string Name { get; set; }
    public DateTime? CreatedDTM { get; set; }
    public DateTime? UpdatedDTM { get; set; }
    public bool IsDeleted { get; set; }
    [Timestamp]
    public virtual byte[] RowVersion { get; set; }

    public List<Ticket> Tickets {get; set;}
}