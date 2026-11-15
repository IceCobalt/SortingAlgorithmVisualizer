using System;
using System.Collections.Generic;
using System.Text;


namespace SortingAlgorithmVisualizer {
    class BubbleSort : ISorter {

        //Variables needed by the algorithm
        private int[] arr;
        private Graphics g;
        private int MaxVal;
        private Action<string> log = message => { };
        Brush WhiteBrush = new System.Drawing.SolidBrush( System.Drawing.Color.White );
        Brush BlackBrush = new System.Drawing.SolidBrush( System.Drawing.Color.Black );
        private int comparisons = 0;
        private int swaps = 0;

        //Constructor
        public BubbleSort( int[] arrIn, Graphics gIn, int MaxValIn, Action<string>? logIn = null ) {
            //using this.arr didnt properly pass the values in so I had to make the names different
            arr = arrIn;
            g = gIn;
            MaxVal = MaxValIn;
            if ( logIn != null )
                log = logIn;
        }

        public void NextStep() { 
            for (int i = 0; i < arr.Length - 1; i++ ) {
                comparisons++;
                if ( arr[i] > arr[i + 1] ) {
                    Swap( i, i + 1 );
                }
            }
        }

        private void Swap( int x, int y ) {
            //x ^= y ^= x ^= y; //GOATED XOR SWAP
            //okay xor swap is actually way slower than using a tmp variable
            int tmp = arr[x];
            arr[x] = arr[y];
            arr[y] = tmp;


            //remove old values
            //OPTIMIZE? make this one instance that is two pixels, instead of two instances that are one pixel each (for both?)
            DrawBar(x, arr[x]);
            DrawBar(y, arr[y]);
            swaps++;
        }

        private void DrawBar(int position, int height) {
            g.FillRectangle(BlackBrush, position, 0, 1, MaxVal);
            g.FillRectangle(WhiteBrush, position, MaxVal - arr[position], 1, height);
        }

        public bool IsSorted() { //if every spot i is less than spot i + 1, the arr is sorted
            for ( int i = 0; i < arr.Length - 1; i++ ) {
                if ( arr[i] > arr[i + 1] ) return false;
            }
            log.Invoke($"\nSorted!\nComparisons: {comparisons}\nSwaps: {swaps}");
            return true;
        }

        public void ReDraw() {
            for (int i = 0; i < arr.Length - 1; i++ ) {
                g.FillRectangle( new System.Drawing.SolidBrush( System.Drawing.Color.White ), i, MaxVal - arr[i], 1, MaxVal );
            }
        }
    }
}
