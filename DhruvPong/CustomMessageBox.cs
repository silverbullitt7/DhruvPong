using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DhruvPong
{
    public partial class CustomMessageBox : Form
    {
        int player1score = 0;
        int player2score = 0;
        public CustomMessageBox()
        {

            if (player1score > 6)
            {
                Tex.Show("Player 1 Won!");
                Close();
            }
            else if (player2score > 6)
            {
                MessageBox.Show("Player 2 Won!");
                Close();
            }

            InitializeComponent();
        }
    }
}
