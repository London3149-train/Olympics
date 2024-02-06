using static Olympics.ParticipantsResult;

namespace Olympics.Classes_for_outputting_data
{
    public class ReportOnMedalistsOfVariousSportsForEntireOlympics
    {
        public int YearCarryingOut { get; set; }
        public string? TypeOlympicsSummerOrWinter { get; set; }
        public string? NameOfSport { get; set; }
        public string? FIO { get; set; }
        public Medals Medal { get; set; }
    }
}
