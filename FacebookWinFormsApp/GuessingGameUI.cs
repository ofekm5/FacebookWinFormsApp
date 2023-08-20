using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;

namespace BasicFacebookFeatures
{
    class GuessingGameUI
    {
        private GuessingGameEngine m_GuessGame;
        private TextBox m_TextBoxGuess;
        private Button m_ButtonGuess;
        private Label m_LabelOutcome;
        private Button m_ButtonPlayAgain;
        private Label m_LabelPage;
        private Label[] m_LabelChars;

        public Label[] LabelChars {
            get
            {
                return m_LabelChars;
            }
        }

        public GuessingGameUI(List<Page> i_LikedPages, TextBox i_TextBoxGuess, Button i_ButtonGuess, Label i_LabelOutcome, Button i_ButtonPlayAgain, Label i_LabelPage)
        {
            m_TextBoxGuess = i_TextBoxGuess;
            m_ButtonGuess = i_ButtonGuess;
            m_LabelOutcome = i_LabelOutcome;
            m_ButtonPlayAgain = i_ButtonPlayAgain;
            m_LabelPage = i_LabelPage;

            try
            {
                m_GuessGame = new GuessingGameEngine(i_LikedPages);
                initiallizeUI();
            }
            catch (Exception ex)
            {
                m_TextBoxGuess.Text = ex.Message;
            }
        }

        private void initiallizeUI()
        {
            int totalChars = m_GuessGame.TotalChars;
            int currentLabelX = (m_LabelPage.Location.X) - (totalChars * 10) + 50;
            int currentLabelY = m_LabelPage.Location.Y + 100;

            m_LabelChars = new Label[totalChars];
            for (int i = 0 ; i < totalChars; i++)
            {
                m_LabelChars[i] = new Label();
                m_LabelChars[i].Height = m_LabelPage.Height;
                m_LabelChars[i].Width = m_LabelPage.Width;
                m_LabelChars[i].Location = new System.Drawing.Point(currentLabelX, currentLabelY);
                m_LabelChars[i].Visible = true;
                storeCurrectCharInLabel(i);
                currentLabelX += 50;
            }

            m_LabelOutcome.Text = "Let's Play!";
            m_TextBoxGuess.Enabled = true;
            m_TextBoxGuess.Text = "";
            m_ButtonGuess.Enabled = true;
            m_LabelOutcome.Visible = true;
        }

        private void storeCurrectCharInLabel(int i_LabelIndex)
        {
            if (m_GuessGame.ChosenPageLetters.PageLettersIndices.ContainsKey(' ') && m_GuessGame.ChosenPageLetters.PageLettersIndices[' '].Contains(i_LabelIndex))
            {
                m_LabelChars[i_LabelIndex].Text = " ";
            }
            else if (m_GuessGame.ChosenPageLetters.PageLettersIndices.ContainsKey('.') && m_GuessGame.ChosenPageLetters.PageLettersIndices['.'].Contains(i_LabelIndex))
            {
                m_LabelChars[i_LabelIndex].Text = ".";
            }
            else if (m_GuessGame.ChosenPageLetters.PageLettersIndices.ContainsKey('\'') && m_GuessGame.ChosenPageLetters.PageLettersIndices['\''].Contains(i_LabelIndex))
            {
                m_LabelChars[i_LabelIndex].Text = "\'";
            }
            else if (m_GuessGame.ChosenPageLetters.PageLettersIndices.ContainsKey(',') && m_GuessGame.ChosenPageLetters.PageLettersIndices[','].Contains(i_LabelIndex))
            {
                m_LabelChars[i_LabelIndex].Text = ",";
            }
            else
            {
                m_LabelChars[i_LabelIndex].Text = "?";
            }
        }

        public void PlayTurn()
        {
            try
            {
                List<int> indices = m_GuessGame.GuessLetter(m_TextBoxGuess.Text);
                switch (m_GuessGame.Outcome)
                {
                    case "You won!":
                        updateLabelsChar(indices, m_TextBoxGuess.Text);
                        wrapUpGame();
                        break;
                    case "You lost!":
                        wrapUpGame();
                        break;
                    case "Good guess":
                        updateLabelsChar(indices, m_TextBoxGuess.Text);
                        break;
                }
                m_LabelOutcome.Text = m_GuessGame.Outcome;
                m_TextBoxGuess.Text = "";
            }
            catch (Exception ex)
            {
                m_LabelOutcome.Text = ex.Message;
            }
        }

        private void updateLabelsChar(List<int> i_Indices, string i_C)
        {
            foreach(int i in i_Indices)
            {
                m_LabelChars[i].Text = i_C;
            }
        }

        private void wrapUpGame()
        {
            m_ButtonPlayAgain.Enabled = true;
            m_ButtonPlayAgain.Visible = true;
            m_TextBoxGuess.Text = "Game finished";
            m_TextBoxGuess.Enabled = false;
            m_ButtonGuess.Enabled = false;
        }

        public void Rematch()
        {
            m_GuessGame.RestartGame();
            initiallizeUI();
            m_ButtonPlayAgain.Enabled = false;
            m_ButtonPlayAgain.Visible = false;
        }

        public void UserLogout()
        {
            m_TextBoxGuess.Enabled = false;
            m_TextBoxGuess.Text = "You have to login in order to play";

            m_ButtonGuess.Enabled = false;

            m_LabelOutcome.Visible = false;

            m_ButtonPlayAgain.Enabled = false;
            m_ButtonPlayAgain.Visible = false;

            foreach(Label labelChar in m_LabelChars)
            {
                labelChar.Visible = false;
            }
        }
    }
}
