using System.ComponentModel;
using System.Diagnostics;

namespace SortingAlgorithmVisualizer {
    public partial class Form1 : Form {

        int[]? arr;
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
            if ( output.InvokeRequired ) {
                output.Invoke(new Action(() => outputLine(output, text)));
                return;
            }
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
            if ( arr == null ) buttonReset_Click(null, null);

            bgw = new BackgroundWorker(); //do the work in a background thread
            bgw.WorkerSupportsCancellation = true; //make sure it can cancel
            bgw.DoWork += new DoWorkEventHandler(bgw_Task); //add event handler when it runs
            bgw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgw_Completed);
            bgw.RunWorkerAsync(argument: comboBox1.SelectedItem);

            timer.Restart();


            buttonStart.Enabled = false;
            comboBox1.Enabled = false;
            buttonReset.Enabled = false;

        }

        private void buttonPause_Click( object sender, EventArgs e ) {
            if (!Paused) {
                bgw.CancelAsync();
                Paused = true;
                timer.Stop();
                buttonReset.Enabled = true;
            } else {
                if (bgw.IsBusy) return;
                //int NumEntries = panel1.Width;
                //int MaxVal = panel1.Height;
                int NumEntries = arr.Length; //prevents out of bounds arr
                int MaxVal = arr.Max();
                Paused = false;

                for (int i = 0; i < NumEntries; i++ ) {
                    g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Black), i, 0, 1, MaxVal);
                    g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.White), i, MaxVal - arr[i], 1, MaxVal);
                }
                bgw.RunWorkerAsync(argument: comboBox1.SelectedItem);
                buttonReset.Enabled = false;
                timer.Start();
            }
        }

        private void buttonReset_Click( object? sender, EventArgs? e ) { // curently creates a whole new arr, old one is left in memory (will eventually use up all memory
            g = panel1.CreateGraphics();
            int NumEntries = panel1.Width;
            int MaxVal = panel1.Height;
            arr = new int[NumEntries];
            g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Black), 0, 0, NumEntries, MaxVal);
            int overflow = 1;
            for ( int i = 0; i < NumEntries; i++ ) {
                //when drawing bars, make sure the value stays in bounds
                //if window is wider than it is tall, we run out of values since we are setting the max value
                //to the height of the window. so we just generate values until we hit the max value then start over
                if ( i < (MaxVal * overflow) )
                    arr[i] = i - ((overflow - 1) * MaxVal);
                else {
                    arr[i] = i - ( MaxVal * overflow );
                    overflow++;
                }
            }
            if ( shuffleToggle.Checked ) //shuffle order
                Random.Shared.Shuffle(arr);

            for ( int i = 0; i < NumEntries; i++ ) { //draw rectangles
                g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.White), i, MaxVal - arr[i], 1, arr[i]);
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
                var outputPerms = giveClassOutput;
                ISorter sort = ( ISorter )constructors[0].Invoke(new object[] { arr, g, panel1.Height, outputPerms });
                while ( !sort.IsSorted() && ( !bgw.CancellationPending ) ) {
                    sort.NextStep();
                }
            } catch ( Exception ex ) {
                outputLine(output1, ex.Message);
            }
        }

        private void bgw_Completed( object? sender, RunWorkerCompletedEventArgs e ) {
            if ( !Paused ) {//dont run it bgw ended via pause 
                timer.Stop();
                outputLine(output1, $"Time elapsed: {timer.Elapsed.TotalMilliseconds:f0} ms");
                comboBox1.Enabled = true;
                buttonReset.Enabled = true;
            }
        }

        #endregion

    }
}
