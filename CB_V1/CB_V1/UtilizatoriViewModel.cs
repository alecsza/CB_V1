using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CB_V1
{
    class UtilizatoriViewModel : INotifyPropertyChanged
    {
        private readonly IUtilizatoriRepository _utilizatoriRepository;

        private IEnumerable<Utilizator> _utilizatori;

        public IEnumerable<Utilizator> Utilizatori
        {
            get
            {
                return _utilizatori;
            }
            set
            {
                _utilizatori = value;
                OnPropertyChanged();
            }
        }

        public string nume { get; set; }
        public string parola { get; set; }

        public IEnumerable<string> UtilizatoriStr { get; set; }

        public ICommand RefreshCommandStr
        {
            get
            {
                return new Command(async () =>
                {
                    UtilizatoriStr = await _utilizatoriRepository.GetUtilizatoriStrAsync();
                    
                });
            }
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    Utilizatori = await _utilizatoriRepository.GetUtilizatoriAsync();
                });
            }
        }

        public ICommand AddCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var utilizator = new Utilizator
                    {
                        Nume = nume,
                        Parola = parola,

                    };
                    await _utilizatoriRepository.AddUtilizatorAsync(utilizator);
                });

            }
        }


        public UtilizatoriViewModel(IUtilizatoriRepository utilizatoriRepository)
        {
            _utilizatoriRepository = utilizatoriRepository;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
