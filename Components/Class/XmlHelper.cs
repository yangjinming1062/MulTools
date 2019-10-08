using System;
using System.IO;
using System.Xml;
using System.Reflection;

namespace MulTools.Components.Class
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
        /// <summary>
        /// 实例化XmlHelper对象
        /// </summary>
        /// <param name="xmlFilePath">Xml文件的相对路径</param>
        public XmlHelper(string xmlFilePath) => _filePath = GetMapPath(xmlFilePath);//获取XML文件的绝对路径
        #endregion

        /// <summary>
        /// 创建XML的根节点
        /// </summary>
        private void CreateXMLElement()
        {
            _xml = new XmlDocument();//创建一个XML对象
            if (File.Exists(_filePath))
            {
                _xml.Load(_filePath);//加载XML文件
            }
            _element = _xml.DocumentElement;//为XML的根节点赋值
        }

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

        /// <summary>
        /// 新增节点
        /// </summary>
        public void AppendNode<T>(T obj, string title = "IP")
        {
            CreateXMLElement();
            //XmlNode node = _xml.SelectSingleNode(xPath);//"/Root/Rules"
            XmlElement element = _xml.CreateElement(title);
            PropertyInfo[] propertys = obj.GetType().GetProperties();
            string str_value;
            foreach (PropertyInfo pi in propertys)
            {
                str_value = pi.GetValue(obj, null) == null ? string.Empty : pi.GetValue(obj, null).ToString();
                element.SetAttribute(pi.Name, str_value);//设置属性
            }
            _element.AppendChild(element);
            _xml.Save(_filePath);//保存文件
        }

        /// <summary>
        /// 修改节点及属性
        /// </summary>
        public void UpdateNode<T>(string xPath, string Name, T obj)
        {
            CreateXMLElement();
            //XmlElement element = (XmlElement)_xml.SelectSingleNode(xPath);
            XmlNodeList list = _element.SelectNodes(xPath);
            PropertyInfo[] propertys = obj.GetType().GetProperties();
            string str_value;
            foreach (XmlNode xml in list)
            {
                XmlElement element = (XmlElement)xml;
                if (element.GetAttribute("NAME") == Name)
                {
                    foreach (PropertyInfo pi in propertys)
                    {
                        str_value = pi.GetValue(obj, null) == null ? string.Empty : pi.GetValue(obj, null).ToString();
                        element.SetAttribute(pi.Name, str_value);//设置属性
                    }
                    break;
                }
            }
            _xml.Save(_filePath);//保存文件
        }

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
            _xml.Save(_filePath);
        }

        /// <summary>
        /// 保存XML文件
        /// </summary>        
        public void Save()
        {
            CreateXMLElement();//创建XML的根节点
            _xml.Save(_filePath);//保存XML文件
        }

        /// <summary>
        /// 任意相对或者绝对路径，返回一个可以进行操作的路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string GetMapPath(string path) => File.Exists(path) ? path : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
    }
}
