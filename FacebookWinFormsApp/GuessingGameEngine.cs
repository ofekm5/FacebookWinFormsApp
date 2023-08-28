//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using FacebookWrapper.ObjectModel;
//using FacebookWrapper;

<<<<<<< HEAD
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
=======
//namespace BasicFacebookFeatures
//{
//    class GuessingGameEngine
//    {
//        private PageLetterList m_ChosenPage;
//        private string m_Outcome;
//        List<Page> m_LikedPages;
//        Random m_Random;
>>>>>>> f5d4fba9c8394e0c90d43cd28e08b606270100b7

//        public string Outcome
//        {
//            get
//            {
//                return m_Outcome;
//            }
//        }

<<<<<<< HEAD
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
=======
//        public string Language
//        {
//            get
//            {
//                return m_ChosenPage.Language;
//            }
//        }

//        public GuessThePageGame(List<Page> i_LikedPages)
//        {
//            m_Random = new Random();
//            m_LikedPages = i_LikedPages;
//            initiallizeGame();
//        }

//        private void initiallizeGame()
//        {
//            m_Outcome = "Let\'s Play!";
//            pickRandomPage();
//        }
>>>>>>> f5d4fba9c8394e0c90d43cd28e08b606270100b7

//        private void pickRandomPage()
//        {
//            bool isPageValid = true;

//            do
//            {
//                int randomNumber = m_Random.Next(0, m_LikedPages.Count - 1);

<<<<<<< HEAD
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
=======
//                try
//                {
//                    m_ChosenPage = new PageLetterList(m_LikedPages[randomNumber]);
//                }
//                catch (Exception ex)
//                {
//                    isPageValid = false;
//                }
//            }
//            while (!isPageValid);
//        }

//        public List<string> GuessLetter(char i_Guess)
//        {
//            List<string> guessIndicesInPage = null;

//            if (m_Outcome != "You won!")
//            {
//                if (m_ChosenPage.ChosenPage.ContainsKey(i_Guess))
//                {
//                    guessIndicesInPage = m_ChosenPage.ChosenPage[i_Guess];

//                    m_ChosenPage.RemoveLetter(i_Guess);

//                    if (m_ChosenPage.Length == 0)
//                    {
//                        m_Outcome = "You won!";
//                    }
//                    else
//                    {
//                        m_Outcome = "Good guess";
//                    }
//                }
//                else
//                {
//                    m_Outcome = "Wrong guess";
//                }
//            }
//            else
//            {
//                throw new Exception("Trying to guess a finished game");
//            }
>>>>>>> f5d4fba9c8394e0c90d43cd28e08b606270100b7

//            return guessIndicesInPage;
//        }
//    }
//}
