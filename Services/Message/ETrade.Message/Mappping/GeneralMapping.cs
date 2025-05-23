﻿using AutoMapper;
using ETrade.Message.Dal.Entities;
using ETrade.Message.Dtos;

namespace ETrade.Message.Mappping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<UserMessage,ResultMessageDto>().ReverseMap();
            CreateMap<UserMessage,CreateMessageDto>().ReverseMap();
            CreateMap<UserMessage,ResultInboxMessageDto>().ReverseMap();
            CreateMap<UserMessage,ResultSendboxMessageDto>().ReverseMap();
            CreateMap<UserMessage,GetByIdMessageDto>().ReverseMap();
            CreateMap<UserMessage,UpdateMessageDto>().ReverseMap();
        }
    }
}
