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
    public partial class Desarrollo : Form
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
        private EntradaDatos datosI;
        public Desarrollo(EntradaDatos etddts)
        {
            InitializeComponent();
            datosI = etddts;
            BTxt1Prev.Text = datosI.getModel().actualGrammar;
            BTxt2Next.Text = datosI.getModel().nextGrammar;
        }

        private void BTxt1Prev_TextChanged(object sender, EventArgs e)
        {

        }

        private void panelButtom_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Desarrollo_Load(object sender, EventArgs e)
        {
            IntPtr hmenu = GetSystemMenu(this.Handle, 0);

            int cnt = GetMenuItemCount(hmenu);

            // remove 'close' action

            RemoveMenu(hmenu, cnt - 1, MF_DISABLED | MF_BYPOSITION);

            // remove extra menu line

            RemoveMenu(hmenu, cnt - 2, MF_DISABLED | MF_BYPOSITION);

            DrawMenuBar(this.Handle);
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            datosI.Close();
        }

        private void Next_Click(object sender, EventArgs e)
        {
            datosI.getModel().applyAlgorithm();
            BTxt1Prev.Text = datosI.getModel().actualGrammar;
            BTxt2Next.Text = datosI.getModel().nextGrammar;
        }
    }
}
