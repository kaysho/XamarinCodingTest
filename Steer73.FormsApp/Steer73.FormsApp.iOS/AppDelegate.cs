using Foundation;
using UIKit;

namespace Steer73.FormsApp.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            NugetInstallers.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
