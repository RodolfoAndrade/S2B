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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ObrasRecife
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page2 : Page
    {
        public static string Href;
        public static ObraHref obrahref;
        public Page2()
        {
            this.InitializeComponent(); 
            
            obrahref = Pagina.getItemHref();

            this.h3.Text = obrahref.H3+"\n";
            this.municipio.Text = obrahref.Municipio;
            this.orgao.Text = obrahref.Orgao;
            this.tipoIntervencao.Text = obrahref.TipoIntervencao;
            this.naturezaIntervencao.Text = obrahref.NaturezaIntervencao;
            this.dataInicial.Text = obrahref.DataInicial;
            this.prazoInicial.Text = obrahref.PrazoInicial;
            this.prazoAditado.Text = obrahref.PrazoAditado;
            this.prazoTotal.Text = obrahref.PrazoTotal;
            if (obrahref.Fotos.Count == 0)
            {
                this.Fotos.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                this.fotos.Text = "Não existem fotos da Obra";
                /*for (int i = 1; i < obrahref.Fotos.Count; i++)
                {
                    this.fotos.Text += "\nFotos: " + obrahref.Fotos[i];
                }*/
            }
            
        }
        public class ObraHref
        {
            public string H3 { get; set; }
            public string Municipio { get; set; }
            public string Orgao { get; set; }
            public string TipoIntervencao { get; set; }
            public string NaturezaIntervencao { get; set; }
            public string DataInicial { get; set; }
            public string PrazoInicial { get; set; }
            public string PrazoAditado { get; set; }
            public string PrazoTotal { get; set; }
            public List<string> Fotos { get; set; }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Page3));
        }

        private void Voltar_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Page1));
        }

    }
}
