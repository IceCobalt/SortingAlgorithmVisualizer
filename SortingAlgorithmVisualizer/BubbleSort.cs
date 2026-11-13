using System;
using System.Collections.Generic;
using System.Text;


namespace SortingAlgorithmVisualizer {
    class BubbleSort : ISorter {

        //Variables needed by the algorithm
        private bool _sorted = false;
        private int[] Array;
        private Graphics g;
        private int MaxVal;
        Brush WhiteBrush = new System.Drawing.SolidBrush( System.Drawing.Color.White );
        Brush BlackBrush = new System.Drawing.SolidBrush( System.Drawing.Color.Black );

        public void Sort( int[] ArrayIn, Graphics gIn, int MaxValIn ) { 
            //using this.Array didnt properly pass the values in so I had to make the names different
            Array = ArrayIn;
            g = gIn;
            MaxVal = MaxValIn;

            while ( !_sorted ) {

                for (int i = 0; i < Array.Count() - 1; i++ ) {
                    if ( Array[i] > Array[i + 1] ) {
                        Swap( i, i + 1 );
                    }
                }
                _sorted = IsSorted();
            }
        }

        private void Swap( int x, int y ) {
            //x ^= y ^= x ^= y; //GOATED XOR SWAP
            //okay xor swap is actually way slower than using a tmp variable
            int tmp = Array[x];
            Array[x] = Array[y];
            Array[y] = tmp;


            //remove old values
            //OPTIMIZE? make this one instance that is two pixels, instead of two instances that are one pixel each (for both?)
            g.FillRectangle( BlackBrush, x, 0, 1, MaxVal );
            g.FillRectangle( BlackBrush, y, 0, 1, MaxVal );

            g.FillRectangle( WhiteBrush, x, MaxVal - Array[x], 1, MaxVal );
            g.FillRectangle( WhiteBrush, y, MaxVal - Array[y], 1, MaxVal );
        }

        private bool IsSorted() { //if every spot i is less than spot i + 1, the array is sorted
            for ( int i = 0; i < Array.Count() - 1; i++ ) {
                if ( Array[i] > Array[i + 1] ) return false;
            }
            return true;
        }
    }
}
