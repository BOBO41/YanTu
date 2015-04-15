using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web.UI.WebControls;

namespace WebSite.Lib.Security
{
    /// <summary>
    /// 名称：IMG_UPLOAD
    /// 说明：对图片文件上传，缩略图，水印。
    /// 作者：承信-JXY
    /// 时间：2009年05月22日
    /// </summary>
    public sealed class IMG_UPLOAD
    {
        static JXY_UPLOAD_IMG upobject = new JXY_UPLOAD_IMG();
        public static string FileName = "";

        #region 对方法简化包装
        /// <summary>
        /// 说明：上传一张图片，不生成缩略图，不添加水印
        /// 使用方法：IMG_UPLOAD.Save_NoSmall_NoMark(this.FileUpload1, Server.MapPath("laojiatest/"));
        /// </summary>
        /// <param name="WebFileUpload">上传控件id</param>
        /// <param name="path">上传的路径：必须是已经存在的目录</param>
        /// <returns>错误的值</returns>
        public static int Save_NoSmall_NoMark(FileUpload WebFileUpload, string path)
        {
            upobject.Random_name = true;
            upobject.IsDraw = false;
            upobject.IsCreateImg = false;
            upobject.SavePath = path;
            upobject._File_Upload = WebFileUpload;
            upobject.Save_AS();
            FileName = upobject.New_ImageName;
            return upobject.Error;
        }

        /// <summary>
        /// 上传图片和缩略图片
        /// </summary>
        /// <param name="WebFileUpload">上传控件id</param>
        /// <param name="path">存放的路径</param>
        /// <param name="s_width">缩略图片的宽</param>
        /// <param name="s_height">缩略图片的高</param>
        /// <returns>状态值</returns>
        public static int Save_HasSmall(FileUpload WebFileUpload, string path, int s_width, int s_height)
        {
            upobject.Random_name = true;
            upobject.SavePath = path;
            upobject.IsDraw = false;
            upobject.IsCreateImg = true;
            upobject.sHeight = s_height;
            upobject.sWidth = s_width;
            upobject._File_Upload = WebFileUpload;
            upobject.Save_AS();
            FileName = upobject.New_ImageName;
            return upobject.Error;
        }

        /// <summary>
        /// 上传带有水印的图片
        /// </summary>
        /// <param name="WebFileUpload">上传空间的id</param>
        /// <param name="path">存储的路径</param>
        /// <param name="markstring">水印的字符串</param>
        /// <returns>处理的状态</returns>
        public static int Save_HasMark(FileUpload WebFileUpload, string path, string markstring)
        {
            upobject.Random_name = true;
            upobject.SavePath = path;
            upobject.IsDraw = true;
            upobject.IsCreateImg = false;
            upobject._File_Upload = WebFileUpload;
            upobject.AddText = markstring;
            upobject.DrawString_x = upobject.AddText.Length * 25;
            upobject.DrawString_y = 30;
            upobject.Save_AS();
            FileName = upobject.New_ImageName;
            return upobject.Error;
        }

        /// <summary>
        /// 生成的图片的缩略图片和水印
        /// </summary>
        /// <param name="WebFileUpload">上传的控件</param>
        /// <param name="path">文件存在路径</param>
        /// <param name="s_width">缩略图的宽</param>
        /// <param name="s_height">缩略图的高</param>
        /// <param name="markstring">水印字符串</param>
        /// <returns>上传处理状态</returns>
        public static int Save_HasSamll_HasMark(FileUpload WebFileUpload, string path, int s_width, int s_height, string markstring)
        {
            upobject.Random_name = true;
            upobject.SavePath = path;
            upobject.IsDraw = true;
            upobject.IsCreateImg = true;
            upobject._File_Upload = WebFileUpload;
            upobject.AddText = markstring;
            upobject.DrawString_x = upobject.AddText.Length * 25;
            upobject.DrawString_y = 30;
            upobject.sHeight = s_height;
            upobject.sWidth = s_width;
            upobject.Save_AS();
            FileName = upobject.New_ImageName;
            return upobject.Error;
        }
        #endregion
    }



