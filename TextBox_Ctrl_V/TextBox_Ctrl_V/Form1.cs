using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TextBox_Ctrl_V
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            //https://dotblogs.com.tw/chou/2011/12/20/62709
            //http://www.cnblogs.com/han1982/p/4770270.html
            //https://fredxxx123.wordpress.com/2008/11/22/c-%E8%A4%87%E8%A3%BD%E8%B3%87%E6%96%99%E5%88%B0%E5%89%AA%E8%B2%BC%E7%B0%BF/
            //https://social.msdn.microsoft.com/Forums/zh-TW/3cc1d2be-5be7-4388-831e-2b5485b3b509/-textbox-?forum=233
            if (e.KeyData == (Keys.Control | Keys.A))
            {
                textBox1.SelectAll();
            }
            if (e.KeyData == (Keys.Control | Keys.C))
            {
                //MessageBox.Show("Ctrl + C");
                Clipboard.SetData(DataFormats.Text, textBox1.Text);
            }
            if (e.KeyData == (Keys.Control | Keys.V))//偵測Ctrl+v
            {
                //MessageBox.Show("Ctrl + V");
                if (Clipboard.ContainsText())
                {
                    try
                    {
                        Convert.ToInt64(Clipboard.GetText());  //检查是否数字
                        ((TextBox)sender).SelectedText = Clipboard.GetText().Trim(); //Ctrl+V 粘贴  
                        if (((TextBox)sender).TextLength > 10)
                        {
                            ((TextBox)sender).Text = ((TextBox)sender).Text.Remove(10); //TextBox最大长度为10  移除多余的
                        }
                    }
                    catch (Exception)
                    {
                        e.Handled = true;
                        //throw;
                    }
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)//只允许输入数字，粘贴数字
        {//http://www.cnblogs.com/han1982/p/4770270.html
            
            if (!(Char.IsNumber(e.KeyChar) || e.KeyChar == (char)8))
            {
                e.Handled = true;
            }
        }
    }
}
