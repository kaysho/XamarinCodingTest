namespace Steer73.FormsApp.iOS
{

    /// <summary>
    /// Handles all nuget package initialization for project.
    /// </summary>
    public class NugetInstallers
    {

        /// <summary>
        /// Call the method on app startup
        /// </summary>
        public static void Init()
        {
            Sharpnado.Shades.iOS.iOSShadowsRenderer.Initialize();
        }
    }
}