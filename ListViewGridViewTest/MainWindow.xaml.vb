Imports System.ComponentModel

Class MainWindow

    Private mcolItems As List(Of revenue_forecast)
    Private mcolSalesReps As New List(Of GetContactRecordsResult)
    Private mcolDistricts As List(Of district)
    Private mcolCustomers As List(Of GetCompanyListResult)

    Private miNonConfigIndex As Integer = 7
    Private mcDefaultConfig As String

    Private Sub MainWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        If Not LoadLookupData() Then
            Exit Sub
        End If
        LoadData()
    End Sub

    Private Function LoadLookupData() As Boolean
        Try
            Dim db As New DBDataContext(My.Settings.VdisConnectionString)

            mcolSalesReps = db.GetContactRecords().ToList
            CType(Me.Resources("SalesRepIdToName"), ObjectIDConverter).ItemsSource = New List(Of Object)(mcolSalesReps)

            mcolDistricts = db.GetDistrictList().ToList
            CType(Me.Resources("DistIdToName"), ObjectIDConverter).ItemsSource = New List(Of Object)(mcolDistricts)

            mcolCustomers = db.GetCompanyList().ToList
            CType(Me.Resources("OilCompIdToName"), ObjectIDConverter).ItemsSource = New List(Of Object)(mcolCustomers)

            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Load Lookup Data")
        End Try
        Return False
    End Function

    Private Sub LoadData()
        Try
            mcolItems = New List(Of revenue_forecast)

            Dim ldStart As Date = New Date(2020, 1, 1)
            Dim ldEnd As Date = New Date(2020, 11, 30, 23, 59, 0)
            Dim liRecId As Integer = 0
            While ldStart < ldEnd
                For i As Integer = 1 To 10
                    liRecId += 1
                    Dim loNewItem As New revenue_forecast
                    With loNewItem
                        .psl = If(liRecId Mod 6 = 0, "OH",
                                  If(liRecId Mod 6 = 1, "CH",
                                    If(liRecId Mod 6 = 2, "PD",
                                        If(liRecId Mod 6 = 3, "BL",
                                            If(liRecId Mod 6 = 4, "GS", "IN")))))
                        .rec_id = liRecId
                        .disp_id = liRecId
                        .formatted_disp_id = .psl & Right("000000" & liRecId, 6)
                        .revenue_year = ldStart.Year
                        .revenue_month = ldStart.Month
                        .status = If(.psl = "IN", -1, liRecId Mod 7)
                        .status_desc = If(.status = -1, "Additional Activity",
                                            If(.status = 0, "Bid",
                                                If(.status = 1, "In Progress",
                                                    If(.status = 2, "Pending",
                                                        If(.status = 3, "Canceled",
                                                            If(.status = 4, "Completed",
                                                                If(.status = 5, "Incompleted", "Lost")))))))
                        .dist_id = 1234
                        .oilcomp_id = "5897                                    "
                        .well_name = "Tank " & liRecId
                        .service_list = "PERF, GAMMARAY, 90 DEGREE, URI, UBI"
                        .sales_rep_employee_id = "125315              "
                        .dispatch_offline_flag = CBool(liRecId Mod 2)
                        .critical_job_flag = CBool(liRecId Mod 3 > 0)
                        .job_approved_state = (liRecId Mod 3)
                        .revenue = 25000
                        .total_fso_count = (liRecId Mod 5)
                        .exported_fso_count = (liRecId Mod 3)
                        .total_quote_count = (liRecId Mod 6)
                        .exported_quote_count = (liRecId Mod 3)
                    End With

                    mcolItems.Add(loNewItem)
                Next

                ldStart = ldStart.AddDays(1)
            End While

            Dim loView As ICollectionView = CollectionViewSource.GetDefaultView(mcolItems)
            loView.GroupDescriptions.Add(New PropertyGroupDescription("status_desc"))
            lstItems.ItemsSource = loView
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Load Data")
        End Try
    End Sub

    Private Sub GridViewHeaderContextMenu_Click(sender As Object, e As RoutedEventArgs)
        MessageBox.Show("OK!")
    End Sub

    'Private Sub lstItems_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles lstItems.MouseDoubleClick
    '    If Not ListViewItemWasDoubleClicked(sender, e) Then
    '        Exit Sub
    '    End If
    '    MessageBox.Show(If(CType(lstItems.SelectedItem, revenue_forecast).disp_id, -1))
    'End Sub

    'Public Function ListViewItemWasDoubleClicked(sender As Object, e As MouseButtonEventArgs)
    '    ' Call this sub in a ListBox's MouseDoubleClick event handler to prevent actions from
    '    ' being performed when things like the Column Header or Scroll Bars are double-clicked.
    '    Dim loDepObj As DependencyObject = CType(e.OriginalSource, DependencyObject)
    '    Dim loListViewItem As ListViewItem = loDepObj.GetVisualParent(Of ListViewItem)
    '    If loListViewItem Is Nothing Then
    '        ' Something other than a loListBoxItemRow was double-clicked.
    '        Return False
    '    End If
    '    Dim loLst As ListView = CType(sender, ListView)
    '    loLst.SelectedItem = CType(loListViewItem, ListViewItem).DataContext
    '    Return True
    'End Function

    'Private Sub lstItems_Initialized(sender As Object, e As EventArgs) Handles lstItems.Initialized
    '    mcDefaultConfig = CType(lstItems.View, GridView).GetColumnConfigJson(True)
    '    My.Settings.DefaultConfig = mcDefaultConfig
    '    My.Settings.Save()
    '    Debug.WriteLine(mcDefaultConfig)
    'End Sub

    Private Sub btnSetDefaultConfig_Click(sender As Object, e As RoutedEventArgs) Handles btnSetDefaultConfig.Click
        CType(lstItems.View, GridView).SetColumnConfig(My.Settings.DefaultConfig)
    End Sub

    Private Sub btnSetUserConfig_Click(sender As Object, e As RoutedEventArgs) Handles btnSetUserConfig.Click
        CType(lstItems.View, GridView).SetColumnConfig(My.Settings.UserConfig)
    End Sub

    Private Sub btnReload_Click(sender As Object, e As RoutedEventArgs) Handles btnReload.Click
        LoadData()
    End Sub
End Class

