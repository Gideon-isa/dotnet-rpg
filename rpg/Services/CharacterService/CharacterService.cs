using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using rpg.Dtos.Character;
using rpg.Models;

namespace rpg.Services.CharacterService
{
	public class CharacterService : ICharacterService
	{
		
		
		private static List<Character>  characters = new List<Character>() 
		{
			new Character(),
			new Character 
			{
				Id = 1,
				Name = "Sam"		
			}
		};
		private readonly IMapper _mapper;
		
		public CharacterService(IMapper mapper)		
		{
			_mapper = mapper;
			
		}
		
		public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
		{
			var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
			
			var character = _mapper.Map<Character>(newCharacter);
			character.Id = characters.Max(c => c.Id) + 1;
			characters.Add(character);
			serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
			return serviceResponse;
		}

		public async Task <ServiceResponse <List<GetCharacterDto>>> DeleteCharacter(int id)
		{
			var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
			
			try
			{
				var character = characters.FirstOrDefault(c => c.Id == id);
			
				if (character is null) 
				{
					throw new Exception($"Character with id {id} not found");
				}
				characters.Remove(character);
				
				serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
			}
			catch (System.Exception e)
			{
				
				serviceResponse.Message = e.Message;
				serviceResponse.Success = false;
			}
			
			
			return serviceResponse;
		}

		public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
		{
			var serviceResponse = new ServiceResponse<List<GetCharacterDto>>()
			{
				Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList()
			};
			return serviceResponse;
		}

		public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
		{
			var character = characters.FirstOrDefault(s => s.Id == id);

			return new ServiceResponse<GetCharacterDto>() 
			{
				Data = _mapper.Map<GetCharacterDto>(character)
			};
			
			
					
		}

		public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacter)
		{
			var serviceResponse = new ServiceResponse<GetCharacterDto>();
			try
			{
				var character = characters.FirstOrDefault(c => c.Id == updateCharacter.Id);
			
				if (character is null) 
				{
					throw new Exception($"Character with id {updateCharacter.Id} not found");
				}
				character.Name = updateCharacter.Name;
				character.HitPoint = updateCharacter.HitPoint;
				character.Strength = updateCharacter.Strength;
				character.Defense = updateCharacter.Defense;
				character.Intelligence = updateCharacter.Intelligence;
				character.ClassLevel = updateCharacter.ClassLevel;
				
				serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
			}
			catch (System.Exception e)
			{
				
				serviceResponse.Message = e.Message;
				serviceResponse.Success = false;
			}
			
			
			return serviceResponse;
		}
	}
}