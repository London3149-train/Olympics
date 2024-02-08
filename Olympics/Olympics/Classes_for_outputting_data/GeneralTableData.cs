using static Olympics.ParticipantsResult;

namespace Olympics.Classes_for_outputting_data
{
    public class GeneralTableData
    {
        public bool IsCheks {  get; set; }
        public int ID { get; set; }
        public int YearCarryingOut { get; set; }
        public string? TypeOlympicsSummerOrWinter { get; set; }
        public string? NameOfCountry { get; set; }
        public string? NameCity { get; set; }
        public int KindOfSportID { get; set; }
        public string? NameOfSport { get; set; }
        public int ParticipantId { get; set; }
        public string? FIO { get; set; }
        public string? ParticipantsCountry { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int ParticipantsResultID { get; set; }
        public int PlaceInStandings { get; set; }
        public Medals Medal { get; set; }
    }
}
