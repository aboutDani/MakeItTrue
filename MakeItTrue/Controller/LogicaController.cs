using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MakeItTrue.View;
using System.Windows.Forms;
using MakeItTrue.Model;
using System.Drawing;

namespace MakeItTrue.Controller
{
    class LogicaController
    {
        private Logica logica;
        private Matematica mate = null;

        private int livelloGioco;
        private DecisioneGioco giocoLogica;
        private bool argomentoScelto;

        LogicaLivello1 logica1;
        LogicaLivello2 logica2;
        LogicaLivello3 logica3;

        // Inizializzazione informazioni quesiti
        private int numeroQuesito = 0;
        private int quesEsatto = 0;

        public LogicaController(bool argomento, int livello)
        {
            this.argomentoScelto = argomento;
            this.livelloGioco = livello;

            this.logica = new Logica();
            this.giocoLogica = new DecisioneGioco(argomentoScelto, livelloGioco, mate, logica);

            try
            {
                GiocoStart(livelloGioco);
                InizializzaEventi();
            }
            catch (Exception e)
            {
                MessageBox.Show("Errore nel caricamento del gioco logica " + e);
            }
        }

        // Inizio del gioco di Logica a seconda del livello scelto
        public void GiocoStart(int livello)
        {
            if (livello == 0)
            {
                this.logica1 = new LogicaLivello1();
            }
            else if (livello == 1)
            {
                this.logica2 = new LogicaLivello2();
            }
            else if (livello == 2)
            {
                this.logica3 = new LogicaLivello3();
            }
        }

        public void InizializzaEventi()
        {
            // Risposte e suggerimento disattivati in partenza
            this.logica.risposta1.Enabled = false;
            this.logica.risposta2.Enabled = false;
            this.logica.risposta3.Enabled = false;
            this.logica.risposta4.Enabled = false;
            this.logica.risposta5.Enabled = false;
            this.logica.suggerimento.Enabled = false;
            // Bottone nuova partita disattivato inizialmente
            this.logica.nuova.Enabled = false;
            // Contatore quesiti esatti
            this.logica.quesitoEsatto.Enabled = false;
            // Contatore quesito attuale
            this.logica.numQuesitoAttuale.Enabled = false;

            this.logica.risposta1.MouseClick += new MouseEventHandler(this.Risposta1Click);
            this.logica.risposta2.MouseClick += new MouseEventHandler(this.Risposta2Click);
            this.logica.risposta3.MouseClick += new MouseEventHandler(this.Risposta3Click);
            this.logica.risposta4.MouseClick += new MouseEventHandler(this.Risposta4Click);
            this.logica.risposta5.MouseClick += new MouseEventHandler(this.Risposta5Click);
            this.logica.suggerimento.MouseClick += new MouseEventHandler(this.SuggerimentoClick);
            this.logica.prossimo.MouseClick += new MouseEventHandler(this.ProssimoClick);
            this.logica.nuova.MouseClick += new MouseEventHandler(this.RitentareClick);
        }

        // Mostrare il Form Logica
        public void EsporreLogica()
        {
            this.logica.ShowDialog();
        }

