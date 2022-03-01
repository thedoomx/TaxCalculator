using Application.Commands.CalculateTax;
using AutoMapper;
using Domain.Models;

namespace Application.Common
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<TaxData, CalculateTaxOutputModel>();
		}
	}
}
