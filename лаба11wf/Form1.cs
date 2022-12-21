using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace лаба11wf
{

    public partial class Form1 : Form
    {
        class RegExp
        {
            

           public RegExp(string pattern, string txt)
        {
            r = new Regex(pattern.ToLower());
            text = txt;
        }
        private Regex r;
        private string text;

            public bool Exist(TextBox textBox)
            {
                if (r.IsMatch(text.ToLower()))
                {
                    textBox.Text = "Да";
                    return r.IsMatch(text);
                }
                else
                {
                    textBox.Text = "Нет";
                    return false;
                }
            }

            public void ShowMatches(TextBox textBox)
            {
                MatchCollection m = r.Matches(text.ToLower());
                foreach (Match x in m)
                    textBox.Text += $"{x.Value} ";
            }

            public string DeleteMatches(TextBox textBox)
            {
                MatchCollection m = r.Matches(text.ToLower());
                string s = text.ToLower();
                foreach (Match x in m)
                {
                    int i = s.IndexOf(x.Value);
                    int l = x.Value.Length;
                    s = s.Remove(i, l);
                    text = text.Remove(i, l);
                }
                textBox.Text += text;
                return s;
            }

            public Regex R
            {
                get { return r; }
                set { r = value; }
            }

            public string Text
            {
                get { return text; }
                set { text = value; }
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            textBox4.Text = "";
            string pattern = textBox1.Text;
            string text = textBox2.Text;
            RegExp A = new RegExp(text, pattern);
            A.Exist(textBox5);
            A.ShowMatches(textBox3);
            A.Text = A.DeleteMatches(textBox4);
        }
    }
}
