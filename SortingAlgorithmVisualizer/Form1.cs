namespace SortingAlgorithmVisualizer {
    public partial class Form1 : Form {

        int[] Array;
        Graphics g;

        public Form1() {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click( object sender, EventArgs e ) {
            this.Close();
        }

        private void buttonReset_Click( object sender, EventArgs e ) { // curently creates a whole new array, old one is left in memory (will eventually use up all memory
            g = panel1.CreateGraphics();
            int NumEntries = panel1.Width;
            int MaxVal = panel1.Height;
            Array = new int[NumEntries];
            g.FillRectangle( new System.Drawing.SolidBrush( System.Drawing.Color.Black ), 0, 0, NumEntries, MaxVal );
            Random rand = new Random();
            for ( int i = 0; i < NumEntries; i++ ) {
                Array[i] = rand.Next( 0, MaxVal );
            }
            for ( int i = 0; i < NumEntries; i++ ) {
                g.FillRectangle( new System.Drawing.SolidBrush( System.Drawing.Color.White ), i, MaxVal - Array[i], 1, MaxVal );
            }
        }

        private void buttonStart_Click( object sender, EventArgs e ) {
            ISorter s = new BubbleSort();
            s.Sort( Array, g, panel1.Height );
        }
    }
}
