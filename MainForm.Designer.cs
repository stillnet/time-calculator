namespace TimeCalculator;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.historyTextBox = new TextBox();
        this.totalLabel = new Label();
        this.inputTextBox = new TextBox();
        this.statusLabel = new Label();
        this.historyLabel = new Label();
        this.SuspendLayout();

        // historyLabel
        this.historyLabel.AutoSize = true;
        this.historyLabel.Location = new Point(12, 9);
        this.historyLabel.Name = "historyLabel";
        this.historyLabel.Size = new Size(48, 15);
        this.historyLabel.Text = "History:";

        // historyTextBox
        this.historyTextBox.Location = new Point(12, 27);
        this.historyTextBox.Multiline = true;
        this.historyTextBox.Name = "historyTextBox";
        this.historyTextBox.ReadOnly = true;
        this.historyTextBox.ScrollBars = ScrollBars.Vertical;
        this.historyTextBox.Size = new Size(260, 150);
        this.historyTextBox.TabStop = false;
        this.historyTextBox.Font = new Font("Consolas", 11F);

        // totalLabel
        this.totalLabel.AutoSize = true;
        this.totalLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        this.totalLabel.Location = new Point(12, 190);
        this.totalLabel.Name = "totalLabel";
        this.totalLabel.Size = new Size(100, 32);
        this.totalLabel.Text = "Total: 0:00";

        // inputTextBox
        this.inputTextBox.Font = new Font("Consolas", 14F);
        this.inputTextBox.Location = new Point(12, 235);
        this.inputTextBox.Name = "inputTextBox";
        this.inputTextBox.Size = new Size(260, 29);
        this.inputTextBox.TabIndex = 0;

        // statusLabel
        this.statusLabel.AutoSize = true;
        this.statusLabel.ForeColor = SystemColors.GrayText;
        this.statusLabel.Location = new Point(12, 275);
        this.statusLabel.Name = "statusLabel";
        this.statusLabel.Size = new Size(200, 15);
        this.statusLabel.Text = "[Enter] to add  |  [C] to clear";

        // MainForm
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(284, 301);
        this.Controls.Add(this.historyLabel);
        this.Controls.Add(this.historyTextBox);
        this.Controls.Add(this.totalLabel);
        this.Controls.Add(this.inputTextBox);
        this.Controls.Add(this.statusLabel);
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.Name = "MainForm";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "Time Calculator";
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private TextBox historyTextBox;
    private Label totalLabel;
    private TextBox inputTextBox;
    private Label statusLabel;
    private Label historyLabel;
}
