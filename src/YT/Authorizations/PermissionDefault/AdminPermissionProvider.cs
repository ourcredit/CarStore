using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Components.DictionaryAdapter;
using YT.Navigations;

namespace YT.Authorizations.PermissionDefault
{
    public abstract class BasePermissionProvider : PermissionProvider
    {

    }
    public class AdminPermissionProvider : BasePermissionProvider
    {
        public override IEnumerable<PermissionDefinition> GetPermissionDefinitions(PermissionDefinitionProviderContext context)
        {
            return new List<PermissionDefinition>()
            {

                new PermissionDefinition(StaticPermissionsName.Page, "页面", "鼻祖权限")
                {
                    Childs = new List<PermissionDefinition>()
                    {

                        new PermissionDefinition(StaticPermissionsName.Page_Device, "设备管理", "设备管理",
                            PermissionType.Control)
                        {
                            Childs = new List<PermissionDefinition>()
                            {
                                new PermissionDefinition(StaticPermissionsName.Page_Device_House, "仓库管理", "",
                                    PermissionType.Control),
                                new PermissionDefinition(StaticPermissionsName.Page_Device_HouseProduct, "仓库进货", "",
                                    PermissionType.Control),
                                new PermissionDefinition(StaticPermissionsName.Page_Device_CarOrder, "车辆订单", "",
                                    PermissionType.Control),
                            }
                        },
                        new PermissionDefinition(StaticPermissionsName.Page_Car, "车辆管理", "车辆管理",
                            PermissionType.Control)
                        {
                            Childs = new List<PermissionDefinition>()
                            {
                                new PermissionDefinition(StaticPermissionsName.Page_Car_Apply, "车辆管理", "",
                                    PermissionType.Control),
                                new PermissionDefinition(StaticPermissionsName.Page_Car_Generation, "车辆提现", "",
                                    PermissionType.Control),

                            }
                        },
                        new PermissionDefinition(StaticPermissionsName.Page_Product, "商品管理", "商品管理",
                            PermissionType.Control)
                        {
                            Childs = new List<PermissionDefinition>()
                            {
                                new PermissionDefinition(StaticPermissionsName.Page_Product_Product, "商品管理", "",
                                    PermissionType.Control),
                                new PermissionDefinition(StaticPermissionsName.Page_Product_Price, "商品价格管理", "",
                                    PermissionType.Control),

                            }
                        },
                        new PermissionDefinition(StaticPermissionsName.Page_Staticial, "统计管理", "统计管理",
                            PermissionType.Control)
                        {
                            Childs = new List<PermissionDefinition>()
                            {
                                new PermissionDefinition(StaticPermissionsName.Page_Staticial_Members, "会员管理", "",
                                    PermissionType.Control),
                                new PermissionDefinition(StaticPermissionsName.Page_Staticial_Payfor, "支付管理", "",
                                    PermissionType.Control),
                                new PermissionDefinition(StaticPermissionsName.Page_Staticial_CarReplease, "车辆明细管理", "",
                                    PermissionType.Control),
                                new PermissionDefinition(StaticPermissionsName.Page_Staticial_CarSale, "车辆销售", "",
                                    PermissionType.Control),
                                new PermissionDefinition(StaticPermissionsName.Page_Staticial_HouseShip, "仓库收货", "",
                                    PermissionType.Control),
                                new PermissionDefinition(StaticPermissionsName.Page_Staticial_Ship, "仓库收货统计", "",
                                    PermissionType.Control),

                            }
                        },




                        new PermissionDefinition(StaticPermissionsName.Page_System, "系统管理", "系统管理",
                            PermissionType.Control)
                        {
                            Childs = new List<PermissionDefinition>()
                            {
                                new PermissionDefinition(StaticPermissionsName.Page_System_Role, "角色管理", "角色管理",
                                    PermissionType.Control)
                                {
                                    Childs = new List<PermissionDefinition>()
                                    {
                                        new PermissionDefinition(StaticPermissionsName.Page_System_Role_Create, "创建角色",
                                            "", PermissionType.Control),
                                        new PermissionDefinition(StaticPermissionsName.Page_System_Role_Edit, "编辑角色",
                                            "",
                                            PermissionType.Control),
                                        new PermissionDefinition(StaticPermissionsName.Page_System_Role_Delete, "删除角色",
                                            "", PermissionType.Control),
                                    }
                                },
                                new PermissionDefinition(StaticPermissionsName.Page_System_User, "账户管理", "账户管理",
                                    PermissionType.Control)
                                {
                                    Childs = new List<PermissionDefinition>()
                                    {
                                        new PermissionDefinition(StaticPermissionsName.Page_System_User_Create, "创建账户",
                                            "", PermissionType.Control),
                                        new PermissionDefinition(StaticPermissionsName.Page_System_User_Delete, "编辑账户",
                                            "", PermissionType.Control),
                                        new PermissionDefinition(StaticPermissionsName.Page_System_User_Edit, "删除账户",
                                            "",
                                            PermissionType.Control),
                                    }
                                },

                                new PermissionDefinition(StaticPermissionsName.Page_System_UserArea, "用户区域管理", "用户区域管理",
                                    PermissionType.Control)
                                {
                                    Childs = new List<PermissionDefinition>()
                                    {
                                        new PermissionDefinition(StaticPermissionsName.Page_System_UserArea_Create,
                                            "创建账户区域",
                                            "", PermissionType.Control),
                                        new PermissionDefinition(StaticPermissionsName.Page_System_UserArea_Edit,
                                            "编辑账户区域",
                                            "", PermissionType.Control),
                                        new PermissionDefinition(StaticPermissionsName.Page_System_UserArea_Delete,
                                            "删除账户区域", "",
                                            PermissionType.Control),
                                    }
                                },
                                new PermissionDefinition(StaticPermissionsName.Page_System_Area, "区域管理", "区域管理",
                                    PermissionType.Control)
                                {
                                    Childs = new List<PermissionDefinition>()
                                    {
                                        new PermissionDefinition(StaticPermissionsName.Page_System_Area_Create, "创建区域",
                                            "", PermissionType.Control),
                                        new PermissionDefinition(StaticPermissionsName.Page_System_Area_Edit, "编辑区域",
                                            "", PermissionType.Control),
                                        new PermissionDefinition(StaticPermissionsName.Page_System_Area_Delete, "删除区域",
                                            "",
                                            PermissionType.Control),
                                    }
                                }
                            }
                        }

                    }
                }
            };
        }
    }
    /// <summary>
    /// 静态权限名
    /// </summary>
    public class StaticPermissionsName
    {
        //默认首页权限
        public const string Page = "page";


