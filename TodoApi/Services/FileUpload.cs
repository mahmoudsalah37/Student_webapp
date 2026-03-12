namespace TodoApi.Services;

public class FileUpload : IFileUpload
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public FileUpload(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
    {
        this._webHostEnvironment = webHostEnvironment;
        this._httpContextAccessor = httpContextAccessor;
    }

    public string UploadStudentFile(byte[] file, string imageName)
    {
        if (file == null)
        {
            return string.Empty;
        }

        var folderpath = "studentpictures";
        var url = _httpContextAccessor.HttpContext.Request.Host.Value;
        var ext = Path.GetExtension(imageName);
        var fileName = $"{Guid.NewGuid()}{ext}";
        var path = Path.Combine(_webHostEnvironment.WebRootPath, folderpath, fileName);
        UploadImage(file, path);
        return $"{url}/{folderpath}/{fileName}";

    }

    private void UploadImage(byte[] fileBytes, string path)
    {
        FileInfo file = new FileInfo(path);
        file.Directory?.Create();
        var fileStream = file.Create();
        fileStream.Write(fileBytes, 0, fileBytes.Length);
        fileStream?.Close();
    }
}