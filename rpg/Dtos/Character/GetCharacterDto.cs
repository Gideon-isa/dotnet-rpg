using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rpg.Models;

namespace rpg.Dtos.Character
{
    public class GetCharacterDto
    {
        public int Id { get; set; }
		public string? Name { get; set; } = "Frodo";
		public int HitPoint { get; set; } = 100;
		public int Strength { get; set; } = 10;
		public int Defense { get; set; } = 10;
		public int Intelligence { get; set; } = 10;
		public RpgClass ClassLevel { get; set; } = RpgClass.Knight;
    }
}