using System.IO;

namespace CSharpConsole.Samples.Static
{

    class StaticClassTest
    {
        public void Test()
        {
            var filePath = "C:\\File.doc";

            var canBeAppended = FileUtils.CanFileBeAppended(filePath);
            var isText = FileUtils.IsTextFile(filePath);

            //var util = new FileUtils();
        }
    }
    //e.g. class File or Directory
    static class FileUtils
    {
        public static bool IsTextFile(string filePath)
        {
            var extension = Path.GetExtension(filePath);

            return extension == ".doc" || extension == ".docx"
                || extension == ".txt" || extension == ".log";
        }

        public static bool IsExcelFile(string filePath)
        {
            var extension = Path.GetExtension(filePath);

            return extension == ".xls" || extension == ".xlsx";
        }

        public static bool CanFileBeAppended(string filePath)
        {
            var file = new FileInfo(filePath);

            return file.Exists && !file.IsReadOnly;
        }
    }
}
