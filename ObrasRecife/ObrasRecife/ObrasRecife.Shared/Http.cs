using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ObrasRecife
{
    class Http
    {
        //TextBlock txt;
        public static string codigoFonte = "";
        //public static Stream s;
        //public static bool flag = false;
        /*public Http(Uri end)
        {
            //this.txt = txt;
            CallService(end);
        }*/

        public static async Task CallService(Uri end)
        {
            HttpClient httpClient = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, end);
            HttpResponseMessage response = await httpClient.SendAsync(request);
            byte[] data = await response.Content.ReadAsByteArrayAsync();
            Encoding wind1252 = Encoding.GetEncoding("windows-1252");
            Encoding utf8 = Encoding.UTF8;
            byte[] uft8Bytes = Encoding.Convert(wind1252, utf8, data);
            codigoFonte = Encoding.UTF8.GetString(uft8Bytes, 0, uft8Bytes.Length);
            System.Diagnostics.Debug.WriteLine("CallService");
            //System.Diagnostics.Debug.WriteLine(codigoFonte);
        }

        public static Stream GenerateStreamFromString()
        {
            System.Diagnostics.Debug.WriteLine("GenerateStreamFromString");
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream, Encoding.UTF8);
            writer.Write(codigoFonte.ToCharArray(), 0, codigoFonte.Length);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public static string converteCaracterAcentuacao(string descricao){

            descricao = descricao.Replace( "&Aacute;", "Á");
            descricao = descricao.Replace("&aacute;", "á");
            descricao = descricao.Replace("&Eacute;", "É");
            descricao = descricao.Replace("&eacute;", "é");
            descricao = descricao.Replace( "&Iacute;", "Í");
            descricao = descricao.Replace( "&iacute;", "í");
            descricao = descricao.Replace( "&Oacute;", "Ó");
            descricao = descricao.Replace( "&oacute;", "ó");
            descricao = descricao.Replace( "&Uacute;", "Ú");
            descricao = descricao.Replace( "&uacute;", "ú");

            descricao = descricao.Replace( "&Acirc;", "Â");
            descricao = descricao.Replace( "&acirc;", "â");
            descricao = descricao.Replace( "&Ecirc;", "Ê");
            descricao = descricao.Replace( "&ecirc;", "ê");
            descricao = descricao.Replace( "&Icirc;", "Î");
            descricao = descricao.Replace( "&icirc;", "î");
            descricao = descricao.Replace( "&Ocirc;", "Ô");
            descricao = descricao.Replace( "&ocirc;", "ô");
            descricao = descricao.Replace( "&Ucirc;", "Û");
            descricao = descricao.Replace( "&ucirc;", "û");

            descricao = descricao.Replace( "&Agrave;", "À");
            descricao = descricao.Replace( "&agrave;", "à");
            descricao = descricao.Replace( "&Egrave;", "È");
            descricao = descricao.Replace( "&egrave;", "é");
            descricao = descricao.Replace( "&Igrave;", "Ì");
            descricao = descricao.Replace( "&igrave;", "ì");
            descricao = descricao.Replace( "&Ograve;", "Ò");
            descricao = descricao.Replace( "&ograve;", "ò");
            descricao = descricao.Replace( "&Ugrave;", "Ù");
            descricao = descricao.Replace( "&ugrave;", "ù");

            descricao = descricao.Replace( "&Atilde;", "Ã");
            descricao = descricao.Replace( "&atilde;", "ã");
            descricao = descricao.Replace( "&Otilde;", "Õ");
            descricao = descricao.Replace( "&otilde;", "õ");

            descricao = descricao.Replace( "&Ccedil;", "Ç");
            descricao = descricao.Replace( "&ccedil;", "ç");

            descricao = descricao.Replace( "&nbsp;", " ");

            return descricao;
        }
    }
}
