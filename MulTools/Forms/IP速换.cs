using MulTools.Components.Models;
using MulTools.Components.Class;
using System;
using System.Collections.Generic;
using System.Management;
using System.Net;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Reflection;

namespace MulTools.Forms
{
    public partial class IP速换 : Form
    {
        public IP速换()
        {
            InitializeComponent();
        }

        private XmlHelper xmlHelper;

        #region Function
        private bool Valid()
        {
            List<TextBox> list = new List<TextBox>
            {
                txtIP,
                txtYM,
                txtWG
            };
            foreach (TextBox t in list)
            {
                try
                {
                    IPAddress.Parse(t.Text.Replace(" ", ""));
                }
                catch
                {
                    t.Focus();
                    MessageBox.Show("输入不合法");
                    return false;
                }
            }
            return true;
        }

        private void RefreshTree()
        {
            #region Xml的方式
            XmlNodeList xmlNodes = xmlHelper.GetNodeList("IP");
            tvIP.Nodes.Clear();
            foreach (XmlNode xml in xmlNodes)
            {
                IP iP = new IP();
                PropertyInfo[] propertys = iP.GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    pi.SetValue(iP, xml.Attributes[pi.Name].Value);
                }
                tvIP.Nodes.Add(iP.Name, iP.Name);//添加具有Key的树节点
                tvIP.Nodes.Find(iP.Name,false)[0].Tag = iP;
            }
            #endregion

            #region 序列化的方式
            //StreamReader tempFile = new StreamReader(FilePath);
            //List<Models.IP> IPlist = Function.XmlToList<Models.IP>(tempFile.ReadToEnd(), "IP");
            //tvIP.Nodes.Clear();
            //foreach (var node in IPlist)
            //{
            //    RadTreeNode tvNode = new RadTreeNode();
            //    tvNode.Text = node.Name;
            //    tvNode.Tag = node;
            //    tvIP.Nodes.Add(tvNode);
            //}
            #endregion
            tvIP.ExpandAll();
        }

        private void GetText(IP obj, string Name = null)
        {
            obj.IPDZ = txtIP.Text;
            obj.ZWYM = txtYM.Text;
            obj.MRWG = txtWG.Text;
            obj.FDNS = txtFDNS.Text;
            obj.SDNS = txtSDNS.Text;
            if (!string.IsNullOrEmpty(Name))
                obj.Name = Name;
        }

        private void SetText(IP obj,bool NoName = false)
        {
            txtIP.Text = obj.IPDZ;
            txtYM.Text = obj.ZWYM;
            txtWG.Text = obj.MRWG;
            txtFDNS.Text = obj.FDNS;
            txtSDNS.Text = obj.SDNS;
            if (!NoName)
                txtName.Text = obj.Name;
        }
        #endregion

        #region 事件
        private void IP速换_Load(object sender, EventArgs e)
        {
            if (!File.Exists("IP.xml"))
            {
                //var f = File.Create("IP.xml");
                //byte[] byt = System.Text.Encoding.Default.GetBytes("<?xml version=\"1.0\" encoding=\"UTF-8\"?><Root ></Root >");
                //f.Write(byt, 0, byt.Length);
                var f = File.CreateText("IP.xml");//两种写法哪种都行，但是我更喜欢不用转码的
                f.Write("<?xml version=\"1.0\" encoding=\"UTF-8\"?><Root ></Root >");
                f.Close();
            }
            xmlHelper = new XmlHelper("IP.xml");
            RefreshTree();
            BtRead_Click(null, null);
        }

