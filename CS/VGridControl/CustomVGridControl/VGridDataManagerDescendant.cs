using DevExpress.XtraVerticalGrid.Data;

namespace E4423
{
    public class VGridDataManagerDescendant : VGridDataManager
    {
        public VGridDataManagerDescendant() { }

    
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
