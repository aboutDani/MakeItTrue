using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeItTrue.View
{
    public partial class MenuPrincipale : Form
    {
        public MenuPrincipale()
        {
            InitializeComponent();
            PersonalizzaDesign();

            // Gestione informazioni con Timer
            labelInfo.Text = informazioni[infoAttiva];
            timerInfo.Start();
        }

        // Informazioni iniziali menu per una spiegazione generale del gioco
        List<string> informazioni = new List<string>()
        {
            "Scegli Matematica o Logica",
            "Decidi il livello di gioco",
            "Risposta corretta -> Blu",
            "Risposta errata -> Giallo",
            "Il timer ti sarà nemico"
        };

        // Inizializzazione variabile informazione
        public int infoAttiva = 0;

        // Timer informazioni
        private void timerInfo_Tick(object sender, EventArgs e)
        {
            infoAttiva = (infoAttiva + 1) % informazioni.Count;
            labelInfo.Text = informazioni[infoAttiva];
        }

        // Matematica bottoni
        public Button mateLvl1Button
        { 
            get { return this.mateLvl1Butt; }
        }
        public Button mateLvl2Button
        { 
            get { return this.mateLvl2Butt; }
        }
        public Button mateLvl3Button
        {
            get { return this.mateLvl3Butt; }
        }

        // Logica bottoni
        public Button logicLvl1Button
        { 
            get { return this.logicLvl1Butt; }
        }
        public Button logicLvl2Button
        { 
            get { return this.logicLvl2Butt; }
        }
        public Button logicLvl3Button
        { 
            get { return this.logicLvl3Butt; }
        }

        // Personalizzazione Menu principale
        private void PersonalizzaDesign()
        {
            subMenuMate.Visible = false;
            subMenuLogic.Visible = false;
        }

        // Gestione visibilità dei submenu
        private void MostraSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        // Mostrare i livelli di matematica e logica
        private void mateButt_Click(object sender, EventArgs e)
        {
            MostraSubMenu(subMenuMate);
        }
        private void logicButt_Click(object sender, EventArgs e)
        {
            MostraSubMenu(subMenuLogic);
        }
    }
}
