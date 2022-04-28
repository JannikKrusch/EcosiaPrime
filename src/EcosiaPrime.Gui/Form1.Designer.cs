using EcosiaPrime.Contracts.Constants;
using System;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.houseNumberTextfield = new System.Windows.Forms.TextBox();
            this.paymentMethodPanel = new System.Windows.Forms.Label();
            this.dropdownMenuPayment = new System.Windows.Forms.ComboBox();
            this.dropdownMenuSubscription = new System.Windows.Forms.ComboBox();
            this.Enter = new System.Windows.Forms.Button();
            this.dropdownMenuOption = new System.Windows.Forms.ComboBox();
            this.dataGrid = new System.Windows.Forms.ListView();
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
            this.columnHouseNumber = new System.Windows.Forms.ColumnHeader();
            this.columnStartDate = new System.Windows.Forms.ColumnHeader();
            this.columnEndDate = new System.Windows.Forms.ColumnHeader();
            this.columnPayment = new System.Windows.Forms.ColumnHeader();
            this.columnSubscription = new System.Windows.Forms.ColumnHeader();
            this.dropdownMenuFilter = new System.Windows.Forms.ComboBox();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.responseTextField = new System.Windows.Forms.TextBox();
            this.logo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.SuspendLayout();
            // 
            // idTextfield
            // 
            this.idTextfield.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.idTextfield.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.idTextfield.Location = new System.Drawing.Point(85, 167);
            this.idTextfield.Margin = new System.Windows.Forms.Padding(1);
            this.idTextfield.Name = "idTextfield";
            this.idTextfield.PlaceholderText = "ID";
            this.idTextfield.Size = new System.Drawing.Size(308, 61);
            this.idTextfield.TabIndex = 3;
            // 
            // firstNameTextfield
            // 
            this.firstNameTextfield.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.firstNameTextfield.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.firstNameTextfield.Location = new System.Drawing.Point(85, 230);
            this.firstNameTextfield.Margin = new System.Windows.Forms.Padding(1);
            this.firstNameTextfield.Name = "firstNameTextfield";
            this.firstNameTextfield.PlaceholderText = "Vorname";
            this.firstNameTextfield.Size = new System.Drawing.Size(308, 61);
            this.firstNameTextfield.TabIndex = 4;
            // 
            // lastNameTextfield
            // 
            this.lastNameTextfield.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lastNameTextfield.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lastNameTextfield.Location = new System.Drawing.Point(85, 293);
            this.lastNameTextfield.Margin = new System.Windows.Forms.Padding(1);
            this.lastNameTextfield.Name = "lastNameTextfield";
            this.lastNameTextfield.PlaceholderText = "Nachname";
            this.lastNameTextfield.Size = new System.Drawing.Size(308, 61);
            this.lastNameTextfield.TabIndex = 5;
            // 
            // emailTextfield
            // 
            this.emailTextfield.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.emailTextfield.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.emailTextfield.Location = new System.Drawing.Point(85, 356);
            this.emailTextfield.Margin = new System.Windows.Forms.Padding(1);
            this.emailTextfield.Name = "emailTextfield";
            this.emailTextfield.PlaceholderText = "Email";
            this.emailTextfield.Size = new System.Drawing.Size(308, 61);
            this.emailTextfield.TabIndex = 6;
            // 
            // passwordTextfield
            // 
            this.passwordTextfield.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.passwordTextfield.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.passwordTextfield.Location = new System.Drawing.Point(85, 419);
            this.passwordTextfield.Margin = new System.Windows.Forms.Padding(1);
            this.passwordTextfield.Name = "passwordTextfield";
            this.passwordTextfield.PlaceholderText = "Passwort";
            this.passwordTextfield.Size = new System.Drawing.Size(308, 61);
            this.passwordTextfield.TabIndex = 7;
            // 
            // countryTextfield
            // 
            this.countryTextfield.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.countryTextfield.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.countryTextfield.Location = new System.Drawing.Point(811, 167);
            this.countryTextfield.Margin = new System.Windows.Forms.Padding(1);
            this.countryTextfield.Name = "countryTextfield";
            this.countryTextfield.PlaceholderText = "Land";
            this.countryTextfield.Size = new System.Drawing.Size(308, 61);
            this.countryTextfield.TabIndex = 8;
            // 
            // stateTextfield
            // 
            this.stateTextfield.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.stateTextfield.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.stateTextfield.Location = new System.Drawing.Point(811, 230);
            this.stateTextfield.Margin = new System.Windows.Forms.Padding(1);
            this.stateTextfield.Name = "stateTextfield";
            this.stateTextfield.PlaceholderText = "Bundesland";
            this.stateTextfield.Size = new System.Drawing.Size(308, 61);
            this.stateTextfield.TabIndex = 9;
            // 
            // postcodeTextfield
            // 
            this.postcodeTextfield.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.postcodeTextfield.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.postcodeTextfield.Location = new System.Drawing.Point(811, 293);
            this.postcodeTextfield.Margin = new System.Windows.Forms.Padding(1);
            this.postcodeTextfield.Name = "postcodeTextfield";
            this.postcodeTextfield.PlaceholderText = "Postleitzahl";
            this.postcodeTextfield.Size = new System.Drawing.Size(308, 61);
            this.postcodeTextfield.TabIndex = 10;
            // 
            // cityTextfield
            // 
            this.cityTextfield.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cityTextfield.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cityTextfield.Location = new System.Drawing.Point(811, 356);
            this.cityTextfield.Margin = new System.Windows.Forms.Padding(1);
            this.cityTextfield.Name = "cityTextfield";
            this.cityTextfield.PlaceholderText = "Stadt";
            this.cityTextfield.Size = new System.Drawing.Size(308, 61);
            this.cityTextfield.TabIndex = 11;
            // 
            // streetNameTextfield
            // 
            this.streetNameTextfield.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.streetNameTextfield.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.streetNameTextfield.Location = new System.Drawing.Point(811, 419);
            this.streetNameTextfield.Margin = new System.Windows.Forms.Padding(1);
            this.streetNameTextfield.Name = "streetNameTextfield";
            this.streetNameTextfield.PlaceholderText = "Straße";
            this.streetNameTextfield.Size = new System.Drawing.Size(308, 61);
            this.streetNameTextfield.TabIndex = 12;
            // 
            // houseNumberTextfield
            // 
            this.houseNumberTextfield.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.houseNumberTextfield.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.houseNumberTextfield.Location = new System.Drawing.Point(811, 482);
            this.houseNumberTextfield.Margin = new System.Windows.Forms.Padding(1);
            this.houseNumberTextfield.Name = "houseNumberTextfield";
            this.houseNumberTextfield.PlaceholderText = "Hausnummer";
            this.houseNumberTextfield.Size = new System.Drawing.Size(308, 61);
            this.houseNumberTextfield.TabIndex = 13;
            // 
            // paymentMethodPanel
            // 
            this.paymentMethodPanel.AutoSize = true;
            this.paymentMethodPanel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.paymentMethodPanel.Location = new System.Drawing.Point(1, 0);
            this.paymentMethodPanel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.paymentMethodPanel.Name = "paymentMethodPanel";
            this.paymentMethodPanel.Size = new System.Drawing.Size(277, 108);
            this.paymentMethodPanel.TabIndex = 17;
            this.paymentMethodPanel.Text = "Bezahlmethode";
            // 
            // dropdownMenuPayment
            // 
            this.dropdownMenuPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dropdownMenuPayment.DisplayMember = "PayPal";
            this.dropdownMenuPayment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dropdownMenuPayment.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dropdownMenuPayment.FormattingEnabled = true;
            this.dropdownMenuPayment.Location = new System.Drawing.Point(1510, 293);
            this.dropdownMenuPayment.Margin = new System.Windows.Forms.Padding(1);
            this.dropdownMenuPayment.Name = "dropdownMenuPayment";
            this.dropdownMenuPayment.Size = new System.Drawing.Size(308, 62);
            this.dropdownMenuPayment.TabIndex = 17;
            this.dropdownMenuPayment.SelectedIndexChanged += new System.EventHandler(this.dropdownMenuPayment_SelectedIndexChanged);
            // 
            // dropdownMenuSubscription
            // 
            this.dropdownMenuSubscription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dropdownMenuSubscription.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dropdownMenuSubscription.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dropdownMenuSubscription.FormattingEnabled = true;
            this.dropdownMenuSubscription.Location = new System.Drawing.Point(1510, 356);
            this.dropdownMenuSubscription.Margin = new System.Windows.Forms.Padding(1);
            this.dropdownMenuSubscription.Name = "dropdownMenuSubscription";
            this.dropdownMenuSubscription.Size = new System.Drawing.Size(308, 62);
            this.dropdownMenuSubscription.TabIndex = 18;
            // 
            // Enter
            // 
            this.Enter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Enter.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Enter.Location = new System.Drawing.Point(1578, 545);
            this.Enter.Margin = new System.Windows.Forms.Padding(1);
            this.Enter.Name = "Enter";
            this.Enter.Size = new System.Drawing.Size(169, 62);
            this.Enter.TabIndex = 19;
            this.Enter.Text = "Enter";
            this.Enter.UseVisualStyleBackColor = false;
            this.Enter.Click += new System.EventHandler(this.Enter_Click);
            // 
            // dropdownMenuOption
            // 
            this.dropdownMenuOption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dropdownMenuOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dropdownMenuOption.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dropdownMenuOption.FormattingEnabled = true;
            this.dropdownMenuOption.Location = new System.Drawing.Point(85, 545);
            this.dropdownMenuOption.Margin = new System.Windows.Forms.Padding(1);
            this.dropdownMenuOption.Name = "dropdownMenuOption";
            this.dropdownMenuOption.Size = new System.Drawing.Size(308, 62);
            this.dropdownMenuOption.TabIndex = 20;
            this.dropdownMenuOption.SelectedIndexChanged += new System.EventHandler(this.optionComboBox_SelectedIndexChanged);
            // 
            // dataGrid
            // 
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
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
            this.columnHouseNumber,
            this.columnStartDate,
            this.columnEndDate,
            this.columnPayment,
            this.columnSubscription});
            this.dataGrid.FullRowSelect = true;
            this.dataGrid.GridLines = true;
            this.dataGrid.Location = new System.Drawing.Point(85, 637);
            this.dataGrid.Margin = new System.Windows.Forms.Padding(1);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(1733, 160);
            this.dataGrid.TabIndex = 21;
            this.dataGrid.UseCompatibleStateImageBehavior = false;
            this.dataGrid.View = System.Windows.Forms.View.Details;
            this.dataGrid.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
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
            this.columnState.Width = 500;
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
            // columnHouseNumber
            // 
            this.columnHouseNumber.Text = "Straßennummer";
            this.columnHouseNumber.Width = 150;
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
            // dropdownMenuFilter
            // 
            this.dropdownMenuFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dropdownMenuFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dropdownMenuFilter.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dropdownMenuFilter.FormattingEnabled = true;
            this.dropdownMenuFilter.Location = new System.Drawing.Point(700, 545);
            this.dropdownMenuFilter.Margin = new System.Windows.Forms.Padding(1);
            this.dropdownMenuFilter.Name = "dropdownMenuFilter";
            this.dropdownMenuFilter.Size = new System.Drawing.Size(567, 62);
            this.dropdownMenuFilter.TabIndex = 22;
            // 
            // startDatePicker
            // 
            this.startDatePicker.CalendarFont = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.startDatePicker.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.startDatePicker.Location = new System.Drawing.Point(1510, 167);
            this.startDatePicker.MinimumSize = new System.Drawing.Size(0, 61);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(308, 61);
            this.startDatePicker.TabIndex = 24;
            // 
            // endDatePicker
            // 
            this.endDatePicker.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.endDatePicker.Location = new System.Drawing.Point(1510, 230);
            this.endDatePicker.MinimumSize = new System.Drawing.Size(0, 61);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(308, 61);
            this.endDatePicker.TabIndex = 25;
            // 
            // responseTextField
            // 
            this.responseTextField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.responseTextField.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.responseTextField.Location = new System.Drawing.Point(567, 830);
            this.responseTextField.Multiline = true;
            this.responseTextField.Name = "responseTextField";
            this.responseTextField.PlaceholderText = "Response";
            this.responseTextField.ReadOnly = true;
            this.responseTextField.Size = new System.Drawing.Size(796, 54);
            this.responseTextField.TabIndex = 26;
            this.responseTextField.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // logo
            // 
            this.logo.Image = ((System.Drawing.Image)(resources.GetObject("logo.Image")));
            this.logo.Location = new System.Drawing.Point(811, 12);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(308, 138);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logo.TabIndex = 27;
            this.logo.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(100)))), ((int)(((byte)(102)))));
            this.ClientSize = new System.Drawing.Size(1868, 954);
            this.Controls.Add(this.logo);
            this.Controls.Add(this.responseTextField);
            this.Controls.Add(this.endDatePicker);
            this.Controls.Add(this.startDatePicker);
            this.Controls.Add(this.dropdownMenuFilter);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.dropdownMenuOption);
            this.Controls.Add(this.Enter);
            this.Controls.Add(this.dropdownMenuSubscription);
            this.Controls.Add(this.dropdownMenuPayment);
            this.Controls.Add(this.houseNumberTextfield);
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
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private TextBox houseNumberTextfield;
        private Label paymentMethodPanel;
        private ComboBox dropdownMenuPayment;
        private ComboBox dropdownMenuSubscription;
        private Button Enter;
        private ComboBox dropdownMenuOption;
        private ListView dataGrid;
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
        private ColumnHeader columnHouseNumber;
        private ColumnHeader columnStartDate;
        private ColumnHeader columnEndDate;
        private ColumnHeader columnPayment;
        private ColumnHeader columnSubscription;
        private ComboBox dropdownMenuFilter;
        private DateTimePicker startDatePicker;
        private DateTimePicker endDatePicker;
        private TextBox responseTextField;
        private PictureBox logo;
    }
}