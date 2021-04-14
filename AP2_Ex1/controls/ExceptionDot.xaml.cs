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
    /// Interaction logic for ExceptionDot.xaml
    /// </summary>
    public partial class ExceptionDot : UserControl
    {
        private int exceptionColumn;
        public ExceptionDot()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Exception Column property
        /// </summary>
        public int ExceptionColumn
        {
            get
            {
                return exceptionColumn;
            }
            set
            {
                this.exceptionColumn = value;
            }
        }
    }
}
