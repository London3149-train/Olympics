
namespace Olympics
{
    public class Participant
    {
        public int Id { get; set; }
        public string? FIO { get; set; }
        public string? ParticipantsCountry { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ParticipantsResult Result { get; set; }
    }
}
