using System;
using System.Data;
using System.Collections.Generic;
using Common;
using Model;

namespace BLL
{
    /// <summary>
    /// DrugsInfo
    /// </summary>
    public partial class DrugsInfo
    {
        private readonly DAL.MySqlDrugsInfo dal = new DAL.MySqlDrugsInfo();
        public DrugsInfo()
        { }
        #region  BasicMethod


        /// <summary>
        /// 将药品信息的DateTable转成实体类集合
        /// </summary>
        public List<Model.DrugsInfo> DataTableToList(DataTable dt)
        {
            List<Model.DrugsInfo> modelList = new List<Model.DrugsInfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.DrugsInfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }






        /// <summary>
        /// 根据条件获取线路信息
        /// </summary>
        /// <param name="key">查询条件 0：AutoID 1：DrugName 2：Form,11:Abbr 其他:全部</param>
        /// <param name="value">查询值</param>
        /// <returns>数据集</returns>
        public List<Model.DrugsInfo> GetDrugsInfoModelList(int key, string value)
        {
            DataSet ds = dal.GetList(key, value);
            return DataTableToList(ds.Tables[0]);

        }



         /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(Model.DrugsInfo model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 分页获取集合
        ///<param name="key">查询条件 0：AutoID 1：DrugName 2：Form,11:Abbr 其他:全部</param>
        /// <param name="value">查询值</param>
        /// </summary> 
        public DataSet GetListByPage(int key, string value, int filedOrder, bool desc, int startIndex, int endIndex)
        {
            return dal.GetListByPage(key, value, filedOrder, desc, startIndex, endIndex);
        }


        /// <summary>
        /// 获取记录总数
        /// </summary>
        /// <param name="key">查询条件 0：AutoID 1：DrugName 2：Form,11:Abbr 其他:全部</param>
        /// <param name="value">查询值</param>
        /// <returns>记录总数</returns>
        public int GetRecordCount(int key, string value)
        {
            return dal.GetRecordCount(key, value);
        }


        #endregion  BasicMethod
    }
}
