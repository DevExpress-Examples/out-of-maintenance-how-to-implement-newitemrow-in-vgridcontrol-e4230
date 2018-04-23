using DevExpress.XtraEditors;
using DevExpress.XtraVerticalGrid;

namespace E4423
{
    [System.ComponentModel.DesignerCategory("")]
    public class VGridControlDescendant : VGridControl
    {
        public VGridControlDescendant()
        {
            EditingMode = false;
            DataManager.VisualClient = this;
            DataManager.DataClient = this;
            DataManager.ValidationClient = this;
            DataManager.CurrentClient = this;
            DataManager.ListSourceChanged += OnDataManager_DataSourceChanged;

        }

        protected override DevExpress.XtraVerticalGrid.Data.VGridDataManager CreateDataManager() {
            return new VGridDataManagerDescendant(this);
        }

        protected override DevExpress.XtraVerticalGrid.Painters.VGridPainter CreatePainterCore(DevExpress.XtraVerticalGrid.Painters.PaintEventHelper eventHelper)
        {
            return new CustomVGridPainter(eventHelper);
        }


        #region EventHandlerWhenAllowNew

        public bool AllowNew { get; set; }
        public bool CanRemoveLastCreated;
        bool EditingMode;

        protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (!AllowNew && ActiveEditor == null && CanRemoveLastCreated)
                if (e.KeyCode == System.Windows.Forms.Keys.Escape)
                {
                    this.DeleteRecord(RecordCount - 1);
                    AllowNew = true;
                }
        }


        protected override void ChangeFocusedRecord(int curRecord)
        {
            if (EditingMode)
            {
                AllowNew = true;
                EditingMode = false;
            }
            base.ChangeFocusedRecord(curRecord);
        }

        protected override void RaiseCellValueChanging(DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e)
        {
            base.RaiseCellValueChanging(e);
            if (e.RecordIndex < 0)
            {
                this.HideEditor();
                this.AllowNew = false;
                this.AddNewRecord();
                this.FocusedRecord = RecordCount - 1;
                this.FocusedRecord = RecordCount - 1;
                this.FocusedRecordCellIndex = e.CellIndex;
                this.SetCellValue(e.Row, RecordCount - 1, e.Value);
                this.ShowEditor();
                if (this.ActiveEditor is TextEdit)
                    (this.ActiveEditor as TextEdit).DeselectAll();
                EditingMode = true;
                CanRemoveLastCreated = true;
            }

        }

        #endregion


    }
}
