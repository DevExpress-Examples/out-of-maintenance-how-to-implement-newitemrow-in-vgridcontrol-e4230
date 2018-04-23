using DevExpress.XtraVerticalGrid.Data;
using DevExpress.XtraVerticalGrid;

namespace E4423
{
    public class VGridDataManagerDescendant : VGridDataManager
    {
        public VGridDataManagerDescendant(DevExpress.XtraVerticalGrid.VGridControlBase grid)
            : base(grid) {
            
        }

    
        protected override DataModeHelper CreateDataModeHelper(object dataSource)
        { 
            
            if(AllowNew && dataSource != null)
            {
                   return new CustomDataModeHelper(this);
            }
            return base.CreateDataModeHelper(dataSource);
        }
      
    }
}
