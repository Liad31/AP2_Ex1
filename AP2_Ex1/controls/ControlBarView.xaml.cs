using System.Windows.Controls;

namespace AP2_Ex1.controls
{
    public partial class ControlBarView : UserControl
    {
        private const int RWD_FWD = 5;
        ControlBarViewModel viewModel;
        public ControlBarView()
        {
            InitializeComponent();
            
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
        //TODO: organize controls in grid, implement all function, check if this works if it doesn't delete all and start from scratch
    }
}