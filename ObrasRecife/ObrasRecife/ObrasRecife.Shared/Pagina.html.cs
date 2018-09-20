using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Storage;

namespace ObrasRecife
{
    class Pagina
    {
        ///bin\Debug\pagina.html
        //private static StreamReader sr = new StreamReader("pagina.html", Encoding.GetEncoding("Windows-1252"), true);
        private static StreamReader sr;
        private static StreamReader streamReader;
        private static int numero = 1;
        private static string stringProcurada = "     <td rowspan=\"1\" class=\"scGridFieldOddFont\" align=\"left\" valign=\"top\" height=\"0px\">";
        private static string stringProcurada1 = "     <td rowspan=\"1\" class=\"scGridFieldEvenFont\" align=\"left\" valign=\"top\" height=\"0px\">";
        private static string hrefProcurado = "     <td rowspan=\"1\" class=\"scGridFieldOddFont\" style=\"font-weight:bold;\" align=\"left\" valign=\"top\" height=\"0px\"><a href=\"";
        private static string hrefProcurado1 = "     <td rowspan=\"1\" class=\"scGridFieldEvenFont\" style=\"font-weight:bold;\" align=\"left\" valign=\"top\" height=\"0px\"><a href=\"";
        //private static string line;
        //private static string nl;
        //private static string href;
        //private static string orgao;
        //private static string nome;
        //private static string auditoria;
        //private static int i;

        public static string getString(string line, string str, string s)
        {
            string nl;
            //System.Diagnostics.Debug.WriteLine(line);

            if (line != null && line.StartsWith(str))
            {
                nl = line.Substring(str.Length);
                if (nl.IndexOf(s) != -1) nl = nl.Substring(0, nl.IndexOf(s));
                //System.Diagnostics.Debug.WriteLine("i = " + i);
                //System.Diagnostics.Debug.WriteLine(nl);
                //i--;
                //System.Diagnostics.Debug.WriteLine("i = " + i);
                return nl;
            }
            else
            {
                return null;
            }
        }
        
        public static Page2.ObraHref getItemHref()
        {
            string h3 = null;
            string municipio = null;
            string orgao = null;
            string tipoIntervencao = null;
            string naturezaIntervencao = null;
            string dataInicial = null;
            string prazoInicial = null;
            string prazoAditado = null;
            string prazoTotal = null;
            string foto = null;
            List<string> fotos = new List<string>();
            string ln;

            System.Diagnostics.Debug.WriteLine(Page2.Href);

            Task task = Task.Run(async () => { await Http.CallService(new Uri(Page2.Href)); });
            task.Wait();

            System.Diagnostics.Debug.WriteLine("getItemHref...");

            using (Stream s = Http.GenerateStreamFromString())
            {
                //encodificação errada?
                StreamReader sr = new StreamReader(s, Encoding.UTF8);

                while (!sr.EndOfStream && h3 == null)
                {
                    ln = sr.ReadLine();
                    System.Diagnostics.Debug.WriteLine("h3");
                    h3 = getString(ln, "<h3>", "<");
                }
                while (!sr.EndOfStream && municipio == null)
                {
                    ln = sr.ReadLine();
                    System.Diagnostics.Debug.WriteLine("municipio");
                    municipio = getString(ln, "<p><strong>Município(s):</strong> ", "<");
                }
                while (!sr.EndOfStream && orgao == null)
                {
                    ln = sr.ReadLine();
                    System.Diagnostics.Debug.WriteLine("orgao");
                    orgao = getString(ln, "<p><strong>Órgão:</strong> ", "<");
                }
                while (!sr.EndOfStream && tipoIntervencao == null)
                {
                    ln = sr.ReadLine();
                    System.Diagnostics.Debug.WriteLine("tipointer");
                    tipoIntervencao = getString(ln, "<p><strong>Tipo de Intervenção:</strong> ", "<");
                }
                while (!sr.EndOfStream && naturezaIntervencao == null)
                {
                    ln = sr.ReadLine();
                    System.Diagnostics.Debug.WriteLine(ln);
                    naturezaIntervencao = getString(ln, "<p><strong>Natureza de Intervenção:</strong> ", "<");
                }
                while (!sr.EndOfStream && dataInicial == null)
                {
                    ln = sr.ReadLine();
                    System.Diagnostics.Debug.WriteLine(ln);
                    dataInicial = getString(ln, "<p><strong>Data Inicial da Obra:</strong> ", "<");
                }
                while (!sr.EndOfStream && prazoInicial == null)
                {
                    ln = sr.ReadLine();
                    System.Diagnostics.Debug.WriteLine(ln);
                    prazoInicial = getString(ln, "<p><strong>Prazo Inicial da obra (em dias):</strong> ", "<");
                }
                while (!sr.EndOfStream && prazoAditado == null)
                {
                    ln = sr.ReadLine();
                    System.Diagnostics.Debug.WriteLine(ln);
                    prazoAditado = getString(ln, "<p><strong>Prazo Aditado da obra (em dias):</strong> ", "<");
                }
                while (!sr.EndOfStream && prazoTotal == null)
                {
                    ln = sr.ReadLine();
                    System.Diagnostics.Debug.WriteLine(ln);
                    prazoTotal = getString(ln, "<p><strong>Prazo Total da Obra (em dias):</strong> ", "<");
                }
                while (!sr.EndOfStream && foto == null)
                {
                    ln = sr.ReadLine();
                    System.Diagnostics.Debug.WriteLine("Fotos");
                    System.Diagnostics.Debug.WriteLine(ln);
                    foto = getString(ln, "            <a href='", "'");
                    if (foto != null)
                    {
                        fotos.Add(foto);
                        foto = null;
                    }
                }

                System.Diagnostics.Debug.WriteLine("fim do arquivo ou achado");
            }
            /*
            if(projeto.Http.codigoFonte != ""){
                h3 = projeto.Http.codigoFonte;
                System.Diagnostics.Debug.Write(h3);
            }
            else
                System.Diagnostics.Debug.Write("string vazia");
            */
            return new Page2.ObraHref() { H3 = h3, Municipio = municipio, Orgao = orgao, TipoIntervencao = tipoIntervencao, NaturezaIntervencao = naturezaIntervencao, DataInicial = dataInicial, PrazoInicial = prazoInicial, PrazoAditado = prazoAditado, PrazoTotal = prazoTotal, Fotos = fotos };

        }

