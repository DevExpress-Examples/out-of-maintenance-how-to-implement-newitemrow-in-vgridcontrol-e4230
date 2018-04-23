Imports DevExpress.XtraVerticalGrid.Data
Imports DevExpress.XtraVerticalGrid

Namespace E4423
    Public Class VGridDataManagerDescendant
        Inherits VGridDataManager

        Public Sub New(ByVal grid As DevExpress.XtraVerticalGrid.VGridControlBase)
            MyBase.New(grid)

        End Sub


        Protected Overrides Function CreateDataModeHelper(ByVal dataSource As Object) As DataModeHelper

            If AllowNew AndAlso dataSource IsNot Nothing Then
                   Return New CustomDataModeHelper(Me)
            End If
            Return MyBase.CreateDataModeHelper(dataSource)
        End Function

    End Class
End Namespace
