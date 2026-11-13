using System;
using System.Collections.Generic;
using System.Text;


namespace SortingAlgorithmVisualizer {
    internal interface ISorter {


        void NextStep();
        bool IsSorted();

        void ReDraw();
    }


}
