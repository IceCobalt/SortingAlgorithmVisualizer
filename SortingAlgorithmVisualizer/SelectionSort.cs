using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgorithmVisualizer {
     class SelectionSort : ISorter{

        //Variables needed by the algorithm
        private int[] Array;
        private Graphics g;
        private int MaxVal;
        Brush WhiteBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
        Brush BlackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);

        //Constructor
        public SelectionSort( int[] ArrayIn, Graphics gIn, int MaxValIn ) {
            //using this.Array didnt properly pass the values in so I had to make the names different
            Array = ArrayIn;
            g = gIn;
            MaxVal = MaxValIn;
        }

        public void NextStep() {
            for ( int i = 0; i < Array.Count() - 1; i++ ) {
                //assume current is minimum
                int min = i;

                //find the actual minimum
                for ( int j = i + 1; j < Array.Count(); j++ ) {
                    if ( Array[j] < Array[min] )
                        min = j;
                }

                //move minimum element to right spot
                int tmp = Array[i];
                Array[i] = Array[min];
                Array[min] = tmp;

                DrawBar(i, Array[i]);
                DrawBar(min, Array[min]);


            }
        }

        private void DrawBar( int position, int height ) {
            g.FillRectangle(BlackBrush, position, 0, 1, MaxVal);
            g.FillRectangle(WhiteBrush, position, MaxVal - Array[position], 1, MaxVal);
        }

        public bool IsSorted() { //if every spot i is less than spot i + 1, the array is sorted
            for ( int i = 0; i < Array.Count() - 1; i++ ) {
                if ( Array[i] > Array[i + 1] ) return false;
            }
            return true;
        }

        public void ReDraw() {
            for ( int i = 0; i < Array.Count() - 1; i++ ) {
                g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.White), i, MaxVal - Array[i], 1, MaxVal);
            }
        }
    }
}
