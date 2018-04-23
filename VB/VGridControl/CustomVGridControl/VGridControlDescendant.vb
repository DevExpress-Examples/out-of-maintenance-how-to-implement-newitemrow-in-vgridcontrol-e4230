Imports DevExpress.XtraEditors
Imports DevExpress.XtraVerticalGrid

Namespace E4423
    <System.ComponentModel.DesignerCategory("")> _
    Public Class VGridControlDescendant
        Inherits VGridControl

        Public Sub New()
            EditingMode = False
            DataManager.VisualClient = Me
            DataManager.DataClient = Me
            DataManager.ValidationClient = Me
            DataManager.CurrentClient = Me
            AddHandler DataManager.ListSourceChanged, AddressOf OnDataManager_DataSourceChanged

        End Sub

        Protected Overrides Function CreateDataManager() As DevExpress.XtraVerticalGrid.Data.VGridDataManager
            Return New VGridDataManagerDescendant(Me)
        End Function

        Protected Overrides Function CreatePainterCore(ByVal eventHelper As DevExpress.XtraVerticalGrid.Painters.PaintEventHelper) As DevExpress.XtraVerticalGrid.Painters.VGridPainter
            Return New CustomVGridPainter(eventHelper)
        End Function


        #Region "EventHandlerWhenAllowNew"

        Public Property AllowNew() As Boolean
        Public CanRemoveLastCreated As Boolean
        Private EditingMode As Boolean

        Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
            MyBase.OnKeyDown(e)
            If Not AllowNew AndAlso ActiveEditor Is Nothing AndAlso CanRemoveLastCreated Then
                If e.KeyCode = System.Windows.Forms.Keys.Escape Then
                    Me.DeleteRecord(RecordCount - 1)
                    AllowNew = True
                End If
            End If
        End Sub


        Protected Overrides Sub ChangeFocusedRecord(ByVal curRecord As Integer)
            If EditingMode Then
                AllowNew = True
                EditingMode = False
            End If
            MyBase.ChangeFocusedRecord(curRecord)
        End Sub

        Protected Overrides Sub RaiseCellValueChanging(ByVal e As DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs)
            MyBase.RaiseCellValueChanging(e)
            If e.RecordIndex < 0 Then
                Me.HideEditor()
                Me.AllowNew = False
                Me.AddNewRecord()
                Me.FocusedRecord = RecordCount - 1
                Me.FocusedRecord = RecordCount - 1
                Me.FocusedRecordCellIndex = e.CellIndex
                Me.SetCellValue(e.Row, RecordCount - 1, e.Value)
                Me.ShowEditor()
                If TypeOf Me.ActiveEditor Is TextEdit Then
                    TryCast(Me.ActiveEditor, TextEdit).DeselectAll()
                End If
                EditingMode = True
                CanRemoveLastCreated = True
            End If

        End Sub

        #End Region
        Protected Overrides Sub Dispose(disposing As Boolean)
            If disposing AndAlso DataManager IsNot Nothing Then
                RemoveHandler DataManager.ListSourceChanged, AddressOf OnDataManager_DataSourceChanged
            End If
            MyBase.Dispose(disposing)
        End Sub

    End Class
End Namespace
