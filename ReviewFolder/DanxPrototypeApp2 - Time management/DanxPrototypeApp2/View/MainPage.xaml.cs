using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using DanxPrototypeApp2.View;
using DanxPrototypeApp2.ViewModel;

namespace DanxPrototypeApp2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void TextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            switch (e.Key)
            {
                case VirtualKey.Enter:
                   if(DbViewModel.IsLoggedIn) Frame.Navigate(typeof (BasicPage1));
                    break;
                
                    
            }

        }

        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
           await Task.Delay(1);
            if (DbViewModel.IsLoggedIn) Frame.Navigate(typeof (BasicPage1));
        }

        private void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof (BasicPage1));
        }

      
    }
}
