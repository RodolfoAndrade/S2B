using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ObrasRecife
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page1 : Page
    {
        public static List<Obra> itens;
        public static List<Obra> itensAtivo;
        public static List<Obra> pesquisaItens;
        public Page1()
        {
            this.InitializeComponent();

            //itens = Pagina.getItens();
            //string asdf = "mça manhça organização";
            //itens.Add(new Obra() { Orgao = asdf, Nome = "OBRA 1", Auditoria = "1/1/1" });
            //itens.Add(new Obra() { Orgao = "ORGAO 2", Nome = "OBRA 2", Auditoria = "1/1/2" });
            //itens.Add(new Obra() { Orgao = "ORGAO 3", Nome = "OBRA 3", Auditoria = "1/1/3" });

            lista.ItemsSource = itens;
        }
        public class Obra
        {
            public string Orgao { get; set; }
            public string Nome { get; set; }
            public string Auditoria { get; set; }
            public string Href { get; set; }
            public string NomeLocal { get; set; }
            public BasicGeoposition Local { get; set; }
        }
        void ListBox_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("double click");
            Obra obra = (Obra)lista.SelectedItem;
            if (obra != null)
            {
                System.Diagnostics.Debug.WriteLine(obra.Href);
                try
                {
                    Page2.Href = obra.Href;
                    this.Frame.Navigate(typeof(Page2));
                }
                catch (Exception exp)
                {
                    System.Diagnostics.Debug.WriteLine(exp);
                }
            }
        }

        public static void setPesquisaItens()
        {
            itens = pesquisaItens;
        }

        private void Voltar_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
