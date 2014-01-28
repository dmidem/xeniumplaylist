using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XeniumPlaylist
{
    public partial class InputBox : Form
    {
        public static string Show(string caption, string label, string text)
        {
            InputBox inputBox = new InputBox();
            inputBox.Text = caption;
            inputBox.lblInput.Text = label;
            inputBox.txtInput.Text = text;
            if (inputBox.ShowDialog() == DialogResult.OK)
                return inputBox.txtInput.Text;
            else
                return "";
        }

        public InputBox()
        {
            InitializeComponent();
        }
    }
}
