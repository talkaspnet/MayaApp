/*
 * Code Generator v1.0
 * 2014-11-07 23:46:09
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maya.Services.DAO;
using Maya.Services.VO;


namespace Maya.Services.BO 
{
    public class CategoryBO : BaseBO 
    {
        private ICategoryProvider provider;
        private static CategoryBO instance;

        private CategoryBO() {
            provider = (ICategoryProvider)this.CreateProvider("Category");
        }

        public static CategoryBO GetInstance() {
            if (instance == null) {
                instance = new CategoryBO();
            }
            return instance;
        }

        public List<CategoryVO> GetItems() {
            return provider.GetItems();
        }


        public CategoryVO GetItem( int categoryId ) {
            return provider.GetItem( categoryId );
        }

        public void DeleteItem( int categoryId ) {
            provider.DeleteItem( categoryId );
        }



        public int SaveOrUpdateItem( CategoryVO item ) {
            if ( item == null ) return -1;
            return provider.SaveOrUpdateItem( item );

        }
    }
}