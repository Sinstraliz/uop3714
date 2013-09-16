using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace PlovdivTournament.Web.Manage.Library.Utility
{
    public class ImageUtility
    {
        public static byte[] ByteArrayDelegator(Func<Image, int?, int?, int?, int?, Image> func, byte[] imageData, int? width, int? height, int? maximumWidth, int? maximumHeight)
        {
            Image image = ToImage(imageData);
            Image resized = func(image, width, height, maximumWidth, maximumHeight);
            var result = ToByteArray(resized);

            image.Dispose(); image = null;
            resized.Dispose(); resized = null;

            return result;
        }

        public static byte[] ByteArrayDelegator(Func<Image, int, int, Image> func, byte[] imageData, int width, int height)
        {
            Image image = ToImage(imageData);
            Image resized = func(image, width, height);
            var result = ToByteArray(resized);

            image.Dispose(); image = null;
            resized.Dispose(); resized = null;

            return result;
        }

        public static byte[] Crop(byte[] imageData, int width, int height)
        {
            return ByteArrayDelegator(Crop, imageData, width, height);
        }

        /// <summary>
        /// Crops the image with centered crop rectangle
        /// </summary>
        public static Image Crop(Image originalImage, int width, int height)
        {
            Image croppedImage;

            int sourceWidth = originalImage.Width;
            int sourceHeight = originalImage.Height;

            int destX = 0;
            int destY = 0;

            //  Cannot perform crop operation when the thumb is bigger than the source.
            if (sourceWidth <= width && sourceHeight <= height)
            {
                croppedImage = originalImage;
                return originalImage;
            }

            if (sourceWidth <= width && sourceHeight >= height)
            {
                destX = 0;
                destY = (sourceHeight - height) / 2;
                width = sourceWidth;
            }

            if (sourceWidth >= width && sourceHeight <= height)
            {
                destX = (sourceWidth - width) / 2;
                destY = 0;
                height = sourceHeight;
            }

            return Crop(originalImage, destX, destY, width, height);
        }

        /// <summary>
        /// Crops the image with specific crop rectangle.
        /// </summary>
        public static Image Crop(Image originalImage, int destX, int destY, int width, int height)
        {
            int sourceWidth = originalImage.Width;
            int sourceHeight = originalImage.Height;

            //  If the crop rectangle is out of the original image boudaries then return the original image.
            if (destX + width > sourceWidth || destY + height > sourceHeight)
                return originalImage;

            try
            {
                RectangleF cropRect = new RectangleF(destX, destY, width, height);
                var croppedImage = ((Bitmap)originalImage).Clone(cropRect, PixelFormat.Format32bppArgb);
                return croppedImage;
            }
            catch (OutOfMemoryException)
            {
                //  You are here because the check bellow is not correct
                //if (destX + width > sourceWidth || destY + height > sourceHeight)
                //    return originalImage;

                //  This exception occures when the user uploads an image with strange demensions
                //  and then the crop function fails. This is good.
                return originalImage;
            }
        }

        public static Image Resize(Image originalImage, int width, int height, bool onlyResizeIfWider, bool resizeByHeight)
        {
            // Prevent using images internal thumbnail
            originalImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
            originalImage.RotateFlip(RotateFlipType.Rotate180FlipNone);

            if (onlyResizeIfWider && originalImage.Width <= width)
                width = originalImage.Width;

            int newHeight = originalImage.Height * width / originalImage.Width;
            if (resizeByHeight)
            {
                // Resize with height instead
                width = originalImage.Width * height / originalImage.Height;
                newHeight = height;
            }

            Image newImage = originalImage.GetThumbnailImage(width, newHeight, null, IntPtr.Zero);

            return newImage;
        }

        public static byte[] SmartDecrease(byte[] imageData, int? width, int? height, int? maximumWidth, int? maximumHeight)
        {
            return ByteArrayDelegator(SmartDecrease, imageData, width, height, maximumWidth, maximumHeight);
        }

        public static Image SmartDecrease(Image originalImage, int? width, int? height, int? maximumWidth, int? maximumHeight)
        {
            bool resizeByHeight = !width.HasValue;
            bool resizeByWidth = !height.HasValue;
            int canvasWidth = maximumWidth ?? width ?? 0;
            int canvasHeight = maximumHeight ?? height ?? 0;

            if (!resizeByHeight && !resizeByWidth)
            {
                resizeByHeight = originalImage.Width > originalImage.Height;
                resizeByWidth = originalImage.Width < originalImage.Height;
                canvasWidth = width.Value;
                canvasHeight = height.Value;
            }

            int resizeToWidth = width ?? maximumWidth ?? 0;
            int resizeToHeght = height ?? maximumHeight ?? 0;

            Image thumbImage;
            Image canvas = CreateEmptyCanvas(canvasWidth, canvasHeight);

            using (Bitmap bmp = new Bitmap(originalImage))
            {
                //if (ShouldResize(canvas, bmp))
                //{
                //    thumbImage = Resize(bmp, resizeToWidth, resizeToHeght, resizeByWidth, resizeByHeight);
                //}
                //else
                {
                    thumbImage = Resize(bmp, resizeToWidth, resizeToHeght, resizeByWidth, resizeByHeight);
                }

                thumbImage = Crop(thumbImage, resizeToWidth, resizeToHeght);
            }

            canvas = (Bitmap)Merge(
                canvas,
                thumbImage,
                centerVerically: false,
                centerHorizontally: false,
                keepFrameWidth: false,
                keepFrameHeight:
                false);

            return canvas;
        }

        public static Image SmartResize(Image originalImage, int? width, int? height, int? maximumWidth, int? maximumHeight)
        {
            int newWidth = width ?? maximumWidth ?? originalImage.Width;
            int newHeight = height ?? maximumHeight ?? originalImage.Height;

            bool resizeByHeight = !width.HasValue;
            bool resizeByWidth = !height.HasValue;
            if (!resizeByHeight && !resizeByWidth)
            {
                resizeByHeight = originalImage.Width > originalImage.Height;
                resizeByWidth = originalImage.Width < originalImage.Height;
            }

            if (CanEnlarge(originalImage, newWidth, newHeight))
            {
                var thumbImage = Resize(originalImage, newWidth, newHeight, resizeByWidth, resizeByHeight);
                return thumbImage = Crop(thumbImage, newWidth, newHeight);
            }
            else
                return SmartDecrease(originalImage, width, height, maximumWidth, maximumHeight);
        }

        public static byte[] SmartResize(byte[] imageData, int? width, int? height, int? maximumWidth, int? maximumHeight)
        {
            return ByteArrayDelegator(SmartResize, imageData, width, height, maximumWidth, maximumHeight);
        }

        private static bool ShouldResize(Image frame, Image img, double areaRequiredInPercentage = 100)
        {
            if (areaRequiredInPercentage < 0 || areaRequiredInPercentage > 100)
                throw new ArgumentOutOfRangeException(string.Format("Invalid percent value: {0}. Min=0;Max=100;", areaRequiredInPercentage));

            double ratio = img.Width > img.Height ?
                (1.0d / ((double)img.Width / frame.Width)) :
                (1.0d / ((double)img.Height / frame.Height));

            double allowedResizeArea = frame.Width * frame.Height * areaRequiredInPercentage / 100;
            double imageAreaAfterResize = img.Width * img.Height * ratio * ratio;

            return allowedResizeArea <= imageAreaAfterResize;
        }

        private static bool CanEnlarge(Image originalImage, int width, int height)
        {
            return width > originalImage.Width || height > originalImage.Height;
        }

        private static Bitmap CreateEmptyCanvas(int width, int height)
        {
            return new Bitmap(width, height);
        }

        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        private static Image Merge(Image frame, Image childImage, bool centerHorizontally = true, bool centerVerically = true, bool keepFrameWidth = true, bool keepFrameHeight = true)
        {
            Image merged = (Image)frame.Clone();
            int baseX = centerHorizontally ? (merged.Width - childImage.Width) / 2 : 0;
            int baseY = centerVerically ? (merged.Height - childImage.Height) / 2 : 0;

            if (!keepFrameWidth || keepFrameHeight)
            {
                int frameWidth = keepFrameWidth ? merged.Width : childImage.Width;
                int frameHight = keepFrameHeight ? merged.Height : childImage.Height;

                merged = CreateEmptyCanvas(frameWidth, frameHight);
            }

            using (Graphics grfx = Graphics.FromImage(merged))
            {
                RectangleF srcRect = new RectangleF(0, 0, childImage.Width, childImage.Height);
                RectangleF destRect = new RectangleF(baseX, baseY, childImage.Width, childImage.Height);
                grfx.InterpolationMode = InterpolationMode.HighQualityBilinear;
                grfx.SmoothingMode = SmoothingMode.HighQuality;
                grfx.DrawImage(childImage, destRect, srcRect, GraphicsUnit.Pixel);
            }

            return merged;
        }

        public static byte[] ToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        public static Image ToImage(byte[] content)
        {
            Image image = null;

            if (content == null) return null;

            using (MemoryStream stream = new MemoryStream(content))
            {
                image = Image.FromStream(stream);
            }

            return image;
        }
    }
}