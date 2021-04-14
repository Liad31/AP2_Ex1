using System;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Windows.Shapes;
using System.Windows;
using System.Drawing;

namespace AP2_Ex1.controls
{
    public partial class ControlBarView : System.Windows.Controls.UserControl
    {
        private const int RWD_FWD = 5; //how many second does rewind and forward should move
        ControlBarViewModel viewModel;
        private List<ExceptionDot> exceptions;
        private List<int> exceptionsValues; 

        public ControlBarView()
        {
            InitializeComponent();

            //So cmb have defualt value, without invoking selction changed
            cmbSpeedMultiplier.SelectedIndex = 3;
            cmbSpeedMultiplier.SelectionChanged += ComboBox_SelectionChanged;

            StartPauseButton.Content = "S";

            exceptions = new List<ExceptionDot>();
            exceptionsValues = new List<int>();
        }

        /// <summary>
        /// View Model property
        /// </summary>
        public ControlBarViewModel ViewModel
        {
            set
            {
                this.viewModel = value;
                this.DataContext = viewModel;
            }
        }

        public List<int> Exceptions
        {
            set
            {
                this.exceptionsValues = value;
            }
        }

        /// <summary>
        /// pauses/resumed the video. Called when Pause/Start button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SPButtonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            viewModel.VM_IsPaused = !viewModel.VM_IsPaused;
            StartPauseButton.Content= viewModel.VM_IsPaused ? "S" : "P";
        }

        /// <summary>
        /// Rewinds the video. Called when rwd button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rwdClick(object sender, System.Windows.RoutedEventArgs e)
        {
            int lineToMove = RWD_FWD * viewModel.VM_LPS; //number of line we will move
            if (viewModel.VM_CurrentLine < lineToMove)
            {
                viewModel.VM_CurrentLine = 0;
            }
            else
            {
                viewModel.VM_CurrentLine -= lineToMove;
            }
        }

        /// <summary>
        /// Forwards the video. Called when fwd button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fwdClick(object sender, System.Windows.RoutedEventArgs e)
        {
            int lineToMove = RWD_FWD * viewModel.VM_LPS; //number of lined we will move
            if (viewModel.VM_CurrentLine > viewModel.VM_LineCount - lineToMove)
            {
                viewModel.VM_CurrentLine = viewModel.VM_LineCount;
            }
            else
            {
                viewModel.VM_CurrentLine += lineToMove;
            }
        }

        /// <summary>
        /// Handled combo box selction changed. Called when user wants to change video spped multiplier.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cmbSpeedMultiplier.SelectedIndex)
            {
                case 0:
                    viewModel.VM_SpeedMultiplier = 2;
                    break;
                case 1:
                    viewModel.VM_SpeedMultiplier = 1.5;
                    break;
                case 2:
                    viewModel.VM_SpeedMultiplier = 1.25;
                    break;
                case 3:
                    viewModel.VM_SpeedMultiplier = 1;
                    break;
                case 4:
                    viewModel.VM_SpeedMultiplier = 0.5;
                    break;
                case 5:
                    viewModel.VM_SpeedMultiplier = 0.25;
                    break;
            }
        }

        private void Button_Click_Open(object sender, System.Windows.RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "Dll files (*.dll)| *.dll";
            Nullable<bool> result = (dlg.ShowDialog() == DialogResult.OK);
            if (result == true)
            {
                String dllPath = dlg.FileName; ;
                //TODO: notify view model who will notify the model
            }
        }
       

        public void setExceptions()
        {
            foreach(int exceptionColumn in this.exceptionsValues)
            {
                ExceptionDot exception = new ExceptionDot();
                this.exceptions.Add(exception);
                exception.ExceptionColumn = exceptionColumn;
                exception.dot.Margin = new Thickness((((double)exceptionColumn / viewModel.VM_LineCount) * 490), 0, 495 - (((double)exceptionColumn / viewModel.VM_LineCount) * 490), 0);
                exception.dot.Click += (sender, EventArgs) => { Dot_Click(sender, exceptionColumn); }; ;
                grid.Children.Add(exception);
                Grid.SetRow(exception, 1);
            }
        }

        public void removeExceptions()
        {
            foreach(ExceptionDot exception in this.exceptions)
            {
                grid.Children.Remove(exception);
                this.exceptions.Remove(exception);
            }
        }

        private void Dot_Click(object sender, int exceptionColumn)
        {
            Progress.Value = exceptionColumn;
        }
    }
}