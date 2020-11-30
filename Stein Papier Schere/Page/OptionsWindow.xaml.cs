using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Stein_Papier_Schere.Helper;
using Stein_Papier_Schere.Models;

namespace Stein_Papier_Schere.Page
{
    /// <summary>
    /// Interaktionslogik für OptionsWindow.xaml
    /// </summary>
    public partial class OptionsWindow : Window
    {
        public OptionsWindow()
        {
            InitializeComponent();
            initMain();
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            Raw newRaw = new Raw(nameBox.Text, StaticShit.raws.Count + 1);
            if (!(listOfAllRaws_add.SelectedItem is Models.Raw selected)) return;
            newRaw.winsAgainst = new List<Raw>() {selected};
            StaticShit.raws.Add(newRaw);
            initMain();
        }

        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (listOfAllRaws_delete.SelectedItem is Models.Raw selected)
            {
                StaticShit.raws.Remove(selected);
            }
            initMain();
        }

        private void WinsButton_OnClick(object sender, RoutedEventArgs e)
        {
            //Typ von beiden Items bekommen
            if (!(listOfAllRaws_winsAgainst.SelectedItem is Models.Raw selected1)) return;
            if (!(listOfAllRaws_winsAgainst_2.SelectedItem is Models.Raw selected2)) return;

            selected1.winsAgainst.Add(selected2);

            refreshWin();
        }

        private void LoosesButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (!(listOfAllRaws_loosesAgainst.SelectedItem is Models.Raw selected1)) return;
            if (!(listOfAllRaws_loosesAgainst_2.SelectedItem is Models.Raw selected2)) return;

            selected1.winsAgainst.Remove(selected2);

            refreshLoose();
        }

        private void ListOfAllRaws_winsAgainst_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            refreshWin();
        }

        private void ListOfAllRaws_loosesAgainst_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            refreshLoose();
        }

        private void refreshWin()
        {
            if (!(listOfAllRaws_winsAgainst.SelectedItem is Models.Raw selected)) return;
            List<Raw> list = StaticShit.raws.ToList(); //Deepcopy oder wie das hieß, weil das so spezielle Datentypen sind, keine Ahnung wie das hieß, damit ich nicht die eigentliche Liste bearbeite
            //Entferne jedes Item in der Liste welches bereits im vorher ausgewählten Raw ist
            foreach (Raw rawInWinsAgainst in selected.winsAgainst.Where(rawInWinsAgainst => list.Any(rawInList => rawInWinsAgainst.id == rawInList.id)))
            {
                list.Remove(rawInWinsAgainst);
            }

            listOfAllRaws_winsAgainst_2.ItemsSource = list;
        }

        private void refreshLoose()
        {
            if (!(listOfAllRaws_loosesAgainst.SelectedItem is Models.Raw selected)) return;
            listOfAllRaws_loosesAgainst_2.ItemsSource = selected.winsAgainst.ToList();
        }

        private void initMain()
        {
            listOfAllRaws_add.ItemsSource = StaticShit.raws.ToList();
            listOfAllRaws_delete.ItemsSource = StaticShit.raws.ToList();

            listOfAllRaws_winsAgainst.ItemsSource = StaticShit.raws.ToList();
            listOfAllRaws_loosesAgainst.ItemsSource = StaticShit.raws.ToList();
        }
    }
}
