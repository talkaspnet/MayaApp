/*
 * Code Generator v1.0
 * 2014-11-07 23:46:07
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maya.Services.DAO;
using Maya.Services.VO;


namespace Maya.Services.BO 
{
    public class DistrictBO : BaseBO 
    {
        private IDistrictProvider provider;
        private static DistrictBO instance;

        private DistrictBO() {
            provider = (IDistrictProvider)this.CreateProvider("District");
        }

        public static DistrictBO GetInstance() {
            if (instance == null) {
                instance = new DistrictBO();
            }
            return instance;
        }

        public List<DistrictVO> GetItems() {
            return provider.GetItems();
        }


        public DistrictVO GetItem( int districtId ) {
            return provider.GetItem( districtId );
        }

        public void DeleteItem( int districtId ) {
            provider.DeleteItem( districtId );
        }



        public void SaveOrUpdateItem( DistrictVO item ) {
            if ( item == null ) return;
            provider.SaveOrUpdateItem( item );
            

        }
    }
}