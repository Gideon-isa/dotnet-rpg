using System.Text.Json.Serialization;

namespace rpg.Models
{
	[JsonConverter(typeof(JsonStringEnumConverter<RpgClass>))]
	public enum RpgClass
	{
		Knight = 1,
		Mage = 2,
		Cleric = 3
	}
}