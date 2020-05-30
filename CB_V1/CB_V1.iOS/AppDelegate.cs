using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CB_Database;
using Foundation;
using UIKit;

namespace CB_V1.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {

            var dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "ConfidenceBuilderDB.db");

           // var utilizatoriRepository = new UtilizatoriRepository(dbPath);
            var GenRutineRepository = new GeneratorRutineRepository(dbPath);
            global::Xamarin.Forms.Forms.Init();
           // LoadApplication(new App(utilizatoriRepository));
            LoadApplication(new App(GenRutineRepository));

            return base.FinishedLaunching(app, options);
        }
    }
}
