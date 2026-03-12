namespace TodoApi.Services;

public interface IFileUpload
{
    public string UploadStudentFile(byte[] file, string imageName);
}
