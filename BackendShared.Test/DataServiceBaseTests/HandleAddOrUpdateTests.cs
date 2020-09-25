using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;
using Backend_Shared.Services.DataServices.Base;
using BackendShared.Test.DataServiceBaseTests.Helpers;
using DynamicData;
using NUnit.Framework;
using Shouldly;

namespace BackendShared.Test.DataServiceBaseTests
{
    public class HandleAddOrUpdateTests
    {
        // private async Task<ChangeSet<DataServiceTestModel, string>> ArrangeAndAct(DataServiceTestModel model)
        // {
        //     //Arrange
        //     var dataService = new DataServiceBase<DataServiceTestModel, string>();
        //     var obs = dataService.ObservableOfChangeSet.FirstAsync().ToTask();
        //
        //     //Act
        //     dataService.HandleAddOrUpdate(model);
        //
        //     return await obs;
        // }
        //
        // private async Task<ChangeSet<DataServiceTestModel, string>> ArrangeAndAct(IEnumerable<DataServiceTestModel> list)
        // {
        //     //Arrange
        //     var dataService = new DataServiceBase<DataServiceTestModel, string>();
        //     var obs = dataService.ObservableOfChangeSet.FirstAsync().ToTask();
        //
        //     //Act
        //     dataService.HandleAddOrUpdate(list);
        //
        //     return await obs;
        // }


        // [Test]
        // public async Task SingleItem_Adds_ShouldBe_One()
        // {
        //     var result = await ArrangeAndAct(new DataServiceTestModel {Id = "1", Name = "Name"});
        //     result.Adds.ShouldBe(1);
        // }
        //
        // [Test]
        // public async Task SingleItem_ChangeReason_ShouldBe_Add()
        // {
        //     var result = await ArrangeAndAct(new DataServiceTestModel {Id = "1", Name = "Name"});
        //     result.Single().Reason.ShouldBe(ChangeReason.Add);
        // }
        //
        // [Test]
        // public async Task SingleItem_Key_ShouldBe_EqualToId()
        // {
        //     var testModel = new DataServiceTestModel {Id = "1", Name = "Name"};
        //     var result = await ArrangeAndAct(testModel);
        //     result.Single().Key.ShouldBe(testModel.Id);
        // }
        //
        // [Test]
        // public async Task SingleItem_Current_ShouldBe_EqualToModel()
        // {
        //     var testModel = new DataServiceTestModel {Id = "1", Name = "Name"};
        //     var result = await ArrangeAndAct(testModel);
        //     result.Single().Current.ShouldBe(testModel);
        // }
        //
        //
        // private IList<DataServiceTestModel> _list = new List<DataServiceTestModel>
        // {
        //     new DataServiceTestModel {Id = "1", Name = "One"},
        //     new DataServiceTestModel {Id = "2", Name = "Two"},
        //     new DataServiceTestModel {Id = "3", Name = "Three"},
        // };
        //
        // [Test]
        // public async Task List_Adds_ShouldBe_Three()
        // {
        //     var result = await ArrangeAndAct(_list);
        //     result.Adds.ShouldBe(3);
        // }
        //
        // [Test]
        // public async Task List_ChangeReasons_ShouldBe_Add()
        // {
        //     var result = await ArrangeAndAct(_list);
        //     result.ForEach(change => change.Reason.ShouldBe(ChangeReason.Add));
        // }
        //
        // [Test]
        // public async Task List_Keys_ShouldBe_EqualToIds()
        // {
        //     var testModel = new DataServiceTestModel {Id = "1", Name = "Name"};
        //     var result = await ArrangeAndAct(testModel);
        //     var i = 1;
        //     result.ForEach(change =>
        //     {
        //         change.Key.ShouldBe(i.ToString());
        //         i++;
        //     });
        // }
    }
}