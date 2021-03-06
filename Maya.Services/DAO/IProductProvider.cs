/*
 * Code Generator v1.0
 * 2014-11-07 23:46:07
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maya.Services.VO;


namespace Maya.Services.DAO 
{
    public interface IProductProvider 
    {
        List<ProductVO> GetItems();

        ProductVO GetItem( int productId );

        void DeleteItem( int productId );


        int SaveOrUpdateItem( ProductVO item );

		List<ProductVO> GetItemsByDistrictCriteria( int districtId );
    }
}