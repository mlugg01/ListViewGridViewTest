Public Class ObjectIDConverter
    Implements IValueConverter

    Private mcolItems As New List(Of Object)
    Private mcValueMemberPath As String
    Private mcDisplayMemberPath As String

    Public Property ItemsSource() As List(Of Object)
        Get
            Return mcolItems
        End Get
        Set(ByVal value As List(Of Object))
            mcolItems = value
        End Set
    End Property

    Public Property ValueMemberPath() As String
        Get
            Return mcValueMemberPath
        End Get
        Set(ByVal value As String)
            mcValueMemberPath = value
        End Set
    End Property

    Public Property DisplayMemberPath() As String
        Get
            Return mcDisplayMemberPath
        End Get
        Set(ByVal value As String)
            mcDisplayMemberPath = value
        End Set
    End Property

    Public Function Convert(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.Convert
        If value Is Nothing Then
            Return Nothing
        End If
        Dim loValueToConvert = value
        Dim loItemValue As Object
        For Each loItem In mcolItems
            loItemValue = loItem.GetType.GetProperty(mcValueMemberPath).GetValue(loItem, Nothing)
            If loItemValue IsNot Nothing AndAlso StringsAreEqual(loItemValue, loValueToConvert) Then
                If String.IsNullOrEmpty(mcDisplayMemberPath) Then
                    Return loItem
                Else
                    Dim loValue = loItem.GetType.GetProperty(mcDisplayMemberPath).GetValue(loItem, Nothing)
                    If loValue IsNot Nothing Then
                        Return loValue.ToString.Trim
                    End If
                End If
            End If
        Next
        Return Nothing
    End Function

    Public Function ConvertBack(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.ConvertBack
        If String.IsNullOrEmpty(mcDisplayMemberPath) Then
            Dim loValueToConvert = value
            For Each loItem In mcolItems
                If loItem.Equals(loValueToConvert) Then
                    Return loItem.GetType.GetProperty(mcValueMemberPath).GetValue(loItem, Nothing)
                End If
            Next
        Else
            Dim loValueToConvert = value
            Dim loDisplayValue As Object
            For Each loItem In mcolItems
                loDisplayValue = loItem.GetType.GetProperty(mcDisplayMemberPath).GetValue(loItem, Nothing)
                If loDisplayValue.Equals(loValueToConvert) Then
                    Return loItem.GetType.GetProperty(mcValueMemberPath).GetValue(loItem, Nothing)
                End If
            Next
        End If
        Return Nothing
    End Function

End Class