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

        public int[,] tab_bitRate = new int[6,16]
            {
                { 0, 32, 64, 96, 128, 160, 192, 224, 256, 288, 320, 352, 384, 416, 448, 0 },
                { 0, 32, 48, 56,  64,  80,  96, 112, 128, 160, 192, 224, 256, 320, 384, 0 },
                { 0, 32, 40, 48,  56,  64,  80,  96, 112, 128, 160, 192, 224, 256, 320, 0 },
                { 0, 32, 64, 96, 128, 160, 192, 224, 256, 288, 320, 352, 384, 416, 448, 0 },
                { 0, 32, 48, 56,  64,  80,  96, 112, 128, 160, 192, 224, 256, 320, 384, 0 },
                { 0,  8, 16, 24,  32,  64,  80,  56,  64, 128, 160, 112, 128, 256, 320, 0 }

            };

        public class FRAME
        {
            public byte HEAD_1;
            public byte HEAD_2;
            public byte HEAD_3;
            public byte HEAD_4;

            public string music_type;

            public byte MPEG_X;
            public byte layer_X;
            public byte CRC_EXSIT;
            public int bit_rate;
            public int sample_rate;
            public byte extra_one_byte;

            public byte channel_mode;
            public byte extra_channel_mode;
            public int Start_pos; //帧起始位置

            public bool b_showInfo;

        }
        private FRAME frame = new FRAME();


        List<Byte> m_list = new List<byte>();
        List<Byte> m_output_list = new List<byte>();
        long m_fileSize = 0;

        private void button_import_file_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (m_list.Count > 0)
                {
                    m_list.Clear();
                }
                if (m_output_list.Count > 0)
                {
                    m_output_list.Clear();
                }
                frame = new FRAME(); //重新在获取一个FRAME，之前的留给垃圾回收

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

                //显示音乐信息
                show_music_info();
                if (frame.music_type == "MP3")
                {
                    frame.Start_pos = 45;    //第一帧的数据在45
                    parse_frame(frame.Start_pos);

                    //将第二帧的数据作为app面板信息
                    frame.b_showInfo = true;
                    parse_frame(frame.Start_pos);

                    //解析剩余数据
                    for (; ; )
                    {
                        if (frame.Start_pos >= m_list.Count)
                        {
                            break;
                        }
                        parse_frame(frame.Start_pos);
                    }
                }
                

                MessageBox.Show("Load file successful!");
            }
        }


        private void parse_frame(int startPos)
        {
            if (m_list.Count > 0)
            {
                frame.HEAD_1 = m_list[startPos+0];
                frame.HEAD_2 = m_list[startPos+1];
                frame.HEAD_3 = m_list[startPos+2];
                frame.HEAD_4 = m_list[startPos+3];

                //如果前11位都为1
                if ((frame.HEAD_1 == 0xFF) && (Convert.ToByte(frame.HEAD_2 & 0xE0) == 0xE0))
                {
                    string V_X = "";
                    string L_X = "";
                    string tmp_str = "";

                    frame.Start_pos = startPos;  //第一帧的起始位置为45

                    //获取MPEG的版本
                    #region
                    frame.MPEG_X = Convert.ToByte((frame.HEAD_2 & 0x18) >> 3);
                    if (frame.MPEG_X == 3)   // 000 11 000
                    {
                        tmp_str = "MPEG1";
                        V_X = "V1";
                    }
                    else if (frame.MPEG_X == 0)   // 000 00 000
                    {
                        tmp_str = "MPEG2.5";
                        V_X = "V2.5";
                    }
                    else if (frame.MPEG_X == 1)   // 000 01 000
                    {
                        tmp_str = "unknown";
                        V_X = "unknown";
                    }
                    else if (frame.MPEG_X == 2)   // 000 10 000
                    {
                        tmp_str = "MPEG2";
                        V_X = "V2";
                    }
                    if (frame.b_showInfo)   //更新MPEG
                    {
                        label_version.Text = tmp_str;
                    }
                    #endregion

                    //获取layer
                    #region
                    frame.layer_X = Convert.ToByte((frame.HEAD_2 & 0x03) >> 1);
                    if (frame.layer_X == 3)  // 0000 0 11 0
                    {
                        tmp_str = "layer1";
                        L_X = "L1";
                    }
                    else if (frame.layer_X == 0)  // 0000 0 00 0
                    {
                        tmp_str = "unknown";
                        L_X = "unknown";
                    }
                    else if (frame.layer_X == 1)  // 0000 0 01 0
                    {
                        tmp_str = "layer3";
                        L_X = "L3";
                    }
                    else if (frame.layer_X == 2)  // 0000 0 10 0
                    {
                        tmp_str = "layer2";
                        L_X = "L2";
                    }
                    if (frame.b_showInfo)  //更新layer
                    {
                        label_layer.Text = tmp_str;
                    }
                    #endregion

                    //获取CRC校验，作为判断
                    #region
                    frame.CRC_EXSIT = Convert.ToByte(frame.HEAD_2 & 0x01);
                    if (frame.CRC_EXSIT == 0x00)
                    {
                        tmp_str = "校验";
                        return;
                    }
                    else if (frame.CRC_EXSIT == 0x01)
                    {
                        tmp_str = "不校验";
                    }
                    if (frame.b_showInfo)    //更新CRC
                    {
                        label_CRC.Text = tmp_str;
                    }
                    #endregion

                    //获取bit rate
                    frame.bit_rate = get_bit_rate(V_X, L_X, frame.HEAD_3);
                    if (frame.b_showInfo)     //更新bit rate
                    {
                        label_bit_rate.Text = frame.bit_rate.ToString() + "kbps";
                    }
                    

                    //获取sample rate
                    #region
                    int sampRate_index = Convert.ToInt32((frame.HEAD_3 & 0x0C) >> 2);
                    if (sampRate_index == 0)
                    {
                        frame.sample_rate = 44100;
                        tmp_str = "44.1KHz";
                    }
                    else if (sampRate_index == 1)
                    {
                        frame.sample_rate = 48000;
                        tmp_str = "48KHz";
                    }
                    else if (sampRate_index == 2)
                    {
                        frame.sample_rate = 32000;
                        tmp_str = "32KHz";
                    }
                    else if (sampRate_index == 3)
                    {
                        frame.sample_rate = 0;   //未定义
                        tmp_str = "unknown";
                        return;
                    }
                    if (frame.b_showInfo)   //更新 bit rate
                    {
                        label_sample_rate.Text = tmp_str;
                    }
                    #endregion

                    //获取调节帧长
                    frame.extra_one_byte = Convert.ToByte((frame.HEAD_3 & 0x20) >> 1);
                    if (frame.b_showInfo)   //更新 调节帧长
                    {
                        label_extra_one_byte.Text = frame.extra_one_byte.ToString();
                    }

                    //获取声道模式
                    #region
                    frame.channel_mode = Convert.ToByte((frame.HEAD_4 & 0xC0) >> 6);
                     
                    if (frame.channel_mode == 0)
                    {
                        tmp_str = "立体声stereo";
                    }
                    else if (frame.channel_mode == 1)
                    {
                        tmp_str = "Joint stereo";
                    }
                    else if (frame.channel_mode == 2)
                    {
                        tmp_str = "双声道";
                    }
                    else if (frame.channel_mode == 3)
                    {
                        tmp_str = "单声道";
                    }
                    if (frame.b_showInfo)   //更新 声道模式
                    {
                        label_channel_mode.Text = tmp_str;
                    }
                    #endregion

                    //获取扩充模式
                    #region
                    if (frame.channel_mode == 1)
                    {
                        frame.extra_channel_mode = Convert.ToByte((frame.HEAD_4 & 0x30) >> 4);
                        if (frame.extra_channel_mode == 0)
                        {
                            tmp_str = "强度立体声off,MS立体声off";
                        }
                        else if (frame.extra_channel_mode == 1)
                        {
                            tmp_str = "强度立体声on,MS立体声off";
                        }
                        else if (frame.extra_channel_mode == 2)
                        {
                            tmp_str = "强度立体声off,MS立体声on";
                        }
                        else if (frame.extra_channel_mode == 3)
                        {
                            tmp_str = "强度立体声on,MS立体声on";
                        }
                        if (frame.b_showInfo)   //更新 声道模式
                        {
                            label_extar_channel_mode.Text = tmp_str;
                        }
                    }
                    #endregion

                    //获取下一帧的位置
                    #region
                    double factor = 0;
                    if (V_X == "V1")
                    {
                        if (L_X == "L3" || L_X == "L2")
                        {
                            factor = 144000;
                        }
                        else if (L_X == "L1")
                        {
                            factor = 48000;
                        }
                    }
                    else if (V_X == "V2")
                    {
                        if (L_X == "L3" || L_X == "L2")
                        {
                            factor = 72000;
                        }
                        else if (L_X == "L1")
                        {
                            factor = 24000;
                        }
                    }
                    frame.Start_pos += Convert.ToInt32(Math.Ceiling(factor * ((double)frame.bit_rate) / ((double)frame.sample_rate)));
                    #endregion

                    //app面板更新数据，base on 第二帧数据
                    if (frame.b_showInfo)
                    {
                        frame.b_showInfo = false;
                    }

                    //将信息挂入m_output_list
                    for (int i = startPos + 4; i < frame.Start_pos; i++)
                    {
                        m_output_list.Add(m_list[i]);
                    }
                }
            }
        }

        private int get_bit_rate(string V_X, string L_X, byte HEAD_3)
        {
            int row_index = 0;
            if (V_X == "V1" && L_X == "L1")
            {
                row_index = 0;
            }
            else if (V_X == "V1" && L_X == "L2")
            {
                row_index = 1;
            }
            else if (V_X == "V1" && L_X == "L3")
            {
                row_index = 2;
            }
            else if (V_X == "V2" && L_X == "L1")
            {
                row_index = 3;
            }
            else if (V_X == "V2" && L_X == "L2")
            {
                row_index = 4;
            }
            else if (V_X == "V2" && L_X == "L3")
            {
                row_index = 5;
            }

            int col_index=Convert.ToInt32((HEAD_3 & 0xF0) >> 4);
            return tab_bitRate[row_index,col_index];
        }

        private void clear_labels()
        {
            label_version.Text = "/";
            label_sample_rate.Text = "/";
            label_music_type.Text = "/";
            label_layer.Text = "/";
            label_extra_one_byte.Text = "/";
            label_extar_channel_mode.Text = "/";
            label_CRC.Text = "/";
            label_channel_mode.Text = "/";
            label_bit_rate.Text = "/";
        }

        private void show_music_info()
        {
            clear_labels();


            //throw new NotImplementedException();
            if (m_list[0] == 'I' && m_list[1] == 'D' && m_list[2] == '3')
            {
                if (m_list[3] == 0x01)
                {
                    label_music_type.Text = "MP1";
                    frame.music_type = "MP1";
                }
                else if (m_list[3] == 0x02)
                {
                    label_music_type.Text = "MP2";
                    frame.music_type = "MP2";
                }
                else if (m_list[3] == 0x03)
                {
                    label_music_type.Text = "MP3";
                    frame.music_type = "MP3";
                }
                else
                {
                    //do nothing
                }
            
            }
            else if (m_list[0] == 'R' && m_list[1] == 'I' && m_list[2] == 'F' && m_list[3] == 'F'
                && m_list[8] == 'W' && m_list[9] == 'A' && m_list[10] == 'V')
            {
                label_music_type.Text = "WAV";
                frame.music_type = "WAV";
            }
            else
            {
                label_music_type.Text = "unknown";
                frame.music_type = "unknown";
            }
        }

        private void button_generate_C_file_Click(object sender, EventArgs e)
        {
            if (m_list.Count > 0 && frame.music_type == "WAV")
            {
                if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    var path = this.folderBrowserDialog1.SelectedPath;

                    //写配置文件1
                    FileStream fs = new FileStream(path + @"\" + "WAV.c", FileMode.Create);
                    StreamWriter sw = new StreamWriter(fs, Encoding.Default);

                    string str = "#define ALARM_XXXX_SIZE     " + "(" + m_list.Count.ToString() + "-78)" + "\r\n";
                    sw.WriteLine(str);

                    //string str = "const uint8_t DATA[]={";
                    str = "const uint8_t XXXX_DATA[" + m_list.Count.ToString() + "-78]={";
                    sw.WriteLine(str);

                    //0-77个字节都不是真正的数据，要去掉

                    for (int i = 0; i < 4; i++)
                    {
                        string strTemp = "";
                        for (int j = 0; j < 16; j++)
                        {
                            strTemp += "0x" + ConBverInt2Hex(m_list[i * 16 + j]) + ",";
                        }
                        sw.WriteLine("//  " + strTemp);
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
            else if (m_output_list.Count > 0 && frame.music_type == "MP3")
            {
                if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    var path = this.folderBrowserDialog1.SelectedPath;

                    //写配置文件1
                    FileStream fs = new FileStream(path + @"\" + "MP3.c", FileMode.Create);
                    StreamWriter sw = new StreamWriter(fs, Encoding.Default);

                    //string str = "#define ALARM_XXXX_SIZE     " + m_output_list.Count.ToString() + "\r\n";
                    //sw.WriteLine(str);

                    //str = "const uint8_t XXXX_DATA[" + m_output_list.Count.ToString() + "]={";
                    //sw.WriteLine(str);

                    //long row_size = m_output_list.Count / 16;
                    //for (int i = 0; i < row_size; i++)
                    //{
                    //    string strTemp = "";
                    //    for (int j = 0; j < 16; j++)
                    //    {
                    //        strTemp += "0x" + ConBverInt2Hex(m_output_list[i * 16 + j]) + ",";
                    //    }
                    //    sw.WriteLine(strTemp);
                    //}

                    ////如果还有剩余
                    //int rest = m_output_list.Count % 16;
                    //if (rest > 0)
                    //{
                    //    string strTemp = "";
                    //    for (int i = 0; i < rest; i++)
                    //    {
                    //        strTemp += "0x" + ConBverInt2Hex(m_output_list[i]) + ",";
                    //    }
                    //    sw.WriteLine(strTemp);
                    //}
                    string str = "#define ALARM_XXXX_SIZE     " + m_list.Count.ToString() + "\r\n";
                    sw.WriteLine(str);

                    str = "const uint8_t XXXX_DATA[" + m_list.Count.ToString() + "]={";
                    sw.WriteLine(str);
                    long row_size = m_list.Count / 16;
                    for (int i = 0; i < row_size; i++)
                    {
                        string strTemp = "";
                        for (int j = 0; j < 16; j++)
                        {
                            strTemp += "0x" + ConBverInt2Hex(m_list[i * 16 + j]) + ",";
                        }
                        sw.WriteLine(strTemp);
                    }

                    //如果还有剩余
                    int rest = m_list.Count % 16;
                    if (rest > 0)
                    {
                        string strTemp = "";
                        for (int i = 0; i < rest; i++)
                        {
                            strTemp += "0x" + ConBverInt2Hex(m_list[i]) + ",";
                        }
                        sw.WriteLine(strTemp);
                    }

                    sw.WriteLine("};");

                    sw.Close();
                    fs.Close();
                    MessageBox.Show("MP3.c generate successful!");
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
