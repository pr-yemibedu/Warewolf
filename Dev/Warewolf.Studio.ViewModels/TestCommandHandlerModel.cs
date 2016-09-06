using System.Linq;
using Dev2.Common.Interfaces;
using Dev2.Data;
using Dev2.Data.Binary_Objects;
using Dev2.Studio.Core.Interfaces;

namespace Warewolf.Studio.ViewModels
{
    public sealed class TestCommandHandlerModel : ITestCommandHandler
    {
        public ITestModel CreateTest(IResourceModel resourceModel)
        {
            var testModel = new ServiceTestModel
            {
                TestName = "Test 1"
            };
            if (!string.IsNullOrEmpty(resourceModel.DataList))
            {
                var dataListModel = new DataListModel();
                dataListModel.CreateShape(resourceModel.DataList);
                testModel.Inputs = dataListModel.ShapeScalars?
                                    .Where(scalar => scalar.IODirection == enDev2ColumnArgumentDirection.Input)
                                    .Select(sca => new ServiceTestInput(sca.Name, sca.Value) as ITestInput).ToList();

                testModel.Outputs = dataListModel.ShapeScalars?
                                    .Where(scalar => scalar.IODirection == enDev2ColumnArgumentDirection.Output)
                                    .Select(sca => new ServiceTestOutput(sca.Name, sca.Value) as ITestOutput).ToList();
            }            
            return testModel;
       }

        

        public void StopTest()
        {
        }

      

        public void RunAllTestsInBrowser()
        {
        }

        

        public void RunAllTestsCommand()
        {
        }
        

        public void RunSelectedTestInBrowser()
        {
        }

        

        public void RunSelectedTest()
        {
        }

        

        public void DuplicateTest()
        {
        }

       

        public void DeleteTest()
        {
        }        

    }
}