using System.Windows;
using Stein_Papier_Schere.Page;

namespace Stein_Papier_Schere
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Alles nichts besonderes, nur Management welches Fenster bei welchem Button wie sich öffnet
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PlayButton_OnClick(object sender, RoutedEventArgs e)
        {
            GameWindow game = new GameWindow();
            this.Close();
            game.Show();
        }

        private void StopButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OptionsButton_OnClick(object sender, RoutedEventArgs e)
        {
            OptionsWindow options = new OptionsWindow();
            options.ShowDialog();
        }
    }
}