    /// <summary>
    /// *****************************************
    /// JXY_UPLOAD_IMG 的摘要说明
    /// 功能说明：下面这个类实现了对图片文件的上传
    /// 功能说明：包含文件的水印添加
    /// 功能说明：包含文件的缩略图的生成
    /// 编辑人：承信网络-JXY 
    /// 编辑时间：2009年05月22日
    /// 说明：该类只针对图片文件使用 不针对其他文档
    /// *****************************************
    /// 
    /// ####################使用的方法###############################
    ///JXY_UPLOAD_IMG upobject = new JXY_UPLOAD_IMG();
    ///upobject.Random_name = true;
    ///upobject.SavePath = Server.MapPath("jxyimags/"); ;
    ///upobject.sHeight = 50;
    ///upobject.sWidth = 50;
    ///upobject.IsDraw = true;
    ///upobject.IsCreateImg = true;
    ///upobject.AddText = "xcxcxc";
    ///upobject.DrawString_x = upobject.AddText.Length*25;
    /// upobject.DrawString_y = 30;
    ///upobject._File_Upload = this.FileUpload1;
    ///upobject.Save_AS();
    ///#############################################################
    /// </summary>

    public class JXY_UPLOAD_IMG
    {
        #region 私有字段的定义
        private bool _Random_name = true;  //是否使用随机名称

        private bool _IsCreateImg = true;  //是否生成缩略图。

        private string _FileType = "jpg/gif/bmp/png"; //所支持的上传类型用"/"隔开

        private string _SavePath = string.Empty;    //保存文件的实际路径

        private int _sHeight = 120;   //设置生成缩略图的高度

        private int _sWidth = 120;    //设置生成缩略图的宽度

        private FileUpload File_Upload; //上传控件。

        private int _Error = 0;//返回上传状态。

        private string _New_FileName = string.Empty; //随机产生得新图片名称

        private string _New_FileName_S = string.Empty; //随机产生得新缩略图名称

        private string _New_FileName_L = string.Empty; //临时随机产生得新图片名称、为加水印前、如果加水印后该文件自动删除

        private string _New_ImageName = string.Empty; //上传服务器后的新图片名称

        private bool _IsDraw = false;//设置是否加水印

        private int _DrawString_x = 200;//绘制文本的Ｘ坐标（右下角）

        private int _DrawString_y = 30;//绘制文本的Ｙ坐标（右下角）

        private string _AddText = "设置水印内容";//设置水印内容

        private string _Font = "Verdana"; //设置水印字体

        private int _FontSize = 16; //设置水印字大小
        #endregion

        #region 判断图片文件是不是索引图片的方法
        /// <summary>
        /// 会产生graphics异常的PixelFormat
        /// 下面这段代码由jxy加入。
        /// 用于去除索引图片
        /// </summary>
        private static PixelFormat[] indexedPixelFormats = { 
            PixelFormat.Undefined, 
            PixelFormat.DontCare,
            PixelFormat.Format16bppArgb1555, 
            PixelFormat.Format1bppIndexed, 
            PixelFormat.Format4bppIndexed,
            PixelFormat.Format8bppIndexed
        };



        /// <summary>
        /// 判断图片的PixelFormat 是否在 引发异常的 PixelFormat 之中
        /// 有jxy添加
        /// </summary>
        /// <param name="imgPixelFormat">原图片的PixelFormat</param>
        /// <returns></returns>
        private static bool IsPixelFormatIndexed(PixelFormat imgPixelFormat)
        {
            foreach (PixelFormat pf in indexedPixelFormats)
            {
                if (pf.Equals(imgPixelFormat)) return true;
            }

            return false;
        }
        #endregion

        #region 属性的定义
        /// <summary>
        /// 是否使用随机名称，是为:TRUE;不使用则FLASE
        /// </summary>
        public bool Random_name
        {
            get { return _Random_name; }
            set { _Random_name = value; }
        }

        /// <summary>
        /// 获取随机产生得新图片名称
        /// </summary>
        public string New_FileName
        {
            get { return _New_FileName; }
        }

        /// <summary>
        /// 上传服务器后的新图片名称
        /// </summary>
        public string New_ImageName
        {
            get { return _New_ImageName; }
        }

        /// <summary>
        /// 随机产生得新缩略图名称
        /// </summary>
        public string New_FileName_S
        {
            get { return _New_FileName_S; }
        }

        /// <summary>
        /// //上传控件。
        /// </summary>
        public FileUpload _File_Upload
        {
            get { return File_Upload; }
            set { File_Upload = value; }
        }

