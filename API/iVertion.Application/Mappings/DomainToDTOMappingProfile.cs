using AutoMapper;
using iVertion.Application.DTOs;
using iVertion.Domain.Entities;

namespace iVertion.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            // User Profiles and Roles
            CreateMap<UserProfile, UserProfileDTO>().ReverseMap();
            CreateMap<RoleProfile, RoleProfileDTO>().ReverseMap();
            CreateMap<AdditionalUserRole, AdditionalUserRoleDTO>().ReverseMap();
            // Articles
            CreateMap<Article, ArticleDTO>().ReverseMap();
            CreateMap<ArticleHistory, ArticleHistoryDTO>().ReverseMap();
            
            // Tickets Panel
            CreateMap<ClientType, ClientTypeDTO>().ReverseMap();
            CreateMap<Counter, CounterDTO>().ReverseMap();
            CreateMap<Merchandising, MerchandisingDTO>().ReverseMap();
            CreateMap<PanelMerchandising, PanelMerchandisingDTO>().ReverseMap();
            CreateMap<Panel, PanelDTO>().ReverseMap();
            CreateMap<PreferenceType, PreferenceTypeDTO>().ReverseMap();
            CreateMap<ServiceType, ServiceTypeDTO>().ReverseMap();
            CreateMap<TicketFollowUp, TicketFollowUpDTO>().ReverseMap();
            CreateMap<Ticket, TicketDTO>().ReverseMap();
            CreateMap<TicketSubject, TicketSubjectDTO>().ReverseMap();
            CreateMap<TotemPanel, TotemPanelDTO>().ReverseMap();
            CreateMap<Totem, TotemDTO>().ReverseMap();
        }
    }
}