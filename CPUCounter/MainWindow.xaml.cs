using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Threading;

namespace CPUCounter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly PerformanceCounter performanceCPUCounter = new PerformanceCounter("Processor Information", "% Processor Time", "_Total", true);
        private readonly PerformanceCounter performanceMemoryCounter = new PerformanceCounter("Memory", "Available MBytes", true);
        private readonly PerformanceCounter performanceSystemCounter = new PerformanceCounter("System", "System Up Time", true);
        public MainWindow()
        {
            InitializeComponent();

            var timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Proc.Value = (int)performanceCPUCounter.NextValue();
            ProcLab.Content = Proc.Value + " " + "%";
            AvaMBytes.Content = (int)performanceMemoryCounter.NextValue() + " " + "MB";
            SysTimeUp.Content = (int)performanceSystemCounter.NextValue() /60 /60 + " " + "hours";
        }
    }
}
