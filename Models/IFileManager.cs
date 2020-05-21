namespace MiniTC.Models
{
    interface IFileManager
    {
        bool Copy(string source, string fileName, string destination);
    }
}
