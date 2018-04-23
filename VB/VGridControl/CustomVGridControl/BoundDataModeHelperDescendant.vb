Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.XtraVerticalGrid.Data

Namespace E4423
	Public Class CustomDataModeHelper
		Inherits BoundDataModeHelper
		Public Sub New(ByVal manager As VGridDataManager)
			MyBase.New(manager)

		End Sub

		Public Overrides ReadOnly Property NewItemRecordMode() As Boolean
			Get
				If (TryCast(Me.Manager.CurrentClient, VGridControlDescendant)).AllowNew Then
					Return True
				End If
				Return False
			End Get
		End Property

		Public Overrides ReadOnly Property Position() As Integer
			Get
				If Manager.CurrentControllerRow = -2147483648 Then
					Return RecordCount - 1
				End If
				Return Manager.CurrentControllerRow
			End Get
		End Property
	End Class
End Namespace
