using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

namespace PopupSample
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PopupHelper popup = new PopupHelper();
            popup.Show(new MyUserControl(), new Point(500, 500));
            popup.Siguiente += (s, a) => {
                res.Text = a.Result;
            };
            popup.Anterior += (s, a) => {
                res.Text = a.Result;
            };
        }
    }
    public class MyEventArgs : EventArgs
    {
        public string Result { get; set; }
        public MyEventArgs(string result)
        {
            this.Result = result;
        }
    }
    public class PopupHelper
    {
        public event EventHandler<MyEventArgs> Siguiente;
        public event EventHandler<MyEventArgs> Anterior;
        public PopupHelper()
        {
            
        }
        public void Show(MyUserControl usercontrol, Point location) 
        {
            usercontrol.Siguiente += (s, a) => {
                Siguiente(this, new MyEventArgs(a.Result));
            };
            usercontrol.Anterior += (s, a) => {
                Anterior(this, new MyEventArgs(a.Result));
            };
            Popup popup = new Popup();
            popup.Child = usercontrol;
            popup.HorizontalOffset = location.X;
            popup.VerticalOffset = location.Y;
            popup.IsLightDismissEnabled = true;
            popup.IsOpen = true;
        }
    }
}
