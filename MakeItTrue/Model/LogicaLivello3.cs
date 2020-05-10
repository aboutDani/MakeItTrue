using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeItTrue.Model
{
    sealed class LogicaLivello3 : LogicaLivello2
    {
        // Quesiti da risolvere nel livello 3 per completare la partita di logica
        private const int QDARISOLV = 5;
        // Quesiti totali che possono capitare all'interno del livello 3 di logica
        private const int QTOTALI = 30;

        public override int quesitiDaRisolvere { get { return QDARISOLV; } }

        public override int quesitiTotali { get { return QTOTALI; } }
    }
}
