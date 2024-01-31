using System.Windows;

namespace Olympics
{
    public partial class MainWindow : Window
    {
        ParticipantsResult participantsResult = new ParticipantsResult();
        DB_Info dB_Info = new DB_Info();
        public MainWindow ( )
        {
            InitializeComponent();
        }

        private void Add_Click( object sender, RoutedEventArgs e )
        {
            if( CheckFilling() )
            {
                InfoOlympiad infoOlympiad = new InfoOlympiad
                {
                    YearCarryingOut = Convert.ToInt32(YearCarryingOut.Text),
                    TypeOlympicsSummerOrWinter = TypeOlympicsSummerOrWinter.Text,
                    NameOfCountry = NameOfCountry.Text,
                    NameCity = NameCity.Text,
                    KindOfSport = new KindOfSport
                    {
                        NameOfSport = NameOfSport.Text,
                        Participants = new Participant
                        {
                            FIO = FIO.Text,
                            ParticipantsCountry = ParticipantsCountry.Text,
                            DateOfBirth = DateTime.Parse(DateOfBirth.Text),
                            Result = new ParticipantsResult
                            {
                                Medal = participantsResult.GetMedals(Convert.ToInt32(PlaceInStandings.Text)),
                                PlaceInStandings = Convert.ToInt32(PlaceInStandings.Text)
                            }
                        }
                    }
                };
                dB_Info.InfoOlympiad.Add( infoOlympiad );
                dB_Info.SaveChanges();
                MessageBox.Show("Добавлен");
                Clear();
            }
            else
            {
                MessageBox.Show("Не все данные заполнены");
            }
        }

        public void Clear()
        {
            YearCarryingOut.Text = string.Empty;
            TypeOlympicsSummerOrWinter.Text = string.Empty;
            NameOfCountry.Text = string.Empty;
            NameCity.Text = string.Empty;
            NameOfSport.Text = string.Empty;
            FIO.Text = string.Empty;
            ParticipantsCountry.Text = string.Empty;
            DateOfBirth.Text = string.Empty;
            PlaceInStandings.Text = string.Empty;
        }
        public bool CheckFilling()
        {
            if(!String.IsNullOrEmpty(YearCarryingOut.Text) && !String.IsNullOrEmpty(TypeOlympicsSummerOrWinter.Text) &&
               !String.IsNullOrEmpty(NameOfCountry.Text) && !String.IsNullOrEmpty(NameCity.Text) &&
               !String.IsNullOrEmpty(NameOfSport.Text) && !String.IsNullOrEmpty(FIO.Text) &&
               !String.IsNullOrEmpty(ParticipantsCountry.Text) && !String.IsNullOrEmpty(DateOfBirth.Text) &&
               !String.IsNullOrEmpty(PlaceInStandings.Text) )
            { 
                return true;
            }
            return false;
        }

        private void Delete_Click( object sender, RoutedEventArgs e )
        {

        }
    }
}