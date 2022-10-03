using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace ItemAPITest
{


    public class Item
    {
        public string createdAt { get; set; }
        public string description { get; set; }
        public string price { get; set; }
        public string sku { get; set; }
        public string updatedAt { get; set; }
    }

    [TestClass]
    public class APITest
    {
        [TestMethod]
        public void PostItem_SimpleTest()
        {
            string url = "https://1ryu4whyek.execute-api.us-west-2.amazonaws.com/dev/skus";

            Item item = new Item() { sku = "123", description = "test item", price = "99.99"};

            string jsonValue = RequestHelper.postRequest(item);
            Item returnedItem = JsonConvert.DeserializeObject<Item>(jsonValue);

            Assert.IsNotNull(returnedItem);

            Assert.IsNotNull(returnedItem.createdAt);
            Assert.AreEqual(item.sku, returnedItem.sku);
            Assert.AreEqual(item.description, returnedItem.description);
            Assert.AreEqual(item.price, returnedItem.price);
            Assert.IsNotNull(returnedItem.updatedAt);

            //It's also possible to assert the created and updated time
        }

        [TestMethod]
        public void PostItem_AllEmpty()
        {
            Item item = new Item() { sku = "", description = "", price = "" };

            string jsonValue = RequestHelper.postRequest(item);
            Item returnedItem = JsonConvert.DeserializeObject<Item>(jsonValue);

            Assert.IsNotNull(returnedItem);

            Assert.IsNotNull(returnedItem.createdAt);
            Assert.AreEqual(item.sku, returnedItem.sku);
            Assert.AreEqual(item.description, returnedItem.description);
            Assert.AreEqual(item.price, returnedItem.price);
            Assert.IsNotNull(returnedItem.updatedAt);
        }

        [TestMethod]
        public void PostItem_InfoEmptyWithSku()
        {
            Item item = new Item() { sku = "222", description = "", price = "" };

            string jsonValue = RequestHelper.postRequest(item);
            Item returnedItem = JsonConvert.DeserializeObject<Item>(jsonValue);

            Assert.IsNotNull(returnedItem);

            Assert.IsNotNull(returnedItem.createdAt);
            Assert.AreEqual(item.sku, returnedItem.sku);
            Assert.AreEqual(item.description, returnedItem.description);
            Assert.AreEqual(item.price, returnedItem.price);
            Assert.IsNotNull(returnedItem.updatedAt);
        }

        [TestMethod]
        public void PostItem_SpecialCharactersAndSpaces()
        {
            Item item = new Item() { sku = " !@#$%^&*()_+|QWERTYUIIOP{}ASDFGHJKL:\"ZXCVBNM qwertyuiopasdfghjklzxcvbnm0123456789<>?", description = " !@#$%^&*()_+|QWERTYUIIOP{}ASDFGHJKL:\"ZXCVBNMqwertyuiopasdfghjklzxcvbnm0123456789<>?", price = " !@#$%^&*()_+|QWERTYUIIOP{}ASDFGHJKL:\"ZXCVBNMqwertyuiopasdfghjklzxcvbnm0123456789<>?" };

            string jsonValue = RequestHelper.postRequest(item);
            Item returnedItem = JsonConvert.DeserializeObject<Item>(jsonValue);

            Assert.IsNotNull(returnedItem);

            Assert.IsNotNull(returnedItem.createdAt);
            Assert.AreEqual(item.sku, returnedItem.sku);
            Assert.AreEqual(item.description, returnedItem.description);
            Assert.AreEqual(item.price, returnedItem.price);
            Assert.IsNotNull(returnedItem.updatedAt);
        }

        [TestMethod]
        public void PostItem_CharacterLimit()
        {
            //1000 characters, I don't know what the actual limit should be
            var description = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

            Item item = new Item() { sku = "222", description = description, price = "0.1" };

            string jsonValue = RequestHelper.postRequest(item);
            Item returnedItem = JsonConvert.DeserializeObject<Item>(jsonValue);

            Assert.IsNotNull(returnedItem);

            Assert.IsNotNull(returnedItem.createdAt);
            Assert.AreEqual(item.sku, returnedItem.sku);
            Assert.AreEqual(item.description, returnedItem.description);
            Assert.AreEqual(item.price, returnedItem.price);
            Assert.IsNotNull(returnedItem.updatedAt);
        }

        [TestMethod]
        public void DeleteItem()
        {
            Item item = new Item() { sku = "222", description = "delete test", price = "1" };

            string jsonValue = RequestHelper.postRequest(item);
            Item returnedItem = JsonConvert.DeserializeObject<Item>(jsonValue);

            Assert.IsNotNull(returnedItem);
            Assert.AreEqual(item.sku, returnedItem.sku);
            Assert.AreEqual(item.description, returnedItem.description);
            Assert.AreEqual(item.price, returnedItem.price);

            RequestHelper.deleteRequest(item.sku);
            jsonValue = RequestHelper.getRequest(item.sku);
            item = JsonConvert.DeserializeObject<Item>(jsonValue);

            Assert.IsNull(item.createdAt);
            Assert.IsNull(item.sku);
            Assert.IsNull(item.description);
            Assert.IsNull(item.price);
            Assert.IsNull(item.updatedAt);
        }

        [TestMethod]
        public void GetAllItems()
        {

            string jsonValue = RequestHelper.getAllRequest();

            List<Item> items = JsonConvert.DeserializeObject<List<Item>>(jsonValue);

            Assert.IsNotNull(items);
        }
    }

    
}