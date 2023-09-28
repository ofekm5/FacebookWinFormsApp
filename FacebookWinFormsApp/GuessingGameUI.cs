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
        private GameLettersLabels m_GameLettersLabels;

        public Label[] CharLabels
        {
            get
            {
                return m_GameLettersLabels.CharLabels;
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
            m_GameLettersLabels = new GameLettersLabels(m_LabelPage.Height, m_LabelPage.Width, m_GuessGame.TotalChars, m_LabelPage.Location.X, m_LabelPage.Location.Y, m_GuessGame.ChosenPageLetters.PageLettersIndices);
            m_GuessGame.m_CorrectGuess += m_GameLettersLabels.UpdateLabels;
            m_LabelOutcome.Text = "Let's Play!";
            m_TextBoxGuess.Enabled = true;
            m_TextBoxGuess.Text = "";
            m_ButtonGuess.Enabled = true;
            m_LabelOutcome.Visible = true;
            m_ButtonPlayAgain.Enabled = false;
            m_ButtonPlayAgain.Visible = false;
        }


        public void PlayTurn()
        {
            try
            {
                m_GuessGame.GuessLetter(m_TextBoxGuess.Text);
                switch (m_GuessGame.Outcome)
                {
                    case "You won!":
                        wrapUpGame();
                        break;
                    case "You lost!":
                        wrapUpGame();
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
            m_GameLettersLabels.Restart();
            initiallizeUI();
        }

        public void UserLogout()
        {
            m_TextBoxGuess.Enabled = false;
            m_TextBoxGuess.Text = "You have to login in order to play";

            m_ButtonGuess.Enabled = false;

            m_LabelOutcome.Visible = false;

            m_ButtonPlayAgain.Enabled = false;
            m_ButtonPlayAgain.Visible = false;

            m_GameLettersLabels.Disappear();
        }
    }
}