        /// <summary>
        /// 仓库
        /// </summary>
        public const string Page_Device = "page.device";

        public const string Page_Device_House = "page.device.house";
        public const string Page_Device_HouseProduct = "page.device.houseproduct";
        public const string Page_Device_CarOrder = "page.device.carorder";

        /// <summary>
        /// 车辆
        /// </summary>
        public const string Page_Car = "page.car";

        public const string Page_Car_Apply = "page.car.apply";
        public const string Page_Car_Generation = "page.car.generation";

        /// <summary>
        /// 商品
        /// </summary>
        public const string Page_Product = "page.product";

        public const string Page_Product_Product = "page.product.product";
        public const string Page_Product_Price = "page.product.price";

        /// <summary>
        /// 商品
        /// </summary>
        public const string Page_Staticial = "page.staticial";

        public const string Page_Staticial_Members = "page.staticial.members";
        public const string Page_Staticial_Payfor = "page.staticial.payfor";
        public const string Page_Staticial_CarReplease = "page.staticial.carreplease";
        public const string Page_Staticial_CarSale = "page.staticial.carsale";
        public const string Page_Staticial_HouseShip = "page.staticial.houseship";
        public const string Page_Staticial_Ship = "page.staticial.ship";

        /// <summary>
        /// xitong
        /// </summary>
        public const string Page_System = "page.system";
        public const string Page_System_Role = "page.system.role";
        public const string Page_System_Role_Create = "page.system.role.create";
        public const string Page_System_Role_Edit = "page.system.role.edit";
        public const string Page_System_Role_Delete = "page.system.role.delete";

        public const string Page_System_User = "page.system.user";
        public const string Page_System_User_Create = "page.system.user.create";
        public const string Page_System_User_Edit = "page.system.user.edit";
        public const string Page_System_User_Delete = "page.system.user.delete";

        public const string Page_System_UserArea = "page.system.userarea";
        public const string Page_System_UserArea_Create = "page.system.userarea.create";
        public const string Page_System_UserArea_Edit = "page.system.userarea.edit";
        public const string Page_System_UserArea_Delete = "page.system.userarea.delete";

        public const string Page_System_Area = "page.system.area";
        public const string Page_System_Area_Create = "page.system.area.create";
        public const string Page_System_Area_Edit = "page.system.area.edit";
        public const string Page_System_Area_Delete = "page.system.area.delete";
    }
}
