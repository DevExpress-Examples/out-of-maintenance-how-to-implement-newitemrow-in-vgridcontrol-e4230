Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace E4423
    Public Class SomeList
        Public Sub New()
        End Sub
        Public Sub New(ByVal _number As Integer, ByVal _name As String, ByVal _something As String)
            Number = _number
            Name = _name
            Something = _something

        End Sub
        Public Property Number() As Integer
        Public Property Name() As String
        Public Property Something() As String
    End Class
End Namespace