        private void TvIP_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tvIP.SelectedNode != null && tvIP.SelectedNode.Tag != null)
            {
                SetText(tvIP.SelectedNode.Tag as IP);
                //cmbWK.Visible = false;
                cmbWK.SelectedIndexChanged -= new EventHandler(CmbWK_SelectedIndexChanged);
            }
        }

        private void CbAutoWG_CheckedChanged(object sender, EventArgs e) => txtWG.TabStop = cbAutoWG.Checked ? false : true;

        private void CmbWK_SelectedIndexChanged(object sender, EventArgs e) => SetText(cmbWK.SelectedItem as IP, true);

        private void TxtIP_Leave(object sender, EventArgs e)
        {
            if (cbAutoWG.Checked && string.IsNullOrEmpty(txtWG.Text))
                txtWG.Text = txtIP.Text.Substring(0, txtIP.Text.LastIndexOf('.')) + ".1";
        }

        private void BtDelete_Click(object sender, EventArgs e)
        {
            if (xmlHelper.RemoveNode("IP", "Name", txtName.Text))
                tvIP.Nodes.RemoveByKey(txtName.Text);
        }

        private void BtRead_Click(object sender, EventArgs e)
        {
            tvIP.SelectedNode = null;

            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection nics = mc.GetInstances();
            cmbWK.Items.Clear();
            cmbWK.SelectedIndexChanged -= new EventHandler(CmbWK_SelectedIndexChanged);
            foreach (ManagementObject nic in nics)
            {
                if (Convert.ToBoolean(nic["ipEnabled"]) == true)
                {
                    //foreach (PropertyData prop in nic.Properties)//列出全部属性,不知道有什么的时候可以看一下
                    //    txtName.Text += prop.Name + ":" + prop.Value + "\n";
                    //MessageBox.Show(txtName.Text);
                    txtName.Text = "";
                    txtIP.Text = (nic["IPAddress"] as string[])[0];//IP地址
                    txtYM.Text = (nic["IPSubnet"] as string[])[0];//子网掩码
                    if (nic["DefaultIPGateway"] != null)
                        txtWG.Text = (nic["DefaultIPGateway"] as string[])[0];//默认网关
                    if (nic["DNSServerSearchOrder"] != null)
                    {
                        txtFDNS.Text = (nic["DNSServerSearchOrder"] as string[])[0];
                        if ((nic["DNSServerSearchOrder"] as string[]).Length > 1)
                            txtSDNS.Text = (nic["DNSServerSearchOrder"] as string[])[1];
                    }
                    IP obj = new IP();
                    GetText(obj, nic.Properties["Description"].Value.ToString());
                    cmbWK.Items.Add(obj);
                    cmbWK.DisplayMember = "Name";
                }
            }
            if (cmbWK.Items.Count > 0)
            {
                cmbWK.Visible = true;
                cmbWK.SelectedIndex = 0;
            }
            else
                cmbWK.Visible = false;

            cmbWK.SelectedIndexChanged += new EventHandler(CmbWK_SelectedIndexChanged);
        }

        private void BtSave_Click(object sender, EventArgs e)
        {
            if (!Valid())
                return;
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("请为保存的配置信息取名");
                txtName.Focus();
                return;
            }
            #region 修改xml
            IP obj = null;//是否已经是现有的配置名称，是的话更新现有信息，否的话新增节点
            if (tvIP.SelectedNode != null && tvIP.SelectedNode.Text != txtName.Text)
            {
                DialogResult ds = MessageBox.Show("选择是则修改所选配置为新名称，选择否则保留旧配置新增配置", "修改选择的配置信息", MessageBoxButtons.YesNo);
                if (ds == DialogResult.Yes)
                {
                    obj = tvIP.SelectedNode.Tag as IP;
                    GetText(obj, txtName.Text);
                    xmlHelper.UpdateNode("IP", tvIP.SelectedNode.Text, obj);
                    tvIP.SelectedNode.Text = obj.Name;
                }
            }
            else
            {
                TreeNode[] nodes = tvIP.Nodes.Find(txtName.Text, false);
                if (nodes.Length > 0)
                {
                    obj = nodes[0].Tag as IP;
                    GetText(obj);
                    xmlHelper.UpdateNode("IP", obj.Name, obj);
                }
            }
            if (obj == null)
            {
                obj = new IP();
                GetText(obj, txtName.Text);
                tvIP.Nodes.Add(new TreeNode { Text = obj.Name, Tag = obj });
                xmlHelper.AppendNode(obj, "IP");
            }
            #endregion
            RefreshTree();
            if (cbTogether.Checked)
                BtApply_Click(null, null);
        }

        private void BtApply_Click(object sender, EventArgs e)
        {
            if (Valid())
            {
                #region 修改网络参数
                //DialogResult ds = MessageBox.Show("会将当前全部连接修改为配置信息，如果同时连接了 WIFI和有线 请断开不需要配置的！，了解后继续", "注意", MessageBoxButtons.OKCancel);
                //if (ds != DialogResult.OK)
                //    return;
                ManagementBaseObject inPar;
                ManagementBaseObject outPar;
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    if (!(bool)mo["IPEnabled"])
                        continue;
                    if (mo.Properties["Description"].Value.ToString() == cmbWK.Text)
                    {
                        inPar = mo.GetMethodParameters("EnableStatic");//设置ip地址和子网掩码
                        inPar["IPAddress"] = new string[] { txtIP.Text };// 1.备用 2.IP

                        inPar["SubnetMask"] = new string[] { txtYM.Text };
                        outPar = mo.InvokeMethod("EnableStatic", inPar, null);

                        inPar = mo.GetMethodParameters("SetGateways");//设置网关地址
                        inPar["DefaultIPGateway"] = new string[] { txtWG.Text }; // 1.网关;2.备用网关
                        outPar = mo.InvokeMethod("SetGateways", inPar, null);

                        inPar = mo.GetMethodParameters("SetDNSServerSearchOrder");//设置DNS
                        inPar["DNSServerSearchOrder"] = new string[] { txtFDNS.Text, txtSDNS.Text }; // 1.DNS 2.备用DNS
                        outPar = mo.InvokeMethod("SetDNSServerSearchOrder", inPar, null);
                        MessageBox.Show(text: "应用成功！");
                        break;
                    }
                }
                #endregion
            }
        }
        #endregion
    }
}
