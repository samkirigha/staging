

using AutoMapper;
using ticketsservice.Dtos;

namespace ticketsservice.Profiles;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateTicketDto, Models.Ticket>();
        CreateMap<TicketResponseDto, Models.Ticket>().ReverseMap();
    }
}