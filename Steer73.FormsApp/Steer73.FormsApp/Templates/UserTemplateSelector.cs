using Xamarin.Forms;

namespace Steer73.FormsApp.Templates
{
    public class UserTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DefaultTemplate { get; set; }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return DefaultTemplate;
        }
    }
}
