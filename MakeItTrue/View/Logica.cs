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
    public partial class Logica : Form
    {
        public Logica()
        {
            InitializeComponent();
        }
        // Immagine quesito
        public PictureBox immagine { get { return this.pictureBox1; } }
        // Risposte
        public Button risposta1 { get { return this.answer1Butt; } }
        public Button risposta2 { get { return this.answer2Butt; } }
        public Button risposta3 { get { return this.answer3Butt; } }
        public Button risposta4 { get { return this.answer4Butt; } }
        public Button risposta5 { get { return this.answer5Butt; } }
        // Avanti al prossimo quesito
        public Button prossimo { get { return this.ProssimoButt; } }
        // Riprova 
        public Button nuova { get { return this.newButt; } }
        // Suggerimento
        public Button suggerimento { get { return this.solutionButt; } }
        // Punteggio per quesito esatto
        public TextBox quesitoEsatto { get { return this.quesEsattoTextBox; } }
        // Contatore quesiti
        public TextBox numQuesitoAttuale { get { return this.textBoxNumQuesito; } }
        // Timer
        public Timer timer { get { return this.timer1; } }
       
        
        // Gestione del Click prossimo quesito
        private void ProssimaButt_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();
        }
        
        // Timer principale con personalizzazione colore barra
        private void Timer1_Tick(object sender, EventArgs e)
        {
            // Scorrere del tempo con aumento di 1 nella barra
            panel1.Width += 1;

            // Cambio di colore della barra del tempo come avviso
            if (panel1.Width == 467)
                panel1.BackColor = Color.Yellow;

            if (panel1.Width >= 589)
            {
                timer1.Stop();
                // Tempo scaduto risposte bloccate e messaggio al giocatore
                MessageBox.Show("Tempo finito. Riprova!");
                risposta1.Enabled = false;
                risposta2.Enabled = false;
                risposta3.Enabled = false;
                risposta4.Enabled = false;
                risposta5.Enabled = false;
            }
        }

        // Riavviare il timer e ripristinare colore della barra
        public void RiavviaTimer()
        {
            panel1.Width = 5;
            panel1.BackColor = Color.SteelBlue;
        }

        // Timer per livello 3 con aumento di 50 ogni risposta errata
        public void TimerLivello3()
        {
            panel1.Width += 50;
            // Cambio di colore della barra del tempo come avviso
            if (panel1.Width >= 467)
                panel1.BackColor = Color.Yellow;
        }

        // Chiusura del form da parte del giocatore e quindi fermare il timer principale per evitare errori
        private void Logica_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
        }

        // Tornare indietro al menu
        private void Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
