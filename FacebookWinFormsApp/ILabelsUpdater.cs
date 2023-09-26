using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFacebookFeatures
{
    interface ILabelsUpdater
    {
        void UpdateLabels(List<int> i_Indices, string i_C);
    }
}
