using Microsoft.EntityFrameworkCore;
using Olympics.Classes_for_outputting_data;
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
            this.GetValeDB();
        }

        private void Add_Click ( object sender, RoutedEventArgs e )
        {
            if( CheckFilling() )
            {
                InfoOlympiad infoOlympiad = new InfoOlympiad
                {
                    YearCarryingOut = Convert.ToInt32( YearCarryingOut.Text ),
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
                            DateOfBirth = DateTime.Parse( DateOfBirth.Text ),
                            Result = new ParticipantsResult
                            {
                                Medal = participantsResult.GetMedals( Convert.ToInt32( PlaceInStandings.Text ) ),
                                PlaceInStandings = Convert.ToInt32( PlaceInStandings.Text )
                            }
                        }
                    }
                };
                dB_Info.InfoOlympiad.Add( infoOlympiad );
                dB_Info.SaveChanges();
                MessageBox.Show( "Добавлен" );
                this.GetValeDB();
                this.Clear();
            }
            else
            {
                MessageBox.Show( "Не все данные заполнены" );
            }
        }

        public void Clear ( )
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

        public bool CheckFilling ( )
        {
            if( !String.IsNullOrEmpty( YearCarryingOut.Text ) && !String.IsNullOrEmpty( TypeOlympicsSummerOrWinter.Text ) &&
               !String.IsNullOrEmpty( NameOfCountry.Text ) && !String.IsNullOrEmpty( NameCity.Text ) &&
               !String.IsNullOrEmpty( NameOfSport.Text ) && !String.IsNullOrEmpty( FIO.Text ) &&
               !String.IsNullOrEmpty( ParticipantsCountry.Text ) && !String.IsNullOrEmpty( DateOfBirth.Text ) &&
               !String.IsNullOrEmpty( PlaceInStandings.Text ) )
            {
                return true;
            }
            return false;
        }

        private void Search_Click ( object sender, RoutedEventArgs e )
        {
            this.GetValeDB();
            this.Clear();
        }

        private void GetValeDB ( )
        {
            var _olympics = dB_Info.InfoOlympiad.Include( c => c.KindOfSport.Participants.Result ).Where( c => c.KindOfSport.Participants.FIO.Contains(FIO.Text) ).ToList();
            FieldDisplay.ItemsSource = GetGeneralTableData( _olympics );
        }

        private void Delete_Click ( object sender, RoutedEventArgs e )
        {

            foreach( GeneralTableData item in FieldDisplay.ItemsSource )
            {
                if( item.IsCheks == true )
                {
                    InfoOlympiad infoOlympiad = dB_Info.InfoOlympiad.Where( c => c.ID == item.ID ).FirstOrDefault();
                    KindOfSport kindOfSport = dB_Info.KindOfSport.Where( c => c.ID == item.KindOfSportID ).FirstOrDefault();
                    Participant participant = dB_Info.Participant.Where( c => c.Id == item.ParticipantId ).FirstOrDefault();
                    ParticipantsResult participantsResult = dB_Info.ParticipantsResult.Where( c => c.ID == item.ParticipantsResultID ).FirstOrDefault();

                    dB_Info.ParticipantsResult.Remove( participantsResult );
                    dB_Info.Participant.Remove( participant );
                    dB_Info.KindOfSport.Remove( kindOfSport );
                    dB_Info.InfoOlympiad.Remove( infoOlympiad );

                    dB_Info.SaveChanges();
                }

            }
            MessageBox.Show( "Выбранные данные удалены" );
            this.GetValeDB();
        }

        private List<GeneralTableData> GetGeneralTableData ( List<InfoOlympiad> _olympics )
        {
            List<GeneralTableData> generalTableData1 = new List<GeneralTableData>();

            foreach( var item in _olympics )
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
                generalTableData1.Add( generalTableData );
            }

            return generalTableData1;
        }

        private void Edit_Click ( object sender, RoutedEventArgs e )
        {
            foreach( GeneralTableData item in FieldDisplay.ItemsSource )
            {
                if( item.IsCheks == true )
                {
                    this.SetEditDB( item );
                }
            }
            MessageBox.Show( "Выбранное данные Изменены" );
            this.GetValeDB();
            this.Clear();
        }

        private void SetEditDB( GeneralTableData item )
        {
            if ( item != null ) 
            {
                if (!String.IsNullOrEmpty( YearCarryingOut.Text ) )
                {
                    var g = dB_Info.InfoOlympiad.Where( c => c.ID == item.ID ).FirstOrDefault();
                    g.YearCarryingOut = Convert.ToInt32( YearCarryingOut.Text );
                    dB_Info.SaveChanges();
                }
                if( !String.IsNullOrEmpty( TypeOlympicsSummerOrWinter.Text) )
                {
                    var g = dB_Info.InfoOlympiad.Where( c => c.ID == item.ID ).FirstOrDefault();
                    g.TypeOlympicsSummerOrWinter = TypeOlympicsSummerOrWinter.Text ;
                    dB_Info.SaveChanges();
                }
                if( !String.IsNullOrEmpty( NameOfCountry.Text ) )
                {
                    var g = dB_Info.InfoOlympiad.Where( c => c.ID == item.ID ).FirstOrDefault();
                    g.NameOfCountry = NameOfCountry.Text;
                    dB_Info.SaveChanges();
                }
                if( !String.IsNullOrEmpty( NameCity.Text ) )
                {
                    var g = dB_Info.InfoOlympiad.Where( c => c.ID == item.ID ).FirstOrDefault();
                    g.NameCity = NameCity.Text;
                    dB_Info.SaveChanges();
                }
                if( !String.IsNullOrEmpty( NameOfSport.Text ) )
                {
                    var g = dB_Info.KindOfSport.Where( c => c.ID == item.KindOfSportID ).FirstOrDefault();
                    g.NameOfSport = NameOfSport.Text;
                    dB_Info.SaveChanges();
                }
                if( !String.IsNullOrEmpty( FIO.Text ) )
                {
                    var g = dB_Info.Participant.Where( c => c.Id == item.ParticipantId ).FirstOrDefault();
                    g.FIO = FIO.Text;
                    dB_Info.SaveChanges();
                }
                if( !String.IsNullOrEmpty( ParticipantsCountry.Text ) )
                {
                    var g = dB_Info.Participant.Where( c => c.Id == item.ParticipantId ).FirstOrDefault();
                    g.ParticipantsCountry = ParticipantsCountry.Text;
                    dB_Info.SaveChanges();
                }
                if( !String.IsNullOrEmpty( DateOfBirth.Text ) )
                {
                    var g = dB_Info.Participant.Where( c => c.Id == item.ParticipantId ).FirstOrDefault();
                    g.DateOfBirth = DateTime.Parse( DateOfBirth.Text );
                    dB_Info.SaveChanges();
                }
                if( !String.IsNullOrEmpty( PlaceInStandings.Text ) )
                {
                    var g = dB_Info.ParticipantsResult.Where( c => c.ID == item.ParticipantsResultID ).FirstOrDefault();
                    g.PlaceInStandings = Convert.ToInt32( PlaceInStandings.Text );
                    g.Medal = participantsResult.GetMedals( Convert.ToInt32( PlaceInStandings.Text ) );
                    dB_Info.SaveChanges();
                }
            }
        }

        private void AdditionalWindow_Click ( object sender, RoutedEventArgs e )
        {
            QueryWindow queryWindow = new QueryWindow(this);
            queryWindow.ShowDialog();
        }
    }
}