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
    class HDD
    {
        public void hdd()
        {
            //Создание ПДФ-ФАЙЛА
            var Doc = new Document();
            iTextSharp.text.pdf.PdfWriter.GetInstance(Doc,
                new System.IO.FileStream("HDD.pdf", System.IO.FileMode.Create));
            Doc.Open();
            BaseFont BF = BaseFont.CreateFont(@"C:\Windows\Fonts\comic.ttf"
               , "CP1251", BaseFont.EMBEDDED);
            var font = new iTextSharp.text.Font(BF, 12, iTextSharp.text.Font.NORMAL);
            Doc.Add(new Paragraph("Информация о всех жестких дисков системы: " + "\n", font));

            //Сбор информации
            ManagementObjectSearcher searcher13 =
            new ManagementObjectSearcher("root\\CIMV2",
            "SELECT * FROM Win32_DiskDrive");

            //Console.WriteLine("--------- Win32_DiskDrive instance ---------------");

            foreach (ManagementObject queryObj in searcher13.Get())
            {/*
                Console.WriteLine("DeviceID: {0}; InterfaceType: {1}; Manufacturer: {2}; Model: {3}; SerialNumber: {4}; Size: {5} Gb", queryObj["DeviceID"],
                queryObj["InterfaceType"],
                queryObj["Manufacturer"],
                queryObj["Model"],
                queryObj["SerialNumber"],
                Math.Round(System.Convert.ToDouble(queryObj["Size"]) / 1024 / 1024 / 1024, 2));
                Console.WriteLine("-----");*/
                Doc.Add(new Paragraph(" Win32_DiskDrive instance ", font));
                Doc.Add(new Paragraph("DeviceID: "+ queryObj["DeviceID"], font));
                Doc.Add(new Paragraph(" InterfaceType: "+ queryObj["InterfaceType"], font));
                Doc.Add(new Paragraph("Manufacturer: "+ queryObj["Manufacturer"], font));
                Doc.Add(new Paragraph("Model: "+ queryObj["Model"], font));
                Doc.Add(new Paragraph("SerialNumber: " + queryObj["SerialNumber"], font));
                Doc.Add(new Paragraph("Size: "+ Math.Round(System.Convert.ToDouble(queryObj["Size"]) / 1024 / 1024 / 1024, 2)+" GB "
                , font));
                Doc.Add(new Paragraph(" ", font));

            }

            Doc.Close();
            System.Diagnostics.Process.Start("hdd.pdf");
            Console.Write("ИНФОРМАЦИЯ О ЖЕСТКИХ ДИСКОВ СОХРАНЕНО В ФАЙЛЕ hdd.pdf \n");
            //Console.ReadKey(true);
        }
    }
}
