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
    public interface IDistrictProvider 
    {
        List<DistrictVO> GetItems();

        DistrictVO GetItem( int districtId );

        void DeleteItem( int districtId );


        void SaveOrUpdateItem( DistrictVO item );
    }
}