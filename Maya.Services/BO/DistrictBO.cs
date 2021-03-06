/*
 * Code Generator v1.0
 * 2014-11-11 23:08:31
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

		public List<DistrictVO> GetAllItems() {
			return provider.GetItems();
		}

		/// <summary>
		/// 返回的数据不包含根节点（全球）
		/// </summary>
		/// <returns></returns>
        public List<DistrictVO> GetItems() {
			return provider.GetItems().Where( item => item.Name != "全球" ).ToList();
        }


        public DistrictVO GetItem( int districtId ) {
            return provider.GetItem( districtId );
        }

		public List<DistrictVO> GetParentItems( int districtId ) {
			return provider.GetParentItems( districtId );
		}

		public List<DistrictVO> GetChildItems( int districtId ) {
			return provider.GetChildItems( districtId );
		}

		public void DeleteItem( int districtId ) {
            provider.DeleteItem( districtId );
        }



        public int UpdateItem( DistrictVO item ) {
            if ( item == null ) return -1;
            return provider.UpdateItem( item );

        }

        public int SaveItem( int parentId, DistrictVO item )
        {
            if ( parentId <= 0 ) return -1;
            if ( item == null ) return -1;

            return provider.SaveItem( parentId, item );
        }

		public List<DistrictVO> GetItems(string searchText ) {
			if ( string.IsNullOrEmpty( searchText ) )
				return this.GetItems();

			return provider.GetItems( searchText );
		}
    }
}