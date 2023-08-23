using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AddServices
{
    public class UploadExtensions
    { 
        /*
   public static async Task<List<Upload>> UploadFiles(this AppDbContext db, IFormFileCollection files, string path, string url, int userId)
    {
        var uploads = new List<Upload>();

        foreach (var file in files)
        {
            uploads.Add(await db.AddUpload(file, path, url, userId));
        }

        return uploads;
    }

    static async Task<Upload> AddUpload(this AppDbContext db, IFormFile file, string path, string url, int userId)
    {
        var upload = await file.WriteFile(path, url);
        upload.UserId = userId;
        upload.UploadDate = DateTime.Now;
        await db.Uploads.AddAsync(upload);
        await db.SaveChangesAsync();
        return upload;
    }

    static async Task<Upload> WriteFile(this IFormFile file, string path, string url)
    {
        if (!(Directory.Exists(path)))
        {
            Directory.CreateDirectory(path);
        }

        var upload = await file.CreateUpload(path, url);

        using (var stream = new FileStream(upload.Path, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return upload;
    }

    static Task<Upload> CreateUpload(this IFormFile file, string path, string url) => Task.Run(() =>
    {
        var name = file.CreateSafeName(path);

        var upload = new Upload
        {
            File = name,
            Name = file.Name,
            Path = $"{path}{name}",
            Url = $"{url}{name}"
        };

        return upload;
    });

    static string CreateSafeName(this IFormFile file, string path)
    {
        var increment = 0;
        var fileName = file.FileName.UrlEncode();
        var newName = fileName;

        while (File.Exists(path + newName))
        {
            var extension = fileName.Split('.').Last();
            newName = $"{fileName.Replace($".{extension}", "")}_{++increment}.{extension}";
        }

        return newName;
    }

    private static readonly string urlPattern = "[^a-zA-Z0-9-.]";

    static string UrlEncode(this string url)
    {
        var friendlyUrl = Regex.Replace(url, @"\s", "-").ToLower();
        friendlyUrl = Regex.Replace(friendlyUrl, urlPattern, string.Empty);
        return friendlyUrl;
    }
        */
}
    }