/*
 * Code Generator v1.0
 * 2014-11-24 23:23:51
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maya.Services.VO;


namespace Maya.Services.DAO 
{
    public interface ICurrencyProvider 
    {
        List<CurrencyVO> GetItems();

        CurrencyVO GetItem( int id );

        void DeleteItem( int id );


        int SaveOrUpdateItem( CurrencyVO item );
    }
}