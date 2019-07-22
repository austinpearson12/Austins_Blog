using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;

namespace Austins_Blog.Utilities
{
    public static class ImageUploadValidator
    {
   
            public static bool isWebFriendlyImage(HttpPostedFileBase file)
            {
                if (file == null)
                    return false;

                try
                {
                    using (var img = Image.FromStream(file.InputStream))
                    {
                        return ImageFormat.Jpeg.Equals(img.RawFormat) ||
                               ImageFormat.Png.Equals(img.RawFormat) ||
                               ImageFormat.Gif.Equals(img.RawFormat);

                    }
                }
                catch
                {
                    return false;
                }
            }
    }
}