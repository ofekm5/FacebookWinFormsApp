using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;

namespace BasicFacebookFeatures
{
    class PageLetters
    {
        private Dictionary<char, List<int>> m_ChosenPageLetters;
        private int m_TotalChars;
        private int m_ActualLetters;

        public PageLetters(Page i_LikedPage)
        {
            if (!isCharALetter(i_LikedPage.Name[0])){
                throw new Exception("Page starts in non-english language");
            }
            else if (i_LikedPage.Name.Length > 30)
            {
                throw new Exception("Page is too long");
            }
            else
            {
                m_ChosenPageLetters = new Dictionary<char, List<int>>();
                m_ActualLetters = 0;
            }

            validatePageName(i_LikedPage.Name);
        }

        private void validatePageName(string i_PageName)
        {
            int pageLen = i_PageName.Length;
            int i;

            for (i = 0; i < pageLen; i++) //could not use foreach because of index storing
            {
                if (!isCharALetter(i_PageName[i]) && !isSpecialChar(i_PageName[i]))
                {
                    break;
                }
                else
                {
                    storeCharAccordingly(i_PageName[i], i);
                }
            }

            m_TotalChars = i;
        }

        public int ActualLetters
        {
            get
            {
                return m_ActualLetters;
            }
        }

        private void storeCharAccordingly(char i_C, int i_CharIndex)
        {
            char currentLetterLowercased = char.ToLower(i_C);

            if (!m_ChosenPageLetters.ContainsKey(currentLetterLowercased))
            {
                List<int> newKeyList = new List<int>();
                newKeyList.Add(i_CharIndex);
                m_ChosenPageLetters.Add(currentLetterLowercased, newKeyList);
                if (!isSpecialChar(currentLetterLowercased))
                {
                    m_ActualLetters++;
                }
            }
            else
            {
                m_ChosenPageLetters[currentLetterLowercased].Add(i_CharIndex);
            }
        }

        public int TotalChars
        {
            get
            {
                return m_TotalChars;
            }
        }

        private bool isCharALetter(char i_C)
        {
            return ((i_C >= 'A' && i_C <= 'Z') || (i_C >= 'a' && i_C <= 'z')) ? true : false;
        }

        private bool isSpecialChar(char i_C)
        {
            return (i_C == ' ' || i_C == '\'' || i_C == '.' || i_C == ',') ? true : false;
        }

        public Dictionary<char, List<int>> PageLettersIndices
        {
            get
            {
                return m_ChosenPageLetters;
            }
        }
    }
}
