using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace MySansWriter
{
    public partial class Form1 : Form
    {
        public class RH
        {
            public Keys key;
            public bool control;
            public bool alt;
            public string text;
            public RH()
            {
            }

            public RH(Keys k, bool c, bool a, string t)
            {
                key = k;
                control = c;
                alt = a;
                text = t;
            }
        };

        public RH[] map = new RH[]{
            new RH(Keys.A, true, false, "ā"),
            
            new RH(Keys.D, false, true, "ḍ"),
            
            new RH(Keys.H, false, true, "ḥ"),
            
            new RH(Keys.I, true, false, "ī"),
            
            new RH(Keys.L, false, true, "ḷ"),
            new RH(Keys.L, true, false, "ḹ"),
            
            new RH(Keys.M, true, false, "ṁ"),
            new RH(Keys.M, false, true, "ṃ"),
            
            new RH(Keys.N, true, false, "ṅ"),
            new RH(Keys.N, false, true, "ṇ"),
            new RH(Keys.N, true, true, "ñ"),

            new RH(Keys.R, true, false, "ṝ"),
            new RH(Keys.R, false, true,"ṛ"),
            
            new RH(Keys.S, false, true, "ṣ"),
            new RH(Keys.S, true, false, "ś"),
            
            new RH(Keys.T, false, true, "ṭ"),
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void richTextBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C && e.Alt == false && e.Control == true)
            {
                e.Handled = true;
                int start = richTextBox1.SelectionStart;
                int length = richTextBox1.SelectionLength;
                richTextBox1.SelectAll();
                richTextBox1.Copy();
                richTextBox1.SelectionStart = start;
                richTextBox1.SelectionLength = length;
                return;
            }

            //Debugger.Log(0, "", "KeyDown: " + e.KeyCode.ToString() + ", C: " + e.Control + ", A: " + e.Alt + "\n");
            foreach (RH rh in map)
            {
                //Debugger.Log(0, "", "  TEST: " + rh.key.ToString() + ", C: " + rh.control + ", A: " + rh.alt + "\n");
                if (rh.key == e.KeyCode && rh.alt == e.Alt && rh.control == e.Control)
                {
                    //Debugger.Log(0, "", "    HIT: " + rh.text + "\n");
                    e.Handled = true;
                    richTextBox1.SelectedText = rh.text;
                    break;
                }
            }
        }

        private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            //Debugger.Log(0, "", "KeyUp: " + e.KeyCode.ToString() + "\n");
        }
    }
}
