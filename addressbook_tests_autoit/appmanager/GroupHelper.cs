using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//31:45
namespace addressbook_tests_autoit
{
    public class GroupHelper : HelperBase
    {
        public ApplicationManager manager;
        public static string GROUPWINTITLE = "Group editor";
        public static string GROUPREMOVECONFIRM = "Delete group";
        public GroupHelper(ApplicationManager manager) : base(manager) { }

        //
        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            OpenGroupsDialogue();

            string count = aux.ControlTreeView(
                GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                "GetItemCount", "#0", "");

            for (int i = 0; i < int.Parse(count); i++)
            {
                string item = aux.ControlTreeView(
                GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                "GetText", "#0|#" + i, "");

                list.Add(new GroupData()
                {
                    Name = item
                });
            }

            CloseGroupsDialogue();
            return list;
        }

        public void Add(GroupData newGroup)
        {
            OpenGroupsDialogue();
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            aux.Send(newGroup.Name);
            aux.Send("{ENTER}");
            CloseGroupsDialogue();
        }

        public void CloseGroupsDialogue()
        {
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d54");
        }

        public void OpenGroupsDialogue()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d512");
            aux.WinWait(GROUPWINTITLE);
        }

        //8.0
        public GroupHelper RemoveGroups(int groups_rev_index)
        {

            aux.ControlTreeView(
                    GROUPWINTITLE, "" , "WindowsForms10.SysTreeView32.app.0.2c908d51" , "Select"
                    , "#0|#" + groups_rev_index , "" );

            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");
            aux.WinWait(GROUPREMOVECONFIRM);
            aux.WinActivate(GROUPREMOVECONFIRM);
            aux.WinWaitActive(GROUPREMOVECONFIRM);
            aux.ControlClick(GROUPREMOVECONFIRM, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            aux.WinWaitClose(GROUPREMOVECONFIRM, "", 10);


            return this;
        }
    }
}




















