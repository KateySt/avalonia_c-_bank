using System;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Avalonia.Data.Converters;
using Avalonia.Media.Imaging;

namespace bank.Helpers;

public class ImageHelper : IValueConverter
{
    public static readonly ImageHelper Instance = new();

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value == null || !(value is string imageUrl))
            return null;

        try
        {
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("AvaloniaTest", "0.1"));
            var data = httpClient.GetByteArrayAsync(imageUrl).Result;
            return new Bitmap(new MemoryStream(data));
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"An error occurred while downloading image '{imageUrl}' : {ex.Message}");
            return null;
        }
    }
    
    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}
