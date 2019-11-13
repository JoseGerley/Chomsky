namespace ChomskyLogic
{
    partial class Desarrollo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Desarrollo));
            this.BTxt1Prev = new System.Windows.Forms.RichTextBox();
            this.BTxt2Next = new System.Windows.Forms.RichTextBox();
            this.panelButtom = new System.Windows.Forms.Panel();
            this.symbol = new System.Windows.Forms.Label();
            this.Next = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.panelButtom.SuspendLayout();
            this.SuspendLayout();
            // 
            // BTxt1Prev
            // 
            this.BTxt1Prev.BackColor = System.Drawing.Color.LightGray;
            this.BTxt1Prev.Dock = System.Windows.Forms.DockStyle.Left;
            this.BTxt1Prev.Enabled = false;
            this.BTxt1Prev.ForeColor = System.Drawing.Color.Black;
            this.BTxt1Prev.Location = new System.Drawing.Point(0, 0);
            this.BTxt1Prev.Name = "BTxt1Prev";
            this.BTxt1Prev.Size = new System.Drawing.Size(295, 450);
            this.BTxt1Prev.TabIndex = 0;
            this.BTxt1Prev.Text = "";
            this.BTxt1Prev.TextChanged += new System.EventHandler(this.BTxt1Prev_TextChanged);
            // 
            // BTxt2Next
            // 
            this.BTxt2Next.BackColor = System.Drawing.Color.LightGray;
            this.BTxt2Next.Dock = System.Windows.Forms.DockStyle.Right;
            this.BTxt2Next.Enabled = false;
            this.BTxt2Next.ForeColor = System.Drawing.Color.Black;
            this.BTxt2Next.Location = new System.Drawing.Point(483, 0);
            this.BTxt2Next.Name = "BTxt2Next";
            this.BTxt2Next.Size = new System.Drawing.Size(317, 450);
            this.BTxt2Next.TabIndex = 1;
            this.BTxt2Next.Text = "";
            // 
            // panelButtom
            // 
            this.panelButtom.BackColor = System.Drawing.Color.Transparent;
            this.panelButtom.Controls.Add(this.symbol);
            this.panelButtom.Controls.Add(this.Next);
            this.panelButtom.Controls.Add(this.Exit);
            this.panelButtom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtom.Location = new System.Drawing.Point(295, 0);
            this.panelButtom.Name = "panelButtom";
            this.panelButtom.Size = new System.Drawing.Size(188, 450);
            this.panelButtom.TabIndex = 2;
            this.panelButtom.Paint += new System.Windows.Forms.PaintEventHandler(this.panelButtom_Paint);
            // 
            // symbol
            // 
            this.symbol.AutoSize = true;
            this.symbol.Font = new System.Drawing.Font("Arial", 40.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.symbol.ForeColor = System.Drawing.Color.White;
            this.symbol.Location = new System.Drawing.Point(22, 180);
            this.symbol.Name = "symbol";
            this.symbol.Size = new System.Drawing.Size(160, 79);
            this.symbol.TabIndex = 10;
            this.symbol.Text = "<-->";
            // 
            // Next
            // 
            this.Next.BackColor = System.Drawing.Color.Transparent;
            this.Next.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Next.BackgroundImage")));
            this.Next.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Next.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Next.Location = new System.Drawing.Point(6, 3);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(176, 88);
            this.Next.TabIndex = 8;
            this.Next.UseVisualStyleBackColor = false;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // Exit
            // 
            this.Exit.AutoSize = true;
            this.Exit.BackColor = System.Drawing.Color.Transparent;
            this.Exit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Exit.BackgroundImage")));
            this.Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exit.Location = new System.Drawing.Point(6, 356);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(176, 82);
            this.Exit.TabIndex = 7;
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Desarrollo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelButtom);
            this.Controls.Add(this.BTxt2Next);
            this.Controls.Add(this.BTxt1Prev);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Desarrollo";
            this.Text = "Desarrollo";
            this.Load += new System.EventHandler(this.Desarrollo_Load);
            this.panelButtom.ResumeLayout(false);
            this.panelButtom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox BTxt1Prev;
        private System.Windows.Forms.RichTextBox BTxt2Next;
        private System.Windows.Forms.Panel panelButtom;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Label symbol;
        private System.Windows.Forms.Button Next;
    }
}