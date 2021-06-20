
namespace GestionTâche
{
    partial class StatistiqueControl
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
            this.tauxTache = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // tauxTache
            // 
            this.tauxTache.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(196)))), ((int)(((byte)(211)))));
            this.tauxTache.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tauxTache.Cursor = System.Windows.Forms.Cursors.Default;
            this.tauxTache.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tauxTache.ForeColor = System.Drawing.Color.White;
            this.tauxTache.Location = new System.Drawing.Point(28, 13);
            this.tauxTache.Name = "tauxTache";
            this.tauxTache.ReadOnly = true;
            this.tauxTache.Size = new System.Drawing.Size(100, 36);
            this.tauxTache.TabIndex = 1;
            this.tauxTache.Text = "Nb tache";
            // 
            // StatistiqueControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(196)))), ((int)(((byte)(211)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tauxTache);
            this.Name = "StatistiqueControl";
            this.Size = new System.Drawing.Size(160, 65);
            this.Load += new System.EventHandler(this.StatistiqueControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox tauxTache;
    }
}
