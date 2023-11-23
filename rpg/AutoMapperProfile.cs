using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using rpg.Dtos.Character;
using rpg.Models;

namespace rpg
{
	public class AutoMapperProfile : Profile
	{
		
		public AutoMapperProfile()
		{
			//GetAll method
			// Mapping from character to GetCharacterDto
			CreateMap<Character, GetCharacterDto>(); // GetA
			
			// Add Method
			// Mapping from AddCharacterDto to Character
			CreateMap<AddCharacterDto, Character>();
		}
		
	}
}