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
    class Services
    {
        public void Servic()
        {
            //создание пдф-файла 
            var Doc = new Document();
            iTextSharp.text.pdf.PdfWriter.GetInstance(Doc,
                new System.IO.FileStream("Services.pdf", System.IO.FileMode.Create));
            Doc.Open();
            BaseFont BF = BaseFont.CreateFont(@"C:\Windows\Fonts\comic.ttf"
               , "CP1251", BaseFont.EMBEDDED);
            var font = new iTextSharp.text.Font(BF, 12, iTextSharp.text.Font.NORMAL);
            Doc.Add(new Paragraph("Запушенные на устройстве службы, их описание и состояние : \n " + "\n", font));
            
            //сбор информации
           ManagementObjectSearcher searcher3 =
           new ManagementObjectSearcher("root\\CIMV2",
           "SELECT * FROM Win32_Service");
            string qwe = " ";
            foreach (ManagementObject queryObj in searcher3.Get())
            {
                Doc.Add(new Paragraph("Win32_Service instance" + "\n", font));
                Doc.Add(new Paragraph("Caption: " + queryObj["Caption"], font));
                Doc.Add(new Paragraph("Description: " + queryObj["Description"], font));
                Doc.Add(new Paragraph("DisplayName: {0} " + queryObj["DisplayName"], font));
                Doc.Add(new Paragraph("Name: "+ queryObj["Name"], font));
                Doc.Add(new Paragraph("PathName: " + queryObj["PathName"], font));
                Doc.Add(new Paragraph("Started: " + queryObj["Started"], font));
                Doc.Add(new Paragraph("\n", font));
            }

            Doc.Close();
            System.Diagnostics.Process.Start("services.pdf");

            Console.Write("СПИСОК СЛУЖБ, ИХ ОПИСАНИЯ И СОСТОЯНИЯ СОХРАНЕН НА ФАЙЛ services.pdf \n");
            //Console.ReadKey(true);
        }
    }
}
