//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using FacebookWrapper.ObjectModel;
//using FacebookWrapper;

//namespace BasicFacebookFeatures
//{
//    class GuessingGameEngine
//    {
//        private PageLetterList m_ChosenPage;
//        private string m_Outcome;
//        List<Page> m_LikedPages;
//        Random m_Random;

//        public string Outcome
//        {
//            get
//            {
//                return m_Outcome;
//            }
//        }

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

//        private void pickRandomPage()
//        {
//            bool isPageValid = true;

//            do
//            {
//                int randomNumber = m_Random.Next(0, m_LikedPages.Count - 1);

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

//            return guessIndicesInPage;
//        }
//    }
//}