       // Risposta 1
        public void Risposta1Click(object sender, EventArgs e)
        {
            // Verifica se la risposta 1 è quella esatta 
            if (this.giocoLogica.SoluzioneEsatta(numeroQuesito) == 1)
            {
                // Timer si ferma
                this.logica.timer.Stop();

                // Colore blu per il bottone con la risposta esatta e 
                // bottone prossima domanda attivato mentre disattivati gli altri
                this.logica.risposta1.BackColor = Color.SteelBlue;
                this.logica.prossimo.Enabled = true;
                this.logica.risposta1.Enabled = false;
                this.logica.risposta2.Enabled = false;
                this.logica.risposta3.Enabled = false;
                this.logica.risposta4.Enabled = false;
                this.logica.risposta5.Enabled = false;
                this.logica.suggerimento.Enabled = false;
                this.logica.quesitoEsatto.Enabled = false;

                // Se vengono scelte le risposte sbagliate non si effettua alcuna operazione
                if ((this.logica.risposta2.BackColor == Color.Yellow) || (this.logica.risposta3.BackColor == Color.Yellow) ||
                (this.logica.risposta4.BackColor == Color.Yellow) || (this.logica.risposta5.BackColor == Color.Yellow))
                {
                    // Nessun aumento di punteggio
                }
                else
                {
                    // Aumento di 1 per il TextBox dei quesiti esatti
                    quesEsatto++;
                    // Separazione del modo di visualizzare la stringa a seconda del livello dato che
                    // nel livello 1 e 2 sono 7 quesiti mentre nel livello 3 solo 5
                    if (livelloGioco == 2)
                        this.logica.quesitoEsatto.Text = "Corrette -> " + quesEsatto.ToString() + " / 5";
                    else
                        this.logica.quesitoEsatto.Text = "Corrette -> " + quesEsatto.ToString() + " / 7";
                }
            }
            // Risposta 1 è quella sbagliata
            else
            {
                // Color giallo perchè la risposta 1 è sbagliata
                this.logica.risposta1.BackColor = Color.Yellow;

                // Viene aggiunto del tempo di penale se il livello è quello difficile (3)
                if (this.livelloGioco == 2)
                {
                    this.logica.TimerLivello3();
                    // Bloccare il pulsante al giocatore in modo tale da non togliere altro tempo in caso
                    // il giocatore seleziona la stessa risposta sbagliata
                    this.logica.risposta1.Enabled = false;
                }
            }
        }

        // Risposta 2
        public void Risposta2Click(object sender, EventArgs e)
        {
            // Verifica se la risposta 2 è quella esatta 
            if (this.giocoLogica.SoluzioneEsatta(numeroQuesito) == 2)
            {
                // Timer si ferma
                this.logica.timer.Stop();

                // Colore blu per il bottone con la risposta esatta e 
                // bottone prossima domanda attivato mentre disattivati gli altri
                this.logica.risposta2.BackColor = Color.SteelBlue;
                this.logica.prossimo.Enabled = true;
                this.logica.risposta1.Enabled = false;
                this.logica.risposta2.Enabled = false;
                this.logica.risposta3.Enabled = false;
                this.logica.risposta4.Enabled = false;
                this.logica.risposta5.Enabled = false;
                this.logica.suggerimento.Enabled = false;
                this.logica.quesitoEsatto.Enabled = false;

                // Se vengono scelte le risposte sbagliate non si effettua alcuna operazione
                if ((this.logica.risposta1.BackColor == Color.Yellow) || (this.logica.risposta3.BackColor == Color.Yellow) ||
                    (this.logica.risposta4.BackColor == Color.Yellow) || (this.logica.risposta5.BackColor == Color.Yellow))
                {
                    // Nessun aumento di punteggio
                }
                else
                {
                    // Aumento di 1 per il TextBox dei quesiti esatti
                    quesEsatto++;
                    // Separazione del modo di visualizzare la stringa a seconda del livello dato che
                    // nel livello 1 e 2 sono 7 quesiti mentre nel livello 3 solo 5
                    if (livelloGioco == 2)
                        this.logica.quesitoEsatto.Text = "Corrette -> " + quesEsatto.ToString() + " / 5";
                    else
                        this.logica.quesitoEsatto.Text = "Corrette -> " + quesEsatto.ToString() + " / 7";
                }
            }
            else
            {
                this.logica.risposta2.BackColor = Color.Yellow;

                // Viene aggiunto del tempo di penale se il livello è quello difficile (3)
                if (this.livelloGioco == 2)
                {
                    this.logica.TimerLivello3();
                    // Bloccare il pulsante al giocatore in modo tale da non togliere altro tempo in caso
                    // il giocatore seleziona la stessa risposta sbagliata
                    this.logica.risposta2.Enabled = false;
                }
            }
        }

