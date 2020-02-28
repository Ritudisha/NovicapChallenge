using Novicap;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {
        class InputData : IEnumerable<object[]>
        {
            static string json 
            { 
                get 
                {
                    var directory = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
                    return directory + @"\Novicap\ProductConfig.json";
                } 
            }
            private readonly List<object[]> _data = new List<object[]>
            {
                new object[] { //Test Case 1
                    new List<string> { "VOUCHER", "TSHIRT", "MUG" },
                    json,
                    32.50
                },
                new object[] { //Test Case 2
                    new List<string> { "VOUCHER", "TSHIRT", "VOUCHER" },
                    json,
                    25.00
                },
                new object[] { //Test Case 3
                    new List<string> { "TSHIRT", "TSHIRT", "TSHIRT", "VOUCHER", "TSHIRT" },
                    json,
                    81.00
                },
                new object[] { //Test Case 4
                    new List<string> { "VOUCHER", "TSHIRT", "VOUCHER", "VOUCHER", "MUG", "TSHIRT", "TSHIRT" },
                    json,
                    74.50
                }

            };

            public IEnumerator<object[]> GetEnumerator()
            {
                return _data.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
        [Theory]
        [ClassData(typeof(InputData))]
        public void Test_GetInvoice(List<string> products, string productConfig, decimal expectedTotal)
        {
            //arrange
            var invoice = new Invoice();
            
            //Act
            var total = invoice.GetInvoice(products, productConfig);
            
            //assert
            Assert.Equal(total, expectedTotal);
        }

        class InvalidProductCodeInputData : IEnumerable<object[]>
        {
            static string json
            {
                get
                {
                    var directory = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
                    return directory + @"\Novicap\ProductConfig.json";
                }
            }
            private readonly List<object[]> _data = new List<object[]>
            {
                
                new object[] { //Invalid product Code Handled
                    new List<string> { "VOUCHER", "TSHIRT", "VOUCHER", "VOUCHER", "MUG", "TSHIRT", "TSHIRT", "HELLO" },
                    json
                }

            };

            public IEnumerator<object[]> GetEnumerator()
            {
                return _data.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
        [Theory]
        [ClassData(typeof(InvalidProductCodeInputData))]
        public void Test_GetInvoiceInvalidProductCodeExceptions(List<string> products, string productConfig)
        {
            //arrange
            var invoice = new Invoice();

            //assert
            var ex = Assert.Throws<Exception>(() => invoice.GetInvoice(products, productConfig));
            Assert.Equal("One of more of the Product codes is or are invalid", ex.Message);
        }

        class InvalidProductConfigInputData : IEnumerable<object[]>
        {
            static string json
            {
                get
                {
                    var directory = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
                    return directory + @"\Novicap\ProductConfig.json";
                }
            }
            private readonly List<object[]> _data = new List<object[]>
            {

                new object[] { //Product code with invalid discount type object
                    new List<string> { "VOUCHER", "TSHIRT", "MUG2", "VOUCHER", "MUG", "TSHIRT", "TSHIRT" },
                    json
                }

            };

            public IEnumerator<object[]> GetEnumerator()
            {
                return _data.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
        [Theory]
        [ClassData(typeof(InvalidProductConfigInputData))]
        public void Test_GetInvoiceInvalidProductConfigExceptions(List<string> products, string productConfig)
        {
            //arrange
            var invoice = new Invoice();

            //assert
            var ex = Assert.Throws<Exception>(() => invoice.GetInvoice(products, productConfig));
            Assert.Equal("Invalid Product config", ex.Message);
        }
    }
}
