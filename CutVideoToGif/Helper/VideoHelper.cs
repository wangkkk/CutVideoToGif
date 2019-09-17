using MediaToolkit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace CutVideoToGif.Helper
{
    public static class VideoHelper
    {
        /// <summary>
        /// 视频缩小 0 源视频路径 1目标视频路径
        /// </summary>
        public static string narrow = " -i  {0}  -s  300x642  {1}";
        /// <summary>
        /// 转换为gif 0 长度 1 开始转换的时间点 2 源文件 3 目标gif名称
        /// 示例：ffmpeg -t 2.3 -ss 00:00:02 -i output_file.mp4 -b 2048k small-clip.gif
        /// </summary>
        public static string convertToGif = " -t {0} -ss {1} -i {2} -b 2048k {3}";
        public static bool GenerateGif(string pathText, string filter, string Minute)
        {
            //得到所有的文件
            List<string> allFile = FileHelper.GetAllFile(pathText, filter);
            string ffmpegPath = $"{Environment.CurrentDirectory}\\ffmpeg\\ffmpeg.exe";
            foreach (var item in allFile)
            {
                //得到视频信息
                string newName = item.Replace(".mp4", "") + "_" + System.DateTime.Now.ToString("HHmmss") + ".mp4";
                string nCommand = string.Format(narrow, item, newName);
                string gifFolder = Path.Combine(pathText, "gif\\");
                if (!Directory.Exists(gifFolder)) Directory.CreateDirectory(gifFolder);
                string Minutes = Minute;
                double videoLength = GetVideoInfo(item);
                //得到名字
                string name = item.Substring(item.LastIndexOf('\\')).Replace(".mp4", "");
                //得到的名字作为gif文件夹名字
                string gifTwiceFolder = gifFolder + name + "\\";
                if (!Directory.Exists(gifTwiceFolder)) Directory.CreateDirectory(gifTwiceFolder);
                //得到gif的名字
                string gifName = gifTwiceFolder + name + "_";
                try
                {


                    string result = ExecuteHelper.Execute(ffmpegPath, nCommand);
                    int j = 0;
                    //转换为gif
                    for (int i = 0; i < videoLength;)
                    {
                        string cCommand = string.Empty;
                        //确定切割的起点
                        double currentLength = Double.Parse(Minutes) * j + Double.Parse(Minutes);
                        cCommand = string.Format(convertToGif, currentLength > videoLength ? (videoLength - Double.Parse(Minutes) * j).ToString() : Minutes, $"00:00:{Double.Parse(Minutes) * j}", newName, gifName);
                        //执行命令
                        ExecuteHelper.Execute(ffmpegPath,$"{cCommand}_{i}.gif");
                        j++;
                        i = Convert.ToInt32(j * Double.Parse(Minutes));
                    }           
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }

            }

            MessageBox.Show("成功");
            return true;
        }

       

        // a method to get Width, Height, and Duration in Ticks for video.
        public static double GetVideoInfo(string fileName)
        {
            var inputFile = new MediaToolkit.Model.MediaFile { Filename = fileName };
            using (var engine = new Engine())
            {
                engine.GetMetadata(inputFile);
            }

            // FrameSize is returned as '1280x768' string.
            //var size = inputFile.Metadata.VideoData.FrameSize.Split(new[] { 'x' }).Select(o => int.Parse(o)).ToArray();

            return inputFile.Metadata.Duration.TotalSeconds;
        }
    }
}
