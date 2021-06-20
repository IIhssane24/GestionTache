
namespace GestionTâche
{
    partial class TacheContrôleTerminer
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtId = new System.Windows.Forms.Label();
            this.btnNonTer = new System.Windows.Forms.Button();
            this.txtTitre = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // txtId
            // 
            this.txtId.AutoSize = true;
            this.txtId.Location = new System.Drawing.Point(17, 75);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(48, 13);
            this.txtId.TabIndex = 0;
            this.txtId.Text = "id_tâche";
            // 
            // btnNonTer
            // 
            this.btnNonTer.BackColor = System.Drawing.Color.Black;
            this.btnNonTer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNonTer.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNonTer.ForeColor = System.Drawing.Color.White;
            this.btnNonTer.Location = new System.Drawing.Point(100, 115);
            this.btnNonTer.Name = "btnNonTer";
            this.btnNonTer.Size = new System.Drawing.Size(121, 35);
            this.btnNonTer.TabIndex = 1;
            this.btnNonTer.Text = "Non Terminer";
            this.btnNonTer.UseVisualStyleBackColor = false;
            this.btnNonTer.Click += new System.EventHandler(this.btnNonTer_Click);
            // 
            // txtTitre
            // 
            this.txtTitre.AutoSize = true;
            this.txtTitre.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitre.ForeColor = System.Drawing.Color.Black;
            this.txtTitre.Location = new System.Drawing.Point(3, 30);
            this.txtTitre.Name = "txtTitre";
            this.txtTitre.Size = new System.Drawing.Size(124, 28);
            this.txtTitre.TabIndex = 2;
            this.txtTitre.Text = "Titre Tâche";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(118, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(80, 11);
            this.panel1.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(-1, 143);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(13, 12);
            this.panel2.TabIndex = 12;
            // 
            // TacheContrôleTerminer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(227)))), ((int)(((byte)(231)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtTitre);
            this.Controls.Add(this.btnNonTer);
            this.Controls.Add(this.txtId);
            this.Name = "TacheContrôleTerminer";
            this.Size = new System.Drawing.Size(224, 153);
            this.Load += new System.EventHandler(this.TacheContrôleTerminer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtId;
        private System.Windows.Forms.Button btnNonTer;
        private System.Windows.Forms.Label txtTitre;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}
