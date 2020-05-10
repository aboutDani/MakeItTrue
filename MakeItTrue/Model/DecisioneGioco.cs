using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MakeItTrue.View;

namespace MakeItTrue.Model
{
    class DecisioneGioco
    {
        /* ------------
            Matematica
                e
              Logica 
           ------------ */

        // Lista quesiti per tutti i livelli
        private List<LivelliGioco> quesiti;

        // Lista suggerimenti esatti per tutti i livelli
        private List<string> suggerimentoEsatto;

        // Lista risultati esatti dei quesiti 
        private List<string> risultatoEsatto;

        // Liste per creare numeri casuali
        private List<int> listaNumeri;
        private List<bool> listaUtilizzoQues;

        // Variabili che si occupano dei Form Logica e Matematica
        private Matematica argomentoMate;
        private Logica argomentoLogica;

        // Variabile livelli di entrambi gli argomenti
        private LivelliGioco l;

        /* Variabili per suddividere il gioco a seconda
           del livello giocato e dell'argomento
           (matematica o logica) */
        private bool argomento;
        private int livello;

        /* ------------
            Matematica
           ------------ */

        // Liste matematica
        private List<MatematicaLivello1> listaMateLivello1;
        private List<MatematicaLivello2> listaMateLivello2Livello3;

        // Lista per i risultati dei livelli di matematica
        private List<string> risultatiMateLivello1;
        private List<string> risultatiMateLivello2;

        // Lista per i suggerimenti dei livelli di matematica
        private List<string> suggerimentoMateLivello1;
        private List<string> suggerimentoMateLivello2;

        /* ------------
              Logica
           ------------ */

        // Liste logica
        private List<LogicaLivello1> listaLogicaLivello1;
        private List<LogicaLivello2> listaLogicaLivello2Livello3;

        // Lista per i risultati dei livelli di logica
        private List<string> risultatiLogicaLivello1;
        private List<string> risultatiLogicaLivello2;

        // Lista per i suggerimenti dei livelli di logica
        private List<string> suggerimentoLogicaLivello1;
        private List<string> suggerimentoLogicaLivello2;

        // Costruttore
        public DecisioneGioco(bool arg, int liv, Matematica mat, Logica log)
        {
            this.argomento = arg;
            this.livello = liv;
            this.argomentoMate = mat;
            this.argomentoLogica = log;

            this.risultatoEsatto = new List<string>();
            this.suggerimentoEsatto = new List<string>();

            // Metodi
            SceltaLivello();
            ListeMatematica();
            ListeLogica();
            CreaListaArgomento();
        }

        // Metodo per decidere il tipo di argomento -> logica o mate
        // e il relativo livello -> 1-2-3
        public void SceltaLivello()
        {
            // True -> Matematica
            if (this.argomento)
            {
                // Livello 1
                if (this.livello == 0)
                {
                    l = new MatematicaLivello1();
                    listaMateLivello1 = new List<MatematicaLivello1>();
                }
                // Livello 2
                else if (this.livello == 1)
                {
                    l = new MatematicaLivello2();
                    listaMateLivello2Livello3 = new List<MatematicaLivello2>();
                }
                // Livello 3, utilizza la stessa lista del livello 2
                else
                {
                    l = new MatematicaLivello3();
                    listaMateLivello2Livello3 = new List<MatematicaLivello2>();
                }
            }
            // False -> Logica
            else
            {
                // Livello 1
                if (this.livello == 0)
                {
                    l = new LogicaLivello1();
                    listaLogicaLivello1 = new List<LogicaLivello1>();
                }
                // Livello 2
                else if (this.livello == 1)
                {
                    l = new LogicaLivello2();
                    listaLogicaLivello2Livello3 = new List<LogicaLivello2>();
                }
                // Livello 3, utilizza la stessa lista del livello 2
                else
                {
                    l = new LogicaLivello3();
                    listaLogicaLivello2Livello3 = new List<LogicaLivello2>();
                }
            }
        }

