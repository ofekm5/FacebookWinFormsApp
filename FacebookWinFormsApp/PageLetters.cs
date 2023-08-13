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
        private int m_TotalLetters;

        public PageLetters(Page i_LikedPage)
        {
            int pageLen = i_LikedPage.Name.Length;
            bool isDictInitiallized = false;
            int i;

            for (i = 0; i < pageLen; i++) //could not use foreach because of index storing
            {
                if ((!isCharALetter(i_LikedPage.Name[i]) || (i == 30)))
                {
                    if (isDictInitiallized)
                    {
                        break;
                    }
                    else
                    {
                        throw new Exception("Page starts in non-english language");
                    }
                }
                else
                {
                    char currentLetterLowercased = char.ToLower(i_LikedPage.Name[i]);

                    if (!isDictInitiallized)
                    {
                        m_ChosenPageLetters = new Dictionary<char, List<int>>();
                        isDictInitiallized = true;
                    }

                    if (!m_ChosenPageLetters.ContainsKey(currentLetterLowercased))
                    {
                        List<int> newKeyList = new List<int>();
                        newKeyList.Add(i);
                        m_ChosenPageLetters.Add(currentLetterLowercased, newKeyList);
                    }
                    else
                    {
                        m_ChosenPageLetters[currentLetterLowercased].Add(i);
                    }
                }
            }

            m_TotalLetters = i;
        }

        public int TotalLetters
        {
            get
            {
                return m_TotalLetters;
            }
        }

        private bool isCharALetter(char i_C)
        {
            return ((i_C >= 'A' && i_C <= 'Z') || (i_C >= 'a' && i_C <= 'z') || i_C == ' ') ? true : false;
        }

        public void RemoveLetter(char i_Letter)
        {
            m_ChosenPageLetters.Remove(i_Letter);
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
