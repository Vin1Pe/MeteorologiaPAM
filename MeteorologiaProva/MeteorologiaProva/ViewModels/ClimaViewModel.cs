using CommunityToolkit.Mvvm.ComponentModel;
using MeteorologiaProva.Models;
using MeteorologiaProva;
using MeteorologiaProva.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteorologyPrevision.ViewModel
{
    public partial class MeteorologyViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<ObservableCollection<Cidade>> meteorologies;

        public MeteorologyViewModel()
        {
            meteorologies = new ObservableCollection<ObservableCollection<Cidade>>();
        }

        public async Task getClimates(string nome)
        {
            ClimaServices MeteorologiaProvaService = new ClimaServices();
            meteorologies = await MeteorologiaProvaService.getClimate(nome);
            Debug.WriteLine(meteorologies);
        }
    }
}