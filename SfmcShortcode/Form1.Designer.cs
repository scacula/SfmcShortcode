namespace SfmcShortcode
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lstShortcodes = new ListBox();
            label1 = new Label();
            btnLoadShortcodes = new Button();
            chkActive = new CheckBox();
            label3 = new Label();
            txtShortcode = new TextBox();
            lblTotal = new Label();
            lstChange = new ListBox();
            btnChangeShortcode = new Button();
            txtNewShortcode = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label2 = new Label();
            txtMid = new TextBox();
            panel1 = new Panel();
            label7 = new Label();
            label6 = new Label();
            txtClientSecret = new TextBox();
            txtClientId = new TextBox();
            btnDisableDk = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lstShortcodes
            // 
            lstShortcodes.FormattingEnabled = true;
            lstShortcodes.ItemHeight = 20;
            lstShortcodes.Location = new Point(12, 194);
            lstShortcodes.Name = "lstShortcodes";
            lstShortcodes.Size = new Size(440, 204);
            lstShortcodes.TabIndex = 0;
            lstShortcodes.SelectedIndexChanged += lstShortcodes_SelectedIndexChanged;
            lstShortcodes.DoubleClick += lstShortcodes_DoubleClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 171);
            label1.Name = "label1";
            label1.Size = new Size(191, 20);
            label1.TabIndex = 1;
            label1.Text = "Definition Key && Shortcode";
            label1.Click += label1_Click;
            // 
            // btnLoadShortcodes
            // 
            btnLoadShortcodes.Location = new Point(12, 415);
            btnLoadShortcodes.Name = "btnLoadShortcodes";
            btnLoadShortcodes.Size = new Size(440, 29);
            btnLoadShortcodes.TabIndex = 4;
            btnLoadShortcodes.Text = "Carregar Shortcodes";
            btnLoadShortcodes.UseVisualStyleBackColor = true;
            btnLoadShortcodes.Click += btnLoadShortcodes_Click;
            // 
            // chkActive
            // 
            chkActive.AutoSize = true;
            chkActive.Checked = true;
            chkActive.CheckState = CheckState.Checked;
            chkActive.Location = new Point(93, 128);
            chkActive.Name = "chkActive";
            chkActive.Size = new Size(72, 24);
            chkActive.TabIndex = 5;
            chkActive.Text = "Ativos";
            chkActive.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 102);
            label3.Name = "label3";
            label3.Size = new Size(77, 20);
            label3.TabIndex = 2;
            label3.Text = "Shortcode";
            // 
            // txtShortcode
            // 
            txtShortcode.Location = new Point(11, 125);
            txtShortcode.Name = "txtShortcode";
            txtShortcode.Size = new Size(76, 27);
            txtShortcode.TabIndex = 3;
            txtShortcode.Text = "28458";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(12, 457);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(57, 20);
            lblTotal.TabIndex = 6;
            lblTotal.Text = "Total: 0";
            // 
            // lstChange
            // 
            lstChange.FormattingEnabled = true;
            lstChange.ItemHeight = 20;
            lstChange.Location = new Point(489, 194);
            lstChange.Name = "lstChange";
            lstChange.Size = new Size(440, 204);
            lstChange.TabIndex = 0;
            lstChange.SelectedIndexChanged += lstChange_SelectedIndexChanged;
            lstChange.DoubleClick += lstChange_DoubleClick;
            // 
            // btnChangeShortcode
            // 
            btnChangeShortcode.Location = new Point(489, 415);
            btnChangeShortcode.Name = "btnChangeShortcode";
            btnChangeShortcode.Size = new Size(440, 29);
            btnChangeShortcode.TabIndex = 4;
            btnChangeShortcode.Text = "Trocar Shortcode";
            btnChangeShortcode.UseVisualStyleBackColor = true;
            btnChangeShortcode.Click += btnChangeShortcode_Click;
            // 
            // txtNewShortcode
            // 
            txtNewShortcode.Location = new Point(489, 125);
            txtNewShortcode.Name = "txtNewShortcode";
            txtNewShortcode.Size = new Size(76, 27);
            txtNewShortcode.TabIndex = 8;
            txtNewShortcode.Text = "28458";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(489, 102);
            label4.Name = "label4";
            label4.Size = new Size(77, 20);
            label4.TabIndex = 7;
            label4.Text = "Shortcode";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(489, 171);
            label5.Name = "label5";
            label5.Size = new Size(122, 20);
            label5.TabIndex = 9;
            label5.Text = "Trocar Shortcode";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 9);
            label2.Name = "label2";
            label2.Size = new Size(98, 20);
            label2.TabIndex = 2;
            label2.Text = "Business Unit:";
            // 
            // txtMid
            // 
            txtMid.Location = new Point(17, 32);
            txtMid.Name = "txtMid";
            txtMid.Size = new Size(109, 27);
            txtMid.TabIndex = 3;
            txtMid.Text = "514015477";
            // 
            // panel1
            // 
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(txtClientSecret);
            panel1.Controls.Add(txtClientId);
            panel1.Controls.Add(txtMid);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(917, 71);
            panel1.TabIndex = 10;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(520, 9);
            label7.Name = "label7";
            label7.Size = new Size(95, 20);
            label7.TabIndex = 6;
            label7.Text = "Client Secret:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(179, 9);
            label6.Name = "label6";
            label6.Size = new Size(67, 20);
            label6.TabIndex = 6;
            label6.Text = "Client Id:";
            // 
            // txtClientSecret
            // 
            txtClientSecret.Location = new Point(520, 32);
            txtClientSecret.Name = "txtClientSecret";
            txtClientSecret.Size = new Size(315, 27);
            txtClientSecret.TabIndex = 5;
            // 
            // txtClientId
            // 
            txtClientId.Location = new Point(179, 32);
            txtClientId.Name = "txtClientId";
            txtClientId.Size = new Size(315, 27);
            txtClientId.TabIndex = 4;
            // 
            // btnDisableDk
            // 
            btnDisableDk.Location = new Point(489, 453);
            btnDisableDk.Name = "btnDisableDk";
            btnDisableDk.Size = new Size(440, 29);
            btnDisableDk.TabIndex = 11;
            btnDisableDk.Text = "Desabilitar DefinitionKey";
            btnDisableDk.UseVisualStyleBackColor = true;
            btnDisableDk.Click += btnDisableDk_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(944, 486);
            Controls.Add(btnDisableDk);
            Controls.Add(panel1);
            Controls.Add(label5);
            Controls.Add(txtNewShortcode);
            Controls.Add(label4);
            Controls.Add(lblTotal);
            Controls.Add(chkActive);
            Controls.Add(btnChangeShortcode);
            Controls.Add(btnLoadShortcodes);
            Controls.Add(txtShortcode);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(lstChange);
            Controls.Add(lstShortcodes);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Marketing Cloud Shortcodes";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstShortcodes;
        private Label label1;
        private Button btnLoadShortcodes;
        private CheckBox chkActive;
        private Label label3;
        private TextBox txtShortcode;
        private Label lblTotal;
        private ListBox lstChange;
        private Button btnChangeShortcode;
        private TextBox txtNewShortcode;
        private Label label4;
        private Label label5;
        private Label label2;
        private TextBox txtMid;
        private Panel panel1;
        private Label label7;
        private Label label6;
        private TextBox txtClientSecret;
        private TextBox txtClientId;
        private Button btnDisableDk;
    }
}