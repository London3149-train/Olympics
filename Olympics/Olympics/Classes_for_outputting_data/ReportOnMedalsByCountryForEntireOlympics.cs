using static Olympics.ParticipantsResult;

namespace Olympics.Classes_for_outputting_data
{
    public class ReportOnMedalsByCountryForEntireOlympics
    {
        public int YearCarryingOut { get; set; }
        public string? TypeOlympicsSummerOrWinter { get; set; }
        public string? FIO { get; set; }
        public string? ParticipantsCountry { get; set; }
        public int PlaceInStandings { get; set; }
        public Medals Medal { get; set; }
    }
}
