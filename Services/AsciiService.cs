using System.Text;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace GuessThatAsciiMon.Services
{
    public class AsciiService : IAsciiService
    {
        private readonly string _asciiRamp = " `.-':_,^=;><+!rc*/z?sLTv)J7(|Fi{C}fI31tlu[neoZ5Yxjya]2ESwqkP6h9d4VpOGbUAKXHm8RD#$Bg0MNWQ%&@";

        public async Task<string> ConvertImageToAsciiAsync(byte[] imageData)
        {
            return await Task.Run(() =>
            {
                using Image<Rgba32> image = Image.Load<Rgba32>(imageData);
                return ProcessImageToAscii(image);
            });
        }

        public string ProcessImageToAscii(Image<Rgba32> image)
        {
            // Resize the image for console display
            // Terminal characters are ~2:1 ratio (height:width), so compensate
            int newWidth = 80;
            int newHeight = (image.Height * newWidth / image.Width) / 2; // Divide by 2 for aspect ratio correction
            image.Mutate(x => x.Resize(newWidth, newHeight));

            // Find the bounding box of the content (auto-crop)
            int minY = -1, maxY = -1;
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    if (image[x, y].A > 0) // Check for non-transparent pixel
                    {
                        if (minY == -1) minY = y;
                        maxY = y;
                        break; // Move to next row
                    }
                }
            }

            // Generate ASCII for the cropped area
            var asciiArt = new StringBuilder();
            for (int y = minY; y <= maxY; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Rgba32 pixel = image[x, y];
                    if (pixel.A == 0)
                    {
                        asciiArt.Append(' '); // Transparent pixel
                        continue;
                    }
                    int brightness = (pixel.R + pixel.G + pixel.B) / 3;
                    int rampIndex = brightness * (_asciiRamp.Length - 1) / 255;
                    asciiArt.Append(_asciiRamp[rampIndex]);
                }
                asciiArt.AppendLine();
            }

            return asciiArt.ToString();
        }
    }
}