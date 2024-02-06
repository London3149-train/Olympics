using Microsoft.EntityFrameworkCore;
using Olympics.Classes_for_outputting_data;
using System.Windows;

namespace Olympics
{
    public partial class MainWindow : Window
    {
        ParticipantsResult participantsResult = new ParticipantsResult();
        GeneralTableData generalTableData = new GeneralTableData();
        DB_Info dB_Info = new DB_Info();
        List<InfoOlympiad> _olympias = new List<InfoOlympiad>();
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

        private void Search_Click ( object sender, RoutedEventArgs e )
        {
            var _olympias = dB_Info.InfoOlympiad.Include( c => c.KindOfSport.Participants.Result ).Where(c => EF.Functions.Like( c.KindOfSport.Participants.FIO, $"%{FIO.Text}%")).ToList();
            FieldDisplay.ItemsSource = GetGeneralTableData( _olympias );
            FIO.Text = string.Empty;
        }

        private void Delete_Click( object sender, RoutedEventArgs e )
        {

            foreach (var item in FieldDisplay.ItemsSource)
            {
                var s = item;
            }

        }

        private List<GeneralTableData> GetGeneralTableData( List<InfoOlympiad> _olympias)
        {
            List < GeneralTableData > generalTableData1 = new List < GeneralTableData >();

            foreach (var item in _olympias)
            {
                GeneralTableData generalTableData = new GeneralTableData();
                generalTableData.IsCheks = false;
                generalTableData.ID = item.ID;
                generalTableData.YearCarryingOut = item.YearCarryingOut;
                generalTableData.TypeOlympicsSummerOrWinter = item.TypeOlympicsSummerOrWinter;
                generalTableData.NameOfCountry = item.NameOfCountry;
                generalTableData.NameCity = item.NameCity;
                generalTableData.KindOfSportID = item.KindOfSport.ID;
                generalTableData.NameOfSport = item.KindOfSport.NameOfSport;
                generalTableData.ParticipantId = item.KindOfSport.Participants.Id;
                generalTableData.FIO = item.KindOfSport.Participants.FIO;
                generalTableData.ParticipantsCountry = item.KindOfSport.Participants.ParticipantsCountry;
                generalTableData.DateOfBirth = item.KindOfSport.Participants.DateOfBirth;
                generalTableData.ParticipantsResultID = item.KindOfSport.Participants.Result.ID;
                generalTableData.PlaceInStandings = item.KindOfSport.Participants.Result.PlaceInStandings;
                generalTableData.Medal = item.KindOfSport.Participants.Result.Medal;
                generalTableData1.Add(generalTableData);
            }

            return generalTableData1;
        }
        
    }
}