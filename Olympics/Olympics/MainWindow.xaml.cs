using System.Windows;

namespace Olympics
{
    public partial class MainWindow : Window
    {
        InfoOlympiad infoOlympiad = new InfoOlympiad();
        KindOfSport kindOfSport = new KindOfSport();
        Participant participant = new Participant();
        ParticipantsResult participantsResult = new ParticipantsResult();
        public MainWindow ( )
        {
            InitializeComponent();
        }

        private void TextBox_MouseLeftButtonDown( object sender, System.Windows.Input.MouseButtonEventArgs e )
        {
            if ( YearCarryingOut.Text == "Год проведения" )
            {
                YearCarryingOut.Text = "";
            }
            else if( TypeOlympicsSummerOrWinter.Text == "Сезон олемпиады")
            {
                TypeOlympicsSummerOrWinter.Text = "";
            }
            else if ( NameOfCountry.Text == "Название строны" )
            {
                NameOfCountry.Text = "";
            }
            else if ( NameCity.Text == "Город" )
            {
                NameCity.Text = "";
            }
            else if ( NameOfSport.Text == "Название спорта" )
            {
                NameOfSport.Text = "";
            }
            else if ( FIO.Text == "ФИО Участника" )
            {
                FIO.Text = "";
            }
            else if ( ParticipantsCountry.Text == "Страна Участника" )
            {
                ParticipantsCountry.Text = "";
            }
            else if ( DateOfBirth.Text == "Дата рождения" )
            {
                DateOfBirth.Text = "";
            }
            else if ( PlaceInStandings.Text == "Занятое место" )
            {
                PlaceInStandings.Text = "";
            }
        }

        private void Add_Click( object sender, RoutedEventArgs e )
        {
            if( CheckFilling() )
            {
                infoOlympiad.YearCarryingOut = Convert.ToInt32(YearCarryingOut.Text);
                infoOlympiad.TypeOlympicsSummerOrWinter = TypeOlympicsSummerOrWinter.Text;
                infoOlympiad.NameOfCountry = NameOfCountry.Text;
                infoOlympiad.NameCity = NameCity.Text;
                kindOfSport.NameOfSport = NameOfSport.Text;
                participant.FIO = FIO.Text;
                participant.ParticipantsCountry = ParticipantsCountry.Text;
                participant.DateOfBirth = DateTime.Parse(DateOfBirth.Text);
                participantsResult.PlaceInStandings = Convert.ToInt32(PlaceInStandings.Text);
                participantsResult.Medal = participantsResult.GetMedals(Convert.ToInt32(PlaceInStandings.Text));
            }
            else
            {
                MessageBox.Show("Не все данные заполнены");
            }
        }

        // Доработать
        public bool CheckFilling()
        {
            if(YearCarryingOut.Text.Length > 0 || TypeOlympicsSummerOrWinter.Text.Length > 0 ||
               NameOfCountry.Text.Length > 0 || NameCity.Text.Length > 0 ||
               NameOfSport.Text.Length > 0 || FIO.Text.Length > 0 ||
               ParticipantsCountry.Text.Length > 0 || DateOfBirth.Text.Length > 0 ||
               PlaceInStandings.Text.Length > 0 )
            { 
                return true;
            }
            return false;
        }
    }
}