
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace GuessThatAsciiMon.Services
{
    public interface IAsciiService
    {
        Task<string> ConvertImageToAsciiAsync(byte[] imageData);
        string ProcessImageToAscii(Image<Rgba32> image);
    }
}