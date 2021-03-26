using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2_Ex1
{
    public class GraphsPanelViewModel
    {
        GraphsModel model;
        public GraphsPanelViewModel(GraphsModel model) {
            this.model = model;
        } 
        public LinkedList<string> Properties
        {
            get
            {
                return model.database.properties;
            }
        }

    }
}