        // Metodo per la creazione della lista a seconda dell'argomento (mate o logica) e del relativo livello.
        public void CreaListaArgomento()
        {
            // Dichiarazione variabili
            int numeroScelto;
            string nomeScelto;
            string suggerimento;
            // Lista quesiti
            quesiti = new List<LivelliGioco>();
            // Liste per ottenere la generazione di quesiti casuali
            listaNumeri = new List<int>();
            listaUtilizzoQues = new List<bool>();

            for (int n = 0; n < l.quesitiTotali; n++)
            {
                listaUtilizzoQues.Insert(n, false);
            }

            // Se l'argomento in questione è matematica (True)
            if (argomento)
            {
                // Matematica livello 1 
                if (this.livello == 0)
                {
                    // Completare la lista di quesiti per poter svolgere il livello 1
                    for (int i = 0; i <= l.quesitiDaRisolvere; i++)
                    {
                        // Numero scelto derivante dal metodo CreaNumeroRandom
                        numeroScelto = CreaNumeroRandom(listaNumeri, listaUtilizzoQues);

                        // Risultato esatto
                        nomeScelto = risultatiMateLivello1[numeroScelto];
                        risultatoEsatto.Add(nomeScelto);

                        // Suggerimento esatto
                        suggerimento = suggerimentoMateLivello1[numeroScelto];
                        suggerimentoEsatto.Add(suggerimento);

                        // Inserimento quesito di matematica
                        InserisciQuesitoMate(this.livello, i, numeroScelto);

                        // La Sleep permette di dar tempo per inserire i valori delle risposte
                        // di ogni quesito in modo casuale e posizionarli in maniera corretta
                        Thread.Sleep(150);

                        // Aggiungere il quesito nella lista di matematica livello 1
                        quesiti.Add(listaMateLivello1[i]);
                    }
                }
                // Matematica livello 2 e 3
                else
                {
                    // Completare la lista di quesiti per poter svolgere il livello 2 e 3
                    for (int i = 0; i <= l.quesitiDaRisolvere; i++)
                    {
                        // Numero scelto derivante dal metodo CreaNumeroRandom
                        numeroScelto = CreaNumeroRandom(listaNumeri, listaUtilizzoQues);

                        // Risultato esatto
                        nomeScelto = risultatiMateLivello2[numeroScelto];
                        risultatoEsatto.Add(nomeScelto);

                        // Suggerimento esatto
                        suggerimento = suggerimentoMateLivello2[numeroScelto];
                        suggerimentoEsatto.Add(suggerimento);

                        // Inserimento quesito di matematica
                        InserisciQuesitoMate(this.livello, i, numeroScelto);
                        // Sleep
                        Thread.Sleep(150);
                        // Aggiungere il quesito nella lista di matematica livello 2, livello 3
                        quesiti.Add(listaMateLivello2Livello3[i]);
                    }
                }
            }

            // Argomento in questione è la logica (False)
            else
            {
                // Logica livello 1 
                if (this.livello == 0)
                {
                    // Completare la lista di quesiti per poter svolgere il livello 1
                    for (int i = 0; i <= l.quesitiDaRisolvere; i++)
                    {
                        // Numero scelto
                        numeroScelto = CreaNumeroRandom(listaNumeri, listaUtilizzoQues);

                        // Risultato esatto
                        nomeScelto = risultatiLogicaLivello1[numeroScelto];
                        risultatoEsatto.Add(nomeScelto);

                        // Suggerimento esatto
                        suggerimento = suggerimentoLogicaLivello1[numeroScelto];
                        suggerimentoEsatto.Add(suggerimento);

                        // Inserimento quesito logica
                        InserisciQuesitoLogica(this.livello, i, numeroScelto);
                        // Sleep
                        Thread.Sleep(150);
                        // Aggiungere il quesito nella lista di logica livello 1
                        quesiti.Add(listaLogicaLivello1[i]);
                    }
                }
                // Logica livello 2 e 3
                else
                {
                    // Completare la lista di quesiti per poter svolgere il livello 2 e 3
                    for (int i = 0; i <= l.quesitiDaRisolvere; i++)
                    {
                        // Numero scelto
                        numeroScelto = CreaNumeroRandom(listaNumeri, listaUtilizzoQues);

                        // Risultato esatto
                        nomeScelto = risultatiLogicaLivello2[numeroScelto];
                        risultatoEsatto.Add(nomeScelto);

                        // Suggerimento esatto
                        suggerimento = suggerimentoLogicaLivello2[numeroScelto];
                        suggerimentoEsatto.Add(suggerimento);

                        // Inserimento quesito logica
                        InserisciQuesitoLogica(this.livello, i, numeroScelto);
                        // Sleep
                        Thread.Sleep(150);
                        // Aggiungere il quesito nella lista di logica livello 2, livello 3
                        quesiti.Add(listaLogicaLivello2Livello3[i]);
                    }
                }
            }
        }

        // Creazione di un numero casuale senza commettere l'errore di ripeterlo.
        public int CreaNumeroRandom(List<int> numero, List<bool> trovato)
        {
            Random rand = new Random();
            int numGenerato;
            do
            {
                numGenerato = rand.Next(0, l.quesitiTotali);
            } while (trovato[numGenerato] != (false));
            // impostare il numero trovato a true
            trovato[numGenerato] = true;
            numero.Add(numGenerato);
            return numGenerato;
        }

