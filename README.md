# How to move selection to record when add the new row in SfDataGrid contains empty record in WPF DataGrid (SfDataGrid)?

## About the sample

This sample illustrates that how to move selection to record when add the new row in SfDataGrid contains empty record in [WPF DataGrid](https://www.syncfusion.com/wpf-ui-controls/datagrid) (SfDataGrid).

The current cell will remain in the AddNewRow after adding a record when the grid has no records in [WPF DataGrid](https://www.syncfusion.com/wpf-ui-controls/datagrid) (SfDataGrid). But, you can move the current cell to the newly added record by moving the current cell in [SfDataGrid.RowValidated](https://help.syncfusion.com/cr/cref_files/wpf/Syncfusion.SfGrid.WPF~Syncfusion.UI.Xaml.Grid.SfDataGrid~RowValidated_EV.html) event using the ScrollInView() method. You can also change the AddNewRow state to the normal using [VisualStateManager.GoToState()](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.visualstatemanager.gotostate?view=winrt-19041) method.

```C#
//Event subscription
this.datagrid.RowValidated += sfdatagrid_RowValidated;

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
```
![CurrentCellAddNewRow](CurrentCellAddNewRow.png)

## Requirements to run the demo
Visual Studio 2015 and above versions


