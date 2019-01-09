using System.Windows.Forms;

namespace JomaTimer
{
    public partial class AddTaskForm : Form
    {
        public string TaskExpression => textBox1.Text;

        public AddTaskForm()
        {
            InitializeComponent();
        }
    }
}
