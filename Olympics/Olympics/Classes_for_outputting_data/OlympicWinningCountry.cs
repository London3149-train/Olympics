using static Olympics.ParticipantsResult;

namespace Olympics.Classes_for_outputting_data
{
    public class OlympicWinningCountry
    {
        public string? TypeOlympicsSummerOrWinter { get; set; }
        public string? ParticipantsCountry { get; set; }
        public int PlaceInStandings { get; set; }
        public Medals Medal { get; set; }
    }
}
