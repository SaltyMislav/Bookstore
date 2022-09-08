using Rhetos.Dsl;
using Rhetos.Dsl.DefaultConcepts;
using System.ComponentModel.Composition;

namespace Bookstore.RhetosExtensions
{
    [Export(typeof(IConceptInfo))]
    [ConceptKeyword("MonitoredRecord")]
    public class MonitoredRecordInfo : IConceptInfo
    {
        [ConceptKey]
        public EntityInfo Entity { get; set; }
    }

    [Export(typeof(IConceptMacro))]
    public class MonitoredRecordMacro : IConceptMacro<MonitoredRecordInfo>
    {
        public IEnumerable<IConceptInfo> CreateNewConcepts(MonitoredRecordInfo conceptInfo, IDslModel existingConcepts)
        {
            var newConcepts = new List<IConceptInfo>();
            // DateTime CreatedAt

            var codeProperty = new DateTimePropertyInfo
            {
                DataStructure = conceptInfo.Entity,
                Name = "CreatedAt"
            };

            newConcepts.Add(codeProperty);
            
            // CreationTime
            newConcepts.Add(
                new CreationTimeInfo
                {
                    Property = codeProperty
                });

            //DenyUserEdit
            newConcepts.Add(
                new DenyUserEditPropertyInfo
                {
                    Property = codeProperty
                });

            // Logging

            var codeProperty1 = new EntityLoggingInfo
            {
                Entity = conceptInfo.Entity
            };

            newConcepts.Add(codeProperty1);

            newConcepts.Add(
                new AllPropertiesLoggingInfo
                {
                    EntityLogging = codeProperty1
                });

            return newConcepts;
        }
    }
}