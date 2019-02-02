using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace InfiniStore.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Root : MasterDetailPage
    {
        public Root()
        {
            InitializeComponent();
        }
    }
}