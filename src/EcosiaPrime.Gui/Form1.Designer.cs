namespace EcosiaPrime.Gui
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.idTextfield = new System.Windows.Forms.TextBox();
            this.firstNameTextfield = new System.Windows.Forms.TextBox();
            this.lastNameTextfield = new System.Windows.Forms.TextBox();
            this.emailTextfield = new System.Windows.Forms.TextBox();
            this.passwordTextfield = new System.Windows.Forms.TextBox();
            this.countryTextfield = new System.Windows.Forms.TextBox();
            this.stateTextfield = new System.Windows.Forms.TextBox();
            this.postcodeTextfield = new System.Windows.Forms.TextBox();
            this.cityTextfield = new System.Windows.Forms.TextBox();
            this.streetNameTextfield = new System.Windows.Forms.TextBox();
            this.streetNumberTextfield = new System.Windows.Forms.TextBox();
            this.startDateTextfield = new System.Windows.Forms.TextBox();
            this.endDateTextfield = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.paymentMethodPanel = new System.Windows.Forms.Label();
            this.dropdownMenuPayment = new System.Windows.Forms.ComboBox();
            this.dropdownMenuSubscription = new System.Windows.Forms.ComboBox();
            this.Enter = new System.Windows.Forms.Button();
            this.optionComboBox = new System.Windows.Forms.ComboBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnID = new System.Windows.Forms.ColumnHeader();
            this.columnFirstName = new System.Windows.Forms.ColumnHeader();
            this.columnLastName = new System.Windows.Forms.ColumnHeader();
            this.columnEmail = new System.Windows.Forms.ColumnHeader();
            this.columnPassword = new System.Windows.Forms.ColumnHeader();
            this.columnCountry = new System.Windows.Forms.ColumnHeader();
            this.columnState = new System.Windows.Forms.ColumnHeader();
            this.columnPostcode = new System.Windows.Forms.ColumnHeader();
            this.columnCity = new System.Windows.Forms.ColumnHeader();
            this.columnStreetName = new System.Windows.Forms.ColumnHeader();
            this.columnStreetNumber = new System.Windows.Forms.ColumnHeader();
            this.columnStartDate = new System.Windows.Forms.ColumnHeader();
            this.columnEndDate = new System.Windows.Forms.ColumnHeader();
            this.columnPayment = new System.Windows.Forms.ColumnHeader();
            this.columnSubscription = new System.Windows.Forms.ColumnHeader();
            this.filterComboBox = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(658, -52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(1436, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(698, 159);
            this.label3.TabIndex = 2;
            this.label3.Text = "EcosiaPrime";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // idTextfield
            // 
            this.idTextfield.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.idTextfield.Location = new System.Drawing.Point(77, 316);
            this.idTextfield.Name = "idTextfield";
            this.idTextfield.PlaceholderText = "ID";
            this.idTextfield.Size = new System.Drawing.Size(650, 114);
            this.idTextfield.TabIndex = 3;
            // 
            // firstNameTextfield
            // 
            this.firstNameTextfield.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.firstNameTextfield.Location = new System.Drawing.Point(77, 436);
            this.firstNameTextfield.Name = "firstNameTextfield";
            this.firstNameTextfield.PlaceholderText = "Vorname";
            this.firstNameTextfield.Size = new System.Drawing.Size(650, 114);
            this.firstNameTextfield.TabIndex = 4;
            this.firstNameTextfield.TextChanged += new System.EventHandler(this.firstNameTextfield_TextChanged);
            // 
            // lastNameTextfield
            // 
            this.lastNameTextfield.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lastNameTextfield.Location = new System.Drawing.Point(77, 556);
            this.lastNameTextfield.Name = "lastNameTextfield";
            this.lastNameTextfield.PlaceholderText = "Nachname";
            this.lastNameTextfield.Size = new System.Drawing.Size(650, 114);
            this.lastNameTextfield.TabIndex = 5;
            // 
            // emailTextfield
            // 
            this.emailTextfield.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.emailTextfield.Location = new System.Drawing.Point(77, 676);
            this.emailTextfield.Name = "emailTextfield";
            this.emailTextfield.PlaceholderText = "Email";
            this.emailTextfield.Size = new System.Drawing.Size(650, 114);
            this.emailTextfield.TabIndex = 6;
            // 
            // passwordTextfield
            // 
            this.passwordTextfield.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.passwordTextfield.Location = new System.Drawing.Point(77, 796);
            this.passwordTextfield.Name = "passwordTextfield";
            this.passwordTextfield.PlaceholderText = "Passwort";
            this.passwordTextfield.Size = new System.Drawing.Size(650, 114);
            this.passwordTextfield.TabIndex = 7;
            // 
            // countryTextfield
            // 
            this.countryTextfield.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.countryTextfield.Location = new System.Drawing.Point(1463, 316);
            this.countryTextfield.Name = "countryTextfield";
            this.countryTextfield.PlaceholderText = "Staat";
            this.countryTextfield.Size = new System.Drawing.Size(650, 114);
            this.countryTextfield.TabIndex = 8;
            // 
            // stateTextfield
            // 
            this.stateTextfield.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.stateTextfield.Location = new System.Drawing.Point(1463, 436);
            this.stateTextfield.Name = "stateTextfield";
            this.stateTextfield.PlaceholderText = "Bundesland";
            this.stateTextfield.Size = new System.Drawing.Size(650, 114);
            this.stateTextfield.TabIndex = 9;
            // 
            // postcodeTextfield
            // 
            this.postcodeTextfield.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.postcodeTextfield.Location = new System.Drawing.Point(1463, 556);
            this.postcodeTextfield.Name = "postcodeTextfield";
            this.postcodeTextfield.PlaceholderText = "Postleitzahl";
            this.postcodeTextfield.Size = new System.Drawing.Size(650, 114);
            this.postcodeTextfield.TabIndex = 10;
            // 
            // cityTextfield
            // 
            this.cityTextfield.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cityTextfield.Location = new System.Drawing.Point(1463, 676);
            this.cityTextfield.Name = "cityTextfield";
            this.cityTextfield.PlaceholderText = "Stadt";
            this.cityTextfield.Size = new System.Drawing.Size(650, 114);
            this.cityTextfield.TabIndex = 11;
            // 
            // streetNameTextfield
            // 
            this.streetNameTextfield.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.streetNameTextfield.Location = new System.Drawing.Point(1463, 796);
            this.streetNameTextfield.Name = "streetNameTextfield";
            this.streetNameTextfield.PlaceholderText = "Straße";
            this.streetNameTextfield.Size = new System.Drawing.Size(650, 114);
            this.streetNameTextfield.TabIndex = 12;
            // 
            // streetNumberTextfield
            // 
            this.streetNumberTextfield.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.streetNumberTextfield.Location = new System.Drawing.Point(1463, 916);
            this.streetNumberTextfield.Name = "streetNumberTextfield";
            this.streetNumberTextfield.PlaceholderText = "Straßennummer";
            this.streetNumberTextfield.Size = new System.Drawing.Size(650, 114);
            this.streetNumberTextfield.TabIndex = 13;
            // 
            // startDateTextfield
            // 
            this.startDateTextfield.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.startDateTextfield.Location = new System.Drawing.Point(2909, 316);
            this.startDateTextfield.Name = "startDateTextfield";
            this.startDateTextfield.PlaceholderText = "Anfangsdatum";
            this.startDateTextfield.Size = new System.Drawing.Size(650, 114);
            this.startDateTextfield.TabIndex = 14;
            // 
            // endDateTextfield
            // 
            this.endDateTextfield.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.endDateTextfield.Location = new System.Drawing.Point(2909, 436);
            this.endDateTextfield.Name = "endDateTextfield";
            this.endDateTextfield.PlaceholderText = "Enddatum";
            this.endDateTextfield.Size = new System.Drawing.Size(650, 114);
            this.endDateTextfield.TabIndex = 15;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.paymentMethodPanel);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(2909, 556);
            this.flowLayoutPanel1.MaximumSize = new System.Drawing.Size(593, 106);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(593, 0);
            this.flowLayoutPanel1.TabIndex = 16;
            // 
            // paymentMethodPanel
            // 
            this.paymentMethodPanel.AutoSize = true;
            this.paymentMethodPanel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.paymentMethodPanel.Location = new System.Drawing.Point(3, 0);
            this.paymentMethodPanel.Name = "paymentMethodPanel";
            this.paymentMethodPanel.Size = new System.Drawing.Size(551, 212);
            this.paymentMethodPanel.TabIndex = 17;
            this.paymentMethodPanel.Text = "Bezahlmethode";
            this.paymentMethodPanel.Click += new System.EventHandler(this.label2_Click);
            // 
            // dropdownMenuPayment
            // 
            this.dropdownMenuPayment.DisplayMember = "PayPal";
            this.dropdownMenuPayment.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dropdownMenuPayment.FormattingEnabled = true;
            this.dropdownMenuPayment.Items.AddRange(new object[] {
            "PayPal",
            "Creditcard",
            "EC",
            "Giftcode",
            "Directdebit"});
            this.dropdownMenuPayment.Location = new System.Drawing.Point(2909, 553);
            this.dropdownMenuPayment.Name = "dropdownMenuPayment";
            this.dropdownMenuPayment.Size = new System.Drawing.Size(650, 114);
            this.dropdownMenuPayment.TabIndex = 17;
            this.dropdownMenuPayment.SelectedIndexChanged += new System.EventHandler(this.dropdownMenuPayment_SelectedIndexChanged);
            // 
            // dropdownMenuSubscription
            // 
            this.dropdownMenuSubscription.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dropdownMenuSubscription.FormattingEnabled = true;
            this.dropdownMenuSubscription.Items.AddRange(new object[] {
            "Basic",
            "Standard",
            "Premium"});
            this.dropdownMenuSubscription.Location = new System.Drawing.Point(2909, 673);
            this.dropdownMenuSubscription.Name = "dropdownMenuSubscription";
            this.dropdownMenuSubscription.Size = new System.Drawing.Size(650, 114);
            this.dropdownMenuSubscription.TabIndex = 18;
            // 
            // Enter
            // 
            this.Enter.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Enter.Location = new System.Drawing.Point(3115, 1118);
            this.Enter.Name = "Enter";
            this.Enter.Size = new System.Drawing.Size(360, 127);
            this.Enter.TabIndex = 19;
            this.Enter.Text = "Enter";
            this.Enter.UseVisualStyleBackColor = true;
            this.Enter.Click += new System.EventHandler(this.Enter_Click);
            // 
            // optionComboBox
            // 
            this.optionComboBox.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.optionComboBox.FormattingEnabled = true;
            this.optionComboBox.Items.AddRange(new object[] {
            "Erstellen",
            "Löschen",
            "Bearbeiten",
            "Anzeigen"});
            this.optionComboBox.Location = new System.Drawing.Point(77, 1118);
            this.optionComboBox.Name = "optionComboBox";
            this.optionComboBox.Size = new System.Drawing.Size(650, 114);
            this.optionComboBox.TabIndex = 20;
            this.optionComboBox.SelectedIndexChanged += new System.EventHandler(this.optionComboBox_SelectedIndexChanged);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnID,
            this.columnFirstName,
            this.columnLastName,
            this.columnEmail,
            this.columnPassword,
            this.columnCountry,
            this.columnState,
            this.columnPostcode,
            this.columnCity,
            this.columnStreetName,
            this.columnStreetNumber,
            this.columnStartDate,
            this.columnEndDate,
            this.columnPayment,
            this.columnSubscription});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(77, 1316);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(3482, 323);
            this.listView1.TabIndex = 21;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnID
            // 
            this.columnID.Tag = "1";
            this.columnID.Text = "ID";
            this.columnID.Width = 200;
            // 
            // columnFirstName
            // 
            this.columnFirstName.Text = "Vorname";
            this.columnFirstName.Width = 150;
            // 
            // columnLastName
            // 
            this.columnLastName.Text = "Nachname";
            this.columnLastName.Width = 150;
            // 
            // columnEmail
            // 
            this.columnEmail.Text = "Email";
            this.columnEmail.Width = 150;
            // 
            // columnPassword
            // 
            this.columnPassword.Text = "Passwort";
            this.columnPassword.Width = 150;
            // 
            // columnCountry
            // 
            this.columnCountry.Text = "Land";
            this.columnCountry.Width = 150;
            // 
            // columnState
            // 
            this.columnState.Text = "Bundesland";
            this.columnState.Width = 150;
            // 
            // columnPostcode
            // 
            this.columnPostcode.Text = "PLZ";
            this.columnPostcode.Width = 150;
            // 
            // columnCity
            // 
            this.columnCity.Text = "Stadt";
            this.columnCity.Width = 150;
            // 
            // columnStreetName
            // 
            this.columnStreetName.Text = "Straße";
            this.columnStreetName.Width = 150;
            // 
            // columnStreetNumber
            // 
            this.columnStreetNumber.Text = "Straßennummer";
            this.columnStreetNumber.Width = 150;
            // 
            // columnStartDate
            // 
            this.columnStartDate.Text = "Anfangsdatum";
            this.columnStartDate.Width = 150;
            // 
            // columnEndDate
            // 
            this.columnEndDate.Text = "Enddatum";
            this.columnEndDate.Width = 150;
            // 
            // columnPayment
            // 
            this.columnPayment.Text = "Bezahlmethode";
            this.columnPayment.Width = 150;
            // 
            // columnSubscription
            // 
            this.columnSubscription.Text = "Abonnement";
            this.columnSubscription.Width = 150;
            // 
            // filterComboBox
            // 
            this.filterComboBox.AutoCompleteCustomSource.AddRange(new string[] {
            "Alle",
            "Eine Person"});
            this.filterComboBox.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.filterComboBox.FormattingEnabled = true;
            this.filterComboBox.Items.AddRange(new object[] {
            "Alle",
            "Eine Person"});
            this.filterComboBox.Location = new System.Drawing.Point(1463, 1118);
            this.filterComboBox.Name = "filterComboBox";
            this.filterComboBox.Size = new System.Drawing.Size(650, 114);
            this.filterComboBox.TabIndex = 22;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(3642, 1671);
            this.Controls.Add(this.filterComboBox);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.optionComboBox);
            this.Controls.Add(this.Enter);
            this.Controls.Add(this.dropdownMenuSubscription);
            this.Controls.Add(this.dropdownMenuPayment);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.endDateTextfield);
            this.Controls.Add(this.startDateTextfield);
            this.Controls.Add(this.streetNumberTextfield);
            this.Controls.Add(this.streetNameTextfield);
            this.Controls.Add(this.cityTextfield);
            this.Controls.Add(this.postcodeTextfield);
            this.Controls.Add(this.stateTextfield);
            this.Controls.Add(this.countryTextfield);
            this.Controls.Add(this.passwordTextfield);
            this.Controls.Add(this.emailTextfield);
            this.Controls.Add(this.lastNameTextfield);
            this.Controls.Add(this.firstNameTextfield);
            this.Controls.Add(this.idTextfield);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label3;
        private TextBox idTextfield;
        private TextBox firstNameTextfield;
        private TextBox lastNameTextfield;
        private TextBox emailTextfield;
        private TextBox passwordTextfield;
        private TextBox countryTextfield;
        private TextBox stateTextfield;
        private TextBox postcodeTextfield;
        private TextBox cityTextfield;
        private TextBox streetNameTextfield;
        private TextBox streetNumberTextfield;
        private TextBox startDateTextfield;
        private TextBox endDateTextfield;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label paymentMethodPanel;
        private ComboBox dropdownMenuPayment;
        private ComboBox dropdownMenuSubscription;
        private Button Enter;
        private ComboBox optionComboBox;
        private ListView listView1;
        private ColumnHeader columnID;
        private ColumnHeader columnFirstName;
        private ColumnHeader columnLastName;
        private ColumnHeader columnEmail;
        private ColumnHeader columnPassword;
        private ColumnHeader columnCountry;
        private ColumnHeader columnState;
        private ColumnHeader columnPostcode;
        private ColumnHeader columnCity;
        private ColumnHeader columnStreetName;
        private ColumnHeader columnStreetNumber;
        private ColumnHeader columnStartDate;
        private ColumnHeader columnEndDate;
        private ColumnHeader columnPayment;
        private ColumnHeader columnSubscription;
        private ComboBox filterComboBox;
    }
}