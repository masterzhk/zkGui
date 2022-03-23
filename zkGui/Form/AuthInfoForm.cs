using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zkGui
{
    public partial class AuthInfoForm : Form
    {
        public string Scheme
        {
            get
            {
                return textBoxScheme.Text;
            }
        }
        public byte[] Auth
        {
            get
            {
                return Encoding.Default.GetBytes(textBoxAuth.Text);
            }
        }

        public AuthInfoForm()
        {
            InitializeComponent();
        }
    }
}
