Imports Microsoft.VisualBasic
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
		Private privateNumber As Integer
		Public Property Number() As Integer
			Get
				Return privateNumber
			End Get
			Set(ByVal value As Integer)
				privateNumber = value
			End Set
		End Property
		Private privateName As String
		Public Property Name() As String
			Get
				Return privateName
			End Get
			Set(ByVal value As String)
				privateName = value
			End Set
		End Property
		Private privateSomething As String
		Public Property Something() As String
			Get
				Return privateSomething
			End Get
			Set(ByVal value As String)
				privateSomething = value
			End Set
		End Property
	End Class
End Namespace
