// ***********************************************************************
// Assembly         : OptLib.Data
// Author           : alidniry
// Created          : 10-16-2018
//
// Last Modified By : alidniry
// Last Modified On : 10-16-2018
// ***********************************************************************
// <copyright file="IEntityIdValueNameDescription.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using OptLib.Data.Base.Interface;

namespace OptLib.Data.Base
{
    /// <summary>
    /// رابط کلاس اولیه مدلهای شامل
    /// Id, Name, Value, Description,
    /// Active, Lock, Visible
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <seealso cref="OptLib.Data.Base.IEntity" />
    /// <seealso cref="OptLib.Data.Base.Interface.IId{TEntity}" />
    /// <seealso cref="OptLib.Data.Base.Interface.IName" />
    /// <seealso cref="OptLib.Data.Base.IDescription" />
    /// <seealso cref="OptLib.Data.Base.Interface.IValue{TEntity}" />
    /// <seealso cref="OptLib.Data.Base.IEntityId{TEntity}" />
    /// <seealso cref="OptLib.Data.Base.IEntityIdName{TEntity}" />
    /// <seealso cref="OptLib.Data.Base.IEntityIdNameDescription{TEntity}" />
    /// <seealso cref="OptLib.Data.Base.IEntityIdValueName{TEntity}" />
    public interface IEntityIdValueNameDescription<TEntity>
        : IEntity, IId<TEntity>, IName, IDescription, IValue<TEntity>
        , IEntityId<TEntity>, IEntityIdName<TEntity>, IEntityIdNameDescription<TEntity>, IEntityIdValueName<TEntity>
    {
        /// <summary>
        /// آیتم مقدار
        /// </summary>
        /// <value>The value.</value>
        TEntity Value { get; set; }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="value">The value.</param>
        void SetValue(TEntity value);
        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        /// <param name="name">The name.</param>
        void SetValue(TEntity id, TEntity value, string name);
    }
}