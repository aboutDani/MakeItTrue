using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeItTrue.Model
{
    class LogicaLivello2 : LivelliGioco
    {
        // Quesiti da risolvere nel livello 2 per completare la partita di logica
        private const int QDARISOLV = 7;
        // Quesiti totali che possono capitare all'interno del livello 2 di logica
        private const int QTOTALI = 30;

        public override int quesitiDaRisolvere { get { return QDARISOLV; } }

        public override int quesitiTotali { get { return QTOTALI; } }
    }
}
