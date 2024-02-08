using Microsoft.EntityFrameworkCore;
using Olympics.Classes_for_outputting_data;
using System.Windows;

namespace Olympics
{
    /// <summary>
    /// Логика взаимодействия для QueryWindow.xaml
    /// </summary>
    public partial class QueryWindow : Window
    {
        MainWindow _mainWindow;
        DB_Info dB_Info = new DB_Info();
        public QueryWindow ( MainWindow mainWindow )
        {
            _mainWindow = mainWindow;
            InitializeComponent();
        }

        private void Request1_Checked ( object sender, RoutedEventArgs e )
        {

            Request2.IsChecked = false;
            Request3.IsChecked = false;
            Request4.IsChecked = false;
            Request5.IsChecked = false;
            Request6.IsChecked = false;
            Request7.IsChecked = false;

        }
        private void Request2_Checked ( object sender, RoutedEventArgs e )
        {

            Request1.IsChecked = false;
            Request3.IsChecked = false;
            Request4.IsChecked = false;
            Request5.IsChecked = false;
            Request6.IsChecked = false;
            Request7.IsChecked = false;

        }
        private void Request3_Checked ( object sender, RoutedEventArgs e )
        {

            Request1.IsChecked = false;
            Request2.IsChecked = false;
            Request4.IsChecked = false;
            Request5.IsChecked = false;
            Request6.IsChecked = false;
            Request7.IsChecked = false;

        }
        private void Request4_Checked ( object sender, RoutedEventArgs e )
        {

            Request1.IsChecked = false;
            Request2.IsChecked = false;
            Request3.IsChecked = false;
            Request5.IsChecked = false;
            Request6.IsChecked = false;
            Request7.IsChecked = false;

        }
        private void Request5_Checked ( object sender, RoutedEventArgs e )
        {

            Request1.IsChecked = false;
            Request2.IsChecked = false;
            Request3.IsChecked = false;
            Request4.IsChecked = false;
            Request6.IsChecked = false;
            Request7.IsChecked = false;

        }
        private void Request6_Checked ( object sender, RoutedEventArgs e )
        {

            Request1.IsChecked = false;
            Request2.IsChecked = false;
            Request3.IsChecked = false;
            Request4.IsChecked = false;
            Request5.IsChecked = false;
            Request7.IsChecked = false;

        }
        private void Request7_Checked ( object sender, RoutedEventArgs e )
        {

            Request1.IsChecked = false;
            Request2.IsChecked = false;
            Request3.IsChecked = false;
            Request4.IsChecked = false;
            Request5.IsChecked = false;
            Request6.IsChecked = false;

        }
        private void Back_Click ( object sender, RoutedEventArgs e )
        {
            Close();
        }

