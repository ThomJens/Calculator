namespace calculator
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private int buttonWidth = 90;
        private int buttonHeight = 60;
        private int x = 75;
        private int y = 90;

        private string[] labels = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", ".", "+", "-", "*", "/", "^", "r", "=", "C", "del" };
        private string[] names = { "number1", "number2", "number3", "number4", "number5", "number6", "number7", "number8", "number9", "number0", "comma", "add", "sub", "mult", "div", "pow", "root", "equal", "clear", "erase" };
        
        private int buttonNumber = 20;
        private Button[] buttons = new Button[20];
        private TextBox textbox;

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
            SuspendLayout();
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyPressed);
            for (int button = 0; button < buttonNumber; button++) {
                buttons[button] = new Button();
                buttons[button].Name = this.names[button];
                buttons[button].Size = new Size(buttonWidth, buttonHeight);
                buttons[button].Font = new Font("Arial", 18);
                buttons[button].TabIndex = 0;
                buttons[button].Text = this.labels[button];
                buttons[button].UseVisualStyleBackColor = true;
                buttons[button].Click += Button_Click;
                buttons[button].TabStop = false;
                Controls.Add(buttons[button]);
                
                if (button < 11)
                {
                    buttons[button].Location = new Point(this.x + this.buttonWidth * (button % 3), this.y + this.buttonHeight * Convert.ToInt32(Math.Floor(Convert.ToDouble(button) / 3)));

                }
                else if (button < buttonNumber - 2)
                {
                    buttons[button].Location = new Point(20 + 4 * this.buttonWidth + this.buttonWidth * ((button - 1) % 2), -5 * this.buttonHeight + this.y + this.buttonHeight * Convert.ToInt32(Math.Floor(Convert.ToDouble(button - 1) / 2)));
                }
                else
                {
                    buttons[button].Location = new Point(this.x + this.buttonWidth * (button % 3), -2 * this.buttonHeight + 20 + this.y + this.buttonHeight * Convert.ToInt32(Math.Floor(Convert.ToDouble(button) / 3)));
                }
            }

            //
            // textbox
            //
            textbox = new TextBox();
            int textboxWidth = 5 * buttonWidth + 34;
            int textboxHeigth = 60;
            textbox.Location = new Point(x, y - textboxHeigth);
            textbox.Size = new Size(textboxWidth, textboxHeigth);
            textbox.TextChanged += new EventHandler(Textbox_Changed);
            textbox.Font = new Font("Arial", 18);
            textbox.ReadOnly = true;

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 420);
            Controls.Add(textbox);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion
    }
}