
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
        public string Name { get; set; }
        public Medals Medal { get; set; }


    }
}
