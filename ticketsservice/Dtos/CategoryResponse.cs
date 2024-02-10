using System.ComponentModel.DataAnnotations;
using ticketsservice.Models;

namespace ticketsservice.Dtos;


public class CategoryResponseDto
{
    public long ID { get; set; }
    public Guid CategoryID { get; set; }
    public required string Name { get; set; }
    public DateTime? CreatedDTM { get; set; }
    public DateTime? UpdatedDTM { get; set; }
    public bool IsDeleted { get; set; }
    public List<Ticket>? Tickets {get; set;}
}