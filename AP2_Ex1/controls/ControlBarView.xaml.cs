using System;
using System.Windows.Controls;
using System.Windows.Forms;

namespace AP2_Ex1.controls
{
    public partial class ControlBarView : System.Windows.Controls.UserControl
    {
        private const int RWD_FWD = 5;
        ControlBarViewModel viewModel;
        private bool isMouseDownInProgress;
        public ControlBarView()
        {
            InitializeComponent();

            //So cmb have defualt value, without invoking selction changed
            cmbSpeedMultiplier.SelectedIndex = 3;
            cmbSpeedMultiplier.SelectionChanged += ComboBox_SelectionChanged;
            StartPauseButton.Content = "S";
        }

        public ControlBarViewModel ViewModel
        {
            set
            {
                this.viewModel = value;
                this.DataContext = viewModel;
            }
        }

        private void SPButtonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            viewModel.VM_IsPaused = !viewModel.VM_IsPaused;
            StartPauseButton.Content= viewModel.VM_IsPaused ? "S" : "P";
        }

        private void rwdClick(object sender, System.Windows.RoutedEventArgs e)
        {
            int lineToMove = RWD_FWD * viewModel.VM_LPS;
            if (viewModel.VM_CurrentLine < lineToMove)
            {
                viewModel.VM_CurrentLine = 0;
            }
            else
            {
                viewModel.VM_CurrentLine -= lineToMove;
            }
        }

        private void fwdClick(object sender, System.Windows.RoutedEventArgs e)
        {
            int lineToMove = RWD_FWD * viewModel.VM_LPS;
            if (viewModel.VM_CurrentLine > viewModel.VM_LineCount - lineToMove)
            {
                viewModel.VM_CurrentLine = viewModel.VM_LineCount;
            }
            else
            {
                viewModel.VM_CurrentLine += lineToMove;
            }
        }

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

        private void Progress_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            Progress.Value = e.NewValue;
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

    }
}