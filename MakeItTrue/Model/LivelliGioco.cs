using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeItTrue.Model
{
     abstract class LivelliGioco
    {
        // Le 5 risposte dei quesiti, per matematica sono numeri mentre
        // per la logica sono le lettere maiuscole A,B,C,D,E.
        public string risposta1 { get; set; }
        public string risposta2 { get; set; }
        public string risposta3 { get; set; }
        public string risposta4 { get; set; }
        public string risposta5 { get; set; }


        // Utilizzate per dare un'identità e un'immagine al quesito.
        public string immQuesito { get; set; }
        public int riferimQuesito { get; set; }


        // Quesiti che ogni argomento prevede (nel caso specifico saranno 7
        // per il livello 1 e 2, per il livello 3 saranno 5)
        public abstract int quesitiDaRisolvere { get; }

        // Quesiti totali da considerare in ogni livello.
        public abstract int quesitiTotali { get; }


        // Suggerimento per ogni quesito
        public string suggerimento { get; set; }

        // Risposta esatta al quesito
        public int esatta { get; set; }
    }
}
