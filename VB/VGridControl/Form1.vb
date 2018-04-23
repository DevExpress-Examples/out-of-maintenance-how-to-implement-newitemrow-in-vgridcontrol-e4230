Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid

Namespace E4423
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
			Dim Some As New BindingList(Of SomeList)()
			Some.Add(New SomeList(12, "Alex", "Some"))
			Some.Add(New SomeList(11, "Bill", "thing"))
			Some.Add(New SomeList(1, "I", "am"))
			Some.AllowNew = True


			vGridControlDescendant1.AllowNew = True
			vGridControlDescendant1.DataSource = Some

			gridControl1.DataSource = Some
			gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.Top



		End Sub

	End Class
End Namespace
