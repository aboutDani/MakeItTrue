using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeItTrue.Model
{
    class MatematicaLivello2 : LivelliGioco
    {
        // Quesiti da risolvere nel livello 2 per completare la partita di matematica
        private const int QDARISOLV = 7;
        // Quesiti totali che possono capitare all'interno del livello 2 di matematica
        private const int QTOTALI = 25;

        public override int quesitiDaRisolvere { get { return QDARISOLV; } }

        public override int quesitiTotali { get { return QTOTALI; } }
    }
}
