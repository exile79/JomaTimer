using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JomaTimer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void addTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteFinishedTasksToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listView1_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void listView1_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Right)
            {
                contextMenuStrip1.Show(taskListView, e.Location);
            }
        }
    }
}
