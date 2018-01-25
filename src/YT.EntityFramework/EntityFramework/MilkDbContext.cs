using System.Data.Common;
using System.Data.Entity;
using Abp.Application.Editions;
using Abp.Organizations;
using Abp.Zero.EntityFramework;
using YT.Authorizations;
using YT.Managers.MultiTenancy;
using YT.Managers.Roles;
using YT.Managers.Users;
using YT.Models;
using YT.MultiTenancy;
using YT.Navigations;
using YT.Organizations;
using YT.Storage;

namespace YT.EntityFramework
{
    /* Constructors of this DbContext is important and each one has it's own use case.
     * - Default constructor is used by EF tooling on design time.
     * - constructor(nameOrConnectionString) is used by ABP on runtime.
     * - constructor(existingConnection) is used by unit tests.
     * - constructor(existingConnection,contextOwnsConnection) can be used by ABP if DbContextEfTransactionStrategy is used.
     * See http://www.aspnetboilerplate.com/Pages/Documents/EntityFramework-Integration for more.
     */
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class MilkDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        #region ϵͳ����
        /// <summary>
        /// ����洢
        /// </summary>
        public virtual IDbSet<BinaryObject> BinaryObjects { get; set; }
        /// <summary>
        /// �˵�����
        /// </summary>
        public virtual IDbSet<Menu> Menus { get; set; }
        /// <summary>
        /// Ȩ������
        /// </summary>
        public virtual IDbSet<YtPermission> YtPermissions { get; set; }
        /// <summary>
        /// ��֯����
        /// </summary>
        public new virtual IDbSet<Organization> OrganizationUnits { get; set; }
        #endregion
        #region ҵ�����
        /// <summary>
        /// ����
        /// </summary>
        public virtual  IDbSet<Car> Cars { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public  virtual  IDbSet<CarProfile> CarProfiles { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public  virtual  IDbSet<CarGeneration> CarGenerations { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public  virtual  IDbSet<CarOrder> CarOrders { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public virtual  IDbSet<Area> Areas { get; set; }
        /// <summary>
        /// ����۸�
        /// </summary>
        public  virtual  IDbSet<AreaPrice> AreaPrices { get; set; }
        /// <summary>
        /// �ֿ�
        /// </summary>
        public  virtual  IDbSet<WareHouse> WareHouses { get; set; }
        /// <summary>
        /// ��Ʒ
        /// </summary>
        public  virtual  IDbSet<Product> Products { get; set; }
        public virtual  IDbSet<Customer> Customers { get; set; }
        /// <summary>
        /// ��������Ʒ
        /// </summary>
        public  virtual  IDbSet<OrderProduct> OrderProducts { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public  virtual  IDbSet<OrderList> OrderLists { get; set; }
        /// <summary>
        /// ���Ѷ���
        /// </summary>
        public  virtual  IDbSet<StoreOrder> StoreOrders { get; set; }
        #endregion
        public MilkDbContext()
            : base("Default")
        {

        }

        public MilkDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        public MilkDbContext(DbConnection existingConnection)
           : base(existingConnection, false)
        {

        }

        public MilkDbContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().Ignore(a => a.Surname);
            modelBuilder.Entity<User>().Property(a => a.EmailAddress).IsOptional();
          
        }
    }
}