        // Risposta 3
        public void Risposta3Click(object sender, EventArgs e)
        {
            if (this.giocoLogica.SoluzioneEsatta(numeroQuesito) == 3)
            {
                // Timer si ferma
                this.logica.timer.Stop();

                // Colore blu per il bottone con la risposta esatta e 
                // bottone prossima domanda attivato mentre disattivati gli altri
                this.logica.risposta3.BackColor = Color.SteelBlue;
                this.logica.prossimo.Enabled = true;
                this.logica.risposta1.Enabled = false;
                this.logica.risposta2.Enabled = false;
                this.logica.risposta3.Enabled = false;
                this.logica.risposta4.Enabled = false;
                this.logica.risposta5.Enabled = false;
                this.logica.suggerimento.Enabled = false;
                this.logica.quesitoEsatto.Enabled = false;

                // Se vengono scelte le risposte sbagliate non si effettua alcuna operazione
                if ((this.logica.risposta1.BackColor == Color.Yellow) || (this.logica.risposta2.BackColor == Color.Yellow) ||
                    (this.logica.risposta4.BackColor == Color.Yellow) || (this.logica.risposta5.BackColor == Color.Yellow))
                {
                    // Nessun aumento di punteggio
                }
                else
                {
                    // Aumento di 1 per il TextBox dei quesiti esatti
                    quesEsatto++;
                    // Separazione del modo di visualizzare la stringa a seconda del livello dato che
                    // nel livello 1 e 2 sono 7 quesiti mentre nel livello 3 solo 5
                    if (livelloGioco == 2)
                        this.logica.quesitoEsatto.Text = "Corrette -> " + quesEsatto.ToString() + " / 5";
                    else
                        this.logica.quesitoEsatto.Text = "Corrette -> " + quesEsatto.ToString() + " / 7";
                }
            }
            else
            {
                this.logica.risposta3.BackColor = Color.Yellow;

                // Viene aggiunto del tempo di penale se il livello è quello difficile (3)
                if (this.livelloGioco == 2)
                {
                    this.logica.TimerLivello3();
                    // Bloccare il pulsante al giocatore in modo tale da non togliere altro tempo in caso
                    // il giocatore seleziona la stessa risposta sbagliata
                    this.logica.risposta3.Enabled = false;
                }
            }
        }

        // Risposta 4
        public void Risposta4Click(object sender, EventArgs e)
        {
            // Verifica se la risposta 4 è quella esatta 
            if (this.giocoLogica.SoluzioneEsatta(numeroQuesito) == 4)
            {
                // Timer si ferma
                this.logica.timer.Stop();

                // Colore blu per il bottone con la risposta esatta e 
                // bottone prossima domanda attivato mentre disattivati gli altri
                this.logica.risposta4.BackColor = Color.SteelBlue;
                this.logica.prossimo.Enabled = true;
                this.logica.risposta1.Enabled = false;
                this.logica.risposta2.Enabled = false;
                this.logica.risposta3.Enabled = false;
                this.logica.risposta4.Enabled = false;
                this.logica.risposta5.Enabled = false;
                this.logica.suggerimento.Enabled = false;
                this.logica.quesitoEsatto.Enabled = false;

                // Se vengono scelte le risposte sbagliate non si effettua alcuna operazione
                if ((this.logica.risposta1.BackColor == Color.Yellow) || (this.logica.risposta2.BackColor == Color.Yellow) ||
                    (this.logica.risposta3.BackColor == Color.Yellow) || (this.logica.risposta5.BackColor == Color.Yellow))
                {
                    // Nessun aumento di punteggio
                }
                else
                {
                    // Aumento di 1 per il TextBox dei quesiti esatti
                    quesEsatto++;
                    // Separazione del modo di visualizzare la stringa a seconda del livello dato che
                    // nel livello 1 e 2 sono 7 quesiti mentre nel livello 3 solo 5
                    if (livelloGioco == 2)
                        this.logica.quesitoEsatto.Text = "Corrette -> " + quesEsatto.ToString() + " / 5";
                    else
                        this.logica.quesitoEsatto.Text = "Corrette -> " + quesEsatto.ToString() + " / 7";
                }
            }
            else
            {
                this.logica.risposta4.BackColor = Color.Yellow;

                // Viene aggiunto del tempo di penale se il livello è quello difficile (3)
                if (this.livelloGioco == 2)
                {
                    this.logica.TimerLivello3();
                    // Bloccare il pulsante al giocatore in modo tale da non togliere altro tempo in caso
                    // il giocatore seleziona la stessa risposta sbagliata
                    this.logica.risposta4.Enabled = false;
                }

            }
        }

