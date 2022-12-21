using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace лаба_11
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

        public bool Exist()
        {
            if (r.IsMatch(text.ToLower()))
            {
                Console.WriteLine("Текст содержит фрагменты, соответствующие шаблону");
                return r.IsMatch(text);
            }
            else
            {
                Console.WriteLine("Текст не содержит фрагменты, соответствующие шаблону");
                return false;
            }
        }

        public void ShowMatches()
        {
            MatchCollection m = r.Matches(text.ToLower());
            foreach (Match x in m)
                Console.Write(x.Value + " ");
        }

        public string DeleteMatches()
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
            Console.WriteLine(text);
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

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите ваш текст: ");
            string text = Console.ReadLine();
            Console.Write("Введите фрагмент текста: ");
            string pattern = Console.ReadLine();
            RegExp A = new RegExp(pattern, text);
            A.Exist();
            Console.WriteLine("Фрагменты, соответствующие шаблону:");
            A.ShowMatches();
            Console.WriteLine("\nОставшийся текст, не соответствующий шаблону:");
            A.Text = A.DeleteMatches();
        }
    }
}
