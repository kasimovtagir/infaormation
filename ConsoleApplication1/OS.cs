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
    class OS
    {
        public void Operation_system()
        {
            //создание пдф-файла 
            var Doc = new Document();
            iTextSharp.text.pdf.PdfWriter.GetInstance(Doc,
                new System.IO.FileStream("OS.pdf", System.IO.FileMode.Create));
            Doc.Open();
            BaseFont BF = BaseFont.CreateFont(@"C:\Windows\Fonts\comic.ttf"
               , "CP1251", BaseFont.EMBEDDED);
            var font = new iTextSharp.text.Font(BF, 12, iTextSharp.text.Font.NORMAL);
            var font1 = new iTextSharp.text.Font(BF, 11, iTextSharp.text.Font.BOLDITALIC);
            Doc.Add(new Paragraph("Операционная система : \n " + "\n", font));

             // Сбор информации
            ManagementObjectSearcher searcher5 =
        new ManagementObjectSearcher("root\\CIMV2",
            "SELECT * FROM Win32_OperatingSystem");

            foreach (ManagementObject queryObj in searcher5.Get())
            {/*
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Win32_OperatingSystem instance");
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("BuildNumber: {0}", queryObj["BuildNumber"]);
                Console.WriteLine("Caption: {0}", queryObj["Caption"]);
                Console.WriteLine("FreePhysicalMemory: {0}", queryObj["FreePhysicalMemory"]);
                Console.WriteLine("FreeVirtualMemory: {0}", queryObj["FreeVirtualMemory"]);
                Console.WriteLine("Name: {0}", queryObj["Name"]);
                Console.WriteLine("OSType: {0}", queryObj["OSType"]);
                Console.WriteLine("RegisteredUser: {0}", queryObj["RegisteredUser"]);
                Console.WriteLine("SerialNumber: {0}", queryObj["SerialNumber"]);
                Console.WriteLine("ServicePackMajorVersion: {0}", queryObj["ServicePackMajorVersion"]);
                Console.WriteLine("ServicePackMinorVersion: {0}", queryObj["ServicePackMinorVersion"]);
                Console.WriteLine("Status: {0}", queryObj["Status"]);
                Console.WriteLine("SystemDevice: {0}", queryObj["SystemDevice"]);
                Console.WriteLine("SystemDirectory: {0}", queryObj["SystemDirectory"]);
                Console.WriteLine("SystemDrive: {0}", queryObj["SystemDrive"]);
                Console.WriteLine("Version: {0}", queryObj["Version"]);
                Console.WriteLine("WindowsDirectory: {0}", queryObj["WindowsDirectory"]);
                */

                Doc.Add(new Paragraph("Win32_OperatingSystem instance", font));
                Doc.Add(new Paragraph("Build Number: "+ queryObj["BuildNumber"], font));
                Doc.Add(new Paragraph("Caption: "+ queryObj["Caption"], font));
                Doc.Add(new Paragraph("Free Physical Memory: "+ queryObj["FreePhysicalMemory"], font));
                Doc.Add(new Paragraph("Free Virtual Memory: "+ queryObj["FreeVirtualMemory"], font));
                Doc.Add(new Paragraph("Name: "+ queryObj["Name"], font));
                Doc.Add(new Paragraph("OS Type: "+ queryObj["OSType"], font));
                Doc.Add(new Paragraph("Registered User: "+ queryObj["RegisteredUser"], font));
                Doc.Add(new Paragraph("Serial Number: "+ queryObj["SerialNumber"], font));
                Doc.Add(new Paragraph("Service PackMajorVersion: "+ queryObj["ServicePackMajorVersion"], font));
                Doc.Add(new Paragraph("Service PackMinorVersion: "+ queryObj["ServicePackMinorVersion"], font));
                Doc.Add(new Paragraph("Status: "+ queryObj["Status"], font));
                Doc.Add(new Paragraph("System Device: "+ queryObj["SystemDevice"], font));
                Doc.Add(new Paragraph("System Directory: "+ queryObj["SystemDirectory"], font));
                Doc.Add(new Paragraph("System Drive: "+ queryObj["SystemDrive"], font));
                Doc.Add(new Paragraph("Version: "+ queryObj["Version"], font));
                Doc.Add(new Paragraph("Windows Directory: "+ queryObj["WindowsDirectory"], font));
                Doc.Add(new Paragraph("\n", font));
            }

            Doc.Close();
            System.Diagnostics.Process.Start("os.pdf");

            Console.Write("ИНФОРМАЦИЯ О ОПЕРАЦИОННОЙ СИСТЕМЕ И МНОГО ДРУГОЕ СОХРАНЕНО В ФАЙЛЕ os.pdf \n");
            //Console.ReadKey(true);
        }
    }
}
