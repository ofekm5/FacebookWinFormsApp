namespace BasicFacebookFeatures
{
    partial class FormMain
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonPast = new System.Windows.Forms.Button();
            this.buttonAlbumCreator = new System.Windows.Forms.Button();
            this.buttonPost = new System.Windows.Forms.Button();
            this.textBoxPostStatus = new System.Windows.Forms.TextBox();
            this.labelWhatsOnYourMind = new System.Windows.Forms.Label();
            this.labelBasicDetails = new System.Windows.Forms.Label();
            this.pictureBoxGroups = new System.Windows.Forms.PictureBox();
            this.listBoxGroups = new System.Windows.Forms.ListBox();
            this.buttonGroups = new System.Windows.Forms.Button();
            this.listBoxPosts = new System.Windows.Forms.ListBox();
            this.buttonPosts = new System.Windows.Forms.Button();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.pictureBoxAlbum = new System.Windows.Forms.PictureBox();
            this.labelDetailsHeadline = new System.Windows.Forms.Label();
            this.listBoxAlbums = new System.Windows.Forms.ListBox();
            this.buttonAlbums = new System.Windows.Forms.Button();
            this.pictureBoxLikedPages = new System.Windows.Forms.PictureBox();
            this.buttonLikedPages = new System.Windows.Forms.Button();
            this.listBoxLikedPages = new System.Windows.Forms.ListBox();
            this.pictureBoxProfile = new System.Windows.Forms.PictureBox();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.labelOutcome = new System.Windows.Forms.Label();
            this.buttonPlayAgain = new System.Windows.Forms.Button();
            this.guessingButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.labelLetterGuess = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxGuess = new System.Windows.Forms.TextBox();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGroups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlbum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLikedPages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonPast);
            this.tabPage1.Controls.Add(this.buttonAlbumCreator);
            this.tabPage1.Controls.Add(this.buttonPost);
            this.tabPage1.Controls.Add(this.textBoxPostStatus);
            this.tabPage1.Controls.Add(this.labelWhatsOnYourMind);
            this.tabPage1.Controls.Add(this.labelBasicDetails);
            this.tabPage1.Controls.Add(this.pictureBoxGroups);
            this.tabPage1.Controls.Add(this.listBoxGroups);
            this.tabPage1.Controls.Add(this.buttonGroups);
            this.tabPage1.Controls.Add(this.listBoxPosts);
            this.tabPage1.Controls.Add(this.buttonPosts);
            this.tabPage1.Controls.Add(this.labelWelcome);
            this.tabPage1.Controls.Add(this.pictureBoxAlbum);
            this.tabPage1.Controls.Add(this.labelDetailsHeadline);
            this.tabPage1.Controls.Add(this.listBoxAlbums);
            this.tabPage1.Controls.Add(this.buttonAlbums);
            this.tabPage1.Controls.Add(this.pictureBoxLikedPages);
            this.tabPage1.Controls.Add(this.buttonLikedPages);
            this.tabPage1.Controls.Add(this.listBoxLikedPages);
            this.tabPage1.Controls.Add(this.pictureBoxProfile);
            this.tabPage1.Controls.Add(this.buttonLogout);
            this.tabPage1.Controls.Add(this.buttonLogin);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1235, 666);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Basic features";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonPast
            // 
            this.buttonPast.Location = new System.Drawing.Point(992, 74);
            this.buttonPast.Name = "buttonPast";
            this.buttonPast.Size = new System.Drawing.Size(207, 32);
            this.buttonPast.TabIndex = 80;
            this.buttonPast.Text = "Blast From The Past";
            this.buttonPast.UseVisualStyleBackColor = true;
            this.buttonPast.Visible = false;
            // 
            // buttonAlbumCreator
            // 
            this.buttonAlbumCreator.Location = new System.Drawing.Point(436, 612);
            this.buttonAlbumCreator.Name = "buttonAlbumCreator";
            this.buttonAlbumCreator.Size = new System.Drawing.Size(235, 34);
            this.buttonAlbumCreator.TabIndex = 79;
            this.buttonAlbumCreator.Text = "Create an album";
            this.buttonAlbumCreator.UseVisualStyleBackColor = true;
            this.buttonAlbumCreator.Visible = false;
            // 
            // buttonPost
            // 
            this.buttonPost.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPost.Location = new System.Drawing.Point(871, 74);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(54, 32);
            this.buttonPost.TabIndex = 78;
            this.buttonPost.Text = "Post";
            this.buttonPost.UseVisualStyleBackColor = true;
            this.buttonPost.Visible = false;
            this.buttonPost.Click += new System.EventHandler(this.buttonPost_Click);
            // 
            // textBoxPostStatus
            // 
            this.textBoxPostStatus.Location = new System.Drawing.Point(553, 58);
            this.textBoxPostStatus.Multiline = true;
            this.textBoxPostStatus.Name = "textBoxPostStatus";
            this.textBoxPostStatus.Size = new System.Drawing.Size(317, 48);
            this.textBoxPostStatus.TabIndex = 77;
            this.textBoxPostStatus.Visible = false;
            // 
            // labelWhatsOnYourMind
            // 
            this.labelWhatsOnYourMind.AutoSize = true;
            this.labelWhatsOnYourMind.Location = new System.Drawing.Point(625, 32);
            this.labelWhatsOnYourMind.Name = "labelWhatsOnYourMind";
            this.labelWhatsOnYourMind.Size = new System.Drawing.Size(152, 18);
            this.labelWhatsOnYourMind.TabIndex = 76;
            this.labelWhatsOnYourMind.Text = "What\'s on your mind?";
            this.labelWhatsOnYourMind.Visible = false;
            // 
            // labelBasicDetails
            // 
            this.labelBasicDetails.AutoSize = true;
            this.labelBasicDetails.Location = new System.Drawing.Point(34, 386);
            this.labelBasicDetails.Name = "labelBasicDetails";
            this.labelBasicDetails.Size = new System.Drawing.Size(53, 18);
            this.labelBasicDetails.TabIndex = 75;
            this.labelBasicDetails.Text = "Details";
            this.labelBasicDetails.Visible = false;
            // 
            // pictureBoxGroups
            // 
            this.pictureBoxGroups.Location = new System.Drawing.Point(1076, 448);
            this.pictureBoxGroups.Name = "pictureBoxGroups";
            this.pictureBoxGroups.Size = new System.Drawing.Size(140, 166);
            this.pictureBoxGroups.TabIndex = 74;
            this.pictureBoxGroups.TabStop = false;
            this.pictureBoxGroups.Visible = false;
            // 
            // listBoxGroups
            // 
            this.listBoxGroups.FormattingEnabled = true;
            this.listBoxGroups.ItemHeight = 18;
            this.listBoxGroups.Location = new System.Drawing.Point(840, 448);
            this.listBoxGroups.Name = "listBoxGroups";
            this.listBoxGroups.Size = new System.Drawing.Size(230, 148);
            this.listBoxGroups.TabIndex = 73;
            this.listBoxGroups.Visible = false;
            // 
            // buttonGroups
            // 
            this.buttonGroups.Location = new System.Drawing.Point(840, 391);
            this.buttonGroups.Name = "buttonGroups";
            this.buttonGroups.Size = new System.Drawing.Size(275, 46);
            this.buttonGroups.TabIndex = 72;
            this.buttonGroups.Text = "Fetch TODO";
            this.buttonGroups.UseVisualStyleBackColor = true;
            this.buttonGroups.Visible = false;
            // 
            // listBoxPosts
            // 
            this.listBoxPosts.FormattingEnabled = true;
            this.listBoxPosts.ItemHeight = 18;
            this.listBoxPosts.Location = new System.Drawing.Point(840, 205);
            this.listBoxPosts.Name = "listBoxPosts";
            this.listBoxPosts.Size = new System.Drawing.Size(376, 148);
            this.listBoxPosts.TabIndex = 70;
            this.listBoxPosts.Visible = false;
            // 
            // buttonPosts
            // 
            this.buttonPosts.Location = new System.Drawing.Point(840, 163);
            this.buttonPosts.Name = "buttonPosts";
            this.buttonPosts.Size = new System.Drawing.Size(187, 34);
            this.buttonPosts.TabIndex = 69;
            this.buttonPosts.Text = "Click to view your posts";
            this.buttonPosts.UseVisualStyleBackColor = true;
            this.buttonPosts.Visible = false;
            this.buttonPosts.Click += new System.EventHandler(this.buttonPosts_Click);
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Location = new System.Drawing.Point(20, 10);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(240, 18);
            this.labelWelcome.TabIndex = 65;
            this.labelWelcome.Text = "Welcome to our Facebook API app";
            // 
            // pictureBoxAlbum
            // 
            this.pictureBoxAlbum.Location = new System.Drawing.Point(611, 446);
            this.pictureBoxAlbum.Name = "pictureBoxAlbum";
            this.pictureBoxAlbum.Size = new System.Drawing.Size(156, 160);
            this.pictureBoxAlbum.TabIndex = 62;
            this.pictureBoxAlbum.TabStop = false;
            this.pictureBoxAlbum.Visible = false;
            // 
            // labelDetailsHeadline
            // 
            this.labelDetailsHeadline.AutoSize = true;
            this.labelDetailsHeadline.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDetailsHeadline.Location = new System.Drawing.Point(33, 346);
            this.labelDetailsHeadline.Name = "labelDetailsHeadline";
            this.labelDetailsHeadline.Size = new System.Drawing.Size(105, 24);
            this.labelDetailsHeadline.TabIndex = 61;
            this.labelDetailsHeadline.Text = "About you";
            this.labelDetailsHeadline.Visible = false;
            // 
            // listBoxAlbums
            // 
            this.listBoxAlbums.FormattingEnabled = true;
            this.listBoxAlbums.ItemHeight = 18;
            this.listBoxAlbums.Location = new System.Drawing.Point(377, 446);
            this.listBoxAlbums.Name = "listBoxAlbums";
            this.listBoxAlbums.Size = new System.Drawing.Size(230, 148);
            this.listBoxAlbums.TabIndex = 60;
            this.listBoxAlbums.Visible = false;
            this.listBoxAlbums.SelectedIndexChanged += new System.EventHandler(this.listBoxAlbums_SelectedIndexChanged);
            // 
            // buttonAlbums
            // 
            this.buttonAlbums.Location = new System.Drawing.Point(377, 405);
            this.buttonAlbums.Name = "buttonAlbums";
            this.buttonAlbums.Size = new System.Drawing.Size(224, 35);
            this.buttonAlbums.TabIndex = 59;
            this.buttonAlbums.Text = "Click to view albums";
            this.buttonAlbums.UseVisualStyleBackColor = true;
            this.buttonAlbums.Visible = false;
            this.buttonAlbums.Click += new System.EventHandler(this.buttonAlbums_Click);
            // 
            // pictureBoxLikedPages
            // 
            this.pictureBoxLikedPages.Location = new System.Drawing.Point(612, 205);
            this.pictureBoxLikedPages.Name = "pictureBoxLikedPages";
            this.pictureBoxLikedPages.Size = new System.Drawing.Size(156, 166);
            this.pictureBoxLikedPages.TabIndex = 58;
            this.pictureBoxLikedPages.TabStop = false;
            this.pictureBoxLikedPages.Visible = false;
            // 
            // buttonLikedPages
            // 
            this.buttonLikedPages.Location = new System.Drawing.Point(377, 165);
            this.buttonLikedPages.Name = "buttonLikedPages";
            this.buttonLikedPages.Size = new System.Drawing.Size(230, 32);
            this.buttonLikedPages.TabIndex = 57;
            this.buttonLikedPages.Text = "Click to view liked pages";
            this.buttonLikedPages.UseVisualStyleBackColor = true;
            this.buttonLikedPages.Visible = false;
            this.buttonLikedPages.Click += new System.EventHandler(this.buttonLikedPages_Click);
            // 
            // listBoxLikedPages
            // 
            this.listBoxLikedPages.FormattingEnabled = true;
            this.listBoxLikedPages.ItemHeight = 18;
            this.listBoxLikedPages.Location = new System.Drawing.Point(377, 205);
            this.listBoxLikedPages.Name = "listBoxLikedPages";
            this.listBoxLikedPages.Size = new System.Drawing.Size(229, 148);
            this.listBoxLikedPages.TabIndex = 56;
            this.listBoxLikedPages.Visible = false;
            this.listBoxLikedPages.SelectedIndexChanged += new System.EventHandler(this.listBoxLikedPages_SelectedIndexChanged);
            // 
            // pictureBoxProfile
            // 
            this.pictureBoxProfile.Location = new System.Drawing.Point(37, 161);
            this.pictureBoxProfile.Name = "pictureBoxProfile";
            this.pictureBoxProfile.Size = new System.Drawing.Size(189, 151);
            this.pictureBoxProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxProfile.TabIndex = 55;
            this.pictureBoxProfile.TabStop = false;
            // 
            // buttonLogout
            // 
            this.buttonLogout.Enabled = false;
            this.buttonLogout.Location = new System.Drawing.Point(23, 85);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(224, 43);
            this.buttonLogout.TabIndex = 52;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(23, 32);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(224, 45);
            this.buttonLogin.TabIndex = 36;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1243, 697);
            this.tabControl1.TabIndex = 54;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.labelOutcome);
            this.tabPage2.Controls.Add(this.buttonPlayAgain);
            this.tabPage2.Controls.Add(this.guessingButton);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.labelLetterGuess);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.textBoxGuess);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1235, 666);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Guess The Page";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // labelOutcome
            // 
            this.labelOutcome.AutoSize = true;
            this.labelOutcome.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOutcome.Location = new System.Drawing.Point(597, 388);
            this.labelOutcome.Name = "labelOutcome";
            this.labelOutcome.Size = new System.Drawing.Size(111, 30);
            this.labelOutcome.TabIndex = 84;
            this.labelOutcome.Text = "Let\'s Play!";
            this.labelOutcome.Visible = false;
            // 
            // buttonPlayAgain
            // 
            this.buttonPlayAgain.Enabled = false;
            this.buttonPlayAgain.Location = new System.Drawing.Point(577, 421);
            this.buttonPlayAgain.Name = "buttonPlayAgain";
            this.buttonPlayAgain.Size = new System.Drawing.Size(161, 33);
            this.buttonPlayAgain.TabIndex = 83;
            this.buttonPlayAgain.Text = "Press to play again";
            this.buttonPlayAgain.UseVisualStyleBackColor = true;
            this.buttonPlayAgain.Visible = false;
            // 
            // guessingButton
            // 
            this.guessingButton.Enabled = false;
            this.guessingButton.Location = new System.Drawing.Point(784, 246);
            this.guessingButton.Name = "guessingButton";
            this.guessingButton.Size = new System.Drawing.Size(65, 24);
            this.guessingButton.TabIndex = 82;
            this.guessingButton.Text = "Guess";
            this.guessingButton.UseVisualStyleBackColor = true;
            this.guessingButton.Click += new System.EventHandler(this.guessingButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(386, 328);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 18);
            this.label4.TabIndex = 70;
            this.label4.Text = "Page: ";
            // 
            // labelLetterGuess
            // 
            this.labelLetterGuess.Location = new System.Drawing.Point(386, 246);
            this.labelLetterGuess.Name = "labelLetterGuess";
            this.labelLetterGuess.Size = new System.Drawing.Size(155, 48);
            this.labelLetterGuess.TabIndex = 69;
            this.labelLetterGuess.Text = "Please guess a letter";
            this.labelLetterGuess.UseWaitCursor = true;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(374, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(592, 142);
            this.label2.TabIndex = 68;
            this.label2.Text = "We have picked a random page you have liked. \r\nCould you guess it? \r\nGuess one le" +
    "tter at a time. Make sure its lowercase and in english.\r\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(464, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 42);
            this.label1.TabIndex = 67;
            this.label1.Text = "Guess The Page";
            // 
            // textBoxGuess
            // 
            this.textBoxGuess.Enabled = false;
            this.textBoxGuess.Location = new System.Drawing.Point(547, 246);
            this.textBoxGuess.Name = "textBoxGuess";
            this.textBoxGuess.Size = new System.Drawing.Size(231, 24);
            this.textBoxGuess.TabIndex = 66;
            this.textBoxGuess.Text = "You have to login in order to play";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 697);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGroups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlbum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLikedPages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PictureBox pictureBoxAlbum;
        private System.Windows.Forms.Label labelDetailsHeadline;
        private System.Windows.Forms.ListBox listBoxAlbums;
        private System.Windows.Forms.Button buttonAlbums;
        private System.Windows.Forms.PictureBox pictureBoxLikedPages;
        private System.Windows.Forms.Button buttonLikedPages;
        private System.Windows.Forms.ListBox listBoxLikedPages;
        private System.Windows.Forms.PictureBox pictureBoxProfile;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.ListBox listBoxPosts;
        private System.Windows.Forms.Button buttonPosts;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox pictureBoxGroups;
        private System.Windows.Forms.ListBox listBoxGroups;
        private System.Windows.Forms.Button buttonGroups;
        private System.Windows.Forms.Label labelBasicDetails;
        private System.Windows.Forms.TextBox textBoxGuess;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPostStatus;
        private System.Windows.Forms.Label labelWhatsOnYourMind;
        private System.Windows.Forms.Button buttonPost;
        private System.Windows.Forms.Button buttonAlbumCreator;
        private System.Windows.Forms.Label labelLetterGuess;
        private System.Windows.Forms.Button buttonPast;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button guessingButton;
        private System.Windows.Forms.Label labelOutcome;
        private System.Windows.Forms.Button buttonPlayAgain;
    }
}

