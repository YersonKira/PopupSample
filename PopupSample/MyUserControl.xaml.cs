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

// La plantilla de elemento Control de usuario está documentada en http://go.microsoft.com/fwlink/?LinkId=234236

namespace PopupSample
{
    public sealed partial class MyUserControl : UserControl
    {
        public event EventHandler<MyEventArgs> Siguiente;
        public event EventHandler<MyEventArgs> Anterior;
        public MyUserControl()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Siguiente(this, new MyEventArgs("click botton siguiente"));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Anterior(this, new MyEventArgs("click botton anterior"));
        }
    }
}
