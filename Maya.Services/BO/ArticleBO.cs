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
    public class ArticleBO : BaseBO 
    {
        private IArticleProvider provider;
        private static ArticleBO instance;

        private ArticleBO() {
            provider = (IArticleProvider)this.CreateProvider("Article");
        }

        public static ArticleBO GetInstance() {
            if (instance == null) {
                instance = new ArticleBO();
            }
            return instance;
        }

        public List<ArticleVO> GetItems() {
            return provider.GetItems();
        }

        public List<ArticleVO> GetItems(int? districtId)
        {
            if (districtId.HasValue) return this.GetItemsByDistrictId(districtId.Value);
            return this.GetItems();
        }

        public ArticleVO GetItem( int articleId ) {
            return provider.GetItem( articleId );
        }

        public void DeleteItem( int articleId ) {
            provider.DeleteItem( articleId );
        }

        public List<ArticleVO> GetItemsByDistrictId( int districtId ) {
            return provider.GetItemsByDistrictId( districtId );
        }

        public void DeleteItemsByDistrictId( int districtId ) {
            provider.DeleteItemsByDistrictId( districtId );
        }
        public List<ArticleVO> GetItemsByCategoryId( int categoryId ) {
            return provider.GetItemsByCategoryId( categoryId );
        }

        public void DeleteItemsByCategoryId( int categoryId ) {
            provider.DeleteItemsByCategoryId( categoryId );
        }


        public int SaveOrUpdateItem( ArticleVO item ) {
            if ( item == null ) return -1;
            return provider.SaveOrUpdateItem( item );

        }

		public List<ArticleVO> GetItems( int categoryId, int districtId ) {
			return provider.GetItems( categoryId, districtId );
		}
    }
}