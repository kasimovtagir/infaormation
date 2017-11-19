using System;
using System.Management;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml.Linq;

namespace ConsoleApplication1
{
    class InterFace
    {
        public void interFace()
        {
            //Создание ПДФ-ФАЙЛА
            var Doc = new Document();
            iTextSharp.text.pdf.PdfWriter.GetInstance(Doc,
                new System.IO.FileStream("InterFace.pdf", System.IO.FileMode.Create));
            Doc.Open();
            BaseFont BF = BaseFont.CreateFont(@"C:\Windows\Fonts\comic.ttf"
               , "CP1251", BaseFont.EMBEDDED);
            var font = new iTextSharp.text.Font(BF, 12, iTextSharp.text.Font.NORMAL);
            Doc.Add(new Paragraph("Информация о интерфейсах: " + "\n", font));

            //Сбор информации
            ManagementObjectSearcher searcher =
   new ManagementObjectSearcher("root\\CIMV2",
   "SELECT * FROM Win32_NetworkAdapterConfiguration");

            foreach (ManagementObject queryObj in searcher.Get())
            {
               // Console.WriteLine("--------- Win32_NetworkAdapterConfiguration instance --------------");
                //Console.WriteLine("Caption: {0}", queryObj["Caption"]);
                Doc.Add(new Paragraph("Win32_NetworkAdapterConfiguration instance", font));
                Doc.Add(new Paragraph("Caption:" + queryObj["Caption"], font));
               
                if (queryObj["DefaultIPGateway"] == null)
                {
                    //Console.WriteLine("DefaultIPGateway: {0}", queryObj["DefaultIPGateway"]);
                    Doc.Add(new Paragraph("DefaultIPGateway: "+ queryObj["DefaultIPGateway"], font));
                    
                }
                else
                {
                    String[] arrDefaultIPGateway = (String[])(queryObj["DefaultIPGateway"]);
                    foreach (String arrValue in arrDefaultIPGateway)
                    {
                        //Console.WriteLine("DefaultIPGateway: {0}", arrValue);
                        Doc.Add(new Paragraph("DefaultIPGateway: " + arrValue , font));
                    }
                }

                if (queryObj["DNSServerSearchOrder"] == null)
                {
                    //Console.WriteLine("DNSServerSearchOrder: {0}", queryObj["DNSServerSearchOrder"]);
                    Doc.Add(new Paragraph("DNSServerSearchOrder: " + queryObj["DNSServerSearchOrder"], font));
                }
                else
                {
                    String[] arrDNSServerSearchOrder = (String[])(queryObj["DNSServerSearchOrder"]);
                    foreach (String arrValue in arrDNSServerSearchOrder)
                    {
                        //Console.WriteLine("DNSServerSearchOrder: {0}", arrValue);
                        Doc.Add(new Paragraph("DNSServerSearchOrder: " + arrValue, font));
                    }
                }

                if (queryObj["IPAddress"] == null)
                {
                    //Console.WriteLine("IPAddress: {0}", queryObj["IPAddress"]);
                    Doc.Add(new Paragraph("IPAddress: " + queryObj["IPAddress"] , font));
                }

                else
                {
                    String[] arrIPAddress = (String[])(queryObj["IPAddress"]);
                    foreach (String arrValue in arrIPAddress)
                    {
                        //Console.WriteLine("IPAddress: {0}", arrValue);
                        Doc.Add(new Paragraph("IPAddress: " + arrValue ,  font));
                    }
                }

                if (queryObj["IPSubnet"] == null)
                {
                    //Console.WriteLine("IPSubnet: {0}", queryObj["IPSubnet"]);
                    Doc.Add(new Paragraph("IPSubnet: "+ queryObj["IPSubnet"] , font));
                }
                else
                {
                    String[] arrIPSubnet = (String[])(queryObj["IPSubnet"]);
                    foreach (String arrValue in arrIPSubnet)
                    {
                        //Console.WriteLine("IPSubnet: {0}", arrValue);
                        Doc.Add(new Paragraph("IPSubnet: "+ arrValue , font));
                     }
                }
                //Console.WriteLine("MACAddress: {0}", queryObj["MACAddress"]);
                //Console.WriteLine("ServiceName: {0}", queryObj["ServiceName"]);
                Doc.Add(new Paragraph("MACAddress: "+ queryObj["MACAddress"] , font));
                Doc.Add(new Paragraph("ServiceName: "+ queryObj["ServiceName"] , font));
                Doc.Add(new Paragraph("\n", font));
            }
            Doc.Close();
            System.Diagnostics.Process.Start("interface.pdf");

            Console.Write("ИНФОРМАЦИЯ О ИНТЕРФЕЙСАХ СОХРАНЕНО В ФАЙЛЕ interface.pdf \n");
            //Console.ReadKey(true);
        }
    }
}
