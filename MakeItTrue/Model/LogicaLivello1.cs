using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeItTrue.Model
{
    class LogicaLivello1 : LivelliGioco
    {
        // Quesiti da risolvere nel livello 1 per completare la partita di logica
        private const int QDARISOLV = 7;
        // Quesiti totali che possono capitare all'interno del livello 1 di logica
        private const int QTOTALI = 27; 

        public override int quesitiDaRisolvere { get { return QDARISOLV; } }
        public override int quesitiTotali { get { return QTOTALI; } }
    }
}
