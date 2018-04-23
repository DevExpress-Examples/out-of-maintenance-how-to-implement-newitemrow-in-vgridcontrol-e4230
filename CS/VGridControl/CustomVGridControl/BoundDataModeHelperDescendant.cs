using DevExpress.XtraVerticalGrid.Data;

namespace E4423
{
    public class CustomDataModeHelper : BoundDataModeHelper
    {
        public CustomDataModeHelper(VGridDataManager manager)
            : base(manager)
        {

        }

        public override bool NewItemRecordMode
        {
            get
            {
                if ((this.Manager.CurrentClient as VGridControlDescendant).AllowNew)
                    return true;
                return false;
            }
        }
       
        public override int Position
        {
            get
            {
                if(Manager.CurrentControllerRow == -2147483648) 
                    return RecordCount - 1;
				return Manager.CurrentControllerRow;
            }
        }
    }
}
