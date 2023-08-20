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
        private int m_WrongGuesses;
        private SortedSet<char> m_CorrectLetters;
        private int m_LettersLeftToGuess;
        private const int k_MaxWrongGuesses = 5;

        public PageLetters ChosenPageLetters
        {
            get
            {
                return m_ChosenPageLetters;
            }
        }

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

        public int TotalChars
        {
            get
            {
                return m_ChosenPageLetters.TotalChars;
            }
        }

        public void RestartGame()
        {
            initiallizeGame();
        }

        private void initiallizeGame()
        {
            m_CorrectLetters = new SortedSet<char>();
            m_WrongGuesses = 0;
            m_Outcome = "Let\'s Play!";
            pickRandomPage();
        }

        private void pickRandomPage()
        {
            bool isPageValid = true;

            do
            {
                int randomNumber = m_Random.Next(0, m_LikedPages.Count - 1);

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

            m_LettersLeftToGuess = m_ChosenPageLetters.ActualLetters;
        }

        public List<int> GuessLetter(string i_Guess)
        {
            List<int> guessIndicesInPage = null;

            if (m_Outcome != "You won!")
            {
                if (i_Guess.Length > 1)
                {
                    m_Outcome = "Guess is longer than a single letter";
                }
                else if (i_Guess.Length < 1)
                {
                    m_Outcome = "Guess is shorter than a single letter";
                }
                else if (i_Guess[0] < 'a' || i_Guess[0] > 'z')
                {
                    m_Outcome = "Guess is not a letter";
                }
                else if (m_CorrectLetters.Contains(i_Guess[0]))
                {
                    m_Outcome = "Correct letter was already guessed";
                }
                else if (m_ChosenPageLetters.PageLettersIndices.ContainsKey(i_Guess[0]))
                {
                    guessIndicesInPage = m_ChosenPageLetters.PageLettersIndices[i_Guess[0]];
                    m_CorrectLetters.Add(i_Guess[0]);
                    m_LettersLeftToGuess--;
                    m_Outcome = (m_LettersLeftToGuess == 0) ? "You won!" : "Good guess";
                }
                else
                {
                    m_WrongGuesses++;
                    m_Outcome = (m_WrongGuesses == k_MaxWrongGuesses)? "You lost!" : "Wrong";
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
