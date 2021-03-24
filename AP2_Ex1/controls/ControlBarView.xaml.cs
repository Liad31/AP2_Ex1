using System.Windows.Controls;

namespace AP2_Ex1.controls
{
    public partial class ControlBarView : UserControl
    {
        ControlBarViewModel viewModel;
        public ControlBarView(IModel model)
        {
            InitializeComponent();
            this.viewModel = new ControlBarViewModel(model);
            this.DataContext = viewModel;
        }
        //TODO: organize controls in grid, implement all function, check if this works if it doesn't delete all and start from scratch
    }
}