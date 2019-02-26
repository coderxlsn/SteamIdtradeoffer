using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace App1
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var param = new Dictionary<string, string>();
            param.Add("block1", TextBox1.Text);
            param.Add("block2", TextBox2.Text);
            param.Add("block3", TextBox3.Text);
            param.Add("SteamId", SteamId.Text);
            param.Add("TokenId", TokenId.Text);
            param.Add("sessionid", sessionid.Text);
            UserClass service = new UserClass();

            var result = await service.Run(param);
            if (result == null) return;
            var popap = new MessageDialog(result);
            await popap.ShowAsync();

        }
    }
}
