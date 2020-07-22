using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.Cells;
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
//using Syncfusion.UI.Xaml.Grid.Helpers;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection;
using Syncfusion.Data;
using Syncfusion.Data.Extensions;
using System.ComponentModel;
using System.Collections;
using System.Globalization;
using Syncfusion.UI.Xaml.Grid.Helpers;

namespace SfDataGridDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
            //Event subscription
            this.datagrid.RowValidated += sfdatagrid_RowValidated;
        }
        bool usetransition = false;

        //Event customization.
        private void sfdatagrid_RowValidated(object sender, RowValidatedEventArgs e)
        {

            var addNewRow = this.datagrid.RowGenerator.Items.FirstOrDefault(item => item.RowType == RowType.AddNewRow);
            if (datagrid.IsAddNewIndex(e.RowIndex))
            {

                datagrid.Dispatcher.BeginInvoke(new Action(() =>
                {
                    datagrid.SelectedItem = e.RowData;
                    //To move the current cell.
                    datagrid.ScrollInView(datagrid.SelectionController.CurrentCellManager.CurrentRowColumnIndex);
                    usetransition = true;
                    //To change the AddNewRow state.
                    VisualStateManager.GoToState(addNewRow.Element, "Normal", usetransition);
                    usetransition = false;

                }));
            }
        }
    }
}   

