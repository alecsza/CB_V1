using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CB_V1
{
    class GeneratorRutineViewModel : INotifyPropertyChanged
    {
        private readonly IGeneratorRutineRepository _genRutineRepository;
        private readonly IActiuniRepository _actiuni;


        private IEnumerable<GeneratorRutina> _genRutine;

        public IEnumerable<GeneratorRutina> GeneratorRutine
        {
            get
            {
                return _genRutine;
            }
            set
            {
                _genRutine = value;
                OnPropertyChanged();
            }
        }

        public string denumire { get; set; }
        public int idUtilizator { get; set; }

        public IEnumerable<string> GeneratorRutineStr { get; set; }

        public ICommand RefreshCommandStr
        {
            get
            {
                return new Command(async () =>
                {
                    GeneratorRutineStr = await _genRutineRepository.GetGeneratorRutineStrAsync();
                    
                });
            }
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    GeneratorRutine = await _genRutineRepository.GetGeneratorRutineAsync();
                });
            }
        }

        public ICommand AddCommand
        {
            get
            {
               

                return new Command(async () =>
                {


                    var act = _actiuni.GetActiuneByNameAsync(denumire);
                    if (act.Result == null)
                    {
                        act.Result.Denumire = denumire;
                        _actiuni.AddActiuneAsync(act.Result);
                        
                    }

                    var genRutina = new GeneratorRutina
                    {
                        IdUtilizator = idUtilizator,
                        IdActiune = act.Result.Id,
                        Actiune = act.Result,
                        Activ = 1,
                        TotalAc = 0
                        
                       

                    };
                    await _genRutineRepository.AddGeneratorRutinaAsync(genRutina);
                });

            }
        }


        public GeneratorRutineViewModel(IGeneratorRutineRepository genRutinaiRepository)
        {
            _genRutineRepository = genRutinaiRepository;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