        // Inserimento quesito di matematica
        public void InserisciQuesitoMate(int liv, int numQuesitoDaRisolvere, int idQuesito)
        {
            // Riferimento del quesito
            int k = numQuesitoDaRisolvere;
            // Immagine del quesito
            int intImm = idQuesito;
            // Variabili per quesito inesatto e utilizzato
            int quesitoInes;
            string[] inesatta = new string[4];
            int[] quesitoUtilizzato = new int[4];

            // Variabile casuale per mettere in modo casuale la risposta corretta
            Random rand = new Random();
            // Variabile casuale per produrre le risposte errate
            Random randInesatta = new Random();
            
            // Stringhe utilizzate per il nome dei quesiti di matematica livello 1 - 2
            string nomeImm = NomeQuesitoMateLivello1(intImm);
            string nomeImm2 = NomeQuesitoMateLivello2(intImm);

            // Livello 1
            if (liv == 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    do
                    {
                        quesitoInes = randInesatta.Next(0, l.quesitiTotali);
                    } while ((quesitoInes == idQuesito) || (quesitoUtilizzato.Contains(quesitoInes)));

                    quesitoUtilizzato[i] = quesitoInes;
                    // Inserimento nella lista inesatta la risposta errata estratta a caso
                    inesatta[i] = risultatiMateLivello1[quesitoInes]; 
                }
                // Posizionare la risposta corretta in maniera casuale in una delle 5 possibili posizioni
                int riferimRisposta = rand.Next(1, 6);
                switch (riferimRisposta)
                {
                    case 1:
                        listaMateLivello1.Add(new MatematicaLivello1()
                        {
                            riferimQuesito = k,
                            immQuesito = nomeImm,
                            risposta1 = risultatoEsatto[k],
                            suggerimento = suggerimentoEsatto[k],
                            risposta2 = inesatta[0],
                            risposta3 = inesatta[1],
                            risposta4 = inesatta[2],
                            risposta5 = inesatta[3],
                            esatta = 1
                        });
                        break;

                    case 2:
                        listaMateLivello1.Add(new MatematicaLivello1()
                        {
                            riferimQuesito = k,
                            immQuesito = nomeImm,
                            risposta1 = inesatta[0],
                            risposta2 = risultatoEsatto[k],
                            suggerimento = suggerimentoEsatto[k],
                            risposta3 = inesatta[1],
                            risposta4 = inesatta[2],
                            risposta5 = inesatta[3],
                            esatta = 2
                        });
                        break;

                    case 3:
                        listaMateLivello1.Add(new MatematicaLivello1()
                        {
                            riferimQuesito = k,
                            immQuesito = nomeImm,
                            risposta1 = inesatta[0],
                            risposta2 = inesatta[1],
                            risposta3 = risultatoEsatto[k],
                            suggerimento = suggerimentoEsatto[k],
                            risposta4 = inesatta[2],
                            risposta5 = inesatta[3],
                            esatta = 3
                        });
                        break;

                    case 4:
                        listaMateLivello1.Add(new MatematicaLivello1()
                        {
                            riferimQuesito = k,
                            immQuesito = nomeImm,
                            risposta1 = inesatta[0],
                            risposta2 = inesatta[1],
                            risposta3 = inesatta[2],
                            risposta4 = risultatoEsatto[k],
                            suggerimento = suggerimentoEsatto[k],
                            risposta5 = inesatta[3],
                            esatta = 4
                        });
                        break;

                    case 5:
                        listaMateLivello1.Add(new MatematicaLivello1()
                        {
                            riferimQuesito = k,
                            immQuesito = nomeImm,
                            risposta1 = inesatta[0],
                            risposta2 = inesatta[1],
                            risposta3 = inesatta[2],
                            risposta4 = inesatta[3],
                            risposta5 = risultatoEsatto[k],
                            suggerimento = suggerimentoEsatto[k],
                            esatta = 5
                        });
                        break;

                    default:
                        break;
                }
            }

            // Livello 2 e 3
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    do
                    {
                        quesitoInes = randInesatta.Next(0, l.quesitiTotali);
                    } while ((quesitoInes == idQuesito) || (quesitoUtilizzato.Contains(quesitoInes)));

