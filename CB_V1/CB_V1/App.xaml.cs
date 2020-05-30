using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CB_V1
{
    public partial class App : Application
    {
        public App(IGeneratorRutineRepository rutRepository)
        {
            InitializeComponent();

            MainPage = new GenRutinaPage();
            {

                BindingContext = new GeneratorRutineViewModel(rutRepository);

            }
        }

        //public App(IUtilizatoriRepository rutRepository)
        //{
        //    InitializeComponent();

        //    MainPage = new UtilizatoriPage();
        //    {

        //        BindingContext = new UtilizatoriViewModel(rutRepository);

        //    }
        //}


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
