using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zkGui
{
    public partial class DigestHelperForm : Form
    {
        public DigestHelperForm()
        {
            InitializeComponent();
        }

        private void buttonCalc_Click(object sender, EventArgs e)
        {
            using (SHA1 sha1 = SHA1.Create())
            {
                textBoxExpression.Text = $"{textBoxUser.Text}:{Convert.ToBase64String(sha1.ComputeHash(Encoding.Default.GetBytes($"{textBoxUser.Text}:{textBoxPwd.Text}")))}";
            }
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBoxExpression.Text);
            MessageBox.Show("Copied.");
        }
    }
}