                    quesitoUtilizzato[i] = quesitoInes;
                    // Inserimento nella lista inesatta la risposta errata estratta a caso
                    inesatta[i] = risultatiMateLivello2[quesitoInes];
                }
                // Posizionare la risposta corretta in maniera casuale in una delle 5 possibili posizioni
                int riferimRisposta = rand.Next(1, 6);
                switch (riferimRisposta)
                {
                    case 1:
                        listaMateLivello2Livello3.Add(new MatematicaLivello2()
                        {
                            riferimQuesito = k,
                            immQuesito = nomeImm2,
                            risposta1 = risultatoEsatto[k],
                            suggerimento = suggerimentoEsatto[k],
                            risposta2 = inesatta[0],
                            risposta3 = inesatta[1],
                            risposta4 = inesatta[2],
                            risposta5 = inesatta[3],
                            esatta = 1
                        }
                     );
                        break;

                    case 2:
                        listaMateLivello2Livello3.Add(new MatematicaLivello2()
                        {
                            riferimQuesito = k,
                            immQuesito = nomeImm2,
                            risposta1 = inesatta[0],
                            risposta2 = risultatoEsatto[k],
                            suggerimento = suggerimentoEsatto[k],
                            risposta3 = inesatta[1],
                            risposta4 = inesatta[2],
                            risposta5 = inesatta[3],
                            esatta = 2
                        });
                        break;

                    case 3:
                        listaMateLivello2Livello3.Add(new MatematicaLivello2()
                        {
                            riferimQuesito = k,
                            immQuesito = nomeImm2,
                            risposta1 = inesatta[0],
                            risposta2 = inesatta[1],
                            risposta3 = risultatoEsatto[k],
                            suggerimento = suggerimentoEsatto[k],
                            risposta4 = inesatta[2],
                            risposta5 = inesatta[3],
                            esatta = 3
                        });
                        break;

                    case 4:
                        listaMateLivello2Livello3.Add(new MatematicaLivello2()
                        {
                            riferimQuesito = k,
                            immQuesito = nomeImm2,
                            risposta1 = inesatta[0],
                            risposta2 = inesatta[1],
                            risposta3 = inesatta[2],
                            risposta4 = risultatoEsatto[k],
                            suggerimento = suggerimentoEsatto[k],
                            risposta5 = inesatta[3],
                            esatta = 4
                        });
                        break;

                    case 5:
                        listaMateLivello2Livello3.Add(new MatematicaLivello2()
                        {
                            riferimQuesito = k,
                            immQuesito = nomeImm2,
                            risposta1 = inesatta[0],
                            risposta2 = inesatta[1],
                            risposta3 = inesatta[2],
                            risposta4 = inesatta[3],
                            risposta5 = risultatoEsatto[k],
                            suggerimento = suggerimentoEsatto[k],
                            esatta = 5
                        });
                        break;

                    default:
                        break;
                }
            }
        }

        // Inserimento quesito di logica
        public void InserisciQuesitoLogica(int liv, int numQuesitoDaRisolvere, int idQuesito)
        {
            // Riferimento del quesito
            int k = numQuesitoDaRisolvere;
            // Immagine del quesito
            int intImm = idQuesito;
            // Variabili per quesito inesatto e utilizzato
            int quesitoInes;
            string[] inesatta = new string[4];
            int[] quesitoUtilizzato = new int[4];

            // Variabile casuale per mettere in modo casuale la risposta corretta
            Random rand = new Random();
            // Variabile casuale per produrre le risposte errate
            Random randInesatta = new Random();

            // Stringhe utilizzate per il nome dei quesiti di logica livello 1 - 2
            string nomeImm3 = NomeQuesitoLogicaLivello1(intImm);
            string nomeImm4 = NomeQuesitoLogicaLivello2(intImm);

            // Livello 1
            if (liv == 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    do
                    {
                        quesitoInes = randInesatta.Next(0, l.quesitiTotali);
                    } while ((quesitoInes == idQuesito) || (quesitoUtilizzato.Contains(quesitoInes)));

                    quesitoUtilizzato[i] = quesitoInes;
                    // Inserimento nella lista inesatta la risposta errata estratta a caso
                    inesatta[i] = risultatiLogicaLivello1[quesitoInes];
                }
                // Posizionare la risposta corretta in maniera casuale in una delle 5 possibili posizioni
                int riferimRisposta = rand.Next(1, 6);

                switch (riferimRisposta)
                {
                    case 1:
                        listaLogicaLivello1.Add(new LogicaLivello1()
                        {
                            riferimQuesito = k,
                            immQuesito = nomeImm3,
                            risposta1 = risultatoEsatto[k],
                            suggerimento = suggerimentoEsatto[k],
                            risposta2 = inesatta[0],
                            risposta3 = inesatta[1],
                            risposta4 = inesatta[2],
                            risposta5 = inesatta[3],
                            esatta = 1
                        });
                        break;

                    case 2:
                        listaLogicaLivello1.Add(new LogicaLivello1()
                        {
                            riferimQuesito = k,
                            immQuesito = nomeImm3,
                            risposta1 = inesatta[0],
                            risposta2 = risultatoEsatto[k],
                            suggerimento = suggerimentoEsatto[k],
                            risposta3 = inesatta[1],
                            risposta4 = inesatta[2],
                            risposta5 = inesatta[3],
                            esatta = 2
                        });
                        break;

                    case 3:
                        listaLogicaLivello1.Add(new LogicaLivello1()
                        {
                            riferimQuesito = k,
                            immQuesito = nomeImm3,
                            risposta1 = inesatta[0],
                            risposta2 = inesatta[1],
                            risposta3 = risultatoEsatto[k],
                            suggerimento = suggerimentoEsatto[k],
                            risposta4 = inesatta[2],
                            risposta5 = inesatta[3],
                            esatta = 3
                        });
                        break;

                    case 4:
                        listaLogicaLivello1.Add(new LogicaLivello1()
                        {
                            riferimQuesito = k,
                            immQuesito = nomeImm3,
                            risposta1 = inesatta[0],
                            risposta2 = inesatta[1],
                            risposta3 = inesatta[2],
                            risposta4 = risultatoEsatto[k],
                            suggerimento = suggerimentoEsatto[k],
                            risposta5 = inesatta[3],
                            esatta = 4
                        });
                        break;

                    case 5:
                        listaLogicaLivello1.Add(new LogicaLivello1()
                        {
                            riferimQuesito = k,
                            immQuesito = nomeImm3,
                            risposta1 = inesatta[0],
                            risposta2 = inesatta[1],
                            risposta3 = inesatta[2],
                            risposta4 = inesatta[3],
                            risposta5 = risultatoEsatto[k],
                            suggerimento = suggerimentoEsatto[k],
                            esatta = 5
                        });
                        break;

                    default:
                        break;
                }
            }

            // Livello 2 e 3
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    do
                    {
                        quesitoInes = randInesatta.Next(0, l.quesitiTotali);
                    } while ((quesitoInes == idQuesito) || (quesitoUtilizzato.Contains(quesitoInes)));

                    quesitoUtilizzato[i] = quesitoInes;
                    // Inserimento nella lista inesatta la risposta errata estratta a caso
                    inesatta[i] = risultatiLogicaLivello2[quesitoInes];
                }
                // Posizionare la risposta corretta in maniera casuale in una delle 5 possibili posizioni
                int riferimRisposta = rand.Next(1, 6);

                switch (riferimRisposta)
                {
                    case 1:
                        listaLogicaLivello2Livello3.Add(new LogicaLivello2()
                        {
                            riferimQuesito = k,
                            immQuesito = nomeImm4,
                            risposta1 = risultatoEsatto[k],
                            suggerimento = suggerimentoEsatto[k],
                            risposta2 = inesatta[0],
                            risposta3 = inesatta[1],
                            risposta4 = inesatta[2],
                            risposta5 = inesatta[3],
                            esatta = 1
                        }
                     );
                        break;

                    case 2:
                        listaLogicaLivello2Livello3.Add(new LogicaLivello2()
                        {
                            riferimQuesito = k,
                            immQuesito = nomeImm4,
                            risposta1 = inesatta[0],
                            risposta2 = risultatoEsatto[k],
                            suggerimento = suggerimentoEsatto[k],
                            risposta3 = inesatta[1],
                            risposta4 = inesatta[2],
                            risposta5 = inesatta[3],
                            esatta = 2
                        });
                        break;

                    case 3:
                        listaLogicaLivello2Livello3.Add(new LogicaLivello2()
                        {
                            riferimQuesito = k,
                            immQuesito = nomeImm4,
                            risposta1 = inesatta[0],
                            risposta2 = inesatta[1],
                            risposta3 = risultatoEsatto[k],
                            suggerimento = suggerimentoEsatto[k],
                            risposta4 = inesatta[2],
                            risposta5 = inesatta[3],
                            esatta = 3
                        });
                        break;

                    case 4:
                        listaLogicaLivello2Livello3.Add(new LogicaLivello2()
                        {
                            riferimQuesito = k,
                            immQuesito = nomeImm4,
                            risposta1 = inesatta[0],
                            risposta2 = inesatta[1],
                            risposta3 = inesatta[2],
                            risposta4 = risultatoEsatto[k],
                            suggerimento = suggerimentoEsatto[k],
                            risposta5 = inesatta[3],
                            esatta = 4
                        });
                        break;

                    case 5:
                        listaLogicaLivello2Livello3.Add(new LogicaLivello2()
                        {
                            riferimQuesito = k,
                            immQuesito = nomeImm4,
                            risposta1 = inesatta[0],
                            risposta2 = inesatta[1],
                            risposta3 = inesatta[2],
                            risposta4 = inesatta[3],
                            risposta5 = risultatoEsatto[k],
                            suggerimento = suggerimentoEsatto[k],
                            esatta = 5
                        });
                        break;

                    default:
                        break;
                }
            }
        }
    
        /* ----------------------------------------------------------------------------------------------------- 
           Stringhe immagini matematica                     -> Livello 1 = 'm' + numero di riferimento
           (le prime due lettere della parola matematica)   -> Livello 2 = 'a' + numero di riferimento

           Metodi che collegano il numero random con il nome dell'immagine che conterrà il quesito. (Matematica)
           ----------------------------------------------------------------------------------------------------- */

        // Matematica Livello 1
        public string NomeQuesitoMateLivello1(int riferimQuesito)
        {
            int rif = riferimQuesito + 1; // i riferimenti iniziano da 1 e non da 0. Esempio m1, m2, m3..

            string nomeQuesitoImm;
            nomeQuesitoImm = 'm' + rif.ToString();

            return nomeQuesitoImm;
        }

        // Matematica Livello 2 e 3
        public string NomeQuesitoMateLivello2(int riferimQuesito)
        {
            int rif = riferimQuesito + 1; // i riferimenti iniziano da 1 e non da 0. Esempio a1, a2, a3..

            string nomeQuesitoImm;
            nomeQuesitoImm = 'a' + rif.ToString();

            return nomeQuesitoImm;
        }


        /* -----------------------------------------------------------------------------------------------------
           Stringhe immagini logica                     -> Livello 1 = 'l' + numero di riferimento
           (le prime due lettere della parola logica)   -> Livello 2 = 'o' + numero di riferimento

           Metodi che collegano il numero random con il nome dell'immagine che conterrà il quesito. (Logica)
           ----------------------------------------------------------------------------------------------------- */

        // Logica Livello 1
        public string NomeQuesitoLogicaLivello1(int riferimQuesito)
        {
            int rif = riferimQuesito + 1; // i riferimenti iniziano da 1 e non da 0. Esempio l1, l2, l3..

            string nomeQuesitoImm;
            nomeQuesitoImm = 'l' + rif.ToString();

            return nomeQuesitoImm;
        }
        // Logica Livello 2 e 3
        public string NomeQuesitoLogicaLivello2(int riferimQuesito)
        {
            int rif = riferimQuesito + 1; // i riferimenti iniziano da 1 e non da 0. Esempio o1, o2, o3..

            string nomeQuesitoImm;
            nomeQuesitoImm = 'o' + rif.ToString();

            return nomeQuesitoImm;
        }


        /* ----------------------------------------------------------------------------------------------- 
           Metodo che contiene tutte le liste inerenti
           l'argomento matematica, nello specifico:
                                                    - Tutti i possibili risultati livello 1
                                                    - Tutti i possibili risultati livello 2 e 3
                                                    - Tutti i possibili suggerimenti livello 1
                                                    - Tutti i possibili suggerimenti livello 2
           ----------------------------------------------------------------------------------------------- */
        public void ListeMatematica()
        {
            risultatiMateLivello1 = new List<string>(new string[]
            {
                "0", "2", "3", "4", "5", "6", "7.5", "7", "8", "9",
                "10","11", "15", "16", "17", "32", "34", "55", "75", "99", "118"
            });

            risultatiMateLivello2 = new List<string>(new string[]
            {
                "0", "1", "2", "3", "4", "5", "7", "8", "9", "10", 
                "14", "15", "23", "29", "36", "38","46", "50", "52", "69", 
                "74", "84", "96", "129", "145"
            });

            suggerimentoMateLivello1 = new List<string>(new string[]
            {
                "9 × 8 = 72; 72 × 8 = 576; 576 × 8 = _",
                "Esempio 5 + 9 = 10 + 4",
                "7 + 6 + _ = 16 e 4 × 7 × _ = 84",
                "9 × 8 = 72",
                "(9 + 7) x 2 = 32",
                "5749827 + 3864759 = _",
                "9 × 5 = 45 e 6 × ? = 45",
                "3 + 5 = 8, 2 + 7 = 9",
                "(9 + 7 + 1 = 17) – (4 + 3 = 7) = 10",
                "(9 + 8) – (7 + 5)",
                "16 – 10 = 10 – 4",
                "Ogni piramide di 3 numberi totale 21",
                "72 + 44 = 116 / 4 = 29",
                "(33 + 31) / 4 = _",
                "7 + 6 = 13",
                "6 × 4 = 6 + 18",
                "8 x 5 – 2",
                "Ogni numero indica la sua posizione",
                "7 × 52 = 364",
                "8 + 1 = 9, 6 + 2 = 8",
                "3 + 5 = 8, 6 + 7 = 13",
            });

            suggerimentoMateLivello2 = new List<string>(new string[]
            {
                "574 + 212 + 324 = 1110",
                "Ogni triangolo contiene 1 – 9",
                "Senza ombra -> (2+7+3+4) / 2 = con ombra -> 1 + 7",
                "Iniziare dall'alto 12 + 1 + 2 = 15, 15 + 1 + 5 = 21",
                "7 x 3 = 21 e 2 x 3 = 6",
                "70 ÷ 14 = 5",
                "2, 5, 8, 11 -> 3",
                "La media dei numeri",
                "473892 + 516359 = _",
                "Gruppo triangolare di 3 numeri = 21",
                "7 × 9 = 63; 63 / 3 = 21",
                "Iniziare da 0 e saltare 2 segmenti ogni volta",
                "La terza riga è la prima riga con cifre invertite",
                "93 + 95 = 188. 188 ÷ 4 = 47",
                "24 / 6 x 7 = 28",
                "(8 × 7 = 56) – (3 × 4 = 12) = 44",
                "Aggiunta in senso orario 3, 6, 9, 12, 15, 18",
                "Aggiungere 1, 3, 9, 27, 81",
                "+ 9 e poi - 3",
                "(6 × 9 = 54) + (7 × 8 = 56) = 110",
                "Leggere in senso orario sezione esterna ed interna",
                "(6 × 8) × 10/5 = 96",
                "(6 × 5) + (2 × 4) = 38",
                "3 x 8 = 24 e 2 + 7 = 9",
                "Aggiungere i quattro numeri precedenti",
            });
        }

        /* ------------------------------------------------------------------------------------------- 
           Metodo che contiene tutte le liste inerenti
           l'argomento logica, nello specifico:
                                                - Tutti i possibili risultati livello 1
                                                - Tutti i possibili risultati livello 2 e 3
                                                - Tutti i possibili suggerimenti livello 1
                                                - Tutti i possibili suggerimenti livello 2 
           ------------------------------------------------------------------------------------------- */

        public void ListeLogica()
        {
            risultatiLogicaLivello1 = new List<string>(new string[]
            {
                "A","A","A","A","A","A",
                "B","B","B","B","B",
                "C","C","C","C","C",
                "D","D","D","D","D","D",
                "E","E","E","E","E",
            });

            risultatiLogicaLivello2 = new List<string>(new string[]
            {
                "A","A","A","A","A","A",
                "B","B","B","B","B","B",
                "C","C","C","C","C","C",
                "D","D","D","D","D","D",
                "E","E","E","E","E","E",
            });

            suggerimentoLogicaLivello1 = new List<string>(new string[]
            {
                // A
                "Bianco e nero al contrario",
                "Immagine riflessa",
                "Immagine riflessa",
                "La combinazione di punti all'interno è lo stesso diamante opposto",
                "Le figure superiori e inferiori si rimbaltano",
                "I 2 cerchi sottostanti si combinano per produrre il cerchio sopra",
                // B
                "La parte comune a tutte e 3 le figure è ombreggiata",
                "I 3 anelli sono ombreggiati in nero una volta",
                "Determinato dal contenuto dei primi 2 quadrati",
                "Determinato dal contenuto dei primi 2 esagoni",
                "Il resto ha la stessa figura ruotata",
                // C
                "Stesse figure",
                "Vengono aggiunti 2 cerchi per produrre il cerchio sopra",
                "Immagine riflessa dell'opposto, con inversione bianco nero",
                "L'altro quadrato nero si sta spostando dal basso verso l'alto",
                "Determinato dal contenuto dei 2 pentagoni sotto",
                // D
                "Immagine riflessa dell'opposto",
                "Il numero di punti +1 e il bianco diventa nero",
                "Immagine rilfessa dell'opposto, con inversione bianco nero",
                "Ci sono 4 coppie identiche con inversione bianco nero",
                "Determinato dai 2 esagoni immediatamente sotto",
                "Il diamante si muove attorno ad ogni angolo in senso orario",
                // E
                "In ogni gruppo di 4, la freccia si sposta di 90 gradi senso orario",
                "Ogni linea lato opposto e verso il basso contiene 1 dei 3 simboli",
                "In tutti gli altri le aree comuni ai 2 cerchi sono ombreggiate",
                "Contiene un cerchio in un quadrato",
                "Tutti i punti bianchi sono collegati",
            });

            suggerimentoLogicaLivello2 = new List<string>(new string[]
            {
                // A
                "Un punto bianco, un punto nero e la figura interna invertita",
                "Immaginare come può essere riprodotto il cubo",
                "Il quadrato 1 si sposta in basso a destra",
                "Immaginare solamente come può essere chiuso",
                "La figura in basso ruota di 90 gradi e va verso sinistra",
                "Il quadrato va inserito dentro il diamante",
                // B
                "Gli oggetti neri diventano bianchi e viceversa",
                "I cerchi vengono trasferiti solo nel cerchio centrale",
                "Ruotare di metà della lunghezza del rettangolo stazionario",
                "Solo punti che appaiono nella stessa posizione solo 2 volte",
                "Invertire la prima analogia",
                "Le figure sono immagini speculari con inversione bianca-nera",
                // C
                "Viene aggiunto un nuovo triangolo che si muove in senso antiorario",
                "Il cerchio nero è collegato a 3 cerchi bianchi",
                "Il punto si sta muovendo da un angolo all'altro in senso orario",
                "Solo linee e simboli che compaiono 2 volte",
                "Ogni coppia di esagoni adiacenti contiene 3 punti neri, 5 bianchi",
                "La sezione comune ad entrambi i triangoli è sembre ombreggiata",
                // D
                "Simboli dei cerchi inferiori si combinano per formare quello sopra",
                "A è uguale a E con le ali *dentro-fuori*",
                "Le frecce puntano in ciascuna delle 3 direzioni",
                "I blocchi opposti dei 4 quadrati sono identici",
                "Il pentagono è determinato dal contenuto dei 2 sottostanti",
                "Le figure sono nello stesso ordine attorno al corpo",
                // E
                "Le linee che appaiono 3 volte vengono trasportate",
                "La sezione 2 in senso orario dal singolo punto bianco scompare",
                "Il parallelogramma si capovolge",
                "I 2 cerchi più piccoli uniti formano il cerchio sopra",
                "x + y = z, 1 + 2 creano 3, ma i simboli simili si eliminano",
                "x + y = z; 1 + 2 creano 3, ma i simboli simili si eliminano",
            });
        }

        /* ------------------------------------------------------------------
           Metodi per trovare sia in logica
           che in matematica:
                                    - immagine del quesito
                                    - 5 risposte possibili alla risoluzione
                                    - suggerimento del quesito
                                    - soluzione del quesito
           ------------------------------------------------------------------ */

        // Metodo per trovare il quesito (immagine)
        public string AcquisisciImmagineQuesito(int deciso)
        {
            LivelliGioco ques = quesiti.Find(x => (x.riferimQuesito == deciso));
            string imm = ques.immQuesito;
            return imm;
        }

        // Metodo per trovare il risultato da inserire nella prima risposta
        public string RisultatoNumeroLettera1(int deciso)
        {
            LivelliGioco ques = quesiti.Find(x => (x.riferimQuesito == deciso));
            string risult1 = ques.risposta1;
            return risult1;
        }

        // Metodo per trovare il risultato da inserire nella seconda risposta
        public string RisultatoNumeroLettera2(int deciso)
        {
            LivelliGioco ques = quesiti.Find(x => (x.riferimQuesito == deciso));
            string risult2 = ques.risposta2;
            return risult2;
        }

        // Metodo per trovare il risultato da inserire nella terza risposta
        public string RisultatoNumeroLettera3(int deciso)
        {
            LivelliGioco ques = quesiti.Find(x => (x.riferimQuesito == deciso));
            string risult3 = ques.risposta3;
            return risult3;
        }

        // Metodo per trovare il risultato da inserire nella quarta risposta
        public string RisultatoNumeroLettera4(int deciso)
        {
            LivelliGioco ques = quesiti.Find(x => (x.riferimQuesito == deciso));
            string risult4 = ques.risposta4;
            return risult4;
        }

        // Metodo per trovare il risultato da inserire nella quinta risposta
        public string RisultatoNumeroLettera5(int deciso)
        {
            LivelliGioco ques = quesiti.Find(x => (x.riferimQuesito == deciso));
            string risult5 = ques.risposta5;
            return risult5;
        }

        // Metodo per trovare il suggerimento esatto per il quesito
        public string RisultatoSuggerimento(int deciso)
        {
            LivelliGioco ques = quesiti.Find(x => (x.riferimQuesito == deciso));
            string risultSugg = ques.suggerimento;
            return risultSugg;
        }

        // Metodo per trovare la risposta esatta del quesito
        public int SoluzioneEsatta(int deciso)
        {
            LivelliGioco ques = quesiti.Find(x => (x.riferimQuesito == deciso));
            int esatta = ques.esatta;
            return esatta;
        }
    }
}