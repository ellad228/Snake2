namespace Snake2
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
            components = new System.ComponentModel.Container();
            startButton = new Button();
            scoreLabel = new Label();
            highScoreLabel = new Label();
            picCanvas = new PictureBox();
            GameTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)picCanvas).BeginInit();
            SuspendLayout();
            // 
            // startButton
            // 
            startButton.Font = new Font("Unispace", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            startButton.Location = new Point(537, 12);
            startButton.Name = "startButton";
            startButton.Size = new Size(89, 39);
            startButton.TabIndex = 0;
            startButton.Text = "Start";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += StartButtonClick;
            // 
            // scoreLabel
            // 
            scoreLabel.AutoSize = true;
            scoreLabel.Font = new Font("Unispace", 9.749999F, FontStyle.Bold, GraphicsUnit.Point);
            scoreLabel.Location = new Point(537, 86);
            scoreLabel.Name = "scoreLabel";
            scoreLabel.Size = new Size(71, 15);
            scoreLabel.TabIndex = 1;
            scoreLabel.Text = "Score: 0";
            // 
            // highScoreLabel
            // 
            highScoreLabel.AutoSize = true;
            highScoreLabel.Font = new Font("Unispace", 9.749999F, FontStyle.Bold, GraphicsUnit.Point);
            highScoreLabel.Location = new Point(537, 122);
            highScoreLabel.Name = "highScoreLabel";
            highScoreLabel.Size = new Size(111, 15);
            highScoreLabel.TabIndex = 2;
            highScoreLabel.Text = "High Score: 0";
            // 
            // picCanvas
            // 
            picCanvas.BackColor = SystemColors.ControlDark;
            picCanvas.BorderStyle = BorderStyle.FixedSingle;
            picCanvas.Location = new Point(12, 12);
            picCanvas.Name = "picCanvas";
            picCanvas.Size = new Size(500, 500);
            picCanvas.TabIndex = 3;
            picCanvas.TabStop = false;
            picCanvas.Paint += UpdatePictureBoxGraphics;
            // 
            // GameTimer
            // 
            GameTimer.Interval = 50;
            GameTimer.Tick += GameTimerEvent;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 526);
            Controls.Add(picCanvas);
            Controls.Add(highScoreLabel);
            Controls.Add(scoreLabel);
            Controls.Add(startButton);
            Name = "Form1";
            Text = "Snake game";
            Load += Form1_Load;
            KeyDown += OnKeyDown;
            KeyUp += OnKeyUp;
            ((System.ComponentModel.ISupportInitialize)picCanvas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button startButton;
        private Label scoreLabel;
        private Label highScoreLabel;
        private PictureBox picCanvas;
        private System.Windows.Forms.Timer GameTimer;
    }
}