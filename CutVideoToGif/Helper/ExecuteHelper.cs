using System;
using System.Diagnostics;

namespace CutVideoToGif.Helper
{
    public static class ExecuteHelper
    {
        /// <summary>
        /// 执行可执行文件
        /// </summary>
        /// <param name="exePath"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static string Execute(string exePath, string parameters)
        {
            string result = String.Empty;

            using (Process p = new Process())
            {
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.FileName = exePath;
                p.StartInfo.Arguments = parameters;
                p.Start();
                p.WaitForExit();

                result = p.StandardOutput.ReadToEnd();
            }

            return result;
        }
    }
}
