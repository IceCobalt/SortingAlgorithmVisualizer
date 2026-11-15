using System.ComponentModel;
using System.Diagnostics;

namespace SortingAlgorithmVisualizer {
    public partial class Form1 : Form {

        int[]? Array;
        Graphics? g;
        BackgroundWorker? bgw;
        bool Paused = false;

        private Stopwatch timer = new Stopwatch();

        public Form1() {
            InitializeComponent();
            PopulateDropdown();
        }

        private void PopulateDropdown() {
            // in the current app domain, select assemblies of the ISorter type that aren't interfaces or abstract
            List<string> ClassList = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(x => typeof(ISorter).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(x => x.Name).ToList();
            ClassList.Sort();
            foreach ( string entry in ClassList ) {
                comboBox1.Items.Add(entry);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void outputLine( RichTextBox output, string text ) { //so that my rich text box doesnt have
            if ( output.TextLength > 0 ) {                           //weird newline issues and uses
                output.AppendText(Environment.NewLine);              //the whole textbox
            }
            output.AppendText(text);
            output1.ScrollToCaret();
        }

        private void giveClassOutput( string message ) { // for other classes to send output
            outputLine(output1, message + Environment.NewLine);
        }

        private void exitToolStripMenuItem_Click( object sender, EventArgs e ) {
            this.Close();
        }

        private void buttonStart_Click( object sender, EventArgs e ) {
            if ( Array == null ) buttonReset_Click(null, null);

            bgw = new BackgroundWorker(); //do the work in a background thread
            bgw.WorkerSupportsCancellation = true; //make sure it can cancel
            bgw.DoWork += new DoWorkEventHandler(bgw_Task); //add event handler when it runs
            bgw.RunWorkerAsync(argument: comboBox1.SelectedItem);

            timer.Restart();


            buttonStart.Enabled = false;
            comboBox1.Enabled = false;

        }

        private void buttonPause_Click( object sender, EventArgs e ) {
            if (!Paused) {
                bgw.CancelAsync();
                Paused = true;
                timer.Stop();
            } else {
                if (bgw.IsBusy) return;
                //int NumEntries = panel1.Width;
                //int MaxVal = panel1.Height;
                int NumEntries = Array.Length; //prevents out of bounds array
                int MaxVal = Array.Max();

                Paused = false;

                for (int i = 0; i < NumEntries; i++ ) {
                    g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Black), i, 0, 1, MaxVal);
                    g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.White), i, MaxVal - Array[i], 1, MaxVal);
                }
                bgw.RunWorkerAsync(argument: comboBox1.SelectedItem);
                timer.Start();
            }
        }

        private void buttonReset_Click( object? sender, EventArgs? e ) { // curently creates a whole new array, old one is left in memory (will eventually use up all memory
            g = panel1.CreateGraphics();
            int NumEntries = panel1.Width;
            int MaxVal = panel1.Height;
            Array = new int[NumEntries];
            g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Black), 0, 0, NumEntries, MaxVal);

            for ( int i = 0; i < NumEntries; i++ ) {
                int overflow = 1;
                if ( i < MaxVal )
                    Array[i] = i;
                else {
                    Array[i] = i - ( overflow * MaxVal );
                }
                if ( i > ( MaxVal * overflow ) )
                    overflow++;
            }
            if (shuffleToggle.Checked) {
                Random.Shared.Shuffle(Array);
            }
            for ( int i = 0; i < NumEntries; i++ ) {
                g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.White), i, MaxVal - Array[i], 1, Array[i]);
            }

            buttonStart.Enabled = true;
        }
        #region BackgroundStuff
        //group all the background stuff here
        public void bgw_Task( object sender, System.ComponentModel.DoWorkEventArgs e ) { //what caused the event, and the arguments
            BackgroundWorker bw = sender as BackgroundWorker;
            string SortEngineName = (string)e.Argument;
            Type type = Type.GetType("SortingAlgorithmVisualizer." + SortEngineName);
            var constructors = type.GetConstructors();
            try {
                //make a new object that could be any specific type of sorting algorithm. We dont know it in advance
                ISorter sort = ( ISorter )constructors[0].Invoke(new object[] { Array, g, panel1.Height, giveClassOutput });
                while ( !sort.IsSorted() && ( !bgw.CancellationPending ) ) {
                    sort.NextStep();

                }
            } catch ( Exception ex ) {
                outputLine(output1, ex.Message);
            }
            timer.Stop();
            outputLine(output1, $"Time ellapsed: {timer.Elapsed.TotalMilliseconds:f4} ms");
        }

        #endregion

    }
}
