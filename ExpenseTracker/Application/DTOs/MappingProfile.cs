using System.Collections.Generic;
using AutoMapper;
using Domain;

namespace Application.DTOs
{
    public class MappingProfile : Profile 
    {
        public MappingProfile()
        {
            CreateMap<Expense,ExpenseDTO>();
            CreateMap<ExpenseDTO,Expense>();
        }
    }
}