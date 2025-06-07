Public Class ListViewConfig

    Public Shared ReadOnly ColumnNameProperty As DependencyProperty = DependencyProperty.RegisterAttached("ColumnName", GetType(String), GetType(ListViewConfig), New PropertyMetadata(""))
    Public Shared Sub SetColumnName(column As GridViewColumn, value As String)
        column.SetValue(ColumnNameProperty, value)
    End Sub

    Public Shared Function GetColumnName(column As GridViewColumn) As String
        Return column.GetValue(ColumnNameProperty)
    End Function

    Public Shared ReadOnly CanUserSetVisibilityProperty As DependencyProperty = DependencyProperty.RegisterAttached("CanUserSetVisibility", GetType(Boolean), GetType(ListViewConfig), New PropertyMetadata(False))
    Public Shared Sub SetCanUserSetVisibility(column As GridViewColumn, value As Boolean)
        column.SetValue(CanUserSetVisibilityProperty, value)
    End Sub

    Public Shared Function GetCanUserSetVisibility(column As GridViewColumn) As Boolean
        Return column.GetValue(CanUserSetVisibilityProperty)
    End Function

    Public Shared ReadOnly CanUserReorderProperty As DependencyProperty = DependencyProperty.RegisterAttached("CanUserReorder", GetType(Boolean), GetType(ListViewConfig), New PropertyMetadata(False))
    Public Shared Sub SetCanUserReorder(column As GridViewColumn, value As Boolean)
        column.SetValue(CanUserReorderProperty, value)
    End Sub

    Public Shared Function GetCanUserReorder(column As GridViewColumn) As Boolean
        Return column.GetValue(CanUserReorderProperty)
    End Function

    Public Shared ReadOnly DefaultDisplayIndexProperty As DependencyProperty = DependencyProperty.RegisterAttached("DefaultDisplayIndex", GetType(Integer), GetType(ListViewConfig), New PropertyMetadata(0))
    Public Shared Sub SetDefaultDisplayIndex(column As GridViewColumn, value As Integer)
        column.SetValue(DefaultDisplayIndexProperty, value)
    End Sub

    Public Shared Function GetDefaultDisplayIndex(column As GridViewColumn) As Integer
        Return column.GetValue(DefaultDisplayIndexProperty)
    End Function

    Public Shared ReadOnly DefaultDisplayWidthProperty As DependencyProperty = DependencyProperty.RegisterAttached("DefaultDisplayWidth", GetType(Double?), GetType(ListViewConfig), New PropertyMetadata(Nothing))
    Public Shared Sub SetDefaultDisplayWidth(column As GridViewColumn, value As Double?)
        column.SetValue(DefaultDisplayWidthProperty, value)
    End Sub

    Public Shared Function GetDefaultDisplayWidth(column As GridViewColumn) As Double?
        Return column.GetValue(DefaultDisplayWidthProperty)
    End Function

End Class
