using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeItTrue.Model
{
    class MatematicaLivello1 : LivelliGioco
    {
        // Quesiti da risolvere nel livello 1 per completare la partita di matematica
        private const int QDARISOLV = 7;
        // Quesiti totali che possono capitare all'interno del livello 1 di matematica
        private const int QTOTALI = 21;

        public override int quesitiDaRisolvere { get { return QDARISOLV; } }

        public override int quesitiTotali { get { return QTOTALI; } }
    }
}
