using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;
using CB_Database;

namespace CB_V1.Droid
{
    [Activity(Label = "CB_V1", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            string dbp = Utils.GetLocalFilePath("ConfidenceBuilderDB.db");

            var dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "ConfidenceBuilderDB.db");

         //   var utilizatoriRepository = new UtilizatoriRepository(dbp);
            var rutineRepository = new GeneratorRutineRepository(dbp);


            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App(rutineRepository));
            //LoadApplication(new App(utilizatoriRepository));
        }
    }
}