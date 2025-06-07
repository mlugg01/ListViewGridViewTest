Imports System.Globalization
Imports System.Windows.Media

Public Class DispStatJobApprovedStatusToColorConverter
    Implements IMultiValueConverter

    Public Function Convert(values() As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IMultiValueConverter.Convert
        Dim liJobApprovedStatus As Enums.JobApprovedStates = values(0)
        Dim liJobStatus As Enums.JobStatusValues = values(1)
        If liJobStatus <> Enums.JobStatusValues.Completed Then
            Return Brushes.LightGray
        Else
            Select Case liJobApprovedStatus
                Case Enums.JobApprovedStates.Approved
                    Return Brushes.Green

                Case Enums.JobApprovedStates.DataChangedSinceApproved
                    Return Brushes.Yellow

                Case Else
                    Return Brushes.Red
            End Select
        End If
    End Function

    Public Function ConvertBack(value As Object, targetTypes() As Type, parameter As Object, culture As CultureInfo) As Object() Implements IMultiValueConverter.ConvertBack
        Throw New NotImplementedException()
    End Function

End Class
