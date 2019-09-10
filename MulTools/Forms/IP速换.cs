using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Net;
using System.Xml;
using System.Windows.Forms;
using MulTools.Function;

namespace MulTools.Forms
{
    public partial class IP速换 : Form
    {
        public IP速换()
        {
            InitializeComponent();
        }

        #region Variable
        //string FilePath = Application.StartupPath + "\\IP.xml";
        string xmlFile = "IP.xml";
        List<Models.IP> wkList = new List<Models.IP>();
        string lbWK = "";
        #endregion

        #region Function
        bool Valid()
        {
            List<MaskedTextBox> list = new List<MaskedTextBox>();
            list.Add(txtIP);
            list.Add(txtYM);
            list.Add(txtWG);
            foreach (var t in list)
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
            XmlHelper xmlHelper = new XmlHelper(xmlFile);
            XmlNodeList xmlNodes = xmlHelper.GetNodeList("IP");
            tvIP.Nodes.Clear();
            foreach (XmlNode xml in xmlNodes)
            {
                TreeNode tvNode = new TreeNode();
                Models.IP iP = new Models.IP
                {
                    IPDZ = xml.Attributes[(int)IPenum.IPDZ].InnerText,
                    ZWYM = xml.Attributes[(int)IPenum.ZWYM].InnerText,
                    MRWG = xml.Attributes[(int)IPenum.MRWG].InnerText,
                    FDNS = xml.Attributes[(int)IPenum.FDNS].InnerText,
                    SDNS = xml.Attributes[(int)IPenum.SDNS].InnerText,
                    Name = xml.Attributes[(int)IPenum.NAME].InnerText
                };
                Models.IP obj = iP;
                tvNode.Text = obj.Name;
                tvNode.Tag = obj;
                tvIP.Nodes.Add(tvNode);
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
        #endregion

        private void IP速换_Load(object sender, EventArgs e)
        {
            RefreshTree();
            txtWG.TabStop = false;//因为默认设置了自动生成网关
            BtRead_Click(null, null);
        }

        private void TvIP_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tvIP.SelectedNode != null && tvIP.SelectedNode.Tag != null)
            {
                Models.IP obj = tvIP.SelectedNode.Tag as Models.IP;
                txtIP.Text = obj.IPDZ;
                txtYM.Text = obj.ZWYM;
                txtWG.Text = obj.MRWG;
                txtFDNS.Text = obj.FDNS;
                txtSDNS.Text = obj.SDNS;
                txtName.Text = obj.Name;
                lbWK = "";
                //cmbWK.Visible = false;
                cmbWK.SelectedIndexChanged -= new EventHandler(CmbWK_SelectedIndexChanged);
            }
        }