        private void Show_Click ( object sender, RoutedEventArgs e )
        {
            if( Request1.IsChecked == true)
            {
                List<ReportOnMedalsByCountryForEntireOlympics> list = new List<ReportOnMedalsByCountryForEntireOlympics>();
                var _olympics = dB_Info.InfoOlympiad.Include( c => c.KindOfSport.Participants.Result ).Where(c => c.TypeOlympicsSummerOrWinter == _mainWindow.TypeOlympicsSummerOrWinter.Text).ToList();
                foreach (var item in _olympics)
                {
                    ReportOnMedalsByCountryForEntireOlympics reportOnMedalsByCountryForEntireOlympics = new ReportOnMedalsByCountryForEntireOlympics();

                    reportOnMedalsByCountryForEntireOlympics.YearCarryingOut = item.YearCarryingOut;
                    reportOnMedalsByCountryForEntireOlympics.TypeOlympicsSummerOrWinter = item.TypeOlympicsSummerOrWinter;
                    reportOnMedalsByCountryForEntireOlympics.ParticipantsCountry = item.KindOfSport.Participants.ParticipantsCountry;
                    reportOnMedalsByCountryForEntireOlympics.Medal = item.KindOfSport.Participants.Result.Medal;
                    reportOnMedalsByCountryForEntireOlympics.FIO = item.KindOfSport.Participants.FIO;
                    reportOnMedalsByCountryForEntireOlympics.PlaceInStandings = item.KindOfSport.Participants.Result.PlaceInStandings;

                    list.Add( reportOnMedalsByCountryForEntireOlympics );
                }
                _mainWindow.FieldDisplay.ItemsSource = list;
                _mainWindow.Clear();
                Close();
            }
            else if( Request2.IsChecked == true )
            {
                List<ReportOnMedalistsOfVariousSportsForEntireOlympics> list = new List<ReportOnMedalistsOfVariousSportsForEntireOlympics>();
                var _olympics = dB_Info.InfoOlympiad.Include( c => c.KindOfSport.Participants.Result ).Where( c => c.KindOfSport.NameOfSport.Contains( _mainWindow.NameOfSport.Text ) &&
                                                             c.TypeOlympicsSummerOrWinter.Contains( _mainWindow.TypeOlympicsSummerOrWinter.Text ) ).ToList();
                foreach (var item in _olympics)
                {
                    ReportOnMedalistsOfVariousSportsForEntireOlympics reportOnMedalistsOfVariousSportsForEntireOlympics = new ReportOnMedalistsOfVariousSportsForEntireOlympics();

                    reportOnMedalistsOfVariousSportsForEntireOlympics.YearCarryingOut = item.YearCarryingOut;
                    reportOnMedalistsOfVariousSportsForEntireOlympics.TypeOlympicsSummerOrWinter = item.TypeOlympicsSummerOrWinter;
                    reportOnMedalistsOfVariousSportsForEntireOlympics.NameOfSport = item.KindOfSport.NameOfSport;
                    reportOnMedalistsOfVariousSportsForEntireOlympics.FIO = item.KindOfSport.Participants.FIO;
                    reportOnMedalistsOfVariousSportsForEntireOlympics.Medal = item.KindOfSport.Participants.Result.Medal;

                    list.Add( reportOnMedalistsOfVariousSportsForEntireOlympics );
                }
                _mainWindow.FieldDisplay.ItemsSource = list;
                _mainWindow.Clear();
                Close();
            }
            else if( Request3.IsChecked == true )
            {
                List<CountrysMedalsAreGoldOfParticularOlympics> list = new List<CountrysMedalsAreGoldOfParticularOlympics>();
                var _olympics = dB_Info.InfoOlympiad.Include( c => c.KindOfSport.Participants.Result ).Where( c => c.TypeOlympicsSummerOrWinter.Contains( _mainWindow.TypeOlympicsSummerOrWinter.Text ) ).ToList();
                foreach( var item in _olympics )
                {
                    CountrysMedalsAreGoldOfParticularOlympics countrysMedalsAreGoldOfParticularOlympics = new CountrysMedalsAreGoldOfParticularOlympics();


                }
                _mainWindow.FieldDisplay.ItemsSource = list;
                _mainWindow.Clear();
                Close();
            }
            else if( Request4.IsChecked == true )
            {
                List<ReportOnMedalistsOfVariousSportsForEntireOlympics> list = new List<ReportOnMedalistsOfVariousSportsForEntireOlympics>();
                var _olympics = dB_Info.InfoOlympiad.Include( c => c.KindOfSport.Participants.Result ).Where( c => c.KindOfSport.NameOfSport.Contains( _mainWindow.NameOfSport.Text ) &&
                                                             c.TypeOlympicsSummerOrWinter.Contains( _mainWindow.TypeOlympicsSummerOrWinter.Text ) ).ToList();
                foreach( var item in _olympics )
                {
                    ReportOnMedalistsOfVariousSportsForEntireOlympics reportOnMedalistsOfVariousSportsForEntireOlympics = new ReportOnMedalistsOfVariousSportsForEntireOlympics();

                }
                _mainWindow.FieldDisplay.ItemsSource = list;
                _mainWindow.Clear();
                Close();
            }
            else if( Request5.IsChecked == true )
            {
                List<OlympicWinningCountry> list = new List<OlympicWinningCountry>();
                var _olympics = dB_Info.InfoOlympiad.Include( c => c.KindOfSport.Participants.Result ).Where( c => c.KindOfSport.NameOfSport.Contains( _mainWindow.NameOfSport.Text ) &&
                                                             c.TypeOlympicsSummerOrWinter.Contains( _mainWindow.TypeOlympicsSummerOrWinter.Text ) ).ToList();
                foreach( var item in _olympics )
                {
                    OlympicWinningCountry olympicWinningCountry = new OlympicWinningCountry();

                }
                _mainWindow.FieldDisplay.ItemsSource = list;
                _mainWindow.Clear();
                Close();
            }
            else if( Request6.IsChecked == true )
            {
                List<NationalTeamComposition> list = new List<NationalTeamComposition>();
                var _olympics = dB_Info.InfoOlympiad.Include( c => c.KindOfSport.Participants.Result ).Where( c => c.KindOfSport.Participants.ParticipantsCountry.Contains( _mainWindow.ParticipantsCountry.Text )).ToList();
                foreach( var item in _olympics )
                {
                    NationalTeamComposition nationalTeamComposition = new NationalTeamComposition();

                    nationalTeamComposition.FIO = item.KindOfSport.Participants.FIO;
                    nationalTeamComposition.ParticipantsCountry = item.KindOfSport.Participants.ParticipantsCountry;

                    list.Add( nationalTeamComposition );
                }
                _mainWindow.FieldDisplay.ItemsSource = list;
                _mainWindow.Clear();
                Close();
            }
            else if( Request7.IsChecked == true )
            {
                List<GeneralTableData> list = new List<GeneralTableData>();
                var _olympics = dB_Info.InfoOlympiad.Include( c => c.KindOfSport.Participants.Result ).Where( c => c.KindOfSport.NameOfSport.Contains( _mainWindow.NameOfSport.Text ) &&
                                                             c.TypeOlympicsSummerOrWinter.Contains( _mainWindow.TypeOlympicsSummerOrWinter.Text ) ).ToList();
                foreach( var item in _olympics )
                {
                    GeneralTableData generalTableData = new GeneralTableData();

                }
                _mainWindow.FieldDisplay.ItemsSource = list;
                _mainWindow.Clear();
                Close();
            }
        }
    }
}
