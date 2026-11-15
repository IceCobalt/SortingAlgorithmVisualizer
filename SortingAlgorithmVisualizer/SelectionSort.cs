using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgorithmVisualizer {
     class SelectionSort : ISorter{

        //Variables needed by the algorithm
        private int[] arr;
        private Graphics g;
        private int MaxVal;
        private Action<string> log = message => { };
        Brush WhiteBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
        Brush BlackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
        private int comparisons = 0;
        private int swaps = 0;

        //Constructor
        public SelectionSort( int[] arrIn, Graphics gIn, int MaxValIn, Action<string>? logIn = null ) {
            //using this.arr didnt properly pass the values in so I had to make the names different
            arr = arrIn;
            g = gIn;
            MaxVal = MaxValIn;
            if ( logIn != null )
                log = logIn;
        }
        private int i = 0;
        public void NextStep() {
            if ( i >= arr.Length - 1 )
                return;

            // Assume current position is minimum
            int min = i;

            // Find actual minimum
            for ( int j = i + 1; j < arr.Length; j++ ) {
                comparisons++;
                if ( arr[j] < arr[min] )
                    min = j;
            }

            // Swap minimum into correct position
            if ( min != i ) {
                int tmp = arr[i];
                arr[i] = arr[min];
                arr[min] = tmp;

                DrawBar(i, arr[i]);
                DrawBar(min, arr[min]);

                swaps++;
            }
            i++;
        }
        private void DrawBar(int position, int height) {
            g.FillRectangle(BlackBrush, position, 0, 1, MaxVal);
            g.FillRectangle(WhiteBrush, position, MaxVal - arr[position], 1, height);
            //log?.Invoke($"Drew Rectangle at {position} with height {height} and max value {MaxVal}");
        }

        public bool IsSorted() { //if every spot i is less than spot i + 1, the arr is sorted
            for ( int i = 0; i < arr.Length - 1; i++ ) {
                if ( arr[i] > arr[i + 1] ) return false;
            }
            log.Invoke($"\nSorted!\nComparisons: {comparisons}\nSwaps: {swaps}");
            return true;
        }

        public void ReDraw() {
            for ( int i = 0; i < arr.Length - 1; i++ ) {
                g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.White), i, MaxVal - arr[i], 1, MaxVal);
            }
        }
    }
}
