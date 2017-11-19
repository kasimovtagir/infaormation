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
    class Local_disk
    {
        public void hard_drive()
        {
            //Создание ПДФ-ФАЙЛА
            var Doc = new Document();
            iTextSharp.text.pdf.PdfWriter.GetInstance(Doc,
                new System.IO.FileStream("LOCALDISK.pdf", System.IO.FileMode.Create));
            Doc.Open();
            BaseFont BF = BaseFont.CreateFont(@"C:\Windows\Fonts\comic.ttf"
               , "CP1251", BaseFont.EMBEDDED);
            var font = new iTextSharp.text.Font(BF, 12, iTextSharp.text.Font.NORMAL);
            Doc.Add(new Paragraph("Информация о всех локальных дисков системы: " + "\n", font));

            //Сбор информации
            ManagementObjectSearcher searcher =
            new ManagementObjectSearcher("root\\CIMV2",
            "SELECT * FROM Win32_Volume");

            foreach (ManagementObject queryObj in searcher.Get())
            {
                /*
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Win32_Volume instance");
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Capacity: {0}", queryObj["Capacity"]);
                Console.WriteLine("Caption: {0}", queryObj["Caption"]);
                Console.WriteLine("DriveLetter: {0}", queryObj["DriveLetter"]);
                Console.WriteLine("DriveType: {0}", queryObj["DriveType"]);
                Console.WriteLine("FileSystem: {0}", queryObj["FileSystem"]);
                Console.WriteLine("FreeSpace: {0}", queryObj["FreeSpace"]);*/
                

                Doc.Add(new Paragraph("Win32_Volume instance", font));
                Doc.Add(new Paragraph("Capacity: "+ queryObj["Capacity"], font));
                Doc.Add(new Paragraph("Caption: "+ queryObj["Caption"], font));
                Doc.Add(new Paragraph("DriveLetter: "+ queryObj["DriveLetter"], font));
                Doc.Add(new Paragraph("DriveType: "+ queryObj["DriveType"], font));
                Doc.Add(new Paragraph("FileSystem: "+ queryObj["FileSystem"], font));
                Doc.Add(new Paragraph("FreeSpace: "+ queryObj["FreeSpace"], font));
                Doc.Add(new Paragraph("\n", font));


            }

            Doc.Close();
            System.Diagnostics.Process.Start("localdisk.pdf");

            Console.Write("ИНФОРМАЦИЯ О ЛОКАЛЬНЫХ ДИСКАХ И МНОГО ДРУГОЕ СОХРАНЕНО В ФАЙЛЕ localdisk.pdf \n");
            //Console.ReadKey(true);
        }
    }
}
