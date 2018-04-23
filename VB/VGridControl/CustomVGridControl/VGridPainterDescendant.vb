Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.XtraVerticalGrid.Painters

Namespace E4423
	Public Class CustomVGridPainter
		Inherits VGridPainter
		Public Sub New(ByVal eventHelper As PaintEventHelper)
			MyBase.New(eventHelper)
		End Sub
		Protected Overrides Sub DrawRowValueCellCore(ByVal e As DevExpress.XtraVerticalGrid.Events.CustomDrawRowValueCellEventArgs, ByVal pb As DevExpress.XtraEditors.Drawing.BaseEditPainter, ByVal bvi As DevExpress.XtraEditors.ViewInfo.BaseEditViewInfo, ByVal vi As DevExpress.XtraVerticalGrid.ViewInfo.BaseViewInfo)
			Dim Grid As VGridControlDescendant = TryCast(vi.Grid, VGridControlDescendant)
			If Grid.RecordCount - 1 = e.RecordIndex AndAlso Grid.FocusedRecord<> -1 Then
				If (Not Grid.AllowNew) Then
					MyBase.DrawRowValueCellCore(e, pb, bvi, vi)
				End If
			Else
				MyBase.DrawRowValueCellCore(e, pb, bvi, vi)
			End If
		End Sub
	End Class
End Namespace
