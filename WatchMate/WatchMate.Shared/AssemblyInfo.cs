using System.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.ComponentModel;


[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

[assembly: ExportFont("Font Awesome 6 Brands-Regular-400.otf", Alias = "FA-B")]
[assembly: ExportFont("Font Awesome 6 Free-Regular-400.otf", Alias = "FA-R")]
[assembly: ExportFont("Font Awesome 6 Free-Solid-900.otf", Alias = "FA-S")]

[assembly: NeutralResourcesLanguage("en-gb")]


namespace System.Runtime.CompilerServices
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class IsExternalInit { }
}