using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MakeItTrue.View;
using System.Windows.Forms;
using System.Drawing;
using MakeItTrue.Model;
using System.Threading;

namespace MakeItTrue.Controller
{
    class MatematicaController
    {
        private Matematica mate;
        private Logica logica = null;

        private int livelloGioco;
        private DecisioneGioco giocoMate;
        private bool argomentoScelto;

        MatematicaLivello1 mate1;
        MatematicaLivello2 mate2;
        MatematicaLivello3 mate3;

        // Inizializzazione informazioni quesiti
        private int numeroQuesito = 0;
        private int quesitoEsatto = 0;

        public MatematicaController(bool argomento, int livello)
        {
            this.argomentoScelto = argomento;
            this.livelloGioco = livello;
            this.mate = new Matematica();
            this.giocoMate = new DecisioneGioco(argomentoScelto, livelloGioco, mate, logica);

            try
            {
                GiocoStart(livelloGioco);
                InizializzaEventi();
            }
            catch (Exception e)
            {
                MessageBox.Show("Errore nel caricamento del gioco matematica " + e);
            }
        }

        // Inizio del gioco di Matemtica a seconda del livello scelto
        public void GiocoStart(int livello)
        {
            if (livello == 0)
            {
                this.mate1 = new MatematicaLivello1();
            }
            else if (livello == 1)
            {
                this.mate2 = new MatematicaLivello2();
            }
            else if (livello == 2)
            {
                this.mate3 = new MatematicaLivello3();
            }
        }
       
        public void InizializzaEventi()
        {
            // Risposte e suggerimento disattivati in partenza
            this.mate.risposta1.Enabled = false;
            this.mate.risposta2.Enabled = false;
            this.mate.risposta3.Enabled = false;
            this.mate.risposta4.Enabled = false;
            this.mate.risposta5.Enabled = false;
            this.mate.suggerimento.Enabled = false;
            // Bottone nuova partita disattivato inizialmente
            this.mate.nuova.Enabled = false;
            // Contatore quesiti esatti
            this.mate.quesitoEsatto.Enabled = false;
            // Contatore quesito attuale
            this.mate.numQuesitoAttuale.Enabled = false;

            this.mate.risposta1.MouseClick += new MouseEventHandler(this.Risposta1Click);
            this.mate.risposta2.MouseClick += new MouseEventHandler(this.Risposta2Click);
            this.mate.risposta3.MouseClick += new MouseEventHandler(this.Risposta3Click);
            this.mate.risposta4.MouseClick += new MouseEventHandler(this.Risposta4Click);
            this.mate.risposta5.MouseClick += new MouseEventHandler(this.Risposta5Click);
            this.mate.suggerimento.MouseClick += new MouseEventHandler(this.SuggerimentoClick);
            this.mate.prossimo.MouseClick += new MouseEventHandler(this.ProssimoClick);
            this.mate.nuova.MouseClick += new MouseEventHandler(this.RitentareClick);
        }

        // Mostrare il Form Matematica
        public void EsporreMate()
        {
            this.mate.ShowDialog();
        }

