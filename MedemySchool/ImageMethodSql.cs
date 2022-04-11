using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedemySchool
{
    public class ImageMethodSql
    {
        public byte[] ConvertImageToByte(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();

            }
        }
        public Image ConvertByteToImage(byte[] data,Image ErrorImage)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(data))
                {
                    return Image.FromStream(ms);
                }
            }
            catch (Exception)
            {
                return ErrorImage;
            }
        }
    }
}
