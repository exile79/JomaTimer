using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace JomaTimer
{
    public partial class MainForm : Form
    {
        Timer _timer;
        List<Task> _tasks = new List<Task>();

        public MainForm()
        {
            InitializeComponent();

            _timer = new Timer
            {
                Interval = 1000
            };

            _timer.Tick += _timer_Tick;
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            // update all tasks
            foreach(var t in _tasks)
            {
                if (!t.Paused && t.Seconds > 0)
                {
                    t.Seconds -= 1;

                    if (t.Seconds == 0) // just finsihed
                    {
                        //string Toast = String.Format("<toast>" +
                        //                  "<visual>+" +
                        //                        "<binding template=\"ToastImageAndText04\">" +
                        //                            "<text id = \"1\" >Toast Test </text>+" +
                        //                            "<text id = \"2\" >{0}</text>+" +
                        //                            "<text id = \"2\" >{1}</text>+" +
                        //                        "</binding>+" +
                        //                  "</visual>+" +
                        //             "</toast>", "XAXAXA", DateTime.Now);

                        //var tileXml = new XmlDocument();
                        //tileXml.LoadXml(Toast);
                        //var toast = new ToastNotification(tileXml);
                        //ToastNotificationManager.CreateToastNotifier("JomaTimer").Show(toast);
                        MessageBox.Show("Task " + t.Name + " completed");
                    }
                }
            }

            UpdateListView();
            CheckTimerActiveTasks();
        }

        private void CheckTimerActiveTasks(bool checkToStart = false)
        {
            if (!_tasks.Any(t => !t.Paused && t.Seconds > 0))
            {
                Console.WriteLine("STOP TIMER");
                _timer.Stop();
            }
            else if (checkToStart)
            {
                Console.WriteLine("START TIMER");
                _timer.Start();
            }
        }

        private void addTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTask();
        }

        private void AddTask()
        {
            var d = new AddTaskForm();
            if (d.ShowDialog(taskListView) == DialogResult.OK)
            {
                Console.WriteLine("ADD TASK " + d.TaskExpression);
                Task task = TaskParser.Parse(d.TaskExpression);
                _tasks.Add(task);
                UpdateListView();
                CheckTimerActiveTasks(true);

                Console.WriteLine(task.ToString());
            }
        }

        private void UpdateListView()
        {
            //Console.WriteLine("UPDATE");
            taskListView.BeginUpdate();
            taskListView.Items.Clear();
            
            foreach (var t in _tasks)
            {
                taskListView.Items.Add(new ListViewItem(new[] { t.Name, t.Time.ToShortTimeString(), t.Remaining.ToString() }));
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

        private void listView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(taskListView, e.Location);
            }
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D && e.Control && e.Shift)
            {
                AddTask();
            }
        }
    }
}
