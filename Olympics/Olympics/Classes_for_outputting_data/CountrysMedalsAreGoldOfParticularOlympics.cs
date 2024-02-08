using static Olympics.ParticipantsResult;

namespace Olympics.Classes_for_outputting_data
{
    public class CountrysMedalsAreGoldOfParticularOlympics
    {
        public int YearCarryingOut { get; set; }
        public string? TypeOlympicsSummerOrWinter { get; set; }
        public string? ParticipantsCountry { get; set; }
        public Medals Medal { get; set; }
    }
}
