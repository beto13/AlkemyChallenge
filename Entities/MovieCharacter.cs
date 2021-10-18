
namespace Entities
{
    public class MovieCharacter
    {
        public int MovieId { get; set; }
        public int CharacterId { get; set; }

        public Movie Movie { get; set; }
        public Character Character { get; set; }
    }
}
