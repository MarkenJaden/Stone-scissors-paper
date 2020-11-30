using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Stein_Papier_Schere.Helper;
using Stein_Papier_Schere.Models;

namespace Stein_Papier_Schere
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            //Beim init der gesamten Application Schere, Stein und Papier erstellen
            Raw schere = new Raw("Schere", 1);
            Raw stein = new Raw("Stein", 2);
            Raw papier = new Raw("Papier", 3);
            schere.winsAgainst = new List<Raw>() { papier };
            stein.winsAgainst = new List<Raw>() { schere };
            papier.winsAgainst = new List<Raw>() { stein };
            StaticShit.raws.Add(schere);
            StaticShit.raws.Add(stein);
            StaticShit.raws.Add(papier);
        }
    }
}
