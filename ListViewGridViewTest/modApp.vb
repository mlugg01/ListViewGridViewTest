Module modApp
    Function StringsAreEqual(str1 As String, str2 As String) As Boolean
        Return Trim(str1 & "").ToUpper = Trim(str2 & "").ToUpper
    End Function


    <System.Runtime.CompilerServices.Extension>
    Public Function GetVisualParent(Of T As Visual)(child As DependencyObject) As T
        Do While (child IsNot Nothing) AndAlso Not (TypeOf child Is T)
            child = VisualTreeHelper.GetParent(child)
        Loop
        Return TryCast(child, T)
    End Function

    <System.Runtime.CompilerServices.Extension>
    Function GetColumnConfigJson(gv As GridView, defaultConfig As Boolean) As String
        Try
            If gv Is Nothing Then
                Return Nothing
            End If
            Dim lcolConfigItems As New List(Of GridColumnConfigItem)
            Dim loColumn As GridViewColumn
            For i As Integer = 0 To gv.Columns.Count - 1
                loColumn = gv.Columns(i)
                lcolConfigItems.Add(loColumn.DataGridConfigItemFromColumn(defaultConfig, i))
            Next
            Return Newtonsoft.Json.JsonConvert.SerializeObject(lcolConfigItems)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "GetColumnConfigJson")

        End Try
        Return Nothing
    End Function

    <Runtime.CompilerServices.Extension>
    Sub SetColumnConfig(gv As GridView, configJson As String)
        Try
            If String.IsNullOrWhiteSpace(configJson) Then
                Exit Try
            End If

            Dim lcolConfigItems = Newtonsoft.Json.JsonConvert.DeserializeObject(Of List(Of GridColumnConfigItem))(configJson)
            Dim loConfigItem As GridColumnConfigItem

            ' Remove saved config items which do not correspond to columns in the gridview (IE, they are for columns that have been removed form the gridview).
            For i As Integer = lcolConfigItems.Count - 1 To 0 Step -1
                loConfigItem = lcolConfigItems(i)
                If Not gv.Columns.Any(Function(c) ListViewConfig.GetColumnName(c) = loConfigItem.ColumnName) Then
                    lcolConfigItems.RemoveAt(i)
                End If
            Next

            ' Add a config item for any new gridview columns, otherwise set the DefaultDisplayIndex according to the column design.
            Dim loColumn As GridViewColumn
            For i As Integer = 0 To gv.Columns.Count - 1
                loColumn = gv.Columns(i)
                loConfigItem = lcolConfigItems.FirstOrDefault(Function(c) c.ColumnName = ListViewConfig.GetColumnName(loColumn))
                If loConfigItem Is Nothing Then
                    lcolConfigItems.Add(loColumn.DataGridConfigItemFromColumn(True, i))
                Else
                    loConfigItem.DefaultDisplayIndex = ListViewConfig.GetDefaultDisplayIndex(loColumn)
                End If
            Next

            ' Reset the config items' DisplayIndex in case the column set has changed so the indexes are consecutive.
            Dim liIndex As Integer = 0
            For Each loConfigItem In lcolConfigItems.OrderBy(Function(i) i.DisplayIndex).ThenBy(Function(i) i.DefaultDisplayIndex)
                loConfigItem.DisplayIndex = liIndex
                liIndex += 1
            Next

            For Each loConfigItem In lcolConfigItems.OrderBy(Function(i) i.DisplayIndex)
                For liIndex = 0 To gv.Columns.Count - 1
                    loColumn = gv.Columns(liIndex)
                    If ListViewConfig.GetColumnName(loColumn) = loConfigItem.ColumnName Then
                        If liIndex <> loConfigItem.DisplayIndex Then
                            gv.Columns.Move(liIndex, loConfigItem.DisplayIndex)
                        End If
                        loColumn.Width = loConfigItem.GetWidth()
                        Exit For
                    End If
                Next
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SetColumnConfig")
        End Try
    End Sub

    <System.Runtime.CompilerServices.Extension>
    Function DataGridConfigItemFromColumn(c As GridViewColumn, defaultConfig As Boolean, displayIndex As Integer) As GridColumnConfigItem
        Dim loConfigItem As GridColumnConfigItem
        loConfigItem = New GridColumnConfigItem
        loConfigItem.ColumnName = ListViewConfig.GetColumnName(c)

        loConfigItem.ColumnHeader = c.HeaderText()
        If TypeOf c.Header Is TextBlock Then
            loConfigItem.ColumnHeader = CType(c.Header, TextBlock).Text
        Else
            loConfigItem.ColumnHeader = c.Header
        End If

        loConfigItem.DisplayIndex = displayIndex
        If defaultConfig Then
            loConfigItem.DefaultDisplayIndex = displayIndex
            ListViewConfig.SetDefaultDisplayIndex(c, displayIndex)
        Else
            loConfigItem.DefaultDisplayIndex = ListViewConfig.GetDefaultDisplayIndex(c)
        End If

        loConfigItem.SetIsHidden(c.Width)
        If defaultConfig Then
            loConfigItem.DefaultWidth = c.Width
        End If
        loConfigItem.CanUserReorder = ListViewConfig.GetCanUserReorder(c)
        loConfigItem.CanUserSetVisibility = ListViewConfig.GetCanUserSetVisibility(c)
        Return loConfigItem
    End Function

    <System.Runtime.CompilerServices.Extension>
    Function HeaderText(c As GridViewColumn) As String
        If TypeOf c.Header Is TextBlock Then
            Return CType(c.Header, TextBlock).Text
        Else
            Return c.Header
        End If
    End Function

End Module
