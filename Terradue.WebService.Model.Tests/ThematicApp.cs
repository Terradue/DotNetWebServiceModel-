using NUnit.Framework;
using System;
using Terradue.OpenSearch.Result;
using System.IO;
using System.Xml;
using Terradue.OpenSearch.GeoJson.Result;

namespace Terradue.WebService.Model.Tests {
    
    [TestFixture()]
    public class ThematicApp {
        
        [Test()]
        public void XmlToJson() {

            FileStream file = new FileStream("../../../Models/thematicapp.xml", FileMode.Open, FileAccess.Read);

            var xr = XmlReader.Create(file,new XmlReaderSettings(){
                IgnoreWhitespace = true
            });

            AtomFeed feed = AtomFeed.Load(xr);

            FeatureCollectionResult fc = FeatureCollectionResult.FromOpenSearchResultCollection(feed);

            string json = fc.SerializeToString();



        }
    }
}

