using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TOUCH
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            string tabName = "TOUCH";

            application.CreateRibbonTab(tabName);
            //string utilsFolderPath = @"\\nut\home\s.hramcov\Desktop\RevitAPITraining";

            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;

            var panel1 = application.CreateRibbonPanel(tabName, "Объем");
            var panel2 = application.CreateRibbonPanel(tabName, "Площадь");
            var panel3 = application.CreateRibbonPanel(tabName, "TOUCH");

            var button1 = new PushButtonData("Объем", "Получение объема стен",
                Path.Combine(thisAssemblyPath, "WallVolume.dll"),
                "WallVolume.Main");            

            Uri uriImage1 = new Uri(@"C:\Users\s.hramcov\source\repos\RevitAPI\RevitAPI\Images\Volume.jpg", UriKind.Absolute);
            BitmapImage largeImage1 = new BitmapImage(uriImage1);
            button1.LargeImage = largeImage1;

            panel1.AddItem(button1);

            var button2 = new PushButtonData("Площадь", "Получение площади стен",
               Path.Combine(thisAssemblyPath, "WallArea.dll"),
               "WallArea.Main");

            Uri uriImage2 = new Uri(@"C:\Users\s.hramcov\source\repos\RevitAPI\RevitAPI\Images\Area.jpg", UriKind.Absolute);
            BitmapImage largeImage2 = new BitmapImage(uriImage2);
            button2.LargeImage = largeImage2;

            panel2.AddItem(button2);

            var button3 = new PushButtonData("TOUCH", "Справка",
                Path.Combine(thisAssemblyPath, "TOUCHhelp.dll"),
                "TOUCHhelp.Main");

            Uri uriImage3 = new Uri(@"C:\Users\s.hramcov\source\repos\RevitAPI\RevitAPI\Images\TOUCH.jpg", UriKind.Absolute);
            BitmapImage largeImage3 = new BitmapImage(uriImage3);
            button3.LargeImage = largeImage3;

            panel3.AddItem(button3);


            //ImageSource dictionaryIcon = GetIconSource(ApartmentParameters.Properties.Resources.DictionaryIco);
            //dictionaryButton.LargeImage = dictionaryIcon;

            //public static System.Windows.Media.ImageSource GetIconSource(System.Drawing.Bitmap bmp)
            //{
            //    BitmapSource icon = Imaging.CreateBitmapSourceFromHBitmap(bmp.GetHbitmap(), IntPtr.Zero, System.Windows.Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            //    return icon;
            //}

            return Result.Succeeded;
        }
    }
}
