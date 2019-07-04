﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace PetResort.UI.Services
{
    public class ImageService
    {
        public static void ResizeImage(string savePath, string fileName, Image image, int maxImgSize, int maxThumbSize)
        {
            int[] newImageSizes = GetNewSize(image.Width, image.Height, maxImgSize);

            Bitmap newImage = DoResizeImage(newImageSizes[0], newImageSizes[1], image);

            newImage.Save(savePath + fileName);

            int[] newThumbSizes = GetNewSize(newImage.Width, newImage.Height, maxThumbSize);

            Bitmap newThumb = DoResizeImage(newThumbSizes[0], newThumbSizes[1], image);

            newThumb.Save(savePath + "t_" + fileName);

            newImage.Dispose();
            newThumb.Dispose();
            image.Dispose();
        }

        public static int[] GetNewSize(int imgWidth, int imgHeight, int maxImgSize)
        {
            float ratioX = maxImgSize / (float) imgWidth;
            float ratioY = maxImgSize / (float) imgHeight;
            float ratio = Math.Min(ratioX, ratioY);

            int[] newImgSizes = new int[2];
            newImgSizes[0] = (int) (imgWidth * ratio);
            newImgSizes[1] = (int) (imgHeight * ratio);

            return newImgSizes;
        }

        private static Bitmap DoResizeImage(int imgWidth, int imgHeight, Image image)
        {
            Bitmap newImage = new Bitmap(imgWidth, imgHeight, PixelFormat.Format24bppRgb);

            newImage.MakeTransparent();

            newImage.SetResolution(72, 72);

            using (Graphics graphics = Graphics.FromImage(newImage))
            {
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.DrawImage(image, 0, 0, imgWidth, imgHeight);
            }
            return newImage;
        }

        public static void Delete(string path, string imgName)
        {
            FileInfo fullImg = new FileInfo(path + imgName);
            FileInfo thumbImg = new FileInfo(path + "t_" + imgName);

            if (fullImg.Exists)
            {
                fullImg.Delete();
            }

            if (thumbImg.Exists)
            {
                thumbImg.Delete();
            }
        }
    }
}