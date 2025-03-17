using System.Windows;
using System.Windows.Controls;

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

            dataGridItems.Add(new GridData(true, "test1", false));
            dataGridItems.Add(new GridData(false, "test2", false));
            dataGridItems.Add(new GridData(true, "test3", false));
            dataGridItems.Add(new GridData(false, "test4", false));
            dataGridItems.Add(new GridData(true, "test5", false));

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
            CheckBoxEnable(true);
        }

        private void CheckBox_EnableUnChecked(object sender, RoutedEventArgs e)
        {
            CheckBoxEnable(false);
        }

        private void CheckBoxEnable(bool enable)
        {
            int rowNum = sampleGrid.ItemContainerGenerator.Items.Count;

            for (int i = 0; i < rowNum; i++)
            {
                var row = (DataGridRow)sampleGrid.ItemContainerGenerator.ContainerFromIndex(i);
                var rowData = row.DataContext as GridData;
                if (rowData != null && rowData.select == true)
                {
                    rowData.enable = enable;
                }
            }
        }
    }
}