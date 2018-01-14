using AutoMapper;
using ExampleWebApiCore.Models;
using ExampleWebApiCore.Views;
using ExampleWebApiCore.Views.Good;

namespace ExampleWebApiCore
{
    public class GoodProfile : Profile
    {
        public GoodProfile()
        {
            CreateMap<Good, GoodView>();
        }
    }
}