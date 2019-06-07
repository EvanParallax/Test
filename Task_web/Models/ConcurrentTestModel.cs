using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_web.Models
{
    public interface ITestSet
    {
        void Add(TestModel model);

        bool Remove(Guid id);

        IEnumerable<TestModel> GetModels();

        TestModel GetModel(Guid id);

        bool UpdateModel(TestModel model);
    }

    public class ConcurrentTestSet : ITestSet
    {
        private readonly List<TestModel> models;

        private readonly Object sync;

        public ConcurrentTestSet()
        {
            // типа читаем из базы... :)
            models = new List<TestModel>();

            sync = new Object();
        }

        public void Add(TestModel model)
        {
            lock (sync)
                models.Add(model);
        }

        public TestModel GetModel(Guid id)
        {
            lock(sync)
                return models.FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<TestModel> GetModels()
        {
            lock (sync)
                return models;
        }

        public bool Remove(Guid id)
        {
            bool result = false;

            lock (sync)
            {
                var model = models.FirstOrDefault(m => m.Id == id);
                if(model != null)
                {
                    models.Remove(model);
                    result = true;
                }
            }
            return result;
        }

        public bool UpdateModel(TestModel model)
        {
            bool result = false;

            lock (sync)
            {
                var buf = models.FirstOrDefault(m => m.Id == model.Id);
                if (model != null)
                {
                    buf.Name = model.Name;
                    result = true;
                }
            }
            return result;
        }
    }
}
