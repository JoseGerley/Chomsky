using ChomskyLogic.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChomskyLogic
{
    public partial class EntradaDatos : Form
    {

        [DllImport("user32.dll", EntryPoint = "GetSystemMenu")]

        private static extern IntPtr GetSystemMenu(IntPtr hwnd, int revert);

        [DllImport("user32.dll", EntryPoint = "GetMenuItemCount")]

        private static extern int GetMenuItemCount(IntPtr hmenu);

        [DllImport("user32.dll", EntryPoint = "RemoveMenu")]

        private static extern int RemoveMenu(IntPtr hmenu, int npos, int wflags);

        [DllImport("user32.dll", EntryPoint = "DrawMenuBar")]

        private static extern int DrawMenuBar(IntPtr hwnd);

        private const int MF_BYPOSITION = 0x0400;

        private const int MF_DISABLED = 0x0002;

        private Login log;
        private Chomsky chomsky;

        public EntradaDatos(Login l)
        {
            InitializeComponent();
            log = l;
            this.TextHere.Text = Inicializate_Text_Note();
        }

        private void Next_Click(object sender, EventArgs e)
        {
            chomsky = new Chomsky(txtBoxGrammar.Text);
            Desarrollo des = new Desarrollo(this);
            
            des.Show();
            this.Hide();
            

        }

        public Chomsky getModel()
        {
            return chomsky;
        }

        private String Inicializate_Text_Note()
        {
            String msj = "Nota (Por cada linea): \n" +
                "1. Primero introduzca la Variable \n" +
                "2. Separe las Variable de las producciones atraves de '>' \n" +
                "3. Separe cada subproduccion por medio de un '_' \n" +
                "4. Utilice una linea por cada produccion \n" +
                "5. La primera produccion, deberá ser 'S' \n" +
                "6. Identifique el simbolo lamda como # \n" +
                "7. Por ejemplo S>AB_aBC_SBS";
            return msj;
        }

        private void variableslbl_Click(object sender, EventArgs e)
        {

        }

        private void TextHere_Click(object sender, EventArgs e)
        {

        }
 

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public new void Close()
        {
            log.Close();
        }

        private void EntradaDatos_Load(object sender, EventArgs e)
        {
            IntPtr hmenu = GetSystemMenu(this.Handle, 0);

            int cnt = GetMenuItemCount(hmenu);

            // remove 'close' action

            RemoveMenu(hmenu, cnt - 1, MF_DISABLED | MF_BYPOSITION);

            // remove extra menu line

            RemoveMenu(hmenu, cnt - 2, MF_DISABLED | MF_BYPOSITION);

            DrawMenuBar(this.Handle);
        }

        private void txtBoxGrammar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
