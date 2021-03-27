using System.Windows.Controls;

namespace AP2_Ex1.controls
{
    public partial class ControlBarView : UserControl
    {
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
            }
        }
        //TODO: organize controls in grid, implement all function, check if this works if it doesn't delete all and start from scratch
    }
}