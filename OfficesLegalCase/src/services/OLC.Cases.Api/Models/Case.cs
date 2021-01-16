using OLC.Core.DomainObjects;
using System;

namespace OLC.Cases.Api.Models
{
    public class Case : IAggregateRoot
    {
        public string CaseNumber { get; private set; }
        public string CourtName { get; private set; }
        public string NameOfTheResponsible { get; private set; }
        public DateTime RegistrationDate { get; private set; }

        protected Case() { }

        public Case(string caseNumber, string courtName, string nameOfTheResponsible)
        {
            CaseNumber = caseNumber;
            CourtName = courtName;
            NameOfTheResponsible = nameOfTheResponsible;
            RegistrationDate = DateTime.Now;
        }
    }
}
