using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<CheckBox> CheckBoxes = new List<CheckBox>();

        public MainWindow()
        {
            InitializeComponent();

            List<GridData> dataGridItems = new List<GridData>();

            for (int i=0; i<1000; i++)
            {
                dataGridItems.Add(new GridData(i % 2 == 0, "test"+i.ToString(), false));
            }

            sampleGrid.ItemsSource = dataGridItems;
        }

        private void DataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            foreach (var add in e.AddedCells)
            {
                var data = add.Item as GridData;
                if (data != null)
                {
                    data.select = true;
                }
            }
            foreach (var add in e.RemovedCells)
            {
                var data = add.Item as GridData;
                if (data != null)
                {
                    data.select = false;
                }
            }
        }

        private void CheckBox_EnableChecked(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox checkBox && checkBox.IsKeyboardFocusWithin)
            {
                CheckBoxEnable(sender, e, true);
            }
        }

        private void CheckBox_EnableUnChecked(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox checkBox && checkBox.IsKeyboardFocusWithin)
            {
                CheckBoxEnable(sender, e, false);
            }
        }

        private void CheckBoxEnable(object sender, RoutedEventArgs e, bool enable)
        {
            int rowNum = sampleGrid.ItemContainerGenerator.Items.Count;

            for (int i = 0; i < rowNum; i++)
            {
                var row = (DataGridRow)sampleGrid.ItemContainerGenerator.ContainerFromIndex(i);
                if (row != null)
                {
                    var rowData = row.DataContext as GridData;
                    if (rowData != null && rowData.select == true)
                    {
                        rowData.enable = enable;
                    }
                }
            }
        }
    }
}