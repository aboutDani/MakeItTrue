using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeItTrue.View
{
    public partial class Benvenuto : Form
    {
        public Benvenuto()
        {
            InitializeComponent();
        }
        public Button menuButton
        { 
            get { return this.menuButt; }
        }

        // Variabili per creazione effetto titolo
        int contatore = 0;
        int len = 0;
        string text;
        private void Benvenuto_Load(object sender, EventArgs e)
        {
            menuButton.Hide();
            text = titolo.Text;
            len = text.Length;
            titolo.Text = "";
            timerTitolo.Start();
        }

        // Timer per creare effetto titolo del gioco (MakeItTrue)
        private void TimerTitolo_Tick(object sender, EventArgs e)
        {
            titolo.Text = text.Substring(0, contatore);
            ++contatore;

            if (contatore > len)
            {
                menuButton.Show();
                timerTitolo.Stop();
            }
        }
    }
}
