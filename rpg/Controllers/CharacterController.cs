using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using rpg.Dtos.Character;
using rpg.Models;
using rpg.Services.CharacterService;

namespace rpg.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CharacterController : ControllerBase
	{
		private readonly ICharacterService _characterService;
		
		public CharacterController(ICharacterService characterService)
		{
			this._characterService = characterService;
			
		}
		
		[Route("GetAll")]
		[HttpGet]
		public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Get() 
		{
			return Ok(await _characterService.GetAllCharacters());
		}
		
		[Route("{id:int}")]
		[HttpGet]
		public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetSingle(int id) 
		{
			return Ok(await _characterService.GetCharacterById(id));
		}
		
		[HttpPost]
		public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter (AddCharacterDto newCharacter) 
		{
			return Ok(await _characterService.AddCharacter(newCharacter));
			
		}
		
		[HttpPut]
		public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> UpdateCharacter (UpdateCharacterDto newCharacter) 
		{
			var response = await _characterService.UpdateCharacter(newCharacter);
			if (response is null) 
			{
				return NotFound(response);
			}
			return Ok(response);
			
			
		}
		
		[HttpDelete]
		public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> DeleteCharacter (int id) 
		{
			var response = await _characterService.DeleteCharacter(id);
			if (response is null) 
			{
				return NotFound(response);
			}
			return Ok(response);
			
			
		}
	}
}