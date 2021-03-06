/*
 * Code Generator v1.0
 * 2014-11-07 23:46:08
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maya.Services.DAO;
using Maya.Services.VO;


namespace Maya.Services.BO 
{
    public class MusicBO : BaseBO 
    {
        private IMusicProvider provider;
        private static MusicBO instance;

        private MusicBO() {
            provider = (IMusicProvider)this.CreateProvider("Music");
        }

        public static MusicBO GetInstance() {
            if (instance == null) {
                instance = new MusicBO();
            }
            return instance;
        }

        public List<MusicVO> GetItems() {
            return provider.GetItems();
        }

        public List<MusicVO> GetItems(int? districtId)
        {
            if (districtId.HasValue) return this.GetItemsByDistrictId(districtId.Value);
            return this.GetItems();
        }

        public MusicVO GetItem( int musicId ) {
            return provider.GetItem( musicId );
        }

        public void DeleteItem( int musicId ) {
            provider.DeleteItem( musicId );
        }

        public List<MusicVO> GetItemsByDistrictId( int districtId ) {
            return provider.GetItemsByDistrictId( districtId );
        }

        public void DeleteItemsByDistrictId( int districtId ) {
            provider.DeleteItemsByDistrictId( districtId );
        }


        public int SaveOrUpdateItem( MusicVO item ) {
            if ( item == null ) return -1;
            return provider.SaveOrUpdateItem( item );

        }

		public List<MusicVO> GetItemsByDistrictCriteria( int districtId ) {
			if (districtId <= 0) return new List<MusicVO>();

			return provider.GetItemsByDistrictCriteria( districtId );
		}
    }
}