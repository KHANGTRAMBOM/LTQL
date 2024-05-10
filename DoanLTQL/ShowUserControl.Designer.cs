namespace GUI
{
    partial class ShowUserControl
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
        /// the contents of this method with the code editor.public
        /// </summary>
        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // ShowUserControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ShowUserControl";
            Text = "ShowUserControl";
            MouseDown += MouseDownn;
            MouseMove += MouseMovee;
            MouseUp += MouseUpp;
            ResumeLayout(false);
        }

        #endregion
    }
}