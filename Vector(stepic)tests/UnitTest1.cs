using System.Windows.Markup;
using Vector_stepic_;
using System.Linq;

namespace Vector_stepic_tests
{
    public class UnitTest1
    {
        [Fact]
        
        public void InputParser()
        {
            List<string> actualdep = new List<string>(
                MadeDepartament
                    .InputParser("Äåïàğòàìåíò çàêóïîê: 9 * manager1, 3 * manager2, 2 * manager3, 2 * marketer1 + ğóêîâîäèòåëü äåïàğòàìåíòà manager2")
                    .Split(' '));
            string[] namedeps = { "çàêóïîê", "ïğîäàæ", "ğåêëàìû", "ëîãèñòèêè" };
            Assert.Equal("Äåïàğòàìåíò", actualdep[0]);
            Assert.Contains(actualdep[1], namedeps);
        }

        [Fact]
        public void MadeManager()
        {
            Manager manager = new Manager(9, 1, false);
            Assert.Equal(450000,manager.Allprice);
            Assert.Equal(9, manager.CountsEmploees);
            Assert.Equal(180,manager.CountsÑoffe);
            Assert.False(manager.DirOrnotdir);
            Assert.Equal(1800, manager.PageCounts);
            Assert.Equal(1, manager.Ratio);

            Manager managerd = new Manager(1, 1, true);
            Assert.Equal(75000, managerd.Allprice);
            Assert.Equal(1, managerd.CountsEmploees);
            Assert.Equal(40, managerd.CountsÑoffe);
            Assert.True(managerd.DirOrnotdir);
            Assert.Equal(0, managerd.PageCounts);
            Assert.Equal(1.5, managerd.Ratio);

            Manager manager2 = new Manager(9, 2, false);
            Assert.Equal(562500, manager2.Allprice);
            Assert.Equal(9, manager2.CountsEmploees);
            Assert.Equal(180, manager2.CountsÑoffe);
            Assert.False(manager2.DirOrnotdir);
            Assert.Equal(1800, manager2.PageCounts);
            Assert.Equal(1.5625, manager2.Ratio);

            Manager manager2d = new Manager(1, 2, true);
            Assert.Equal(93750, manager2d.Allprice);
            Assert.Equal(1, manager2d.CountsEmploees);
            Assert.Equal(40, manager2d.CountsÑoffe);
            Assert.True(manager2d.DirOrnotdir);
            Assert.Equal(0, manager2d.PageCounts);
            Assert.Equal(1.875, manager2d.Ratio);

            Manager manager3 = new Manager(9, 3, false);
            Assert.Equal(675000, manager3.Allprice);
            Assert.Equal(9, manager3.CountsEmploees);
            Assert.Equal(180, manager3.CountsÑoffe);
            Assert.False(manager3.DirOrnotdir);
            Assert.Equal(1800, manager3.PageCounts);
            Assert.Equal(2.25, manager3.Ratio);

            Manager manager3d = new Manager(1, 3, true);
            Assert.Equal(112500, manager3d.Allprice);
            Assert.Equal(1, manager3d.CountsEmploees);
            Assert.Equal(40, manager3d.CountsÑoffe);
            Assert.True(manager3d.DirOrnotdir);
            Assert.Equal(0, manager3d.PageCounts);
            Assert.Equal(2.25, manager3d.Ratio);
        }
    }
}