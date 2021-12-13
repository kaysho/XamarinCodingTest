
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Steer73.FormsApp.Styles.Resources
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomTemplate : ResourceDictionary
    {
        public static CustomTemplate SharedInstance { get; } = new CustomTemplate();
        public CustomTemplate()
        {
            InitializeComponent();
        }
    }
}