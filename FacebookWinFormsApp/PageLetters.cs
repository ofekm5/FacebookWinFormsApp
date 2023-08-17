//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using FacebookWrapper.ObjectModel;
//using FacebookWrapper;

//namespace BasicFacebookFeatures
//{
//    class PageLetters
//    {
//        private Dictionary<char, List<string>> m_ChosenPage;
//        private string m_Lang;

//        public PageLetters(Page i_LikedPage)
//        {
//            int letterCounter = 0;

//            foreach (char letter in i_LikedPage.Name)
//            {
//                //if ()//a number or diff lang or counter==30
//                //{
//                //    throw new Exception("illegal page name");
//                //}
//                //else
//                //{
//                //    if ()//if the key is already inside
//                //    {

//                //    }
//                //    else
//                //    {
//                //        letterCounter++;
//                //    }
//                //}
//            }
//        }

//        public void RemoveLetter(char i_Letter)
//        {
//            m_ChosenPage.Remove(i_Letter);
//        }

//        public Dictionary<char, List<string>> ChosenPage
//        {
//            get
//            {
//                return m_ChosenPage;
//            }
//        }

//        public string Language
//        {
//            get
//            {
//                return m_Lang;
//            }
//        }

//        public int Length
//        {
//            get
//            {
//                return m_ChosenPage.Keys.Count();
//            }
//        }
//    }
//}
