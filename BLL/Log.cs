using System;
using System.Data;
using System.Collections.Generic;
using Common;
using Model;


namespace BLL
{
	/// <summary>
	/// log
	/// </summary>
	public partial class Log
	{
		private readonly DAL.MySqlLog dal=new DAL.MySqlLog();
		public Log()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long AutoID)
		{
			return dal.Exists(AutoID);
		}

		/// <summary>
		/// 增加日志
		/// </summary>
		public bool Add(Model.Log model)
		{
			return dal.Add(model);
		}

        ///// <summary>
        ///// 更新日志
        ///// </summary>
        //public bool Update(Model.Log model)
        //{
        //    return dal.Update(model);
        //}

		/// <summary>
        /// 删除日志
		/// </summary>
		public bool Delete(long AutoID)
		{
			
			return dal.Delete(AutoID);
		}
		/// <summary>
        /// 批量删除日志
		/// </summary>
		public int DeleteList(string[] AutoIDlist )
		{
			return dal.DeleteList(AutoIDlist );
		}

		/// <summary>
        /// 得到日志对象实体
		/// </summary>
		public Model.Log GetModel(long AutoID)
		{
			
			return dal.GetModel(AutoID);
		}

		/// <summary>
        /// 得到日志对象实体，从缓存中
		/// </summary>
		public Model.Log GetModelByCache(long AutoID)
		{
			
			string CacheKey = "logModel-" + AutoID;
			object objModel = Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(AutoID);
					if (objModel != null)
					{
						int ModelCache = Common.ConfigHelper.GetConfigInt("ModelCache");
						Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Model.Log)objModel;
		}

        /// <summary>
        /// 根据条件获取日志列表
        /// </summary>
        /// <param name="key">查询条件 0：AutoID 1：OperationItem 2：OperationTime 3：OperationDetail 4：Operator 5:Memo 其他:全部</param>
        /// <param name="value">查询值</param>
        /// <returns>日志集合</returns>
        public DataSet GetList(int key, string value)
        {
            return dal.GetList(key, value);
        }

        /// <summary>
        /// 根据条件获取日志列表
        /// </summary>
        /// <param name="key">查询条件 0：AutoID 1：OperationItem 2：OperationTime 3：OperationDetail 4：Operator 5:Memo 其他:全部</param>
        /// <param name="value">查询值</param>
        /// <param name="Top">获取的条目数（小于0不限）</param>
        /// <param name="filedOrder">排序字段 0：AutoID 1：OperationItem 2：OperationTime 3：OperationDetail 4：Operator 其他:不排序</param>
        /// <param name="desc">选用倒序</param>
        /// <returns>日志集合</returns>
        public DataSet GetList(int key, string value, int Top, int filedOrder, bool desc)
        {
            return dal.GetList(key, value, Top, filedOrder, desc);
        }

        /// <summary>
        /// 根据条件获取日志列表(list)
        /// </summary>
        /// <param name="key">查询条件 0：AutoID 1：OperationItem 2：OperationTime 3：OperationDetail 4：Operator 5:Memo 其他:全部</param>
        /// <param name="value">查询值</param>
        /// <param name="Top">获取的条目数（小于0不限）</param>
        /// <param name="filedOrder">排序字段 0：AutoID 1：OperationItem 2：OperationTime 3：OperationDetail 4：Operator 其他:不排序</param>
        /// <param name="desc">选用倒序</param>
        /// <returns>日志集合</returns>
        public List<Model.Log> GetModelList(int key, string value, int Top, int filedOrder, bool desc)
        {
            DataSet ds = dal.GetList(key, value, Top, filedOrder, desc);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 将DateTable转成实体类集合
        /// </summary>
        public List<Model.Log> DataTableToList(DataTable dt)
        {
            List<Model.Log> modelList = new List<Model.Log>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.Log model;
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
        /// 获得所有日志集合
        /// </summary>
        /// <returns>日志集合</returns>
        public DataSet GetAllList()
        {
            return GetList(-1, "");
        }

        /// <summary>
        /// 根据条件获得日志条目数
        /// </summary>
        /// <param name="key">查询条件 0：AutoID 1：OperationItem 2：OperationTime 3：OperationDetail 4：Operator 5:Memo 其他:全部</param>
        /// <param name="value">查询值</param>
        /// <returns>日志集合条目数</returns>
        public int GetRecordCount(int key, string value)
        {
            return dal.GetRecordCount(key, value);
        }

        /// <summary>
        /// 分页获取日志集合
        /// </summary>
        /// <param name="key">查询条件 0：AutoID 1：OperationItem 2：OperationTime 3：OperationDetail 4：Operator 5:Memo 其他:全部</param>
        /// <param name="value">查询值</param>
        /// <param name="filedOrder">排序字段 0：AutoID 1：OperationItem 2：OperationTime 3：OperationDetail 4：Operator  其他:不排序</param>
        /// <param name="desc">选用倒序</param>
        /// <param name="startIndex">起始索引</param>
        /// <param name="endIndex">结束索引</param>
        /// <returns>日志集合</returns>
        public DataSet GetListByPage(int key, string value, int filedOrder, bool desc, int startIndex, int endIndex)
        {
            return dal.GetListByPage(key, value, filedOrder, desc, startIndex, endIndex);
        }
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

