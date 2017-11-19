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
    class CPU
    {
        public void cpu()
        {
            //создание пдф-файла
            var Doc = new Document();
            iTextSharp.text.pdf.PdfWriter.GetInstance(Doc,
                new System.IO.FileStream("CPU.pdf", System.IO.FileMode.Create));
            Doc.Open();
            BaseFont BF = BaseFont.CreateFont(@"C:\Windows\Fonts\comic.ttf"
               , "CP1251", BaseFont.EMBEDDED);
            var font = new iTextSharp.text.Font(BF, 12, iTextSharp.text.Font.NORMAL);
            Doc.Add(new Paragraph("Устновленный процессор: " + "\n", font));

            //Сбор информации
            ManagementObjectSearcher searcher8 =
            new ManagementObjectSearcher("root\\CIMV2",
            "SELECT * FROM Win32_Processor");

            foreach (ManagementObject queryObj in searcher8.Get())
            {
                /* Console.WriteLine("------------- Win32_Processor instance ---------------");
                 Console.WriteLine("Name: {0}", queryObj["Name"]);
                 Console.WriteLine("NumberOfCores: {0}", queryObj["NumberOfCores"]);
                 Console.WriteLine("ProcessorId: {0}", queryObj["ProcessorId"]);*/
                Doc.Add(new Paragraph("Win32_Processor instance", font));
                Doc.Add(new Paragraph("Name: "+ queryObj["Name"], font));
                Doc.Add(new Paragraph("NumberOfCores: " + queryObj["NumberOfCores"], font));
                Doc.Add(new Paragraph("ProcessorId: "+ queryObj["ProcessorId"], font));
                Doc.Add(new Paragraph("\n", font));
            }
            Doc.Close();
            System.Diagnostics.Process.Start("cpu.pdf");
            Console.Write("ИНФОРМАЦИЯ О ПРОЦЕССОРЕ СОХРАНЕНА НА ФАЙЛЕ cpu.pdf \n");
            //Console.ReadKey(true);

        }
    }
}
