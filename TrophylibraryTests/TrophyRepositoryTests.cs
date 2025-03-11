using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trophylibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trophylibrary.Tests
{
    [TestClass()]
    public class TrophyRepositoryTests
    {
        private TrophyRepository _trophiesRepository;
        [TestInitialize]

        public void setup()
        {
            _trophiesRepository = new TrophyRepository();
            _trophiesRepository.Add(new Trophy() { Competition = "Bordfodbold", Year = 2001 });
            _trophiesRepository.Add(new Trophy() { Competition = "Basketball", Year = 2005 });
            _trophiesRepository.Add(new Trophy() { Competition = "Fodbold", Year = 2010 });
            _trophiesRepository.Add(new Trophy() { Competition = "Karate", Year = 2012 });
            _trophiesRepository.Add(new Trophy() { Competition = "Svømning", Year = 2009 });
        }

        [TestMethod()]
        public void GetTest()
        {
            IEnumerable<Trophy> trophies = _trophiesRepository.Get();
            Assert.AreEqual(5, trophies.Count());
            Assert.AreEqual("Bordfodbold", trophies.First().Competition);

            IEnumerable<Trophy> sortedTrophies = _trophiesRepository.Get(orderBy: "competition");
            Assert.AreEqual("Basketball", sortedTrophies.First().Competition); 

            IEnumerable<Trophy> sortedTrophies2 = _trophiesRepository.Get(orderBy: "year");
            Assert.AreEqual("Bordfodbold", sortedTrophies2.First().Competition); 
        }

        [TestMethod]
        public void AddTest()
        {
            Trophy t = new() { Competition = "Tennis", Year = 2023 };
            Assert.AreEqual(6, _trophiesRepository.Add(t).Id);
            Assert.AreEqual(6, _trophiesRepository.Get().Count());
        }

        public void DeleteTest()
        {
            Assert.IsNull(_trophiesRepository.Delete(100)); 
            Assert.AreEqual(1, _trophiesRepository.Delete(1)?.Id); 
            Assert.AreEqual(4, _trophiesRepository.Get().Count()); 
        }
    }
}