        // Risposta 1
        public void Risposta1Click(object sender, EventArgs e)
        {
            // Verifica se la risposta 1 è quella esatta 
            if (this.giocoMate.SoluzioneEsatta(numeroQuesito) == 1)
            {
                // Timer si ferma
                this.mate.timer.Stop();

                // Colore blu per il bottone con la risposta esatta e 
                // bottone prossima domanda attivato mentre disattivati gli altri
                this.mate.risposta1.BackColor = Color.SteelBlue;
                this.mate.prossimo.Enabled = true;
                this.mate.risposta1.Enabled = false;
                this.mate.risposta2.Enabled = false;
                this.mate.risposta3.Enabled = false;
                this.mate.risposta4.Enabled = false;
                this.mate.risposta5.Enabled = false;
                this.mate.suggerimento.Enabled = false;
                this.mate.quesitoEsatto.Enabled = false;

                // Se vengono scelte le risposte sbagliate non si effettua alcuna operazione
                if ((this.mate.risposta2.BackColor == Color.Yellow) || (this.mate.risposta3.BackColor == Color.Yellow) ||
                    (this.mate.risposta4.BackColor == Color.Yellow) || (this.mate.risposta5.BackColor == Color.Yellow))
                {
                    // Nessun aumento di punteggio
                }
                else
                {
                    // Aumento di 1 per il TextBox dei quesiti esatti
                    quesitoEsatto++;
                    // Separazione del modo di visualizzare la stringa a seconda del livello dato che
                    // nel livello 1 e 2 sono 7 quesiti mentre nel livello 3 solo 5
                    if (livelloGioco == 2)
                        this.mate.quesitoEsatto.Text = "Corrette -> " + quesitoEsatto.ToString() + " / 5";
                    else
                    {
                        this.mate.quesitoEsatto.Text = "Corrette -> " + quesitoEsatto.ToString() + " / 7";
                    }
                }
            }
            // Risposta 1 è quella sbagliata
            else
            {
                // Color giallo perchè la risposta 1 è sbagliata
                this.mate.risposta1.BackColor = Color.Yellow;

                // Viene aggiunto del tempo di penale se il livello è quello difficile (3)
                if (this.livelloGioco == 2)
                {
                    this.mate.TimerLivello3();
                    // Blocco il pulsante al giocatore in modo tale da non togliere altro tempo in caso
                    // il giocatore seleziona la stessa risposta sbagliata
                    this.mate.risposta1.Enabled = false;
                }
            }
        }

        // Risposta 2
        public void Risposta2Click(object sender, EventArgs e)
        {
            // Verifica se la risposta 2 è quella esatta 
            if (this.giocoMate.SoluzioneEsatta(numeroQuesito) == 2)
            {
                // Timer si ferma
                this.mate.timer.Stop();

                // Colore blu per il bottone con la risposta esatta e 
                // bottone prossima domanda attivato mentre disattivati gli altri
                this.mate.risposta2.BackColor = Color.SteelBlue;
                this.mate.prossimo.Enabled = true;
                this.mate.risposta1.Enabled = false;
                this.mate.risposta2.Enabled = false;
                this.mate.risposta3.Enabled = false;
                this.mate.risposta4.Enabled = false;
                this.mate.risposta5.Enabled = false;
                this.mate.suggerimento.Enabled = false;

                this.mate.quesitoEsatto.Enabled = false;

                // Se vengono scelte le risposte sbagliate non si effettua alcuna operazione
                if ((this.mate.risposta1.BackColor == Color.Yellow) || (this.mate.risposta3.BackColor == Color.Yellow) ||
                    (this.mate.risposta4.BackColor == Color.Yellow) || (this.mate.risposta5.BackColor == Color.Yellow))
                {
                    // Nessun aumento di punteggio
                }
                else
                {
                    // Aumento di 1 per il TextBox dei quesiti esatti
                    quesitoEsatto++;
                    // Separazione del modo di visualizzare la stringa a seconda del livello dato che
                    // nel livello 1 e 2 sono 7 quesiti mentre nel livello 3 solo 5
                    if (livelloGioco == 2)
                        this.mate.quesitoEsatto.Text = "Corrette -> " + quesitoEsatto.ToString() + " / 5";
                    else
                        this.mate.quesitoEsatto.Text = "Corrette -> " + quesitoEsatto.ToString() + " / 7";
                }
            }
            else
            {
                this.mate.risposta2.BackColor = Color.Yellow;

                // Viene aggiunto del tempo di penale se il livello è quello difficile (3)
                if (this.livelloGioco == 2)
                {
                    this.mate.TimerLivello3();
                    // Blocco il pulsante al giocatore in modo tale da non togliere altro tempo in caso
                    // il giocatore seleziona la stessa risposta sbagliata
                    this.mate.risposta2.Enabled = false;
                }
            }
        }

