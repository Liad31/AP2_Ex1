using System;
using System.Windows.Controls;

namespace AP2_Ex1.controls
{
    public partial class ControlBarView : UserControl
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


        }

        public IModel Model
        {
            set
            {
                this.viewModel = new ControlBarViewModel(value);
                this.DataContext = viewModel;
            }
        }

        private void SPButtonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            viewModel.VM_IsPaused = !viewModel.VM_IsPaused;
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

        //TODO: organize controls in grid, implement all function, check if this works if it doesn't delete all and start from scratch
    }
}