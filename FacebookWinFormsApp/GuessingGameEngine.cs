using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;

namespace BasicFacebookFeatures
{
    class GuessingGameEngine
    {
        private PageLetters m_ChosenPageLetters;
        private string m_Outcome;
        private List<Page> m_LikedPages;
        private Random m_Random;

        public string Outcome
        {
            get
            {
                return m_Outcome;
            }
        }

        public GuessingGameEngine(List<Page> i_LikedPages)
        {
            m_Random = new Random();
            if (i_LikedPages.Count<=0)
            {
                throw new Exception("user do not have liked pages");
            }
            else
            {
                m_LikedPages = i_LikedPages;
                initiallizeGame();
            }
        }

        public void RestartGame()
        {
            initiallizeGame();
        }

        private void initiallizeGame()
        {
            m_Outcome = "Let\'s Play!";
            pickRandomPage();
        }

        private void pickRandomPage()
        {
            bool isPageValid = true;

            do
            {
                int randomNumber = 0;//Revert this!!!!! m_Random.Next(0, m_LikedPages.Count - 1);

                try
                {
                    m_ChosenPageLetters = new PageLetters(m_LikedPages[randomNumber]);
                    isPageValid = true;
                }
                catch (Exception ex)
                {
                    isPageValid = false;
                }
            }
            while (!isPageValid);
        }

        public List<int> GuessLetter(char i_Guess)
        {
            List<int> guessIndicesInPage = null;

            if (m_Outcome != "You won!")
            {
                if (m_ChosenPageLetters.PageLettersIndices.ContainsKey(i_Guess))
                {
                    guessIndicesInPage = m_ChosenPageLetters.PageLettersIndices[i_Guess];

                    m_ChosenPageLetters.RemoveLetter(i_Guess);

                    if (m_ChosenPageLetters.PageLettersIndices.Keys.Count == 0)
                    {
                        m_Outcome = "You won!";
                    }
                    else
                    {
                        m_Outcome = "Good guess";
                    }
                }
                else
                {
                    m_Outcome = "Wrong guess";
                }
            }
            else
            {
                throw new Exception("Trying to guess a finished game");
            }

            return guessIndicesInPage;
        }
    }
}
