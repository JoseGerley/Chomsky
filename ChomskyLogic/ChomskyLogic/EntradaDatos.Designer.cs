namespace ChomskyLogic
{
    partial class EntradaDatos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntradaDatos));
            this.Next = new System.Windows.Forms.Button();
            this.variableslbl = new System.Windows.Forms.Label();
            this.txtBoxGrammar = new System.Windows.Forms.RichTextBox();
            this.TextHere = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Exit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Next
            // 
            this.Next.BackColor = System.Drawing.Color.Transparent;
            this.Next.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Next.BackgroundImage")));
            this.Next.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Next.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Next.Location = new System.Drawing.Point(379, 356);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(170, 82);
            this.Next.TabIndex = 0;
            this.Next.UseVisualStyleBackColor = false;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // variableslbl
            // 
            this.variableslbl.AutoSize = true;
            this.variableslbl.BackColor = System.Drawing.Color.Transparent;
            this.variableslbl.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.variableslbl.ForeColor = System.Drawing.SystemColors.Control;
            this.variableslbl.Location = new System.Drawing.Point(12, 9);
            this.variableslbl.Name = "variableslbl";
            this.variableslbl.Size = new System.Drawing.Size(385, 33);
            this.variableslbl.TabIndex = 1;
            this.variableslbl.Text = "Introduzca las producciones de G";
            this.variableslbl.Click += new System.EventHandler(this.variableslbl_Click);
            // 
            // txtBoxGrammar
            // 
            this.txtBoxGrammar.BackColor = System.Drawing.Color.LightGray;
            this.txtBoxGrammar.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtBoxGrammar.ForeColor = System.Drawing.Color.Black;
            this.txtBoxGrammar.Location = new System.Drawing.Point(555, 0);
            this.txtBoxGrammar.Name = "txtBoxGrammar";
            this.txtBoxGrammar.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtBoxGrammar.Size = new System.Drawing.Size(362, 450);
            this.txtBoxGrammar.TabIndex = 3;
            this.txtBoxGrammar.Text = "";
            this.txtBoxGrammar.TextChanged += new System.EventHandler(this.txtBoxGrammar_TextChanged);
            // 
            // TextHere
            // 
            this.TextHere.AutoSize = true;
            this.TextHere.BackColor = System.Drawing.Color.Transparent;
            this.TextHere.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.TextHere.ForeColor = System.Drawing.SystemColors.Control;
            this.TextHere.Location = new System.Drawing.Point(3, 10);
            this.TextHere.Name = "TextHere";
            this.TextHere.Size = new System.Drawing.Size(91, 22);
            this.TextHere.TabIndex = 4;
            this.TextHere.Text = "Text Here";
            this.TextHere.Click += new System.EventHandler(this.TextHere_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.TextHere);
            this.panel1.Location = new System.Drawing.Point(18, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(531, 278);
            this.panel1.TabIndex = 5;
            // 
            // Exit
            // 
            this.Exit.AutoSize = true;
            this.Exit.BackColor = System.Drawing.Color.Transparent;
            this.Exit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Exit.BackgroundImage")));
            this.Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exit.Location = new System.Drawing.Point(25, 356);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(166, 82);
            this.Exit.TabIndex = 6;
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // EntradaDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(917, 450);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtBoxGrammar);
            this.Controls.Add(this.variableslbl);
            this.Controls.Add(this.Next);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EntradaDatos";
            this.Text = "EntradaDatos";
            this.Load += new System.EventHandler(this.EntradaDatos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Next;
        private System.Windows.Forms.Label variableslbl;
        private System.Windows.Forms.RichTextBox txtBoxGrammar;
        private System.Windows.Forms.Label TextHere;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Exit;
    }
}