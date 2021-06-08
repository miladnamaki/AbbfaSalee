using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABBFA_UTility
{
    public class Convertt
    {
        public static byte[] GetPicbyte(PictureBox pictureBox)
        {
            byte[] Arrypic = null;
            using (MemoryStream Ms = new MemoryStream())
            {
                if (pictureBox != null)
                {
                    pictureBox.Image.Save(Ms, pictureBox.Image.RawFormat);
                    Arrypic = Ms.GetBuffer();
                }
            }
            return Arrypic;
        }
        public static DateTime miladtoshamsi(DateTime dateTime)
        {
            System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();
            string ps = p.GetYear(dateTime).ToString() + "/" + p.GetMonth(dateTime).ToString() + "/" + p.GetDayOfMonth(dateTime).ToString();
            DateTime date = Convert.ToDateTime(ps);
            return date;
        }
        public  static DateTime Shamsitomilad(string date)
        {
            System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();
            char[] spearator = { '/' };
            string[] listDate = date.Split(spearator);
            int Year = Convert.ToInt32(listDate[0]);
            int Month = Convert.ToInt32(listDate[1]);
            int Day = Convert.ToInt32(listDate[2]);
            DateTime dt = new DateTime(Year, Month, Day, p);

            DateTime milad = Convert.ToDateTime(dt.ToString("d"));
            return milad;

        }
    }      
     
}
