# How to Move Selection to Record when Add the New Row Contains Empty Record in WPF DataGrid?

This sample illustrates that how to move selection to record when add the new row contains empty record in [WPF DataGrid](https://www.syncfusion.com/wpf-controls/datagrid) (SfDataGrid).

The current cell will remain in the AddNewRow after adding a record when the grid has no records in `DataGrid`. But, you can move the current cell to the newly added record by moving the current cell in [SfDataGrid.RowValidated](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.SfDataGrid.html#Syncfusion_UI_Xaml_Grid_SfDataGrid_RowValidated) event using the ScrollInView() method. You can also change the AddNewRow state to the normal using [VisualStateManager.GoToState()](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.visualstatemanager.gotostate?view=winrt-19041) method.

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
![DataGrid with new row added](RowAddedUsingAddNewRow.png)
