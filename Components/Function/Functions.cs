using MulTools.Components.Function;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.ComponentModel;
using System.Data;

namespace MulTools.Components
{
    public static class Functions
    {
        /// <summary>
        /// 提升进程权限
        /// </summary>
        public static void PrivilegesUp(string Privilege)
        {
            bool ToF;
            Win32.TokPriv1Luid tp;
            tp.PrivilegeCount = 1;
            tp.Luid = 0;
            tp.Attr = Win32.SE_PRIVILEGE_ENABLED;

            IntPtr hproc = Win32.GetCurrentProcess();
            IntPtr htok = IntPtr.Zero;

            ToF = Win32.OpenProcessToken(hproc, Win32.TOKEN_ADJUST_PRIVILEGES | Win32.TOKEN_QUERY, ref htok);//获得进程访问令牌的句柄
            ToF = Win32.LookupPrivilegeValue(null, Privilege, ref tp.Luid);//查找newPrivileges参数对应的Luid
            ToF = Win32.AdjustTokenPrivileges(htok, false, ref tp, 0, IntPtr.Zero, IntPtr.Zero);//通知系统修改进程权限
        }

        public static void DoExitWin(int flg)
        {
            bool ok;
            Win32.TokPriv1Luid tp;
            tp.PrivilegeCount = 1;
            tp.Luid = 0;
            tp.Attr = Win32.SE_PRIVILEGE_ENABLED;

            IntPtr hproc = Win32.GetCurrentProcess();
            IntPtr htok = IntPtr.Zero;

            ok = Win32.OpenProcessToken(hproc, Win32.TOKEN_ADJUST_PRIVILEGES | Win32.TOKEN_QUERY, ref htok);//获得进程访问令牌的句柄
            ok = Win32.LookupPrivilegeValue(null, Win32.SE_SHUTDOWN_NAME, ref tp.Luid);//修改进程权限
            ok = Win32.AdjustTokenPrivileges(htok, false, ref tp, 0, IntPtr.Zero, IntPtr.Zero);//通知系统修改进程权限
            ok = Win32.ExitWindowsEx(flg, 0);
        }

        #region Oracle
        /// <summary>
        /// 分页绑定  --大量数据一次性查询卡顿，分页查
        /// </summary> 
        /// <param name="table">表名</param>
        /// <param name="where">要加载的条件</param>
        /// <param name="column">查询的列，比如：*或者code,name</param>
        /// <param name="order">排序字段，比如：code desc或者code asc</param>
        /// <param name="mPageSize">每页大小</param> 
        /// <param name="mPageIndex">查询第几页</param> 
        /// <param name="recount">out形式参数，返回记录总数</param>
        /// <returns>返回的数据集</returns> 
        public static DataTable PageBind(string table, string where, string column, string order, int mPageSize, int mPageIndex, out int recount)
        {
            DataTable dt = null;
            recount = 0;
            //try
            //{
            //    System.Text.StringBuilder sb = new System.Text.StringBuilder(57);
            //    sb.Append("select count(1) from " + table);
            //    if (where.Length > 0)
            //    {
            //        sb.Append(" where " + where);
            //    }

            //    recount = int.Parse(DBEMRHelper.GetDataTable(sb.ToString()).Rows[0][0].ToString());
            //    sb = new System.Text.StringBuilder(500);

            //    sb.Append(" select " + column + " from ( select temp_b.*,rownum rk from (select * from " + table);
            //    if (where.Length > 0)
            //    {
            //        sb.Append(" where " + where);
            //    }
            //    if (order.Length > 0)
            //    {
            //        sb.Append(" order by " + order);
            //    }
            //    sb.Append(" ) temp_b where rownum<" + (mPageIndex * mPageSize + 1) + ") s where s.rk> " + mPageSize * (mPageIndex - 1));
            //    dt = DBEMRHelper.GetDataTable(sb.ToString());
            //}
            //catch
            //{

            //}
            return dt;
        }
        #endregion