        /// <summary>
        /// 是否生成缩略图
        /// </summary>
        public bool IsCreateImg
        {
            get { return _IsCreateImg; }
            set { _IsCreateImg = value; }
        }

        /// <summary>
        /// 所支持的上传类型用"/"隔开
        /// </summary>
        public string FileType
        {
            set { _FileType = value; }
        }

        /// <summary>
        /// 绘制文本的Ｘ坐标（左上角）
        /// </summary>
        public int DrawString_x
        {
            get { return _DrawString_x; }
            set { _DrawString_x = value; }
        }
        /// <summary>
        /// 绘制文本的Ｙ坐标（左上角）
        /// </summary>
        public int DrawString_y
        {
            get { return _DrawString_y; }
            set { _DrawString_y = value; }
        }

        /// <summary>
        /// 是否加水印
        /// </summary>
        public bool IsDraw
        {
            get { return _IsDraw; }
            set { _IsDraw = value; }
        }

        /// <summary>
        /// 设置文字水印字体
        /// </summary>
        public string Font
        {
            get { return _Font; }
            set { _Font = value; }
        }

        /// <summary>
        /// 设置文字水印字的大小
        /// </summary>
        public int FontSize
        {
            get { return _FontSize; }
            set { _FontSize = value; }
        }

        /// <summary>
        /// 保存文件的实际路径
        /// </summary>
        public string SavePath
        {
            set { _SavePath = value; }
            get { return _SavePath; }
        }

        /// <summary>
        /// 设置缩略图的宽度
        /// </summary>
        public int sWidth
        {
            get { return _sWidth; }
            set { _sWidth = value; }
        }

        /// <summary>
        /// 设置文字水印内容
        /// </summary>
        public string AddText
        {
            get { return _AddText; }
            set { _AddText = value; }
        }

        /// <summary>
        /// 设置缩略图的高度
        /// </summary>
        public int sHeight
        {
            get { return _sHeight; }
            set { _sHeight = value; }
        }

        /// <summary>
        /// Error返回值，1、没有上传的文件。2、类型不允许。3、大小超限。4、未知错误。0、上传成功。
        /// </summary>
        public int Error
        {
            get { return _Error; }
        }

        #endregion

        #region 图片保存到服务器的方法
        /// <summary>
        /// 对上传的文件进行保存
        /// </summary>
        public void Save_AS()
        {
            if (!File_Upload.HasFile)
            {
                _Error = 1;
                return;
            }


            string Ext = GetExt(File_Upload.FileName);
            if (!IsUpload(Ext))
            {
                _Error = 2;
                return;
            }

            //不存在目录时创建目录
            if (!Directory.Exists(_SavePath))
            {
                Directory.CreateDirectory(_SavePath);
            }

            //如果生成的图片不成功则返回
            if (!Pic_Up())
            {
                return;
            }

            //判断是不是生成宿图
            if (_IsCreateImg)
            {
                MakeThumbnail(_New_FileName_L, _New_FileName_S, _sWidth, _sHeight, "W");
            }

            //判断是不是加水印
            if (_IsDraw)
            {
                AddShuiYinWord(_New_FileName_L, _New_FileName);
            }

            _Error = 0;

        }

        /// <summary>
        /// 在服务器上生成临时图片文件
        /// </summary>
        /// <returns></returns>
        private bool Pic_Up()
        {

            _New_ImageName = GetNewFileName(File_Upload.FileName);

            _New_FileName_S = _SavePath + "S_" + _New_ImageName;

            _New_FileName_L = _SavePath + "L_" + _New_ImageName;

            _New_FileName = _SavePath + _New_ImageName;

            try
            {
                if (_IsCreateImg || _IsDraw)
                {
                    File_Upload.SaveAs(_New_FileName_L);
                }
                else
                {
                    File_Upload.SaveAs(_New_FileName);
                }
                return true;
            }
            catch (Exception ex)
            {

                _Error = 4;
                return false;
            }
        }
        #endregion

