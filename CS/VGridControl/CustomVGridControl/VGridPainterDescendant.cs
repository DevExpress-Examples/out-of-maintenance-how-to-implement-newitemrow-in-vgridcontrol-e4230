using DevExpress.XtraVerticalGrid.Painters;

namespace E4423
{
    public class CustomVGridPainter : VGridPainter
    {
        public CustomVGridPainter(PaintEventHelper eventHelper)
            : base(eventHelper)
        {
        }
        protected override void DrawRowValueCellCore(
            DevExpress.XtraVerticalGrid.Events.CustomDrawRowValueCellEventArgs e,
            DevExpress.XtraEditors.Drawing.BaseEditPainter pb,
            DevExpress.XtraEditors.ViewInfo.BaseEditViewInfo bvi,
            DevExpress.XtraVerticalGrid.ViewInfo.BaseViewInfo vi)
        {
            VGridControlDescendant Grid = vi.Grid as VGridControlDescendant;
            if (Grid.RecordCount - 1 == e.RecordIndex && Grid.FocusedRecord!= -1 )
            {
                if (!Grid.AllowNew )
                    base.DrawRowValueCellCore(e, pb, bvi, vi);
            }
            else base.DrawRowValueCellCore(e, pb, bvi, vi);
        }
    }
}
