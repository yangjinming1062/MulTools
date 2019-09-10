using System;
using System.Xml;
using System.IO;

namespace MulTools.Function
{
    public class XmlHelper
    {
        #region 字段定义
        /// <summary>
        /// XML文件的物理路径
        /// </summary>
        private string _filePath = string.Empty;
        /// <summary>
        /// Xml文档
        /// </summary>
        private XmlDocument _xml;
        /// <summary>
        /// XML的根节点
        /// </summary>
        private XmlElement _element;
        #endregion

        #region 构造方法
        public XmlHelper()
        {
        }
        /// <summary>
        /// 实例化XmlHelper对象
        /// </summary>
        /// <param name="xmlFilePath">Xml文件的相对路径</param>
        public XmlHelper(string xmlFilePath)
        {
            _filePath = GetMapPath(xmlFilePath);//获取XML文件的绝对路径
        }
        #endregion

        #region 创建XML的根节点
        /// <summary>
        /// 创建XML的根节点
        /// </summary>
        private void CreateXMLElement()
        {
            _xml = new XmlDocument();//创建一个XML对象
            if (File.Exists(_filePath))
            {
                _xml.Load(this._filePath);//加载XML文件
            }
            _element = _xml.DocumentElement;//为XML的根节点赋值
        }
        #endregion

        #region 获取指定XPath表达式的节点对象
        /// <summary>
        /// 获取指定XPath表达式的节点对象
        /// </summary>        
        /// <param name="xPath">XPath表达式,
        /// 范例1: @"Skill/First/SkillItem", 等效于 @"//Skill/First/SkillItem"
        /// 范例2: @"Table[USERNAME='a']" , []表示筛选,USERNAME是Table下的一个子节点.
        /// 范例3: @"ApplyPost/Item[@itemName='岗位编号']",@itemName是Item节点的属性.
        /// </param>
        public XmlNode GetNode(string xPath)
        {
            CreateXMLElement();//创建XML的根节点
            return _element.SelectSingleNode(xPath);//返回XPath节点
        }

        /// <summary>
        /// 获得节点集合
        /// </summary>
        /// <param name="xPath"></param>
        /// <returns></returns>
        public XmlNodeList GetNodeList(string xPath)
        {
            CreateXMLElement();//创建XML的根节点
            return _element.SelectNodes(xPath);
        }
        #endregion

        #region 获取指定XPath表达式节点的值
        /// <summary>
        /// 获取指定XPath表达式节点的值
        /// </summary>
        /// <param name="xPath">XPath表达式,
        /// 范例1: @"Skill/First/SkillItem", 等效于 @"//Skill/First/SkillItem"
        /// 范例2: @"Table[USERNAME='a']" , []表示筛选,USERNAME是Table下的一个子节点.
        /// 范例3: @"ApplyPost/Item[@itemName='岗位编号']",@itemName是Item节点的属性.
        /// </param>
        public string GetValue(string xPath)
        {
            CreateXMLElement();//创建XML的根节点
            return _element.SelectSingleNode(xPath).InnerText;//返回XPath节点的值
        }
        #endregion

        #region 新增节点
        /// <summary>
        /// 新增节点
        /// </summary>
        /// <param name="xPath">xPath</param>
        /// <param name="elementName">节点名称</param>
        /// <param name="dict">节点属性</param>
        public void AppendNode( Models.IP obj)
        {
            CreateXMLElement();
            //XmlNode node = _xml.SelectSingleNode(xPath);//"/Root/Rules"
            XmlElement element = _xml.CreateElement("IP");//titles
            //设置属性
            element.SetAttribute("NAME", obj.Name);
            element.SetAttribute("IPDZ", obj.IPDZ);
            element.SetAttribute("ZWYM", obj.ZWYM);
            element.SetAttribute("MRWG", obj.MRWG);
            element.SetAttribute("FDNS", obj.FDNS);
            element.SetAttribute("SDNS", obj.SDNS);

            _element.AppendChild(element);
            _xml.Save(this._filePath);//保存文件
        }
        #endregion

        #region 修改节点及属性
        /// <summary>
        /// 修改节点及属性
        /// </summary>
        /// <param name="xPath">xPath</param>
        /// <param name="dict">节点属性</param>
        public void UpdateNode(string xPath, string Name, Models.IP obj)
        {
            CreateXMLElement();
            //XmlElement element = (XmlElement)_xml.SelectSingleNode(xPath);
            XmlNodeList list = _element.SelectNodes(xPath);
            foreach (XmlNode xml in list)
            {
                XmlElement element = (XmlElement)xml;
                if (element.GetAttribute("NAME") == Name)
                {
                    element.SetAttribute("NAME", obj.Name);
                    element.SetAttribute("IPDZ", obj.IPDZ);
                    element.SetAttribute("ZWYM", obj.ZWYM);
                    element.SetAttribute("MRWG", obj.MRWG);
                    element.SetAttribute("FDNS", obj.FDNS);
                    element.SetAttribute("SDNS", obj.SDNS);
                    break;
                }
            }
            _xml.Save(this._filePath);//保存文件
        }
        #endregion

        #region 删除节点
        /// <summary>
        /// 删除指定XPath表达式的节点
        /// </summary>
        /// <param name="xpath">XPath表达式</param>
        /// <param name="xmlAttributeName">要删除包含xmlAttributeName属性的节点的名称</param>
        /// <param name="AttributeValue">要删除包含xmlAttributeName属性的节点值</param>
        public void RemoveNode(string xpath, string xmlAttributeName, string AttributeValue)
        {
            CreateXMLElement();

            XmlNodeList xNodes = _element.SelectNodes(xpath);
            for (int i = xNodes.Count - 1; i >= 0; i--)
            {
                XmlElement xe = (XmlElement)xNodes[i];
                if (xe.GetAttribute(xmlAttributeName) == AttributeValue)
                {
                    xNodes[i].ParentNode.RemoveChild(xNodes[i]);
                    break;
                }
            }
            _xml.Save(this._filePath);
        }
        #endregion //删除节点

        #region 保存XML文件
        /// <summary>
        /// 保存XML文件
        /// </summary>        
        public void Save()
        {
            CreateXMLElement();//创建XML的根节点
            _xml.Save(this._filePath);//保存XML文件
        }
        #endregion //保存XML文件

        #region 获得文件路径
        /// <summary>
        /// 获得文件路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string GetMapPath(string path)
        {
            path = path.Replace("/", "\\");
            if (path.StartsWith("\\"))
                path = path.Substring(path.IndexOf('\\', 1)).TrimStart('\\');

            return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
        }
        #endregion
    }

    /// <summary>
    /// 结果集 枚举
    /// </summary>
    public enum Enum_result
    {
        等于0 = 0,
        不为空 = 1,
        大于0 = 2,
        小于0 = 3
    }
}
