using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Components.DictionaryAdapter;
using YT.Authorizations.PermissionDefault;

namespace YT.Navigations.MenuDefault
{
    public abstract class BaseMenuProvider : MenuProvider
    {

    }

    public class AdminMenuProvider : BaseMenuProvider
    {
        public override IEnumerable<MenuDefinition> GetMenuDefinitions(MenuDefinitionProviderContext context)
        {
            return new List<MenuDefinition>()
           {
                new MenuDefinition("设备管理","","speedometer",true,StaticPermissionsName.Page_Device)
                {
                    Childs = new List<MenuDefinition>()
                    {
                        new MenuDefinition("仓库管理","/house","",true,StaticPermissionsName.Page_Device_House),
                        new MenuDefinition("仓库补货","/houseproduct","",true,StaticPermissionsName.Page_Device_HouseProduct),
                        new MenuDefinition("车辆订单","/carorder","",true,StaticPermissionsName.Page_Device_CarOrder)
                    }
                },
               new MenuDefinition("车辆管理","","speedometer",true,StaticPermissionsName.Page_Car)
               {
                   Childs = new List<MenuDefinition>()
                   {
                       new MenuDefinition("车辆审核","/car","",true,StaticPermissionsName.Page_Car_Apply),
                       new MenuDefinition("提现管理","/generation","",true,StaticPermissionsName.Page_Car_Generation),
                   }
               },
               new MenuDefinition("商品管理","","speedometer",true,StaticPermissionsName.Page_Product)
               {
                   Childs = new List<MenuDefinition>()
                   {
                       new MenuDefinition("商品管理","/product","",true,StaticPermissionsName.Page_Product_Product),
                       new MenuDefinition("商品价格管理","/productprice","",true,StaticPermissionsName.Page_Product_Price),
                   }
               },
               new MenuDefinition("统计管理","","speedometer",true,StaticPermissionsName.Page_Staticial)
               {
                   Childs = new List<MenuDefinition>()
                   {
                       new MenuDefinition("会员信息","/members","",true,StaticPermissionsName.Page_Staticial_Members),
                       new MenuDefinition("会员支付订单","/payfor","",true,StaticPermissionsName.Page_Staticial_Payfor),
                       new MenuDefinition("车辆补货明细","/carreplease","",true,StaticPermissionsName.Page_Staticial_CarReplease),
                       new MenuDefinition("车辆售卖","/carsale","",true,StaticPermissionsName.Page_Staticial_CarSale),
                       new MenuDefinition("仓库出货","/houseship","",true,StaticPermissionsName.Page_Staticial_HouseShip),
                       new MenuDefinition("仓库出货统计","/shipstaticial","",true,StaticPermissionsName.Page_Staticial_Ship),
                   }
               },
              

                  new MenuDefinition("系统管理","","settings",true,StaticPermissionsName.Page_System)
                {
                    Childs = new List<MenuDefinition>()
                    {
                        new MenuDefinition("用户管理","/users","",true,StaticPermissionsName.Page_System_User),
                        new MenuDefinition("角色管理","/roles","",true,StaticPermissionsName.Page_System_Role),
                        new MenuDefinition("负责区域管理","/userareas","calendar",true,StaticPermissionsName.Page_System_UserArea),
                        new MenuDefinition("分类管理","/areas","calendar",true,StaticPermissionsName.Page_System_Area),
                    }
                },
           };
        }
    }
}

