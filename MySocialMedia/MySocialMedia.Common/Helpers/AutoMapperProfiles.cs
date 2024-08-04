using AutoMapper;
using MySocialMedia.Common.DBTables;
using MySocialMedia.Common.DBTables.MessageDTOs;
using MySocialMedia.Common.DTOs.UserDTOs;

namespace MySocialMedia.Common.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserCreationDTO, User>()
            .ForMember(dest => dest.FIRST_NAME, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LAST_NAME, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.USER_NAME, opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.PASSWORD, opt => opt.MapFrom(src => src.Password))
            .ForMember(dest => dest.DATE_CREATE, opt => opt.MapFrom(src => src.DateCreate));

            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ID))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LAST_NAME))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.USER_NAME))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.PASSWORD))
                .ForMember(dest => dest.DateCreate, opt => opt.MapFrom(src => src.DATE_CREATE))
                .ForMember(dest => dest.SendUserMessages, opt => opt.MapFrom(src => src.send_user_messages))
                .ForMember(dest => dest.ReceiveUserMessages, opt => opt.MapFrom(src => src.receive_user_messages))
                .ReverseMap();

            CreateMap<UserMessageCreationDTO, UserMessage>()
                .ForMember(dest => dest.SENDER_USER_ID, opt => opt.MapFrom(src => src.SenderUserId))
                .ForMember(dest => dest.RECEIVER_USER_ID, opt => opt.MapFrom(src => src.ReceiverUserId))
                .ForMember(dest => dest.MESSAGE_DATA, opt => opt.MapFrom(src => src.MessageData))
                .ForMember(dest => dest.MESSAGE_DATE, opt => opt.MapFrom(src => src.MessageDate));


            CreateMap<UserMessageDTO, UserMessage>()
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.SENDER_USER_ID, opt => opt.MapFrom(src => src.SenderUserId))
                .ForMember(dest => dest.RECEIVER_USER_ID, opt => opt.MapFrom(src => src.ReceiverUserId))
                .ForMember(dest => dest.MESSAGE_DATA, opt => opt.MapFrom(src => src.MessageData))
                .ForMember(dest => dest.MESSAGE_DATE, opt => opt.MapFrom(src => src.MessageDate))
                .ForMember(dest => dest.send_user, opt => opt.MapFrom(src => src.SendUser))
                .ForMember(dest => dest.receive_user, opt => opt.MapFrom(src => src.ReceiveUser))
                .ReverseMap();
        }
    }
}
