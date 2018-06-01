using System;
using System.ComponentModel.DataAnnotations.Schema;
using Enterprise.Domain;

namespace Enterprise.Application
{
    public abstract class DataDictionary<TKey,TUser> : BaseEntity<TKey, TUser>
    {

    }

    public abstract class DataItem<TKey,TFKey, TUser> : BaseEntity<TKey, TUser>
    {
        public TFKey DictionaryId { get; set; }
        public int Ordinal { get; set; }

        /// <summary>
        /// Alias of Description
        /// </summary>
        [NotMapped]
        public string Value
        {
            get { return Description; }
            set { Description = value; }
        }
    }

    public class DataDictionary : DataDictionary<Guid,string>,IHasBuiltIn, ICreationInfo, IUpdatingInfo
    {
        public DataDictionary()
        {
            CreatedDate = DateTime.Now;
        }

        public string AppId { get; set; }

        public string Tag { get; set; }

        #region Implementation of IHasBuiltIn

        public bool IsBuiltIn { get; set; }

        #endregion
    }

    public class DataItem : DataItem<Guid, string, string>,IHasBuiltIn, ICreationInfo, IUpdatingInfo
    {
        public DataItem()
        {
            CreatedDate = DateTime.Now;
        }

        #region Implementation of IHasBuiltIn

        public bool IsBuiltIn { get; set; }

        #endregion
    }
}