        // Risposta 3
        public void Risposta3Click(object sender, EventArgs e)
        {
            // Verifica se la risposta 3 è quella esatta 
            if (this.giocoMate.SoluzioneEsatta(numeroQuesito) == 3)
            {
                // Timer si ferma
                this.mate.timer.Stop();

                // Colore blu per il bottone con la risposta esatta e 
                // bottone prossima domanda attivato mentre disattivati gli altri
                this.mate.risposta3.BackColor = Color.SteelBlue;
                this.mate.prossimo.Enabled = true;
                this.mate.risposta1.Enabled = false;
                this.mate.risposta2.Enabled = false;
                this.mate.risposta3.Enabled = false;
                this.mate.risposta4.Enabled = false;
                this.mate.risposta5.Enabled = false;
                this.mate.suggerimento.Enabled = false;
                this.mate.quesitoEsatto.Enabled = false;

                // Se vengono scelte le risposte sbagliate non si effettua alcuna operazione
                if ((this.mate.risposta1.BackColor == Color.Yellow) || (this.mate.risposta2.BackColor == Color.Yellow) ||
                    (this.mate.risposta4.BackColor == Color.Yellow) || (this.mate.risposta5.BackColor == Color.Yellow))
                {
                    // Nessun aumento di punteggio
                }
                else
                {
                    // Aumento di 1 per il TextBox dei quesiti esatti
                    quesitoEsatto++;
                    // Separazione del modo di visualizzare la stringa a seconda del livello dato che
                    // nel livello 1 e 2 sono 7 quesiti mentre nel livello 3 solo 5
                    if (livelloGioco == 2)
                        this.mate.quesitoEsatto.Text = "Corrette -> " + quesitoEsatto.ToString() + " / 5";
                    else
                        this.mate.quesitoEsatto.Text = "Corrette -> " + quesitoEsatto.ToString() + " / 7";
                }
            }
            else
            {
                this.mate.risposta3.BackColor = Color.Yellow;

                // Viene aggiunto del tempo di penale se il livello è quello difficile (3)
                if (this.livelloGioco == 2)
                {
                    this.mate.TimerLivello3();
                    // Blocco il pulsante al giocatore in modo tale da non togliere altro tempo in caso
                    // il giocatore seleziona la stessa risposta sbagliata
                    this.mate.risposta3.Enabled = false;
                }
            }
        }

        // Risposta 4
        public void Risposta4Click(object sender, EventArgs e)
        {
            // Verifica se la risposta 4 è quella esatta 
            if (this.giocoMate.SoluzioneEsatta(numeroQuesito) == 4)
            {
                // Timer si ferma
                this.mate.timer.Stop();

                // Colore blu per il bottone con la risposta esatta e 
                // bottone prossima domanda attivato mentre disattivati gli altri
                this.mate.risposta4.BackColor = Color.SteelBlue;
                this.mate.prossimo.Enabled = true;
                this.mate.risposta1.Enabled = false;
                this.mate.risposta2.Enabled = false;
                this.mate.risposta3.Enabled = false;
                this.mate.risposta4.Enabled = false;
                this.mate.risposta5.Enabled = false;
                this.mate.suggerimento.Enabled = false;
                this.mate.quesitoEsatto.Enabled = false;

                // Se vengono scelte le risposte sbagliate non si effettua alcuna operazione
                if ((this.mate.risposta1.BackColor == Color.Yellow) || (this.mate.risposta2.BackColor == Color.Yellow) ||
                    (this.mate.risposta3.BackColor == Color.Yellow) || (this.mate.risposta5.BackColor == Color.Yellow))
                {
                    // Nessun aumento di punteggio
                }
                else
                {
                    // Aumento di 1 per il TextBox dei quesiti esatti
                    quesitoEsatto++;
                    // Separazione del modo di visualizzare la stringa a seconda del livello dato che
                    // nel livello 1 e 2 sono 7 quesiti mentre nel livello 3 solo 5
                    if (livelloGioco == 2)
                        this.mate.quesitoEsatto.Text = "Corrette -> " + quesitoEsatto.ToString() + " / 5";
                    else
                        this.mate.quesitoEsatto.Text = "Corrette -> " + quesitoEsatto.ToString() + " / 7";
                }
            }
            else
            {
                this.mate.risposta4.BackColor = Color.Yellow;

                // Viene aggiunto del tempo di penale se il livello è quello difficile (3)
                if (this.livelloGioco == 2)
                {
                    this.mate.TimerLivello3();
                    // Blocco il pulsante al giocatore in modo tale da non togliere altro tempo in caso
                    // il giocatore seleziona la stessa risposta sbagliata
                    this.mate.risposta4.Enabled = false;
                }

            }
        }

