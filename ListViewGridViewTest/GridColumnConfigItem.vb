Imports System.ComponentModel

Public Class GridColumnConfigItem
    Implements INotifyPropertyChanged

    Property ColumnName As String
    Property ColumnHeader As String
    Property DefaultDisplayIndex As Integer
    Property DefaultWidth As Double?
    Property CanUserReorder As Boolean
    Property CanUserSetVisibility As Boolean

    Private miDisplayIndex As Integer
    Property DisplayIndex As Integer
        Get
            Return miDisplayIndex
        End Get
        Set(value As Integer)
            miDisplayIndex = value
            NotifyPropertyChanged(NameOf(Me.DisplayIndex))
        End Set
    End Property

    Private mbIsHidden As Boolean
    Property IsHidden As Boolean
        Get
            Return mbIsHidden
        End Get
        Set(value As Boolean)
            mbIsHidden = value
            NotifyPropertyChanged(NameOf(Me.IsHidden))
        End Set
    End Property

    Public Sub SetIsHidden(width As Double)
        Me.IsHidden = (width = 0)
    End Sub

    Public Function GetWidth() As Double?
        Return If(Me.IsHidden, 0, If(Me.DefaultWidth, Double.NaN))
    End Function


    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged

    Private Sub NotifyPropertyChanged(propertyName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub


End Class
