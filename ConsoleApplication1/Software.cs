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
    class Software
    {
        public void Applicationss()
        {
            //создание пдф-файла
            var Doc = new Document();
            iTextSharp.text.pdf.PdfWriter.GetInstance(Doc,
                new System.IO.FileStream("Software.pdf", System.IO.FileMode.Create));
            Doc.Open();
            BaseFont BF = BaseFont.CreateFont(@"C:\Windows\Fonts\comic.ttf"
               , "CP1251", BaseFont.EMBEDDED);
            var font = new iTextSharp.text.Font(BF, 12, iTextSharp.text.Font.NORMAL);
            Doc.Add(new Paragraph("Установленное программное обеспечение на устройстве: " + "\n", font));

            //ПО 
            string qwe = " ";
            ManagementObjectSearcher searcher_soft =
       new ManagementObjectSearcher("root\\CIMV2",
       "SELECT * FROM Win32_Product");

            foreach (ManagementObject queryObj in searcher_soft.Get())
            {
                /* Console.WriteLine("<soft> Caption: {0} ; InstallDate: {1}</soft>",
                                   queryObj["Caption"], queryObj["InstallDate"]);
                qwe = queryObj.ToString();
                Console.WriteLine(qwe);*/

                Doc.Add(new Paragraph("Caption:" + queryObj["Caption"], font));
                Doc.Add(new Paragraph("InstallDate: " + queryObj["InstallDate"], font));
            }

            Doc.Close();
            System.Diagnostics.Process.Start("software.pdf");

            Console.Write("ПОЛНЫЙ СПИСОК УСТАНОВЛЕННОГО ПРОГРАММНОГО ОБЕСПЕЧЕНИЯ СОХРАНЕН НА ФАЙЛ software.pdf");
            //Console.ReadKey(true);
        }
    }
}
