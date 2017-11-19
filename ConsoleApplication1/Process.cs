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
    class Process
    {
        public void ProcessPDF()
        {
            //создание пдф-файла
            var Doc = new Document();
            iTextSharp.text.pdf.PdfWriter.GetInstance(Doc,
                new System.IO.FileStream("Procces.pdf", System.IO.FileMode.Create));
            Doc.Open();
            BaseFont BF = BaseFont.CreateFont(@"C:\Windows\Fonts\comic.ttf"
               , "CP1251", BaseFont.EMBEDDED);
            var font = new iTextSharp.text.Font(BF, 12, iTextSharp.text.Font.NORMAL);
            Doc.Add(new Paragraph("Процессы запушенные на устройстве: " + "\n", font));

            //Вывод информации
            string qwe = " ";
            ManagementObjectSearcher searcher =
            new ManagementObjectSearcher("root\\CIMV2",
            "Select Name, CommandLine From Win32_Process");
            
            foreach (ManagementObject instance in searcher.Get())
            {
                qwe = instance["Name"].ToString();
                //Console.WriteLine(qwe);
                Doc.Add(new Paragraph(qwe + "\n", font));
            }
            Doc.Close();
            System.Diagnostics.Process.Start("procces.pdf");

            Console.Write("СПИСОК ПРОЦЕССОВ СОХРАНЕН НА ФАЙЛ procces.pdf \n");
           // Console.ReadKey(true);
        }
    }
}