        #region XML相关
        #region XML反序列化
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="xml">XML字符串</param>
        /// <returns></returns>
        public static object Deserialize(Type type, string xml)
        {
            try
            {
                using (StringReader rdr = new StringReader(xml))
                {
                    XmlSerializer serializer11 = new XmlSerializer(type);//声明序列化对象实例serializer
                    object obj = serializer11.Deserialize(rdr);//反序列化，并将反序列化结果值赋给变量i
                    return obj;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="type"></param>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static object Deserialize(Type type, Stream stream)
        {
            XmlSerializer xmldes = new XmlSerializer(type);
            return xmldes.Deserialize(stream);
        }
        #endregion

        #region 序列化XML文件
        /// <summary>
        /// 序列化XML文件
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public static string Serializer(Type type, object obj)
        {
            MemoryStream Stream = new MemoryStream();
            //创建序列化对象
            XmlSerializer xml = new XmlSerializer(type);
            try
            {
                xml.Serialize(Stream, obj);//序列化对象
            }
            catch { }
            Stream.Position = 0;
            StreamReader sr = new StreamReader(Stream);
            string str = sr.ReadToEnd();
            return str;
        }
        #endregion

        #region 将XML转换为DATATABLE
        /// <summary>
        /// 将XML转换为DATATABLE
        /// </summary>
        /// <param name="FileURL"></param>
        /// <returns></returns>
        public static DataTable XmlAnalysisArray()
        {
            try
            {
                //string FileURL = System.Configuration.ConfigurationManager.AppSettings["XmlFileUrl"].ToString();
                DataSet ds = new DataSet();
                //ds.ReadXml(FileURL);
                return ds.Tables[0];
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// 将XML转换为DATATABLE
        /// </summary>
        /// <param name="FileURL"></param>
        /// <returns></returns>
        public static DataTable XmlAnalysisArray(string FileURL)
        {
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml(FileURL);
                return ds.Tables[0];
            }
            catch (Exception)
            {
                //  System.Web.HttpContext.Current.Response.Write(ex.Message.ToString());
                return null;
            }
        }
        #endregion

        #region 获取对应XML节点的值
        /// <summary>
        /// 摘要:获取对应XML节点的值
        /// </summary>
        /// <param name="stringRoot">XML节点的标记</param>
        /// <returns>返回获取对应XML节点的值</returns>
        public static string XmlAnalysis(string stringRoot, string xml)
        {
            if (stringRoot.Equals("") == false)
            {
                try
                {
                    XmlDocument XmlLoad = new XmlDocument();
                    XmlLoad.LoadXml(xml);
                    return XmlLoad.DocumentElement.SelectSingleNode(stringRoot).InnerXml.Trim();
                }
                catch { }
            }
            return "";
        }
        #endregion

        #region  XmlToList

        public static List<T> XmlToList<T>(string xml, string root)
        {
            List<T> list = new List<T>();
            try
            {
                XElement xmlE = GetXElement(xml);
                var bookVar = xmlE.Descendants(root);

                T t = default(T);
                PropertyInfo[] propertypes = null;
                string tempName = string.Empty;

                foreach (XElement row in bookVar)
                {
                    t = Activator.CreateInstance<T>();
                    propertypes = t.GetType().GetProperties();
                    foreach (PropertyInfo pro in propertypes)
                    {
                        tempName = pro.Name.ToUpper();
                        if (row.Element(tempName) != null)
                        {
                            string aa = row.Element(tempName).Value.Trim() ?? "";
                            pro.SetValue(t, aa, null);
                        }
                    }
                    list.Add(t);
                }
            }
            catch (Exception)
            {
                return null;
            }
            return list;
        }

        private static XElement GetXElement(string xml)
        {
            StringReader stream = null;
            XmlTextReader reader = null;
            XElement xmlE = null;
            try
            {
                XmlDocument xmld = new XmlDocument();
                stream = new StringReader(xml);
                reader = new XmlTextReader(stream);
                xmlE = XElement.Load(reader);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
            return xmlE;
        }

        #endregion

        #region  ListToXml

        public static string ListToXml<T>(List<T> list, string root)
        {
            XDocument bookDoc = new XDocument();//创建XML文档  
            //创建声明对象  
            //XDeclaration xDeclaration = new XDeclaration("1.0", "utf-8", "yes");
            //bookDoc.Declaration = xDeclaration;    //指定XML声明对象  
            //创建bookstore节点  
            XElement xElement = new XElement("Msg");
            //List<T> list = new List<T>();
            T t = default(T);
            PropertyInfo[] propertypes = null;
            string tempName = string.Empty;
            t = Activator.CreateInstance<T>();
            propertypes = t.GetType().GetProperties();
            for (int i = 0; i < list.Count; i++)
            {
                XElement bookXml = new XElement(root);
                foreach (PropertyInfo pro in propertypes)
                {
                    //添加子节点  
                    T tt = list[i];
                    string ta = string.Empty;
                    try
                    {
                        ta = pro.GetValue(tt, null).ToString();
                    }
                    catch
                    {

                    }
                    if (pro.Name == "DOEVENT")
                    {
                        bookXml.Add(new XElement(pro.Name, ta));
                    }
                    bookXml.Add(new XElement(pro.Name, ta));

                }
                xElement.Add(bookXml);
            }
            return xElement.ToString();
        }
        public static string ListToXmlForWL<T>(List<T> list)
        {
            //创建XML文档  
            XmlDocument xml = new XmlDocument();

            //创建声明对象  
            //XDeclaration xDeclaration = new XDeclaration("1.0", "utf-8", "yes");
            //bookDoc.Declaration = xDeclaration;    //指定XML声明对象  
            //创建bookstore节点  
            XElement xElement = new XElement("response");

            XElement returnresult = new XElement("returnresult");
            xElement.Add(returnresult);
            XElement returncode = new XElement("returncode");
            returnresult.Add(returncode);
            XElement errormsg = new XElement("errormsg");
            returnresult.Add(errormsg);

            //List<T> list = new List<T>();
            T t = default(T);
            PropertyInfo[] propertypes = null;
            string tempName = string.Empty;
            t = Activator.CreateInstance<T>();
            propertypes = t.GetType().GetProperties();

            XElement bookXml = new XElement("data");
            if (list == null)
            {
                returncode.SetValue("-1");
                errormsg.SetValue("入参必填项不能为空!");
                bookXml.SetValue("无数据哟亲");
                xElement.Add(bookXml);
            }
            else
            {
                if (list.Count == 0)
                {
                    returncode.SetValue("-1");
                    errormsg.SetValue("未查询到信息!");
                    bookXml.SetValue("无数据哟亲");
                    xElement.Add(bookXml);
                }
                else if (list.Count == 1)
                {
                    returncode.SetValue("1");
                    errormsg.SetValue("成功返回1条");

                    for (int i = 0; i < list.Count; i++)
                    {

                        foreach (PropertyInfo pro in propertypes)
                        {
                            //添加子节点  
                            T tt = list[i];
                            string ta = string.Empty;
                            try
                            {
                                ta = pro.GetValue(tt, null).ToString();
                            }
                            catch
                            {

                            }
                            if (pro.Name == "DOEVENT")
                            {
                                bookXml.Add(new XElement(pro.Name, ta));
                            }
                            bookXml.Add(new XElement(pro.Name, ta));

                        }
                        xElement.Add(bookXml);
                    }
                }
                else if (list.Count > 1)
                {
                    returncode.SetValue("1");
                    errormsg.SetValue("成功返回" + list.Count.ToString() + "条");
                    for (int i = 0; i < list.Count; i++)
                    {
                        XElement bookXml1 = new XElement("data_row");
                        foreach (PropertyInfo pro in propertypes)
                        {
                            //添加子节点  
                            T tt = list[i];
                            string ta = string.Empty;
                            try
                            {
                                ta = pro.GetValue(tt, null).ToString();
                            }
                            catch
                            {

                            }
                            if (pro.Name == "DOEVENT")
                            {
                                bookXml1.Add(new XElement(pro.Name, ta));
                            }
                            bookXml1.Add(new XElement(pro.Name, ta));

                        }
                        bookXml.Add(bookXml1);

                    }
                    xElement.Add(bookXml);
                }
            }
            return xElement.ToString();
        }

        #endregion
        #endregion

        #region 泛型T相关
        /// <summary>
        /// DataSet转换为实体类
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="p_DataSet">DataSet</param>
        /// <param name="p_TableIndex">待转换数据表索引</param>
        /// <returns>实体类</returns>
        public static IList<T> DataSetToT<T>(DataSet p_DataSet, int p_TableIndex = 0)
        {
            if (p_DataSet == null || p_DataSet.Tables.Count <= 0)
                return new List<T>();
            if (p_TableIndex > p_DataSet.Tables.Count - 1)
                return new List<T>();
            if (p_TableIndex < 0)
                p_TableIndex = 0;
            if (p_DataSet.Tables[p_TableIndex].Rows.Count <= 0)
                return new List<T>();

            DataTable p_Data = p_DataSet.Tables[p_TableIndex];
            // 返回值初始化
            IList<T> result = new List<T>();
            for (int j = 0; j < p_Data.Rows.Count; j++)
            {
                T _t = (T)Activator.CreateInstance(typeof(T));
                PropertyInfo[] propertys = _t.GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    for (int i = 0; i < p_Data.Columns.Count; i++)
                    {
                        try
                        {
                            // 属性与字段名称一致的进行赋值
                            if (pi.Name.ToLower().Equals(p_Data.Columns[i].ColumnName.ToLower()))
                            {
                                // 数据库NULL值单独处理
                                if (p_Data.Rows[j][i] != DBNull.Value)
                                {
                                    pi.SetValue(_t, p_Data.Rows[j][i].ChangeType(pi.PropertyType), null);
                                }
                                else
                                {
                                    pi.SetValue(_t, null, null);
                                }
                                break;
                            }
                        }
                        catch
                        {
                            Type type = p_Data.Rows[j][i].GetType();
                            object value = p_Data.Rows[j][i];
                        }
                    }
                }
                result.Add(_t);
            }
            return result;
        }

        public static object ChangeType(this object value, Type conversionType)
        {
            if (conversionType.IsGenericType && conversionType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value != null)
                {
                    NullableConverter nullableConverter = new NullableConverter(conversionType);
                    conversionType = nullableConverter.UnderlyingType;
                }
                else
                {
                    return null;
                }
            }
            return Convert.ChangeType(value, conversionType);
        }
        /// <summary>
        /// 泛型生成SQL语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">实体</param>
        /// <param name="Model">Update or Insert</param>
        /// <returns>无where条件，自备</returns>
        public static string TSQL<T>(T obj, string Model, string DataFormat = "yyyy-MM-dd HH24:mi:ss")
        {
            if (obj == null || string.IsNullOrEmpty(Model))
                return "";
            string resStr = "";
            string TableName = "";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            T _t = (T)Activator.CreateInstance(typeof(T));
            PropertyInfo[] propertys = _t.GetType().GetProperties();
            if (_t.ToString().Contains("."))
            {
                TableName = _t.ToString().Substring(_t.ToString().LastIndexOf(".") + 1, _t.ToString().Length - _t.ToString().LastIndexOf(".") - 1);
            }
            else
                TableName = _t.ToString();
            switch (Model.ToLower())
            {
                case "update":
                    sb.AppendLine("update " + TableName + " set ");
                    foreach (PropertyInfo pi in propertys)
                    {
                        if (!pi.Name.ToLower().Contains("data"))
                        {
                            if (pi.GetValue(obj, null) != null)
                                sb.AppendLine(pi.Name + "='" + pi.GetValue(obj, null) + "',");
                        }
                        else
                        {
                            if (pi.GetValue(obj, null) != null)
                                sb.AppendLine(pi.Name + "= to_date('" + pi.GetValue(obj, null) + "','" + DataFormat + "'),");
                        }
                    }
                    resStr = sb.ToString().Substring(0, sb.ToString().Length - 3);//因为\r\n的存在不能TrimEnd
                    break;
                case "insert":
                    sb.AppendLine("insert into " + TableName + "(");
                    foreach (PropertyInfo pi in propertys)
                    {
                        if (pi.GetValue(obj, null) != null)
                            sb.Append(pi.Name + ",");
                    }
                    resStr = sb.ToString().TrimEnd(',') + " )values (";
                    sb = new System.Text.StringBuilder();
                    foreach (PropertyInfo pi in propertys)
                    {
                        if (!pi.Name.ToLower().Contains("data"))
                        {
                            if (pi.GetValue(obj, null) != null)
                                sb.AppendLine("'" + pi.GetValue(obj, null) + "',");
                        }
                        else
                        {
                            if (pi.GetValue(obj, null) != null)
                                sb.AppendLine("to_date('" + pi.GetValue(obj, null) + "','" + DataFormat + "'),");
                        }
                    }
                    resStr += sb.ToString().Substring(0, sb.ToString().Length - 3) + ")";
                    break;
            }
            return resStr;
        }
        #endregion

        #region 文件夹操作
        /// <summary>
        /// 删除文件夹
        /// </summary>
        /// <param name="path"></param>
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
        /// <param name="path"></param>
        /// <param name="sou"></param>
        /// <param name="des"></param>
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
        /// <param name="path"></param>
        /// <param name="sou"></param>
        /// <param name="des"></param>
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

        #region 屏幕缩放比
        /// <summary>
        /// 当前系统显示的缩放比
        /// </summary>
        public static decimal Rate
        {
            get
            {
                IntPtr hdc = Win32.GetDC(IntPtr.Zero);
                int realH = Win32.GetDeviceCaps(hdc, 10);//DeviceCaps常量,VERTRES = 10,实际显示分辨率
                int H = Win32.GetDeviceCaps(hdc, 117);//DeviceCaps常量,DESKTOPVERTRES = 117，设置的分辨率
                Win32.ReleaseDC(IntPtr.Zero, hdc);
                return Convert.ToDecimal(H) / Convert.ToDecimal(realH);
            }
        }

        /// <summary>
        /// 因为缩放率的影响，需要进行比例换算
        /// </summary>
        public static int GetRated(decimal res) => Convert.ToInt32(res * Rate);

        /// <summary>
        /// 这里主要是处理鼠标返回的坐标点，需要除以缩放比例
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static Point GetRated(Point source) => new Point(Convert.ToInt32(source.X / Rate), Convert.ToInt32(source.Y / Rate));
        #endregion

        #region 创建进程
        /// <summary>
        /// 调用exe
        /// </summary>
        /// <param name="exeName">程序名称</param>
        /// <param name="args">启动参数,每个参数以空格隔开</param>
        /// <returns></returns>
        public static string SubProcess(string exeName,string args)
        {
            Process pyProcess = new Process();
            pyProcess.StartInfo.FileName = string.Format("{0}.exe", exeName);
            pyProcess.StartInfo.Arguments = args;
            pyProcess.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
            pyProcess.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
            pyProcess.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
            pyProcess.StartInfo.RedirectStandardError = true;//重定向标准错误输出
            pyProcess.StartInfo.CreateNoWindow = true;//不显示程序窗口
            pyProcess.Start();//启动程序
            pyProcess.StandardInput.AutoFlush = true;
            string output = pyProcess.StandardOutput.ReadToEnd();
            pyProcess.Close();
            return output;
        }

        public static string UsePython(string path, string args)
        {
            Process pyProcess = new Process();
            pyProcess.StartInfo.FileName = "Python";
            pyProcess.StartInfo.Arguments = path + " " + args;
            pyProcess.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
            pyProcess.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
            pyProcess.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
            pyProcess.StartInfo.RedirectStandardError = true;//重定向标准错误输出
            pyProcess.StartInfo.CreateNoWindow = true;//不显示程序窗口
            pyProcess.Start();//启动程序
            pyProcess.StandardInput.AutoFlush = true;
            string output = pyProcess.StandardOutput.ReadToEnd();
            pyProcess.Close();
            return output;
        }
        #endregion
    }
}
