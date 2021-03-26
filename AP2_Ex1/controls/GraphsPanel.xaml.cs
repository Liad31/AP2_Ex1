using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AP2_Ex1.controls
{
    /// <summary>
    /// Interaction logic for Graphs.xaml
    /// </summary>
    public partial class GraphsPanel : UserControl
    {
        GraphsPanelViewModel vm_graphs;
        public GraphsPanel(GraphsPanelViewModel vm_graphs, IDatabase database)
        {
            InitializeComponent();
            GraphsModel model = new GraphsModel(database);
            this.vm_graphs = vm_graphs;
        }
    }
}
