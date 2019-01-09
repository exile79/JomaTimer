using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace JomaTimer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        List<Task> _tasks = new List<Task>();

        private void addTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var d = new AddTaskForm();
            if (d.ShowDialog(taskListView) == DialogResult.OK)
            {
                Console.WriteLine("ADD TASK " + d.TaskExpression);
                Task task = TaskParser.Parse(d.TaskExpression);
                _tasks.Add(task);
                UpdateListView();
            }
        }

        private void UpdateListView()
        {
            taskListView.BeginUpdate();
            //taskListView.Clear();
            foreach(var t in _tasks)
            {
                taskListView.Items.Add(new ListViewItem(new[] { t.Name, t.Time.ToShortTimeString() }));
            }

            taskListView.EndUpdate();
            taskListView.Refresh();
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
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(taskListView, e.Location);
            }
        }
    }
}
