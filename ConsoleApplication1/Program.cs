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
using System.Threading;

namespace ConsoleApplication1
{
    class Program 
    {
        static void softWAARE()
        {
            Software soft = new Software();
            soft.Applicationss(); 
        }

        static void Main(string[] args)
        {
            ThreadStart softstart = new ThreadStart(softWAARE);
            Thread thread = new Thread(softstart);
            thread.Start();  

            /*ThreadStart softstart = new ThreadStart(softWAARE);
            Thread thread = new Thread(softstart);
            thread.Start();*/

            ALLINFO allInformation = new ALLINFO();
              allInformation.all();




           // Console.Read();










            // Работает
            /*Process procces = new Process();
            procces.ProcessPDF();*/


            /* Не работает
             * Software soft = new Software();
             soft.Application();*/

            //Рабоатет
            /*Services services = new Services();
            services.Servic();*/

            //Работает
            /*OS oper_sys = new OS();
            oper_sys.Operation_system();*/

            //Работает
            /*Local_disk local_hard = new Local_disk();
            local_hard.hard_drive();*/

            //Работает
            /* InterFace inFace = new InterFace();
             inFace.interFace();*/

            // Работает 
            /*Video videoInfo = new Video();
            videoInfo.video();*/

            // рАБОТАЕТ
            /*CPU cpuInfo = new CPU();
            cpuInfo.cpu();*/

            //Работает
            /*RAM ramInfo = new RAM();
            ramInfo.ram();*/

            //Работает
           /* HDD hddinfo = new HDD();
            hddinfo.hdd();*/
         }
            
    }
}

