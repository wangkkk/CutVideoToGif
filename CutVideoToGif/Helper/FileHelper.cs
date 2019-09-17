using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CutVideoToGif.Helper
{
    public static class FileHelper
    {
        /// <summary>
        /// 得到文件夹下的所有特定文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static List<string> GetAllFile(string path, string filter)
        {
            List<string> fileNameList = new List<string>();
            //C#遍历指定文件夹中的所有文件 
            DirectoryInfo TheFolder = new DirectoryInfo(path);
            if (!TheFolder.Exists)
                return fileNameList;

            //遍历文件
            foreach (FileInfo NextFile in TheFolder.GetFiles())
            {
                // 获取文件完整路径
                string filepath = NextFile.FullName;
                if (filepath.Contains(filter) || filepath.ToUpper().Contains(filter.ToUpper()))
                    fileNameList.Add(filepath);
            }

            return fileNameList;
        }
        
    }
}
