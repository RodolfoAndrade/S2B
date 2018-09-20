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
    public sealed partial class Page4 : Page
    {
        public Page4()
        {
            this.InitializeComponent();


        }

        private void Pesquisar_Click(object sender, RoutedEventArgs e)
        {
            List<Page1.Obra> novasObras = new List<Page1.Obra>();
            bool adicionada = false;
            //string mun = municipio.Text;
            string org = orgao.Text;
            string obr = obra.Text;


            if (org != "" || obr != "")
            {
                System.Diagnostics.Debug.WriteLine("ok");
                System.Diagnostics.Debug.WriteLine(org);
                System.Diagnostics.Debug.WriteLine(obr);

                try
                {
                    foreach (var i in Page1.itens)
                    {
                        if (org != "")
                        {
                            if (i.Orgao.ToLower().Contains(org.ToLower()))
                            {
                                novasObras.Add(i);
                                adicionada = true;
                            }
                        }
                        if (obr != "")
                        {
                            if (i.Nome.ToLower().Contains(obr.ToLower()) && adicionada == false)
                            {
                                novasObras.Add(i);
                            }
                        }
                        adicionada = false;
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex);
                }

                Page1.pesquisaItens = novasObras;
                Page1.setPesquisaItens();
                this.Frame.Navigate(typeof(Page1));
            }
        }

        private void Voltar_Click(object sender, RoutedEventArgs e)
        {
            Page1.itens = Page1.itensAtivo;
            this.Frame.Navigate(typeof(MainPage));
        }

        private void Limpar_Click(object sender, RoutedEventArgs e)
        {
            orgao.Text = "";
            obra.Text = "";
        }
    }
}