        private void CbAutoWG_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAutoWG.Checked)
                txtWG.TabStop = false;
            else
                txtWG.TabStop = true;
        }

        private void CmbWK_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Models.IP obj in wkList)
            {
                if (obj.Name == cmbWK.Text)
                {
                    txtIP.Text = obj.IPDZ;
                    txtYM.Text = obj.ZWYM;
                    txtWG.Text = obj.MRWG;
                    txtFDNS.Text = obj.FDNS;
                    txtSDNS.Text = obj.SDNS;
                }
            }
        }

        private void TxtIP_Leave(object sender, EventArgs e)
        {
            if (cbAutoWG.Checked)
                txtWG.Text = txtIP.Text.Substring(0, txtIP.Text.LastIndexOf('.')) + ".1";
        }

        private void BtDelete_Click(object sender, EventArgs e)
        {
            XmlHelper xmlhelper = new XmlHelper(xmlFile);
            xmlhelper.RemoveNode("IP", "NAME", txtName.Text);
            RefreshTree();
        }

        private void BtRead_Click(object sender, EventArgs e)
        {
            tvIP.SelectedNode = null;

            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection nics = mc.GetInstances();
            wkList.Clear();
            cmbWK.Items.Clear();
            this.cmbWK.SelectedIndexChanged -= new EventHandler(this.CmbWK_SelectedIndexChanged);
            foreach (ManagementObject nic in nics)
            {
                if (Convert.ToBoolean(nic["ipEnabled"]) == true)
                {
                    lbWK = nic.Properties["Description"].Value.ToString();//网卡
                    //foreach (PropertyData prop in nic.Properties)//列出全部属性,不知道有什么的时候可以看一下
                    //    txtName.Text += prop.Name + ":" + prop.Value + "\n";
                    //MessageBox.Show(txtName.Text);
                    txtName.Text = "";
                    txtIP.Text = (nic["IPAddress"] as String[])[0];//IP地址
                    txtYM.Text = (nic["IPSubnet"] as String[])[0];//子网掩码
                    if (nic["DefaultIPGateway"] != null)
                        txtWG.Text = (nic["DefaultIPGateway"] as String[])[0];//默认网关
                    if (nic["DNSServerSearchOrder"] != null)
                    {
                        txtFDNS.Text = (nic["DNSServerSearchOrder"] as String[])[0];
                        if ((nic["DNSServerSearchOrder"] as String[]).Length > 1)
                            txtSDNS.Text = (nic["DNSServerSearchOrder"] as String[])[1];
                    }
                    Models.IP obj = new Models.IP
                    {
                        IPDZ = txtIP.Text,
                        ZWYM = txtYM.Text,
                        MRWG = txtWG.Text,
                        FDNS = txtFDNS.Text,
                        SDNS = txtSDNS.Text,
                        Name = lbWK
                    };
                    wkList.Add(obj);
                    cmbWK.Items.Add(lbWK);
                }
            }
            if (wkList.Count > 0)
            {
                cmbWK.Visible = true;
                cmbWK.SelectedIndex = wkList.Count - 1;
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
            bool IsHaved = false;//是否已经是现有的配置名称，是的话更新现有信息，否的话新增节点
            XmlHelper xmlhelper = new XmlHelper(xmlFile);
            if (tvIP.SelectedNode != null && tvIP.SelectedNode.Text != txtName.Text)
            {
                DialogResult ds = MessageBox.Show("选择是则修改所选配置为新名称，选择否则保留旧配置新增配置", "修改选择的配置信息", MessageBoxButtons.YesNo);
                if (ds == DialogResult.Yes)
                {
                    Models.IP obj = tvIP.SelectedNode.Tag as Models.IP;
                    obj.IPDZ = txtIP.Text;
                    obj.ZWYM = txtYM.Text;
                    obj.MRWG = txtWG.Text;
                    obj.FDNS = txtFDNS.Text;
                    obj.SDNS = txtSDNS.Text;
                    obj.Name = txtName.Text;
                    xmlhelper.UpdateNode("IP", tvIP.SelectedNode.Text, obj);
                    tvIP.SelectedNode.Text = obj.Name;
                    IsHaved = true;
                }
            }
            else
            {
                foreach (var node in tvIP.Nodes)
                {
                    if (node.Text == txtName.Text)
                    {
                        IsHaved = true;
                        Models.IP obj = node.Tag as Models.IP;
                        obj.IPDZ = txtIP.Text;
                        obj.ZWYM = txtYM.Text;
                        obj.MRWG = txtWG.Text;
                        obj.FDNS = txtFDNS.Text;
                        obj.SDNS = txtSDNS.Text;
                        xmlhelper.UpdateNode("IP", node.Text, obj);
                    }
                }
            }
            if (!IsHaved)
            {
                Models.IP obj = new Models.IP
                {
                    IPDZ = txtIP.Text,
                    ZWYM = txtYM.Text,
                    MRWG = txtWG.Text,
                    FDNS = txtFDNS.Text,
                    SDNS = txtSDNS.Text,
                    Name = txtName.Text
                };
                RadTreeNode node = new RadTreeNode
                {
                    Text = obj.Name,
                    Tag = obj
                };
                tvIP.Nodes.Add(node);
                xmlhelper.AppendNode(obj);
            }
            #endregion
            RefreshTree();
            if (cbTogether.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                BtApply_Click(null, null);
        }

        private void BtApply_Click(object sender, EventArgs e)
        {
            if (!Valid())
                return;
            #region 修改网络参数
            DialogResult ds = MessageBox.Show("会将当前全部连接修改为配置信息，如果同时连接了 WIFI和有线 请断开不需要配置的！，了解后继续", "注意", MessageBoxButtons.OKCancel);
            if (ds != DialogResult.OK)
                return;
            ManagementBaseObject inPar = null;
            ManagementBaseObject outPar = null;
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

    enum IPenum
    {
        NAME = 0,
        IPDZ = 1,
        ZWYM = 2,
        MRWG = 3,
        FDNS = 4,
        SDNS = 5
    }
}