        // Risposta 5
        public void Risposta5Click(object sender, EventArgs e)
        {
            // Verifica se la risposta 5 è quella esatta 
            if (this.giocoLogica.SoluzioneEsatta(numeroQuesito) == 5)
            {
                // Timer si ferma
                this.logica.timer.Stop();

                // Colore blu per il bottone con la risposta esatta e 
                // bottone prossima domanda attivato mentre disattivati gli altri
                this.logica.risposta5.BackColor = Color.SteelBlue;
                this.logica.prossimo.Enabled = true;
                this.logica.risposta1.Enabled = false;
                this.logica.risposta2.Enabled = false;
                this.logica.risposta3.Enabled = false;
                this.logica.risposta4.Enabled = false;
                this.logica.risposta5.Enabled = false;
                this.logica.suggerimento.Enabled = false;
                this.logica.quesitoEsatto.Enabled = false;

                // Se vengono scelte le risposte sbagliate non si effettua alcuna operazione
                if ((this.logica.risposta1.BackColor == Color.Yellow) || (this.logica.risposta2.BackColor == Color.Yellow) ||
                    (this.logica.risposta3.BackColor == Color.Yellow) || (this.logica.risposta4.BackColor == Color.Yellow))
                {
                    // Nessun aumento di punteggio
                }
                else
                {
                    // Aumento di 1 per il TextBox dei quesiti esatti
                    quesEsatto++;
                    // Separazione del modo di visualizzare la stringa a seconda del livello dato che
                    // nel livello 1 e 2 sono 7 quesiti mentre nel livello 3 solo 5
                    if (livelloGioco == 2)
                        this.logica.quesitoEsatto.Text = "Corrette -> " + quesEsatto.ToString() + " / 5";
                    else
                        this.logica.quesitoEsatto.Text = "Corrette -> " + quesEsatto.ToString() + " / 7";
                }
            }
            else
            {
                this.logica.risposta5.BackColor = Color.Yellow;

                // Viene aggiunto del tempo di penale se il livello è quello difficile (3)
                if (this.livelloGioco == 2)
                {
                    this.logica.TimerLivello3();
                    // Bloccare il pulsante al giocatore in modo tale da non togliere altro tempo in caso
                    // il giocatore seleziona la stessa risposta sbagliata
                    this.logica.risposta5.Enabled = false;
                }
            }
        }

        // Suggerimento Logica
        public void SuggerimentoClick(object sender, EventArgs e)
        {
            {
                // Personalizzazione suggerimento
                this.logica.suggerimento.BackColor = Color.DarkGray;
                this.logica.suggerimento.Enabled = false;
            }
        }