        // Risposta 5
        public void Risposta5Click(object sender, EventArgs e)
        {
            // Verifica se la risposta 5 è quella esatta 
            if (this.giocoMate.SoluzioneEsatta(numeroQuesito) == 5)
            {
                // Timer si ferma
                this.mate.timer.Stop();

                // Colore blu per il bottone con la risposta esatta e 
                // bottone prossima domanda attivato mentre disattivati gli altri
                this.mate.risposta5.BackColor = Color.SteelBlue;
                this.mate.prossimo.Enabled = true;
                this.mate.risposta1.Enabled = false;
                this.mate.risposta2.Enabled = false;
                this.mate.risposta3.Enabled = false;
                this.mate.risposta4.Enabled = false;
                this.mate.risposta5.Enabled = false;
                this.mate.suggerimento.Enabled = false;
                this.mate.quesitoEsatto.Enabled = false;

                // Se vengono scelte le risposte sbagliate non si effettua alcuna operazione
                if ((this.mate.risposta1.BackColor == Color.Yellow) || (this.mate.risposta2.BackColor == Color.Yellow) ||
                    (this.mate.risposta3.BackColor == Color.Yellow) || (this.mate.risposta4.BackColor == Color.Yellow))
                {
                    // Nessun aumento di punteggio
                }
                else
                {
                    // Aumento di 1 per il TextBox dei quesiti esatti
                    quesitoEsatto++;
                    // Separazione del modo di visualizzare la stringa a seconda del livello dato che
                    // nel livello 1 e 2 sono 7 quesiti mentre nel livello 3 solo 5
                    if (livelloGioco == 2)
                        this.mate.quesitoEsatto.Text = "Corrette -> " + quesitoEsatto.ToString() + " / 5";
                    else
                        this.mate.quesitoEsatto.Text = "Corrette -> " + quesitoEsatto.ToString() + " / 7";
                }
            }
            else
            {
                this.mate.risposta5.BackColor = Color.Yellow;

                // Viene aggiunto del tempo di penale se il livello è quello difficile (3)
                if (this.livelloGioco == 2)
                {
                    this.mate.TimerLivello3();
                    // Blocco il pulsante al giocatore in modo tale da non togliere altro tempo in caso
                    // il giocatore seleziona la stessa risposta sbagliata
                    this.mate.risposta5.Enabled = false;
                }
            }
        }

