using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapstoneSIMS
{
    public class Helper
    {

        public static void LetterOnly(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsNumber(e.KeyChar) && !char.IsPunctuation(e.KeyChar) || e.KeyChar == '!' || e.KeyChar == '@' || e.KeyChar == '#' || e.KeyChar == '$' || e.KeyChar == '%' || e.KeyChar == '&' || e.KeyChar == '*' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '=' || e.KeyChar == '_' || e.KeyChar == '+' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '{' || e.KeyChar == '}' || e.KeyChar == ';' || e.KeyChar == ':' || e.KeyChar == '"' || e.KeyChar == ',' || e.KeyChar == '.' || e.KeyChar == '<' || e.KeyChar == '>' || e.KeyChar == '/' || e.KeyChar == '?')
            {
                e.Handled = true;
            }
        }

        public static void NumberOnly(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public static bool IsNullOrEmpty(params string[] strs)
        {
            foreach (var str in strs)
            {
                if (string.IsNullOrEmpty(str))
                    return true;
            }
            return false;
        }

        public static string AppPath => Application.StartupPath + @"\dbImg\";
    }
}