        // Personalizzazione prossimo quesito
        public void ProssimoClick(object sender, EventArgs e)
        {
            // Livello 1 e 2
            if (this.livelloGioco == 0 || this.livelloGioco == 1)
            {
                try
                {
                    // Attivazione di tutti i bottoni
                    numeroQuesito++;
                    this.logica.risposta1.Enabled = true;
                    this.logica.risposta2.Enabled = true;
                    this.logica.risposta3.Enabled = true;
                    this.logica.risposta4.Enabled = true;
                    this.logica.risposta5.Enabled = true;
                    this.logica.suggerimento.Enabled = true;
                    // Mantenere il textbox del punteggio disattivato
                    this.logica.quesitoEsatto.Enabled = false;

                    // Riattivare il pulsante nuova partita
                    this.logica.nuova.Enabled = true;

                    // Ad ogni nuovo quesito la partenza iniziale delle risposte segue l'ordine
                    // A - B - C - D - E 
                    this.logica.risposta1.Text = "A";
                    this.logica.risposta2.Text = "B";
                    this.logica.risposta3.Text = "C";
                    this.logica.risposta4.Text = "D";
                    this.logica.risposta5.Text = "E";

                    // Personalizzazione bottoni risposte e suggerimento
                    this.logica.risposta1.BackColor = Color.DarkGray;
                    this.logica.risposta2.BackColor = Color.DarkGray;
                    this.logica.risposta3.BackColor = Color.DarkGray;
                    this.logica.risposta4.BackColor = Color.DarkGray;
                    this.logica.risposta5.BackColor = Color.DarkGray;
                    this.logica.suggerimento.BackColor = Color.DimGray;

                    if (numeroQuesito != 8)
                    {
                        this.logica.prossimo.Text = Convert.ToString("Avanti");
                        this.logica.numQuesitoAttuale.Text = "Quesito " + Convert.ToString(numeroQuesito);
                    }

                    switch (numeroQuesito)
                    {
                        case 1:
                            // Disabilita bottone per il quesito seguente
                            this.logica.prossimo.Enabled = false;
                            // Visualizzare quesito
                            MostrareQuesito(numeroQuesito);
                            break;
                        case 2:
                            this.logica.prossimo.Enabled = false;
                            MostrareQuesito(numeroQuesito);
                            break;
                        case 3:
                            this.logica.prossimo.Enabled = false;
                            MostrareQuesito(numeroQuesito);
                            break;
                        case 4:
                            this.logica.prossimo.Enabled = false;
                            MostrareQuesito(numeroQuesito);
                            break;
                        case 5:
                            this.logica.prossimo.Enabled = false;
                            MostrareQuesito(numeroQuesito);
                            break;
                        case 6:
                            this.logica.prossimo.Enabled = false;
                            MostrareQuesito(numeroQuesito);
                            break;
                        case 7:
                            this.logica.prossimo.Enabled = false;
                            MostrareQuesito(numeroQuesito);
                            break;

                        case 8:
                            this.logica.timer.Stop();
                            // Disattiva bottoni principali
                            this.logica.risposta1.Enabled = false;
                            this.logica.risposta2.Enabled = false;
                            this.logica.risposta3.Enabled = false;
                            this.logica.risposta4.Enabled = false;
                            this.logica.risposta5.Enabled = false;
                            this.logica.suggerimento.Enabled = false;
                            this.logica.prossimo.Enabled = false;

                            if (quesEsatto == 7)
                            {
                                // Personalizzazione risultato 7/7
                                this.logica.risposta1.BackColor = Color.LightGreen;
                                this.logica.risposta2.BackColor = Color.LightGreen;
                                this.logica.risposta3.BackColor = Color.LightGreen;
                                this.logica.risposta4.BackColor = Color.LightGreen;
                                this.logica.risposta5.BackColor = Color.LightGreen;
                                this.logica.quesitoEsatto.BackColor = Color.LightGreen;
                                this.logica.numQuesitoAttuale.BackColor = Color.LightGreen;
                                this.logica.suggerimento.Text = null;
                                this.logica.suggerimento.Text = "7/7 Ottimo! Sei pronto per il prossimo livello?";
                                this.logica.suggerimento.BackColor = Color.Lime;
                            }
                            else if (quesEsatto == 6 || quesEsatto == 5)
                            {
                                // Personalizzazione risultato 6/7 e 5/7
                                this.logica.risposta1.BackColor = Color.Aquamarine;
                                this.logica.risposta2.BackColor = Color.Aquamarine;
                                this.logica.risposta3.BackColor = Color.Aquamarine;
                                this.logica.risposta4.BackColor = Color.Aquamarine;
                                this.logica.risposta5.BackColor = Color.Aquamarine;
                                this.logica.quesitoEsatto.BackColor = Color.Aquamarine;
                                this.logica.numQuesitoAttuale.BackColor = Color.Aquamarine;
                                this.logica.suggerimento.Text = null;
                                this.logica.suggerimento.Text = "Quasi perfetto. 'Progressi non Perfezione'.";
                                this.logica.suggerimento.BackColor = Color.DeepSkyBlue;
                            }
                            else
                            {
                                // Personalizzazione risultato < 5/7
                                this.logica.risposta1.BackColor = Color.OrangeRed;
                                this.logica.risposta2.BackColor = Color.OrangeRed;
                                this.logica.risposta3.BackColor = Color.OrangeRed;
                                this.logica.risposta4.BackColor = Color.OrangeRed;
                                this.logica.risposta5.BackColor = Color.OrangeRed;
                                this.logica.quesitoEsatto.BackColor = Color.OrangeRed;
                                this.logica.numQuesitoAttuale.BackColor = Color.OrangeRed;
                                this.logica.suggerimento.Text = null;
                                this.logica.suggerimento.Text = "Riprova! Utilizza i suggerimenti per aiutarti.";
                                this.logica.suggerimento.BackColor = Color.Red;
                            }
                            break;
                    }
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.Message);
                };
            }