        // Suggerimento Logica
        public void SuggerimentoClick(object sender, EventArgs e)
        {
            {
                // Personalizzazione suggerimento
                this.mate.suggerimento.BackColor = Color.DarkGray;
                this.mate.suggerimento.Enabled = false;
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
                    this.mate.risposta1.Enabled = true;
                    this.mate.risposta2.Enabled = true;
                    this.mate.risposta3.Enabled = true;
                    this.mate.risposta4.Enabled = true;
                    this.mate.risposta5.Enabled = true;
                    this.mate.suggerimento.Enabled = true;
                    // Mantenere il textbox del punteggio disattivato
                    this.mate.quesitoEsatto.Enabled = false;

                    // Riattivare il pulsante nuova partita
                    this.mate.nuova.Enabled = true;

                    // Personalizzazione bottoni risposte e suggerimento
                    this.mate.risposta1.BackColor = Color.DarkGray;
                    this.mate.risposta2.BackColor = Color.DarkGray;
                    this.mate.risposta3.BackColor = Color.DarkGray;
                    this.mate.risposta4.BackColor = Color.DarkGray;
                    this.mate.risposta5.BackColor = Color.DarkGray;
                    this.mate.suggerimento.BackColor = Color.DimGray;

                    if (numeroQuesito != 8)
                    {
                        this.mate.prossimo.Text = Convert.ToString("Avanti");
                        this.mate.numQuesitoAttuale.Text = "Quesito " + Convert.ToString(numeroQuesito);
                    }

                    switch (numeroQuesito)
                    {
                        case 1:
                            // Disabilita bottone per il quesito seguente
                            this.mate.prossimo.Enabled = false;
                            // Visualizzare quesito
                            MostrareQuesito(numeroQuesito);
                            break;
                        case 2:
                            this.mate.prossimo.Enabled = false;
                            MostrareQuesito(numeroQuesito);
                            break;
                        case 3:
                            this.mate.prossimo.Enabled = false;
                            MostrareQuesito(numeroQuesito);
                            break;
                        case 4:
                            this.mate.prossimo.Enabled = false;
                            MostrareQuesito(numeroQuesito);
                            break;
                        case 5:
                            this.mate.prossimo.Enabled = false;
                            MostrareQuesito(numeroQuesito);
                            break;
                        case 6:
                            this.mate.prossimo.Enabled = false;
                            MostrareQuesito(numeroQuesito);
                            break;
                        case 7:
                            this.mate.prossimo.Enabled = false;
                            MostrareQuesito(numeroQuesito);
                            break;

                        case 8:
                            this.mate.timer.Stop();
                            // Disattiva bottoni principali
                            this.mate.risposta1.Enabled = false;
                            this.mate.risposta2.Enabled = false;
                            this.mate.risposta3.Enabled = false;
                            this.mate.risposta4.Enabled = false;
                            this.mate.risposta5.Enabled = false;
                            this.mate.suggerimento.Enabled = false;
                            this.mate.prossimo.Enabled = false;

                            if (quesitoEsatto == 7)
                            {
                                // Personalizzazione risultato 7/7
                                this.mate.risposta1.BackColor = Color.LightGreen;
                                this.mate.risposta2.BackColor = Color.LightGreen;
                                this.mate.risposta3.BackColor = Color.LightGreen;
                                this.mate.risposta4.BackColor = Color.LightGreen;
                                this.mate.risposta5.BackColor = Color.LightGreen;
                                this.mate.quesitoEsatto.BackColor = Color.LightGreen;
                                this.mate.numQuesitoAttuale.BackColor = Color.LightGreen;
                                this.mate.suggerimento.Text = null;
                                this.mate.suggerimento.Text = "7/7 Ottimo! Sei pronto per il prossimo livello?";
                                this.mate.suggerimento.BackColor = Color.Lime;
                            }
                            else if (quesitoEsatto == 6 || quesitoEsatto == 5)
                            {
                                // Personalizzazione risultato 6/7 e 5/7
                                this.mate.risposta1.BackColor = Color.Aquamarine;
                                this.mate.risposta2.BackColor = Color.Aquamarine;
                                this.mate.risposta3.BackColor = Color.Aquamarine;
                                this.mate.risposta4.BackColor = Color.Aquamarine;
                                this.mate.risposta5.BackColor = Color.Aquamarine;
                                this.mate.quesitoEsatto.BackColor = Color.Aquamarine;
                                this.mate.numQuesitoAttuale.BackColor = Color.Aquamarine;
                                this.mate.suggerimento.Text = null;
                                this.mate.suggerimento.Text = "Quasi perfetto. 'Progressi non Perfezione'.";
                                this.mate.suggerimento.BackColor = Color.DeepSkyBlue;
                            }
                            else
                            {
                                // Personalizzazione risultato < 5/7
                                this.mate.risposta1.BackColor = Color.OrangeRed;
                                this.mate.risposta2.BackColor = Color.OrangeRed;
                                this.mate.risposta3.BackColor = Color.OrangeRed;
                                this.mate.risposta4.BackColor = Color.OrangeRed;
                                this.mate.risposta5.BackColor = Color.OrangeRed;
                                this.mate.quesitoEsatto.BackColor = Color.OrangeRed;
                                this.mate.numQuesitoAttuale.BackColor = Color.OrangeRed;
                                this.mate.suggerimento.Text = null;
                                this.mate.suggerimento.Text = "Riprova! Utilizza i suggerimenti per aiutarti.";
                                this.mate.suggerimento.BackColor = Color.Red;
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
                    this.mate.risposta1.Enabled = true;
                    this.mate.risposta2.Enabled = true;
                    this.mate.risposta3.Enabled = true;
                    this.mate.risposta4.Enabled = true;
                    this.mate.risposta5.Enabled = true;

                    // Disattivo il suggerimento per aumentare la difficoltà del livello
                    this.mate.suggerimento.Enabled = false;
                    // Mantenere il textbox del punteggio disattivato
                    this.mate.quesitoEsatto.Enabled = false;

                    // Riattivare il pulsante nuova partita
                    this.mate.nuova.Enabled = true;

                    // Personalizzazione bottoni risposte e suggerimento
                    this.mate.risposta1.BackColor = Color.Orange;
                    this.mate.risposta2.BackColor = Color.Orange;
                    this.mate.risposta3.BackColor = Color.Orange;
                    this.mate.risposta4.BackColor = Color.Orange;
                    this.mate.risposta5.BackColor = Color.Orange;
                    this.mate.suggerimento.BackColor = Color.Black;

                    if (numeroQuesito != 6)
                    {
                        this.mate.prossimo.Text = Convert.ToString("Avanti");
                        this.mate.numQuesitoAttuale.Text = "Quesito " + Convert.ToString(numeroQuesito);

                    }
                    switch (numeroQuesito)
                    {
                        case 1:
                            // Disabilita bottone per il quesito seguente
                            this.mate.prossimo.Enabled = false;
                            // Visualizzare quesito
                            MostrareQuesito(numeroQuesito);
                            break;
                        case 2:
                            this.mate.prossimo.Enabled = false;
                            MostrareQuesito(numeroQuesito);
                            break;
                        case 3:
                            this.mate.prossimo.Enabled = false;
                            MostrareQuesito(numeroQuesito);
                            break;
                        case 4:
                            this.mate.prossimo.Enabled = false;
                            MostrareQuesito(numeroQuesito);
                            break;
                        case 5:
                            this.mate.prossimo.Enabled = false;
                            MostrareQuesito(numeroQuesito);
                            break;
                        case 6:
                            this.mate.timer.Stop();
                            // Disattiva bottoni principali
                            this.mate.risposta1.Enabled = false;
                            this.mate.risposta2.Enabled = false;
                            this.mate.risposta3.Enabled = false;
                            this.mate.risposta4.Enabled = false;
                            this.mate.risposta5.Enabled = false;
                            this.mate.suggerimento.Enabled = false;
                            this.mate.prossimo.Enabled = false;

                            if (quesitoEsatto == 5 || quesitoEsatto == 4)
                            {
                                // Personalizzazione risultato 5/5 e 4/5
                                this.mate.risposta1.BackColor = Color.LightGreen;
                                this.mate.risposta2.BackColor = Color.LightGreen;
                                this.mate.risposta3.BackColor = Color.LightGreen;
                                this.mate.risposta4.BackColor = Color.LightGreen;
                                this.mate.risposta5.BackColor = Color.LightGreen;

                                this.mate.quesitoEsatto.BackColor = Color.LightGreen;
                                this.mate.numQuesitoAttuale.BackColor = Color.LightGreen;

                                this.mate.suggerimento.Text = null;
                                this.mate.suggerimento.Text = "Ottimo! Riprova con altre domande della stessa difficoltà.";
                                this.mate.suggerimento.BackColor = Color.Lime;

                            }
                            else
                            {
                                // Personalizzazione risultato < 4/5
                                this.mate.risposta1.BackColor = Color.OrangeRed;
                                this.mate.risposta2.BackColor = Color.OrangeRed;
                                this.mate.risposta3.BackColor = Color.OrangeRed;
                                this.mate.risposta4.BackColor = Color.OrangeRed;
                                this.mate.risposta5.BackColor = Color.OrangeRed;

                                this.mate.quesitoEsatto.BackColor = Color.OrangeRed;
                                this.mate.numQuesitoAttuale.BackColor = Color.OrangeRed;

                                this.mate.suggerimento.Text = null;
                                this.mate.suggerimento.Text = "Riprova! Non arrenderti mai e attento al tempo.";
                                this.mate.suggerimento.BackColor = Color.Red;
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
            this.mate.risposta1.Text = null;
            this.mate.risposta2.Text = null;
            this.mate.risposta3.Text = null;
            this.mate.risposta4.Text = null;
            this.mate.risposta5.Text = null;
            this.mate.suggerimento.Text = null;
            this.mate.immagine.Image = null;
            this.mate.quesitoEsatto.BackColor = Color.Gainsboro;
            this.mate.numQuesitoAttuale.BackColor = Color.Gainsboro;
            this.mate.prossimo.Text = "Start";
            this.mate.prossimo.Enabled = true;

            // Ripristino colori grigio scuro risposte e suggerimento
            this.mate.risposta1.BackColor = Color.DarkGray;
            this.mate.risposta2.BackColor = Color.DarkGray;
            this.mate.risposta3.BackColor = Color.DarkGray;
            this.mate.risposta4.BackColor = Color.DarkGray;
            this.mate.risposta5.BackColor = Color.DarkGray;
            this.mate.suggerimento.BackColor = Color.DimGray;

            // Disattivare risposte, nuova partita e suggerimento
            this.mate.nuova.Enabled = false;
            this.mate.risposta1.Enabled = false;
            this.mate.risposta2.Enabled = false;
            this.mate.risposta3.Enabled = false;
            this.mate.risposta4.Enabled = false;
            this.mate.risposta5.Enabled = false;
            this.mate.suggerimento.Enabled = false;

            // Ripristino timer
            this.mate.timer.Stop();
            this.mate.RiavviaTimer();

            // Ripristino punteggio e conteggio dei quesiti
            quesitoEsatto = 0;
            this.mate.quesitoEsatto.Text = "Corrette -> " + quesitoEsatto.ToString();
            numeroQuesito = 0;
            this.mate.numQuesitoAttuale.Text = "Quesito " + Convert.ToString(numeroQuesito);

            // Nuova partita (Riprova)
            this.giocoMate = new DecisioneGioco(argomentoScelto, livelloGioco, mate, logica);
        }

        // Metodo per esporre il quesito (immagine), le risposte e il relativo suggerimento
        public void MostrareQuesito(int numeroQues)
        {
            String nomeImmagine = this.giocoMate.AcquisisciImmagineQuesito(numeroQues);
            this.mate.immagine.Image = (Image)Properties.Resources.ResourceManager.GetObject(nomeImmagine);

            String risult1 = this.giocoMate.RisultatoNumeroLettera1(numeroQues);
            this.mate.risposta1.Text = risult1;

            String risult2 = this.giocoMate.RisultatoNumeroLettera2(numeroQues);
            this.mate.risposta2.Text = risult2;

            String risult3 = this.giocoMate.RisultatoNumeroLettera3(numeroQues);
            this.mate.risposta3.Text = risult3;

            String risult4 = this.giocoMate.RisultatoNumeroLettera4(numeroQues);
            this.mate.risposta4.Text = risult4;

            String risult5 = this.giocoMate.RisultatoNumeroLettera5(numeroQues);
            this.mate.risposta5.Text = risult5;

            String suggerim = this.giocoMate.RisultatoSuggerimento(numeroQues);
            this.mate.suggerimento.Text = suggerim;
        }        
    }
}
