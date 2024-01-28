
namespace Olympics
{
    public class Participant
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Сountry { get; set; }
        public string? KindOfSport { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhotoOfAthlete { get; set; }
        public ParticipantsResult Result { get; set; }
    }
}
