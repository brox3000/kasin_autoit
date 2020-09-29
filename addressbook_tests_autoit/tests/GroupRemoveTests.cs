using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_tests_autoit
{
    public class GroupRemoveTests : TestBase
    {


        [Test]
        public void TestGroupRemoval()
        {
            int groups_rev_index;


            List<GroupData> oldGroups = app.Groups.GetGroupList();

            if (oldGroups.Count <= 1)
            {
                GroupData newGroup = new GroupData()
                {
                    Name = "test"
                };

                app.Groups.Add(newGroup);

                oldGroups = app.Groups.GetGroupList();
            }

            groups_rev_index = oldGroups.Count - 1;  

            GroupData groups_delete = oldGroups[groups_rev_index]; 

            oldGroups.RemoveAt(groups_rev_index);


            app.Groups.OpenGroupsDialogue();
            app.Groups.RemoveGroups(groups_rev_index);
            app.Groups.CloseGroupsDialogue();

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups.Count, newGroups.Count);
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}