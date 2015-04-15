using System;
using System.Collections.Generic;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

namespace WebSite.Lib
{
    public class MuFileCompress
    {
        /// <summary>
        /// 所有文件缓存
        /// </summary>
        static List<string[]> files;
        static string root = "";
        /// <summary>
        /// 所有空目录缓存
        /// </summary>
        static List<string[]> paths;

        /// <summary>
        ///  将多个文件或文件夹打包
        /// </summary>
        /// <param name="filesOrDirectoriesPaths">被打包文件的路径</param>
        /// <param name="strZipPath">打包后存放的路径</param>
        /// <param name="intZipLevel">打包压缩级别0-9(0为不压缩)</param>
        /// <param name="strPassword">打包密码</param>
        /// <param name="error">打包过程中的错误信息</param>
        /// <returns>是否打包成功</returns>
        public static bool Pack(string[] filesOrDirectoriesPaths, string strZipPath, int intZipLevel, string strPassword, out string error)
        {
            files = new List<string[]>();
            paths = new List<string[]>();
            root = "";
            if (filesOrDirectoriesPaths.Length > 0) // get all files path
            {
                foreach (string filename in filesOrDirectoriesPaths)
                {
                    if (File.Exists(filename))
                    {
                        files.Add(new string[] { filename, filename.Substring(0, filename.LastIndexOf("\\") + 1) });
                    }
                    else if (Directory.Exists(filename))
                    {
                        root = filename.Substring(0, filename.LastIndexOf("\\") + 1);
                        GetAllDirectories(filename);
                    }
                    else
                    {
                        error = "请检查文件路径，某些文件不存在！！！";
                        return false;
                    }
                }
            }
            ZipOutputStream zipOutputStream = new ZipOutputStream(File.Create(strZipPath));
            zipOutputStream.SetLevel(intZipLevel);
            zipOutputStream.Password = strPassword;
            foreach (string[] strFile in files)
            {
                try
                {
                    FileStream fs = File.OpenRead(strFile[0]);
                    byte[] buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);
                    string strFileName = strFile[0].Replace(strFile[1], String.Empty);

                    ZipEntry entry = new ZipEntry(strFileName);
                    entry.IsUnicodeText = true; 
                    entry.DateTime = DateTime.Now;
                    zipOutputStream.PutNextEntry(entry);
                    zipOutputStream.Write(buffer, 0, buffer.Length);
                    fs.Close();
                    fs.Dispose();
                }
                catch
                {
                    error = "文件读取错误！";
                    return false;
                }
            }
            files.Clear();
            foreach (string[] emptyPath in paths)
            {
                ZipEntry entry = new ZipEntry(emptyPath[0].Replace(emptyPath[1], string.Empty) + "/");
                entry.IsUnicodeText = true; 
                zipOutputStream.PutNextEntry(entry);
            }
            paths.Clear();
            zipOutputStream.Finish();
            zipOutputStream.Close();
            error = "";
            return true;
        }

        ///<summary>
        ///实现解包操作
        ///</summary>
        ///<param name="zipfilename">要解包文件(物理路径)</param>
        ///<param name="UnZipDir">解包目的路径(物理路径)</param>
        ///<param name="password">解包密码</param>
        /// <param name="error">异常信息</param>
        ///<returns>是否解包成功</returns>
        public static bool Unpack(string zipfilename, string UnZipDir, string password, out string error)
        {
            //判断待解包文件路径
            if (!File.Exists(zipfilename))
            {
                File.Delete(UnZipDir);
                error = "待解包文件路径不存在!";
                return false;
            }
            //创建ZipInputStream
            ZipInputStream newinStream = new ZipInputStream(File.OpenRead(zipfilename));
            //判断Password
            if (password != null && password.Length > 0)
            {
                newinStream.Password = password;
            }
            //执行解包操作
            try
            {
                ZipEntry theEntry;
                //获取Zip中单个File
                while ((theEntry = newinStream.GetNextEntry()) != null)
                {
                    //判断目的路径
                    if (Directory.Exists(UnZipDir))
                    {
                        Directory.CreateDirectory(UnZipDir);//创建目的目录
                    }
                    //获得目的目录信息
                    string Driectoryname = UnZipDir;
                    string pathname = Path.GetDirectoryName(theEntry.Name);//获得子级目录
                    string filename = Path.GetFileName(theEntry.Name);//获得子集文件名
                    Driectoryname = Driectoryname + "\\" + pathname;
                    //创建
                    Directory.CreateDirectory(Driectoryname);
                    //解包指定子目录
                    if (filename != string.Empty)
                    {
                        FileStream newstream = File.Create(Driectoryname + "\\" + filename);// pathname);
                        int size = 2048;
                        byte[] newbyte = new byte[size];
                        while (true)
                        {
                            size = newinStream.Read(newbyte, 0, newbyte.Length);
                            if (size > 0)
                            {
                                //写入数据
                                newstream.Write(newbyte, 0, size);
                            }
                            else
                            {
                                break;
                            }
                        }
                        newstream.Close();

                    }
                }
                newinStream.Close();
            }
            catch (Exception se)
            {
                error = se.Message.ToString();
                return false;
            }
            finally
            {
                newinStream.Close();
            }
            error = "";
            return true;
        }
        /// <summary>
        /// 取得目录下所有文件及文件夹，分别存入files及paths
        /// </summary>
        /// <param name="rootPath">根目录</param>
        private static void GetAllDirectories(string rootPath)
        {
            string[] subPaths = Directory.GetDirectories(rootPath);//得到所有子目录
            foreach (string path in subPaths)
            {
                GetAllDirectories(path);//对每一个字目录做与根目录相同的操作：即找到子目录并将当前目录的文件名存入List
            }
            string[] filess = Directory.GetFiles(rootPath);
            foreach (string file in filess)
            {
                files.Add(new string[] { file, root });//将当前目录中的所有文件全名存入文件List               
            }
            if (subPaths.Length == filess.Length && filess.Length == 0)//如果是空目录
            {
                //记录空目录
                paths.Add(new string[] { rootPath, root });
            }
        }
    }
}
//使用方法：
// string[] paths = new string[] { "D:\\testFolder\\folder2", "D:\\testFolder\\c#压缩解压.doc", "D:\\wode.doc" };
//            string error = "";
//          //打包
//            MyPackage.Pack(paths, "c:\\hi0.zip", 6, "123", out error);
//            //解包
//            MyPackage.Unpack("c:\\hi0.zip","c:\\hi","123",out error);