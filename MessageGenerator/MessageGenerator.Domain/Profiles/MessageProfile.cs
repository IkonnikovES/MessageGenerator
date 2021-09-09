using AutoMapper;
using MessageGenerator.Domain.Extensions;
using MessageGenerator.Domain.Models;
using MessageGenerator.Entities.Domains;

namespace MessageGenerator.Models.Profiles
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<MessageModel, Message>()
                .ForMemberFrom(x => x.Text, x => x.Text)
                .IgnoreOtherMembers();

            CreateMap<Message, MessageModel>()
                .ForMemberFrom(x => x.Id, x => x.Id)
                .IgnoreOtherMembers();

            CreateMap<Message, ChatMessageModel>()
                .ForMemberFrom(x => x.Text, x => x.Text)
                .ForMemberFrom(x => x.CreatedAt, x => x.CreatedAt)
                .IgnoreOtherMembers();
        }
    }
}
