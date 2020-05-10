using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeItTrue.Model
{
    sealed class MatematicaLivello3 : MatematicaLivello2
    {
        // Quesiti da risolvere nel livello 3 per completare la partita di matematica
        private const int QDARISOLV = 5;
        // Quesiti totali che possono capitare all'interno del livello 3 di matematica
        private const int QTOTALI = 25;

        public override int quesitiDaRisolvere { get { return QDARISOLV; } }

        public override int quesitiTotali { get { return QTOTALI; } }
    }
}
