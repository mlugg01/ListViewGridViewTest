Imports System.Globalization
Imports System.Windows.Media

Public Class DispStatExportedFsoOrQuoteCountToColorConverter
    Implements IMultiValueConverter

    Public Function Convert(values() As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IMultiValueConverter.Convert
        For Each loValue In values
            If loValue IsNot Nothing AndAlso loValue.GetType.FullName = "MS.Internal.NamedObject" Then
                Return Nothing
            End If
        Next
        'If values(0) IsNot Nothing AndAlso values(0).GetType.FullName = "MS.Internal.NamedObject" Then
        '    Return Nothing
        'End If

        Dim liTotalCount As Integer = If(values(0), 0)
        Dim liExportedCount As Integer = If(values(1), 0)
        Dim liJobStatus As Enums.JobStatusValues = If(values(2), Enums.JobStatusValues.Sales)
        If liJobStatus = Enums.JobStatusValues.Sales Then
            Return Brushes.LightGray
        ElseIf liExportedCount = 0 Then
            Return Brushes.Red
        ElseIf liExportedCount < liTotalCount Then
            Return Brushes.Yellow
        Else
            Return Brushes.Green
        End If
    End Function

    Public Function ConvertBack(value As Object, targetTypes() As Type, parameter As Object, culture As CultureInfo) As Object() Implements IMultiValueConverter.ConvertBack
        Throw New NotImplementedException()
    End Function
End Class