        #region 根据临时文件生成缩略图
        /**/
        /// <summary> 
        /// 生成缩略图 
        /// </summary> 
        /// <param name="originalImagePath">源图路径（物理路径）</param> 
        /// <param name="thumbnailPath">缩略图路径（物理路径）</param> 
        /// <param name="width">缩略图宽度</param> 
        /// <param name="height">缩略图高度</param> 
        /// <param name="mode">生成缩略图的方式</param> 
        public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, string mode)
        {
            System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);
            ////判断图片是不是索引图片jxyadd
            //if (IsPixelFormatIndexed(originalImage.PixelFormat))
            //{
            //    Bitmap mybmp = new Bitmap(originalImage.Width, originalImage.Height, PixelFormat.Format32bppArgb);
            //    originalImage = (System.Drawing.Image)mybmp;
            //}
            int towidth = width;
            int toheight = height;

            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;

            #region 处理宿列图的宽高
            switch (mode)
            {
                case "HW"://指定高宽缩放（可能变形） 
                    break;
                case "W"://指定宽，高按比例 
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case "H"://指定高，宽按比例 
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case "Cut"://指定高宽裁减（不变形） 
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    break;
                default:
                    break;
            }

            #endregion

            //新建一个bmp图片 
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);
            //新建一个画板 
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设置高质量插值法 
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度 
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以透明背景色填充 
            g.Clear(System.Drawing.Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分 
            g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight),
                new System.Drawing.Rectangle(x, y, ow, oh),
                System.Drawing.GraphicsUnit.Pixel);

            try
            {
                //以jpg格式保存缩略图 
                bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }


        }
        #endregion

        #region 添加水印的方法
        /**/
        /// <summary> 
        /// 在图片上增加文字水印 
        /// </summary> 
        /// <param name="Path">原服务器图片路径</param> 
        /// <param name="Path_sy">生成的带文字水印的图片路径</param> 
        protected void AddShuiYinWord(string Path, string Path_sy)
        {
            System.Drawing.Image image = System.Drawing.Image.FromFile(Path);
            #region 处理索引图片出错的bug
            //当上传的图片文件是索引图片的时候。例如是GIF图片会报错
            //针对上面的错误对Graphics对象进行修改。
            //当上传的图片时索引图片的时候，就从新的拷贝的图片创建Graphics对象
            //修改人：承信网络-JXY
            System.Drawing.Graphics g;
            if (IsPixelFormatIndexed(image.PixelFormat))
            {
                Bitmap bitmap1 = new Bitmap(image.Width, image.Height, PixelFormat.Format32bppArgb);
                g = System.Drawing.Graphics.FromImage(bitmap1);
            }
            else
            {
                g = System.Drawing.Graphics.FromImage(image);
            }
            #endregion
            g.DrawImage(image, 0, 0, image.Width, image.Height);

            System.Drawing.Font f = new System.Drawing.Font(_Font, _FontSize);

            System.Drawing.Brush b = new System.Drawing.SolidBrush(System.Drawing.Color.White);

            g.DrawString(_AddText, f, b, image.Width - _DrawString_x, image.Height - _DrawString_y);

            g.Dispose();
            image.Save(Path_sy);
            image.Dispose();
            //删除临时文件
            File.Delete(Path);
        }
        #endregion

        #region 对上传的图片文件的服务方法
        /// <summary>
        /// 产生一个随机的文件名称
        /// </summary>
        /// <param name="FileName">原文件的名称</param>
        /// <returns>string</returns>
        private string GetNewFileName(string FileName)
        {
            //跟据文件名产生一个由时间+随机数组成的一个新的文件名 
            string newfilename = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString()
                                 + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString()
                                 + DateTime.Now.Second.ToString() + DateTime.Now.Minute.ToString()
                                 + DateTime.Now.Millisecond.ToString()
                //+ rand.Next(1000).ToString() 
                                 + FileName.Substring(FileName.LastIndexOf("."), FileName.Length - FileName.LastIndexOf("."));
            return newfilename;
        }

        //检查上传的文件的类型，是否允许上传。
        private bool IsUpload(string Ext)
        {
            Ext = Ext.Replace(".", "");
            bool b = false;
            string[] arrFileType = _FileType.Split('/');
            foreach (string str in arrFileType)
            {
                if (str.ToLower() == Ext.ToLower())
                {
                    b = true;
                    break;
                }
            }
            return b;
        }

        //获取文件的后缀名
        private string GetExt(string path)
        {
            return Path.GetExtension(path);
        }
        #endregion


    }
}