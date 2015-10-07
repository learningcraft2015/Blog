using PROJECT.Core.Models;
using PROJECT.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT.Core.Helpers
{
    public class MenuHelpers
    {

        private static Dictionary<Int16, string> _RolesAndMenuMain = new Dictionary<Int16, string>();//, StringComparer.InvariantCultureIgnoreCase);

        private static Dictionary<Int16, string> _RolesAndMenuMaster = new Dictionary<Int16, string>();//50, StringComparer.InvariantCultureIgnoreCase);





        /// <summary>
        /// This Function Fill All roles and its Menu in a Dictionary(_RolesAndMenu) 
        /// </summary>
        /// 
        public static void SetMenuByRoleMain()
        {
            AccountRepository objAccountRepository = new AccountRepository();
            _RolesAndMenuMain.Clear();
            List<TextMenuModel> objTextMenuList = new List<TextMenuModel>();
            objTextMenuList = objAccountRepository.GetRolesForMenus((Int16)UserAccessParentIdEnum.MainForms.GetHashCode());


            foreach (var item in objTextMenuList)
            {
                _RolesAndMenuMain.Add(item.RoleId, item.Menu);

            }


        }


        public static void SetMenuByRoleMaster()
        {
            AccountRepository objAccountRepository = new AccountRepository();
            _RolesAndMenuMaster.Clear();
            List<TextMenuModel> objTextMenuList = new List<TextMenuModel>();
            objTextMenuList = objAccountRepository.GetRolesForMenus((Int16)UserAccessParentIdEnum.MasterForms.GetHashCode());
            foreach (var item in objTextMenuList)
            {
                _RolesAndMenuMaster.Add(item.RoleId, item.Menu);

            }


        }

        public static string GetMenuMain(Int16 roleId)
        {
            string Menu = string.Empty;
            if ((_RolesAndMenuMain.Count == 0))
            {
                SetMenuByRoleMain();
            }
            _RolesAndMenuMain.TryGetValue(roleId, out Menu);
            return Menu;
        }

        public static string GetMenuMaster(Int16 roleId)
        {
            string Menu = string.Empty;
            if (_RolesAndMenuMaster.Count == 0)
            {
                SetMenuByRoleMaster();
            }
            _RolesAndMenuMaster.TryGetValue(roleId, out Menu);
            return Menu;
        }

    }
}
