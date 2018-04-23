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
            fDataMahager.VisualClient = this;
            fDataMahager.DataClient = this;
            fDataMahager.ValidationClient = this;
            fDataMahager.CurrentClient = this;
            fDataMahager.ListSourceChanged += OnDataManager_DataSourceChanged;
        }

        VGridDataManagerDescendant fDataMahager = new VGridDataManagerDescendant();
        protected override DevExpress.XtraVerticalGrid.Data.VGridDataManager DataManager
        {
            get
            {
                return fDataMahager;
            }
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
