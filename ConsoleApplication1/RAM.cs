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
    class RAM
    {
        public void ram()
        {
            //создание пдф-файла
            var Doc = new Document();
            iTextSharp.text.pdf.PdfWriter.GetInstance(Doc,
                new System.IO.FileStream("RAM.pdf", System.IO.FileMode.Create));
            Doc.Open();
            BaseFont BF = BaseFont.CreateFont(@"C:\Windows\Fonts\comic.ttf"
               , "CP1251", BaseFont.EMBEDDED);
            var font = new iTextSharp.text.Font(BF, 12, iTextSharp.text.Font.NORMAL);
            Doc.Add(new Paragraph("Оперативная память: " + "\n", font));

            //Сбор информации
            ManagementObjectSearcher searcher12 =
            new ManagementObjectSearcher("root\\CIMV2",
            "SELECT * FROM Win32_PhysicalMemory");

            //Console.WriteLine("------------- Win32_PhysicalMemory instance --------");
            foreach (ManagementObject queryObj in searcher12.Get())
            {
                /*Console.WriteLine("BankLabel: {0} ; Capacity: {1} Gb; Speed: {2} ", queryObj["BankLabel"],
                                  Math.Round(System.Convert.ToDouble(queryObj["Capacity"]) / 1024 / 1024 / 1024, 2),
                                   queryObj["Speed"]);*/

                Doc.Add(new Paragraph(" Win32_PhysicalMemory instance ", font));
                Doc.Add(new Paragraph("BankLabel: " + queryObj["BankLabel"], font));
                Doc.Add(new Paragraph("Capacity: " + Math.Round(System.Convert.ToDouble(queryObj["Capacity"]) / 1024 / 1024 / 1024, 2), font));
                Doc.Add(new Paragraph("Speed: " + queryObj["Speed"], font));


            }

            Doc.Close();
            System.Diagnostics.Process.Start("ram.pdf");
            Console.Write("ИНФОРМАЦИЯ О ОПЕРАТИВНОЙ ПАМЯТИ СОХРАНЕНА НА ФАЙЛЕ ram.pdf \n");
            //Console.ReadKey(true);
        }
    }
}
