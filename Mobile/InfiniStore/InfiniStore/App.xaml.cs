using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using InfiniStore.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace InfiniStore
{
    public partial class App : Application
    {

        public App()
        {
//            #if DEBUG
//                LiveReload.Init();
//            #endif

            InitializeComponent();
            MainPage = new Root();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
