using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZabbixAgentInstaller.Common
{
    public class FileHelper
    {
        public static void ReplaceFile(string sFileName, string sOrigionContent, string sNewLineContent)
        {
            try
            {
                StringBuilder sbNewSave = new StringBuilder();
                sFileName = sFileName.Replace("|", "_");
                string sFolder = Directory.GetParent(sFileName).ToString();
                if (!Directory.Exists(sFolder))
                {
                    Directory.CreateDirectory(sFolder);
                }

                if (!File.Exists(sFileName))
                {
                    throw new Exception("file not exist");
                }

                String fileContent = ReadContext(sFileName);
                WriteContext(fileContent.Replace(sOrigionContent, sNewLineContent), sFileName);

            }
            catch (Exception ex)
            {
                throw new Exception("Rename host name error");
            }

        }


        public static void ReplaceFileMuti(string sFileName, string[] sOrigionContent, string[] sNewLineContent)
        {
            try
            {
                if (sOrigionContent.Length != sNewLineContent.Length)
                    throw new Exception("replace content count cannot mathced");
                StringBuilder sbNewSave = new StringBuilder();
                sFileName = sFileName.Replace("|", "_");
                string sFolder = Directory.GetParent(sFileName).ToString();
                if (!Directory.Exists(sFolder))
                {
                    Directory.CreateDirectory(sFolder);
                }

                if (!File.Exists(sFileName))
                {
                    throw new Exception("file not exist");
                }

                String fileContent = ReadContext(sFileName);
                for (int i = 0; i < sOrigionContent.Length; i++)
                {
                    fileContent = fileContent.Replace(sOrigionContent[i], sNewLineContent[i]);
                }
                WriteContext(fileContent, sFileName);

            }
            catch (Exception ex)
            {
                throw new Exception("Rename host name error");
            }

        }

        public static void CopyDir(string srcPath, string aimPath)
        {

            try

            {

                // 检查目标目录是否以目录分割字符结束如果不是则添加

                if (aimPath[aimPath.Length - 1] != Path.DirectorySeparatorChar)

                {

                    aimPath += Path.DirectorySeparatorChar;

                }

                // 判断目标目录是否存在如果不存在则新建

                if (!Directory.Exists(aimPath))
                {

                    Directory.CreateDirectory(aimPath);

                }

                // 得到源目录的文件列表，该里面是包含文件以及目录路径的一个数组

                // 如果你指向copy目标文件下面的文件而不包含目录请使用下面的方法

                // string[] fileList = Directory.GetFiles（srcPath）；

                string[] fileList = Directory.GetFileSystemEntries(srcPath);

                // 遍历所有的文件和目录

                foreach (string file in fileList)

                {

                    // 先当作目录处理如果存在这个目录就递归Copy该目录下面的文件

                    if (Directory.Exists(file))

                    {

                        CopyDir(file, aimPath + Path.GetFileName(file));

                    }

                    // 否则直接Copy文件

                    else

                    {

                        File.Copy(file, aimPath + Path.GetFileName(file), true);

                    }

                }

            }

            catch (Exception e)
            {

                throw;

            }


        }


        public static void WriteContext(string Context, string path)
        {
            StreamWriter sw = new StreamWriter(path);
            sw.Write(Context);
            sw.Close();
            sw.Dispose();
        }

        private static string ReadContext(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string context = sr.ReadToEnd();
            fs.Close();
            sr.Close();
            sr.Dispose();
            fs.Dispose();
            return context;
        }

        public static String FindParentDirectory(String directory, String name)
        {
            if (!File.Exists((directory + name).FormatFolderName()))
            {
                DirectoryInfo di = new DirectoryInfo(directory);
                if (di.Parent.Exists)
                {
                    return FindParentDirectory(di.Parent.FullName, name);
                }
                else throw new FileNotFoundException(String.Format("Cannot find  file {0} in all parent directory", name));
            }
            return directory + name;
        }

        public static String FindInChildDirectory(String directory, String name)
        {
            if (!File.Exists((directory + name).FormatFolderName()))
            {
                DirectoryInfo di = new DirectoryInfo(directory);

                var files = di.GetFiles(name.GetFileName(), SearchOption.AllDirectories);
                return files.Count() > 0 ? files[0].FullName : String.Empty;
            }
            return directory + name;
        }
    }
}
