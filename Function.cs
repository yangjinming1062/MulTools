using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MulTools
{
    public static class Function
    {
        #region 文件夹操作
        /// <summary>
        /// 删除文件夹
        /// </summary>
        public static void DeleteDir(string path)
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                foreach (FileSystemInfo file in dirInfo.GetFileSystemInfos())
                {
                    if (file.Attributes == FileAttributes.Directory || string.IsNullOrEmpty(file.Extension))
                        DeleteDir(file.FullName);
                    else
                        File.Delete(file.FullName);
                }
                Directory.Delete(path);
            }
            catch { }
        }
        /// <summary>
        /// 复制文件夹
        /// </summary>
        public static void CopyDir(string path, string sou, string des)
        {
            if (!Directory.Exists(path.Replace(sou, des)))
                Directory.CreateDirectory(path.Replace(sou, des));

            DirectoryInfo dirInfo = new DirectoryInfo(path);
            foreach (FileSystemInfo file in dirInfo.GetFileSystemInfos())
            {
                try
                {
                    if (file.Attributes == FileAttributes.Directory || string.IsNullOrEmpty(file.Extension))
                        CopyDir(file.FullName, sou, des);
                    else
                        File.Copy(file.FullName, file.FullName.Replace(sou, des));
                }
                catch
                { continue; }
            }
        }
        /// <summary>
        /// 剪切文件夹
        /// </summary>
        public static void CutDir(string path, string sou, string des)
        {
            if (!Directory.Exists(path.Replace(sou, des)))
                Directory.CreateDirectory(path.Replace(sou, des));
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            foreach (FileSystemInfo file in dirInfo.GetFileSystemInfos())
            {
                try
                {
                    if (file.Attributes == FileAttributes.Directory || string.IsNullOrEmpty(file.Extension))
                        CutDir(file.FullName, sou, des);
                    else
                        File.Move(file.FullName, file.FullName.Replace(sou, des));
                }
                catch
                { continue; }
            }
            Directory.Delete(path);
        }
        #endregion
    }
}
