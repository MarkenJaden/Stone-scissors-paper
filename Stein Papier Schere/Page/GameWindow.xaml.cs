using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Stein_Papier_Schere.Helper;
using Stein_Papier_Schere.Models;

namespace Stein_Papier_Schere.Page
{
    /// <summary>
    /// Interaktionslogik für GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private int wins;
        private int looses;
        private int rounds;

        public GameWindow()
        {
            //Fenster init
            InitializeComponent();
            //Liste mit den verfügbaren Raws füllen
            rawsToPlay.ItemsSource = StaticShit.raws;
        }

        //Doppelklick Event abfangen
        private void RawsToPlay_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            rounds++; //Rundenzähler hochzählen
            roundsLabel.Content = $"Runden: {rounds}";
            //Prüfen ob das Element wo ein Doppelklick ausgeführt wurde vom Typ "Raw" ist
            if (!(rawsToPlay.SelectedItem is Raw selected)) return;
            Raw opponent;
            List<Raw> tempList = StaticShit.raws.ToList();
            do
            {
                opponent = tempList[new Random().Next(tempList.Count)]; //Zufälligen Gegner aller vorhandenen "Raws" auswählen
                tempList.Remove(opponent);
            } while (opponent.id == selected.id); //Prüfen ob der Gegner nicht dasselbe ist wie man selbst gewählt hat, ansonsten neues Raw bestimmen

            opponentName.Content = opponent.name; //Feld in Oberfläche aktualisieren
            if (selected.checkIfWinsAgainst(opponent)) //Überprüfen ob gewonnen oder verloren
            {
                //Oberfläche aktualisieren
                winLabel.Content = "Gewonnen";
                winLabel.Opacity = 100;
                wins++;
                winsLabel.Content = $"Gewonnen: {wins}";
            }
            else
            {
                //Oberfläche aktualisieren
                winLabel.Content = "Verloren";
                winLabel.Opacity = 100;
                looses++;
                loosesLabel.Content = $"Verloren: {looses}";
            }
        }

        //Event für Button Klick
        private void StopButton_OnClick(object sender, RoutedEventArgs e)
        {
            //Schließen und Hauptmenü wieder öffnen
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }
    }
}
