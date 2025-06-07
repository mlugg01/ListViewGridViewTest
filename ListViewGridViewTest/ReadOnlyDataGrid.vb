Public Class ReadOnlyDataGrid
    Inherits ListView

    Private mcDefaultConfig As String

    Protected Overrides Sub OnMouseDoubleClick(e As MouseButtonEventArgs)
        If Not ListViewItemWasDoubleClicked(Me, e) Then
            Exit Sub
        End If
        MessageBox.Show("You click me?")
    End Sub

    Private Function ListViewItemWasDoubleClicked(sender As Object, e As MouseButtonEventArgs)
        ' Call this sub in a ListBox's MouseDoubleClick event handler to prevent actions from
        ' being performed when things like the Column Header or Scroll Bars are double-clicked.
        Dim loDepObj As DependencyObject = CType(e.OriginalSource, DependencyObject)
        Dim loListViewItem As ListViewItem = loDepObj.GetVisualParent(Of ListViewItem)
        If loListViewItem Is Nothing Then
            ' Something other than a loListBoxItemRow was double-clicked.
            Return False
        End If
        Dim loLst As ListView = CType(sender, ListView)
        loLst.SelectedItem = CType(loListViewItem, ListViewItem).DataContext
        Return True
    End Function

    Protected Overrides Sub OnInitialized(e As EventArgs)
        Try
            If Me.View Is Nothing Then
                Exit Try
            End If
            mcDefaultConfig = CType(Me.View, GridView).GetColumnConfigJson(True)
            My.Settings.DefaultConfig = mcDefaultConfig
            My.Settings.Save()
            Debug.WriteLine(mcDefaultConfig)
        Catch ex As Exception

        End Try
    End Sub



End Class
