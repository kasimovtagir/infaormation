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
    class Video
    {
        public void video()
        {
            //Создание ПДФ-ФАЙЛА
            var Doc = new Document();
            iTextSharp.text.pdf.PdfWriter.GetInstance(Doc,
                new System.IO.FileStream("Video.pdf", System.IO.FileMode.Create));
            Doc.Open();
            BaseFont BF = BaseFont.CreateFont(@"C:\Windows\Fonts\comic.ttf"
               , "CP1251", BaseFont.EMBEDDED);
            var font = new iTextSharp.text.Font(BF, 12, iTextSharp.text.Font.NORMAL);
            Doc.Add(new Paragraph("Информация о всех видеокарт системы: " + "\n", font));
            
            //Сбор информации
            ManagementObjectSearcher searcher11 =
            new ManagementObjectSearcher("root\\CIMV2",
            "SELECT * FROM Win32_VideoController");

            foreach (ManagementObject queryObj in searcher11.Get())
            {/*
                Console.WriteLine("----------- Win32_VideoController instance -----------");
                Console.WriteLine("AdapterRAM: {0}", queryObj["AdapterRAM"]);
                Console.WriteLine("Caption: {0}", queryObj["Caption"]);
                Console.WriteLine("Description: {0}", queryObj["Description"]);
                Console.WriteLine("VideoProcessor: {0}", queryObj["VideoProcessor"]);*/

                Doc.Add(new Paragraph("Win32_VideoController instance", font));
                Doc.Add(new Paragraph("AdapterRAM: "+ queryObj["AdapterRAM"], font));
                Doc.Add(new Paragraph("Caption: "+ queryObj["Caption"], font));
                Doc.Add(new Paragraph("Description: "+ queryObj["Description"], font));
                Doc.Add(new Paragraph("VideoProcessor: "+ queryObj["VideoProcessor"], font));
                Doc.Add(new Paragraph("\n", font));


            }
            Doc.Close();
            System.Diagnostics.Process.Start("video.pdf");
            Console.Write("ИНФОРМАЦИЯ О ВИДЕОКАРТЕ СОХРАНЕНО В ФАЙЛЕ video.pdf \n");
            //Console.ReadKey(true);
        }
    }
}
