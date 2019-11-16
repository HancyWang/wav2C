using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WAV2C
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Byte> m_list = new List<byte>();
        long m_fileSize = 0;

        private void button_import_file_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (m_list.Count > 0)
                {
                    m_list.Clear();
                }
                //this.textBox_paraCfgFilePath.Text = this.openFileDialog1.FileName;
                FileStream fs = new FileStream(this.openFileDialog1.FileName, FileMode.Open);
                BinaryReader br = new BinaryReader(fs, Encoding.ASCII);

                byte bt = new byte();

                //System.Diagnostics.FileVersionInfo info=System.Diagnostics.FileVersionInfo.GetVersionInfo(this.openFileDialog1.FileName);

                //获取文件信息
                FileInfo fileInfo = new System.IO.FileInfo(this.openFileDialog1.FileName);

                //根据文件长度(size)，将二进制内容放入链表中
                m_fileSize = fileInfo.Length;
                for (long i = 0; i < m_fileSize; i++)
                {
                    bt = br.ReadByte();
                    m_list.Add(bt);
                }

                br.Close();
                fs.Close();
                MessageBox.Show("Load file successful!");
            }

        }

        private void button_generate_C_file_Click(object sender, EventArgs e)
        {
            if (m_list.Count > 0)
            {
                if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    var path = this.folderBrowserDialog1.SelectedPath;

                    //写配置文件1
                    FileStream fs = new FileStream(path + @"\" + "WAV.c", FileMode.Create);
                    StreamWriter sw = new StreamWriter(fs, Encoding.Default);

                    string str = "#define ALARM_XXXX_SIZE     "+"("+ m_list.Count.ToString()+"-78)"+"\r\n";
                    sw.WriteLine(str);
                   
                    //string str = "const uint8_t DATA[]={";
                    str = "const uint8_t XXXX_DATA["+m_list.Count.ToString()+ "-78]={";
                    sw.WriteLine(str);

                    //0-77个字节都不是真正的数据，要去掉
                   
                    for (int i = 0; i < 4; i++)
                    {
                        string strTemp = "";
                        for (int j = 0; j < 16; j++)
                        {
                            strTemp += "0x" + ConBverInt2Hex(m_list[i * 16 + j]) + ",";
                        }
                        sw.WriteLine("//  "+strTemp);
                    }

                    int cur_index = 4; //第四行要去掉前面14个数据
                    string str_1 = "";
                    for (int j = 0; j < 14; j++)
                    {
                        str_1 += "0x" + ConBverInt2Hex(m_list[cur_index * 16 + j]) + ",";
                    }
                    sw.WriteLine("//  " + str_1);

                    //保留第四行的14,15字节数据
                    str_1 = "";
                    str_1 += ConBverInt2Hex(m_list[cur_index * 16 + 14]) + "," + ConBverInt2Hex(m_list[cur_index * 16 + 15]) + ",";
                    sw.WriteLine(str_1);



                    for (int i = 6; i < m_fileSize / 16; i++)
                    {
                        string strTemp = "";
                        for (int j = 0; j < 16; j++)
                        {
                            strTemp += "0x" + ConBverInt2Hex(m_list[i * 16 + j]) + ",";
                        }
                        //strTemp += "\n";
                        sw.WriteLine(strTemp);
                    }

                    int rest = (int)(m_fileSize % 16);
                    if (rest > 0)
                    {
                        string strTemp = "";
                        for (int i = 0; i < rest; i++)
                        {
                            strTemp += "0x" + ConBverInt2Hex(m_list[((int)m_fileSize / 16) * 16 + i]) + ",";
                        }
                        //strTemp += "\n";
                        sw.WriteLine(strTemp);
                    }

           
                    sw.WriteLine("};");

                    sw.Close();
                    fs.Close();
                    MessageBox.Show("WAV.c generate successful!");
                }
            }
            else
            {
                MessageBox.Show("Please load file first!");
            }
        }

        string ConBverInt2Hex(byte bt)
        {
            string tmp = null;
            Int32 a = Convert.ToInt32(bt) / 16;
            Int32 b = Convert.ToInt32(bt) % 16;
            //tmp += Convert.ToString(a);
            if (a == 10)
            {
                tmp += "A";
            }
            else if (a == 11)
            {
                tmp += "B";
            }
            else if (a == 12)
            {
                tmp += "C";
            }
            else if (a == 13)
            {
                tmp += "D";
            }
            else if (a == 14)
            {
                tmp += "E";
            }
            else if (a == 15)
            {
                tmp += "F";
            }
            else
            {
                tmp += Convert.ToString(a);
            }

            if (b == 10)
            {
                tmp += "A";
            }
            else if (b == 11)
            {
                tmp += "B";
            }
            else if (b == 12)
            {
                tmp += "C";
            }
            else if (b == 13)
            {
                tmp += "D";
            }
            else if (b == 14)
            {
                tmp += "E";
            }
            else if (b == 15)
            {
                tmp += "F";
            }
            else
            {
                tmp += Convert.ToString(b);
            }
            return tmp;
        }
    }
}
