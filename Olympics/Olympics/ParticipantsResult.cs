
namespace Olympics
{
    public class ParticipantsResult
    {
        public enum Medals : int
        {
            Emty = 0,
            Gold = 1,
            Silver = 2,
            Bronze = 3
        }

        public int ID { get; set; }
        public int PlaceInStandings { get; set; }
        public Medals Medal { get; set; }


        public Medals GetMedals(int medal)
        {
            if( medal == 1)
            {
                return Medals.Gold;
            }
            else if( medal == 2 )
            {
                return Medals.Silver;
            }
            else if( medal == 3 )
            {
                return Medals.Bronze;
            }
            return Medals.Emty;
        }
    }
}