            // Livello 3
            else if (this.livelloGioco == 2)
            {
                try
                {
                    // Attivazione di tutti i bottoni
                    numeroQuesito++;
                    this.logica.risposta1.Enabled = true;
                    this.logica.risposta2.Enabled = true;
                    this.logica.risposta3.Enabled = true;
                    this.logica.risposta4.Enabled = true;
                    this.logica.risposta5.Enabled = true;
                    // Disattivo il suggerimento per aumentare la difficoltà del livello
                    this.logica.suggerimento.Enabled = false;
                    // Mantenere il textbox del punteggio disattivato
                    this.logica.quesitoEsatto.Enabled = false;
                    // Riattivare il pulsante nuova partita
                    this.logica.nuova.Enabled = true;
                    // Ad ogni nuovo quesito la partenza iniziale delle risposte segue l'ordine
                    // A - B - C - D - E  che però potrà essere poi cambiato
                    this.logica.risposta1.Text = "A";
                    this.logica.risposta2.Text = "B";
                    this.logica.risposta3.Text = "C";
                    this.logica.risposta4.Text = "D";
                    this.logica.risposta5.Text = "E";
                    // Personalizzazione bottoni risposte e suggerimento
                    this.logica.risposta1.BackColor = Color.Orange;
                    this.logica.risposta2.BackColor = Color.Orange;
                    this.logica.risposta3.BackColor = Color.Orange;
                    this.logica.risposta4.BackColor = Color.Orange;
                    this.logica.risposta5.BackColor = Color.Orange;
                    // Nascondere il suggerimento con un sfondo nero (lo stesso colore del testo)
                    this.logica.suggerimento.BackColor = Color.Black; 

                    if (numeroQuesito != 6)
                    {
                        this.logica.numQuesitoAttuale.Text = "Quesito " + Convert.ToString(numeroQuesito);
                        this.logica.prossimo.Text = Convert.ToString("Avanti");
                    }
                    switch (numeroQuesito)
                    {
                        case 1:
                            // Disabilita bottone per il quesito seguente
                            this.logica.prossimo.Enabled = false;
                            // Visualizzare quesito
                            MostrareQuesito(numeroQuesito);
                            break;
                        case 2:
                            this.logica.prossimo.Enabled = false;
                            MostrareQuesito(numeroQuesito);
                            break;
                        case 3:
                            this.logica.prossimo.Enabled = false;
                            MostrareQuesito(numeroQuesito);
                            break;
                        case 4:
                            this.logica.prossimo.Enabled = false;
                            MostrareQuesito(numeroQuesito);
                            break;
                        case 5:
                            this.logica.prossimo.Enabled = false;
                            MostrareQuesito(numeroQuesito);
                            break;
                        case 6:
                            this.logica.timer.Stop();
                            // Disattiva bottoni principali
                            this.logica.risposta1.Enabled = false;
                            this.logica.risposta2.Enabled = false;
                            this.logica.risposta3.Enabled = false;
                            this.logica.risposta4.Enabled = false;
                            this.logica.risposta5.Enabled = false;
                            this.logica.suggerimento.Enabled = false;
                            this.logica.prossimo.Enabled = false;

                            if (quesEsatto == 5 || quesEsatto == 4)
                            {
                                // Personalizzazione risultato 5/5 e 4/5
                                this.logica.risposta1.BackColor = Color.LightGreen;
                                this.logica.risposta2.BackColor = Color.LightGreen;
                                this.logica.risposta3.BackColor = Color.LightGreen;
                                this.logica.risposta4.BackColor = Color.LightGreen;
                                this.logica.risposta5.BackColor = Color.LightGreen;
                                this.logica.quesitoEsatto.BackColor = Color.LightGreen;
                                this.logica.numQuesitoAttuale.BackColor = Color.LightGreen;
                                this.logica.suggerimento.Text = null;
                                this.logica.suggerimento.Text = "Ottimo! Riprova con altre domande della stessa difficoltà.";
                                this.logica.suggerimento.BackColor = Color.Lime;
                            }
                            else
                            {
                                // Personalizzazione risultato < 4/5
                                this.logica.risposta1.BackColor = Color.OrangeRed;
                                this.logica.risposta2.BackColor = Color.OrangeRed;
                                this.logica.risposta3.BackColor = Color.OrangeRed;
                                this.logica.risposta4.BackColor = Color.OrangeRed;
                                this.logica.risposta5.BackColor = Color.OrangeRed;
                                this.logica.quesitoEsatto.BackColor = Color.OrangeRed;
                                this.logica.numQuesitoAttuale.BackColor = Color.OrangeRed;
                                this.logica.suggerimento.Text = null;
                                this.logica.suggerimento.Text = "Riprova! Sembra sempre impossibile, finché non viene fatto.";
                                this.logica.suggerimento.BackColor = Color.Red;
                            }
                            break;
                    }
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.Message);
                };
            }
        }

        // Nuova partita
        public void RitentareClick(object sender, EventArgs e)
        {
            // Togliere i dati precedenti e ripristinare i colori iniziali
            this.logica.risposta1.Text = null;
            this.logica.risposta2.Text = null;
            this.logica.risposta3.Text = null;
            this.logica.risposta4.Text = null;
            this.logica.risposta5.Text = null;
            this.logica.suggerimento.Text = null;
            this.logica.immagine.Image = null;
            this.logica.quesitoEsatto.BackColor = Color.Gainsboro;
            this.logica.numQuesitoAttuale.BackColor = Color.Gainsboro;
            this.logica.prossimo.Text = "Start";
            this.logica.prossimo.Enabled = true;

            // Ripristino colori grigio scuro risposte e suggerimento
            this.logica.risposta1.BackColor = Color.DarkGray;
            this.logica.risposta2.BackColor = Color.DarkGray;
            this.logica.risposta3.BackColor = Color.DarkGray;
            this.logica.risposta4.BackColor = Color.DarkGray;
            this.logica.risposta5.BackColor = Color.DarkGray;
            this.logica.suggerimento.BackColor = Color.DimGray;

            // Disattivare risposte, nuova partita e suggerimento
            this.logica.nuova.Enabled = false;
            this.logica.risposta1.Enabled = false;
            this.logica.risposta2.Enabled = false;
            this.logica.risposta3.Enabled = false;
            this.logica.risposta4.Enabled = false;
            this.logica.risposta5.Enabled = false;
            this.logica.suggerimento.Enabled = false;

            // Ripristino timer
            this.logica.timer.Stop();
            this.logica.RiavviaTimer();

            // Ripristino punteggio e conteggio dei quesiti
            quesEsatto = 0;
            this.logica.quesitoEsatto.Text = "Corrette -> " + quesEsatto.ToString();
            numeroQuesito = 0;
            this.logica.numQuesitoAttuale.Text = "Quesito " + Convert.ToString(numeroQuesito);

            // Nuova partita (Riprova)
            this.giocoLogica = new DecisioneGioco(argomentoScelto, livelloGioco, mate, logica);
        }

        // Metodo per esporre il quesito (immagine), le risposte e il relativo suggerimento
        public void MostrareQuesito(int numeroQues)
        {
            String nomeImmagine = this.giocoLogica.AcquisisciImmagineQuesito(numeroQues);
            this.logica.immagine.Image = (Image)Properties.Resources.ResourceManager.GetObject(nomeImmagine);

            String risult1 = this.giocoLogica.RisultatoNumeroLettera1(numeroQues);
            String risult2 = this.giocoLogica.RisultatoNumeroLettera2(numeroQues);
            String risult3 = this.giocoLogica.RisultatoNumeroLettera3(numeroQues);
            String risult4 = this.giocoLogica.RisultatoNumeroLettera4(numeroQues);
            String risult5 = this.giocoLogica.RisultatoNumeroLettera5(numeroQues);
            String suggerim = this.giocoLogica.RisultatoSuggerimento(numeroQues);
            this.logica.suggerimento.Text = suggerim;

            /* Condizioni che verificano l'esatta collocazione delle lettere 
               casuali acquisite nella posizione giusta (A - B - C - D - E),
               in caso si trovino in posizioni diverse si crea un cambio tra
               altre due lettere per creare difficoltà al giocatore ma 
               garantendo sempre l'unicità delle lettere (evitando doppioni). 
               Si evitano dunque situazioni in cui le 5 risposte dei bottoni
               siano -> (A - B - A - C - C) o simili. */

            // A
            if (this.giocoLogica.SoluzioneEsatta(numeroQuesito) == 1)
            {
                this.logica.risposta1.Text = risult1;
                if (risult1 == "B")
                {
                    this.logica.risposta2.Text = "A";
                    this.logica.risposta3.Text = "E";
                    this.logica.risposta5.Text = "C";
                }
                if (risult1 == "C")
                {
                    this.logica.risposta3.Text = "A";
                    this.logica.risposta4.Text = "E";
                    this.logica.risposta5.Text = "D";
                }
                if (risult1 == "D")
                {
                    this.logica.risposta4.Text = "A";
                    this.logica.risposta3.Text = "E";
                    this.logica.risposta5.Text = "B";
                }
                if (risult1 == "E")
                {
                    this.logica.risposta5.Text = "A";
                    this.logica.risposta3.Text = "B";
                    this.logica.risposta2.Text = "C";
                }
            }

            // B
            else if (this.giocoLogica.SoluzioneEsatta(numeroQuesito) == 2)
            {
                this.logica.risposta2.Text = risult2;
                if (risult2 == "A")
                {
                    this.logica.risposta1.Text = "B";
                    this.logica.risposta3.Text = "E";
                    this.logica.risposta5.Text = "C";
                }
                if (risult2 == "C")
                {
                    this.logica.risposta3.Text = "B";
                    this.logica.risposta4.Text = "E";
                    this.logica.risposta5.Text = "D";
                }
                if (risult2 == "D")
                {
                    this.logica.risposta4.Text = "B";
                    this.logica.risposta3.Text = "E";
                    this.logica.risposta5.Text = "C";
                }
                if (risult2 == "E")
                {
                    this.logica.risposta5.Text = "B";
                    this.logica.risposta3.Text = "A";
                    this.logica.risposta1.Text = "C";
                }
            }

            // C
            else if (this.giocoLogica.SoluzioneEsatta(numeroQuesito) == 3)
            {
                this.logica.risposta3.Text = risult3;
                if (risult3 == "A")
                {
                    this.logica.risposta1.Text = "C";
                    this.logica.risposta2.Text = "E";
                    this.logica.risposta5.Text = "B";
                }
                if (risult3 == "B")
                {
                    this.logica.risposta2.Text = "C";
                    this.logica.risposta4.Text = "E";
                    this.logica.risposta5.Text = "D";

                }
                if (risult3 == "D")
                {
                    this.logica.risposta4.Text = "C";
                    this.logica.risposta1.Text = "E";
                    this.logica.risposta5.Text = "A";
                }
                if (risult3 == "E")
                {
                    this.logica.risposta5.Text = "C";
                    this.logica.risposta1.Text = "B";
                    this.logica.risposta2.Text = "A";
                }
            }

            // D
            else if (this.giocoLogica.SoluzioneEsatta(numeroQuesito) == 4)
            {
                this.logica.risposta4.Text = risult4;
                if (risult4 == "A")
                {
                    this.logica.risposta1.Text = "D";
                    this.logica.risposta3.Text = "E";
                    this.logica.risposta5.Text = "C";
                }
                if (risult4 == "B")
                {
                    this.logica.risposta2.Text = "D";
                    this.logica.risposta3.Text = "E";
                    this.logica.risposta5.Text = "C";
                }
                if (risult4 == "C")
                {
                    this.logica.risposta3.Text = "D";
                    this.logica.risposta2.Text = "E";
                    this.logica.risposta5.Text = "B";
                }
                if (risult4 == "E")
                {
                    this.logica.risposta5.Text = "D";
                    this.logica.risposta3.Text = "A";
                    this.logica.risposta1.Text = "C";
                }
            }

            // E
            else if (this.giocoLogica.SoluzioneEsatta(numeroQuesito) == 5)
            {
                this.logica.risposta5.Text = risult5;
                if (risult5 == "A")
                {
                    this.logica.risposta1.Text = "E";
                    this.logica.risposta3.Text = "B";
                    this.logica.risposta2.Text = "C";
                }
                if (risult5 == "B")
                {
                    this.logica.risposta2.Text = "E";
                    this.logica.risposta3.Text = "D";
                    this.logica.risposta4.Text = "C";
                }
                if (risult5 == "C")
                {
                    this.logica.risposta3.Text = "E";
                    this.logica.risposta1.Text = "B";
                    this.logica.risposta2.Text = "A";
                }
                if (risult5 == "D")
                {
                    this.logica.risposta4.Text = "E";
                    this.logica.risposta3.Text = "A";
                    this.logica.risposta1.Text = "C";
                }
            }
        }
    }
}