        public static async Task ReadFile()
        {
            System.Diagnostics.Debug.WriteLine("ReadFile()");
            //string fileContent;
            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(new Uri(@"ms-appx:///obrasrecifemap.txt"));
            /*using (StreamReader sRead = new StreamReader(await file.OpenStreamForReadAsync(),Encoding.GetEncoding("ISO-8859-1")))
                fileContent = await sRead.ReadToEndAsync();

            System.Diagnostics.Debug.WriteLine(fileContent);*/
            streamReader = new StreamReader(await file.OpenStreamForReadAsync(), Encoding.GetEncoding("ISO-8859-1"));
        }
        public static void getLocals()
        {
            double latitude = 0.0;
            double longitude = 0.0;
            int altitude = 0;
            string nome = "";
            int i = 0;
            string linha;

            System.Diagnostics.Debug.WriteLine("using streamReader");
            while(!streamReader.EndOfStream && nome == ""){
                linha = streamReader.ReadLine();
                System.Diagnostics.Debug.WriteLine(linha);
                if (linha.StartsWith(Page1.itens[i].Href))
                {
                    System.Diagnostics.Debug.WriteLine("encontrou " + Page1.itens[i].Href);
                    linha = streamReader.ReadLine();
                    Page1.itens[i].NomeLocal = i.ToString();
                    if(!linha.Equals("?")){
                        //nome = linha;
                        linha = streamReader.ReadLine();
                        latitude = Convert.ToDouble(getString(linha, "@", ","));
                        longitude = Convert.ToDouble(linha.Substring(linha.IndexOf(",") + 1, linha.LastIndexOf(",") - linha.IndexOf(",") - 1));
                        //longitude = Convert.ToDouble(getString(linha, ",", ","));
                        altitude = Convert.ToInt32(linha.Substring(linha.LastIndexOf(",") + 1, 2));
                        Page1.itens[i++].Local = new BasicGeoposition { Latitude = latitude, Longitude = longitude, Altitude = altitude };
                        System.Diagnostics.Debug.WriteLine(latitude + "\n" + longitude + "\n" + altitude + "\n");
                    }
                    else
                    {
                        i++;
                    }
                }
            }
            
            //return new BasicGeoposition { Latitude = latitude, Longitude = longitude, Altitude = altitude };
        }

        public static Page1.Obra getItem(string str, string str1)
        {
            string href = null;
            string orgao = null;
            string nome = null;
            string auditoria = null;
            BasicGeoposition local = new BasicGeoposition { Latitude = 0, Longitude = 0, Altitude = 0 };;
            string linha;
            
            while (!sr.EndOfStream && href == null)
            {
                linha = sr.ReadLine();
                //System.Diagnostics.Debug.WriteLine("href");
                href = getString(linha, str, "\"");
            }
            System.Diagnostics.Debug.WriteLine("getItem: " + href);
            while (!sr.EndOfStream && orgao == null)
            {
                //System.Diagnostics.Debug.WriteLine("orgao");
                orgao = getString(sr.ReadLine(), str1, "<");
            }
            //System.Diagnostics.Debug.WriteLine(orgao);
            while (!sr.EndOfStream && nome == null)
            {
                //System.Diagnostics.Debug.WriteLine("nome");
                nome = getString(sr.ReadLine(), str1, "<");
            }
            //System.Diagnostics.Debug.WriteLine(nome);
            while (!sr.EndOfStream && auditoria == null)
            {
                //System.Diagnostics.Debug.WriteLine("auditoria");
                auditoria = getString(sr.ReadLine(), str1, "<");
            }
            //System.Diagnostics.Debug.WriteLine(href);
            //local = getLocal(href);

            return new Page1.Obra() { Href = href, Orgao = orgao, Nome = nome, Auditoria = auditoria, Local = local, NomeLocal=(numero++).ToString() };
        }

        public static List<Page1.Obra> getItens()
        {
            Task task = Task.Run(async () => { await Http.CallService(new Uri("http://cin.ufpe.br/~risa/pagina.html")); });
            task.Wait();
            Task task1 = Task.Run(async () => { await ReadFile(); });
            task1.Wait();
            Stream stream = Http.GenerateStreamFromString();
            sr = new StreamReader(stream, Encoding.UTF8);

            List<Page1.Obra> obras = new List<Page1.Obra>();
            Page1.Obra obra;

            while (!sr.EndOfStream)
            {
                obra = getItem(hrefProcurado, stringProcurada);
                if (!obras.Exists(x => x.Href.Equals(obra.Href))) obras.Add(obra);
                obra = getItem(hrefProcurado1, stringProcurada1);
                if (!obras.Exists(x => x.Href.Equals(obra.Href))) obras.Add(obra);
            }

            //getLocals();
            //remover obra vazia
            obras.RemoveAt(obras.Count-1);

            return obras;
        }
    }
}
